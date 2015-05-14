using System;
using JustEatDemo.Core.SAL;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo.Core.BL
{
	public class GPSServiceHelper
	{
		private readonly IGPSService gpsService;

		public GPSServiceHelper(IGPSService gpsService)
		{
			this.gpsService = gpsService;
		}

		public bool GPSHardwareExists()
		{
			return gpsService.GPSHardwareExists();
		}

		public bool GPSIsEnabled()
		{
			return gpsService.GPSIsEnabled();
		}

		public string GetPostcodeOfLocation(GPSExactLocation location)
		{
			return gpsService.GetPostcodeOfLocation(location);
		}
	}
}

