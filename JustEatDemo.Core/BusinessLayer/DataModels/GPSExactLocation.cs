using System;

namespace JustEatDemo.Core.BL.DataModels
{
	public class GPSExactLocation
	{
		public GPSExactLocation(double latitude, double longitude)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
		}

		public double Latitude { get; private set; }
		public double Longitude { get; private set; }
	}
}

