using JustEatDemo.Core.SAL;

namespace JustEatDemo.Core.Tests.SAL
{
	public class MockGPSService : IGPSService
	{
		public const string InvalidPostcode = null;
		public const string ValidPostcode = "RG20 9DD";

		private bool gpsHardwareExists; 
		private bool gpsIsEnabled;
		private bool returnsValidPostcode;

		public void MockSetupHardwareExists(bool gpsHardwareExists)
		{
			this.gpsHardwareExists = gpsHardwareExists;
		}

		public void MockSetupGPSIsEnabled(bool gpsIsEnabled)
		{
			this.gpsIsEnabled = gpsIsEnabled;
		}

		public void MockSetupReturnsValidPostcode(bool returnsValidPostcode)
		{
			this.returnsValidPostcode = returnsValidPostcode;
		}

		public bool GPSHardwareExists()
		{
			return gpsHardwareExists;
		}

		public bool GPSIsEnabled()
		{
			return gpsIsEnabled;
		}

		public string GetPostcodeOfLocation(JustEatDemo.Core.BL.DataModels.GPSExactLocation location)
		{
			return returnsValidPostcode ? ValidPostcode : InvalidPostcode;
		}
	}
}