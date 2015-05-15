using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Locations;
using JustEatDemo.Core.SAL;

namespace JustEatDemo
{
	public class GPSService : IGPSService
	{
		private readonly Context context;

		public Criteria LocationCriteria
		{
			get
			{
				return new Criteria { Accuracy = Accuracy.Coarse };
			}
		}

		public GPSService(Context context)
		{
			this.context = context;
		}

		public bool GPSHardwareExists()
		{
			var locationManager = (LocationManager) context.GetSystemService(Context.LocationService);

			var locationProviders = locationManager.GetProviders(LocationCriteria, false);
			bool minimalOneFineLocationProviderExists = (locationProviders != null) && (locationProviders.Count > 0);

			return minimalOneFineLocationProviderExists;
		}

		public bool GPSIsEnabled()
		{
			var locationManager = (LocationManager) context.GetSystemService(Context.LocationService);

			const bool onlyEnabled = true;
			var locationProviders = locationManager.GetProviders(LocationCriteria, onlyEnabled);

			bool minimalOneFineLocationProviderIsEnabled = (locationProviders != null) && (locationProviders.Count > 0);
			return minimalOneFineLocationProviderIsEnabled;
		}

		public string GetPostcodeOfLocation(JustEatDemo.Core.BL.DataModels.GPSExactLocation location)
		{
			var geocoder = new Geocoder(context);
			Address address = geocoder.GetFromLocation(location.Latitude, location.Longitude, 1).FirstOrDefault();
			if (address != null)
			{
				return address.PostalCode;
			}
			else
			{
				return string.Empty;
			}
		}
	}
}