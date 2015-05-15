using System;
using Android.App;
using Android.Locations;
using Android.OS;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo
{
	public abstract class FindGPSLocationActivity : Activity, ILocationListener
	{
		public delegate void LocationAvailableEventHandler(Object sender, GPSExactLocation location);
		public delegate void LocationFailedEventHandler();

		private LocationManager locationManager;

		private LocationAvailableEventHandler locationAvailableEvent;
		private LocationFailedEventHandler locationFailedEvent;

		public void StartLocationService(LocationAvailableEventHandler locationAvailableEvent, LocationFailedEventHandler locationFailedEvent)
		{
			this.locationAvailableEvent = locationAvailableEvent;
			this.locationFailedEvent = locationFailedEvent;

			var gpsService = new GPSService(this);

			locationManager = (LocationManager)GetSystemService(LocationService);
			var locationProvider = locationManager.GetBestProvider(gpsService.LocationCriteria, true);

			locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
		}

		public bool LocationServiceIsActive()
		{
			return (locationManager != null);
		}

		private void StopLocationService()
		{
			locationManager.RemoveUpdates(this);
			locationManager = null;
		}

		protected override void OnStop()
		{
			base.OnStop();

			if (LocationServiceIsActive())
			{
				ReactOnLocationFailure();
			}
		}

		public void OnLocationChanged(Location location)
		{
			StopLocationService();

			if (locationFailedEvent != null)
			{
				locationAvailableEvent(this, new GPSExactLocation(location.Latitude, location.Longitude));
			}
		}

		public void OnProviderDisabled(string provider)
		{
			ReactOnLocationFailure();
		}

		public void OnProviderEnabled(string provider)
		{
			// No reaction
		}

		public void OnStatusChanged(string provider, Availability status, Bundle extras)
		{
			if (status == Availability.OutOfService)
			{
				ReactOnLocationFailure();	
			}
		}

		private void ReactOnLocationFailure()
		{
			StopLocationService();

			if (locationFailedEvent != null)
			{
				locationFailedEvent();
			}
		}
	}
}