using JustEatDemo.Core.BL.DataModels;
using JustEatDemo.Core.SAL;

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