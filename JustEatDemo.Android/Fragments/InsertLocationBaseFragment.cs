
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using JustEatDemo.Core.BL;
using Android.Views.Animations;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo
{
	public abstract class InsertLocationBaseFragment : Fragment
	{
		private const string EnteredPostcode = "ENTERED_POSTCODE";

		protected EditText postcode;
		protected ImageButton clearPostCode;
		protected ImageButton usePostcodeFromGPS;

		private GPSServiceHelper gpsService;

		private AlertDialog enableGPSToGetPostcode;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var androidServiceImplementation = new GPSService(Activity);
			gpsService = new GPSServiceHelper(androidServiceImplementation);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var rootView = inflater.Inflate(Resource.Layout.InsertLocation, null);

			clearPostCode = rootView.FindViewById<ImageButton>(Resource.Id.delete_postcode);
			usePostcodeFromGPS = rootView.FindViewById<ImageButton>(Resource.Id.postcode_from_gps);
			if (gpsService.GPSHardwareExists())
			{
				usePostcodeFromGPS.Visibility = ViewStates.Visible;
			}
			else
			{
				usePostcodeFromGPS.Visibility = ViewStates.Invisible;
			}

			postcode = rootView.FindViewById<EditText>(Resource.Id.postcode);

			if (savedInstanceState != null)
			{
				postcode.Text = savedInstanceState.GetString(EnteredPostcode);
			}

			return rootView;
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

			outState.PutString(EnteredPostcode, postcode.Text);
		}

		private void LocationIsAvailable(Object sender, GPSExactLocation location)
		{
			StopGPSLoadingSignalization();

			postcode.Text = gpsService.GetPostcodeOfLocation(location);
			postcode.Error = null;
		}

		private void LocationFailed()
		{
			StopGPSLoadingSignalization();
		}

		private void StartGPSLoadingSignalization()
		{
			postcode.Error = null;

			usePostcodeFromGPS.SetImageResource(global::Android.Resource.Drawable.IcMenuRotate);
			RotateAnimation rotateAnimation = (RotateAnimation) AnimationUtils.LoadAnimation(Activity, Resource.Animation.rotate);
			usePostcodeFromGPS.StartAnimation(rotateAnimation);
		}

		private void StopGPSLoadingSignalization()
		{
			usePostcodeFromGPS.ClearAnimation();
			usePostcodeFromGPS.SetImageResource(global::Android.Resource.Drawable.IcMenuMyLocation);
		}

		protected void TryToStartLocationSearch()
		{
			if (gpsService.GPSIsEnabled())
			{
				StartGPSLoadingSignalization();
				(Activity as FindGPSLocationActivity).StartLocationService(LocationIsAvailable, LocationFailed);
			}
			else
			{
				DisplayWarningAboutDisableLocationService();
			}
		}

		private void DisplayWarningAboutDisableLocationService()
		{
			enableGPSToGetPostcode = new AlertDialog
				.Builder(Activity)
				.SetMessage(Resource.String.dialog_enable_location_message)
				.SetPositiveButton(Resource.String.dialog_enable_location_positive_text, OpenLocationSettings)
				.SetNegativeButton(Resource.String.dialog_enable_location_negative_text, CloseDialog)
				.Create();

			enableGPSToGetPostcode.Show();
		}

		private void OpenLocationSettings(Object sender, DialogClickEventArgs e)
		{
			var intent = new Intent(global::Android.Provider.Settings.ActionLocationSourceSettings);
			Activity.StartActivity(intent);	
		}

		private void CloseDialog(Object sender, DialogClickEventArgs e)
		{
		}
	}
}

