using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using JustEatDemo.Core.BL;
using JustEatDemo.Core.BL.DataModels;
using System.Linq;

namespace JustEatDemo
{
	public class ListOfRestaurantsFragment : DownloadProgressFragment
	{
		private const string SelectedPostcode = "SELECTED_POSTCODE";
		private const string DataToDisplay = "DATA_TO_DISPLAY";
		private const string DisplayClosedRestaurants = "DISPLAY_CLOSED_RESTAURANTS";

		private string selectedPostcode;
		private List<RestaurantDataToDisplay> dataToDisplay;
		private bool displayClosedRestaurants;

		private ListView list;

		public ListOfRestaurantsFragment() : base()
		{
		}

		public ListOfRestaurantsFragment(string selectedPostcode) : base()
		{
			this.selectedPostcode = selectedPostcode;
		}

		public override bool DataAreDownloaded
		{
			get
			{
				return dataToDisplay != null;
			}
		}

		public override void DownloadData()
		{
			var test = new RestaurantsInArea(new FileHelper(Activity));
			dataToDisplay = test.GetListOfRestaurantsInArea(selectedPostcode);
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (savedInstanceState != null)
			{
				selectedPostcode = savedInstanceState.GetString(SelectedPostcode);
				dataToDisplay = SaveInstanceStateHelper.StructureListFromJSONString<RestaurantDataToDisplay>(savedInstanceState.GetStringArray(DataToDisplay));
				displayClosedRestaurants = savedInstanceState.GetBoolean(DisplayClosedRestaurants, false);
			}
			else
			{
				displayClosedRestaurants = false;
			}

			DataDownloadFinished = RefreshListData;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var rootView = inflater.Inflate(Resource.Layout.ListOfRestaurants, null);

			list = rootView.FindViewById<ListView>(Resource.Id.list);

			if (DataAreDownloaded)
			{
				RefreshListData();
			}

			SetHasOptionsMenu(true);

			return rootView;
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			Activity.ActionBar.Title = selectedPostcode;
		}

		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate(Resource.Menu.list_of_restaurants, menu);

			var showClosedRestautants = menu.FindItem(Resource.Id.show_closed);
			showClosedRestautants.SetVisible(!displayClosedRestaurants);
			var hideClosedRestautants = menu.FindItem(Resource.Id.hide_closed);
			hideClosedRestautants.SetVisible(displayClosedRestaurants);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.show_closed:
					displayClosedRestaurants = true;
					Activity.InvalidateOptionsMenu();
					RefreshListData();
					return true;
				case Resource.Id.hide_closed:
					displayClosedRestaurants = false;
					Activity.InvalidateOptionsMenu();
					RefreshListData();
					return true;
				default:
					return base.OnOptionsItemSelected(item);	
			}
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

			outState.PutString(SelectedPostcode, selectedPostcode);
			if (DataAreDownloaded)
			{
				var test = SaveInstanceStateHelper.StructureListAsJSONString<RestaurantDataToDisplay>(dataToDisplay);
				outState.PutStringArray(DataToDisplay, SaveInstanceStateHelper.StructureListAsJSONString<RestaurantDataToDisplay>(dataToDisplay));
			}
			outState.PutBoolean(DisplayClosedRestaurants, displayClosedRestaurants);
		}

		public void RefreshListData()
		{
			RestaurantsInAreaAdapter adapter;
			if (displayClosedRestaurants)
			{
				adapter = new RestaurantsInAreaAdapter(Activity, dataToDisplay);
			}
			else
			{
				var filteredData = dataToDisplay.Where(x => x.IsOpen == true).ToList();

				if (dataToDisplay.Count > 0)
				{
					DisplayWarningWhenListEmpty(filteredData, Resource.String.no_restaurants_opened);
				}

				adapter = new RestaurantsInAreaAdapter(Activity, filteredData);
			}
			list.Adapter = adapter;

			DisplayWarningWhenListEmpty(dataToDisplay, Resource.String.no_restaurants_available);
		}

		private void DisplayWarningWhenListEmpty(List<RestaurantDataToDisplay> data, int warningMessageId)
		{
			if (data.Count == 0)
			{
				Toast.MakeText(Activity, warningMessageId, ToastLength.Short).Show();
			}	
		}
	}
}