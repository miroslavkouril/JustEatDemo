using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using JustEatDemo.Core.BL;

namespace JustEatDemo
{
	public class InsertLocationFragment : InsertLocationBaseFragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var rootView = base.OnCreateView(inflater, container, savedInstanceState);

			clearPostCode.Click += ClearPostcodeClick;
			usePostcodeFromGPS.Click += UsePostcodeFromGPSReaction;
			postcode.AfterTextChanged += PostcodeTextChangedReaction;

			var displayRestaurants = rootView.FindViewById<Button>(Resource.Id.find_takeaways);
			displayRestaurants.Click += DisplayRestaurantsClick;

			SetupVisibilityOfClearButton();

			return rootView;
		}

		private void PostcodeTextChangedReaction(object sender, Android.Text.AfterTextChangedEventArgs e)
		{
			SetupVisibilityOfClearButton();
		}

		private void SetupVisibilityOfClearButton()
		{
			if (string.IsNullOrEmpty(postcode.Text))
			{
				clearPostCode.Visibility = ViewStates.Invisible;
			}
			else
			{
				clearPostCode.Visibility = ViewStates.Visible;
			}
		}

		private void UsePostcodeFromGPSReaction(object sender, EventArgs e)
		{
			TryToStartLocationSearch();
		}

		private void ClearPostcodeClick(object sender, EventArgs e)
		{
			postcode.Text = string.Empty;
		}

		private void DisplayRestaurantsClick(object sender, EventArgs e)
		{
			string enteredPostcode = postcode.Text;

			if (string.IsNullOrEmpty(enteredPostcode))
			{
				DisplayInvalidPostcodeWarning(Resource.String.insert_location_warning_empty);	
			}
			else
			{
				var postcodeValidator = new PostcodeValidator();
				if (postcodeValidator.IsValid(enteredPostcode))
				{
					DisplayRestaurantsInArea(enteredPostcode);
				}
				else
				{
					DisplayInvalidPostcodeWarning(Resource.String.insert_location_warning_invalid);	
				}
			}
		}

		private void DisplayInvalidPostcodeWarning(int warningMessageId)
		{
			postcode.Error = Activity.Resources.GetString(warningMessageId);
		}

		private void DisplayRestaurantsInArea(string enteredPostcode)
		{
			var intent = new Intent(Activity, typeof(ListOfRestaurantsActivity));
			intent.PutExtra(ListOfRestaurantsActivity.SelectedPostcode, enteredPostcode);
			StartActivity(intent);
		}
	}
}