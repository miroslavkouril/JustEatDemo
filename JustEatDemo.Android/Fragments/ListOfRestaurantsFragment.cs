using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using JustEatDemo.Core.BL;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo
{
	public class ListOfRestaurantsFragment : DownloadProgressFragment
	{
		private const string SelectedPostcode = "SELECTED_POSTCODE";
		private const string DataToDisplay = "DATA_TO_DISPLAY";

		private string selectedPostcode;
		private List<RestaurantDataToDisplay> dataToDisplay;

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

			return rootView;
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			Activity.ActionBar.Title = selectedPostcode;
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
		}

		public void RefreshListData()
		{
			var adapter = new RestaurantsInAreaAdapter(Activity, dataToDisplay);
			list.Adapter = adapter;
		}
	}
}