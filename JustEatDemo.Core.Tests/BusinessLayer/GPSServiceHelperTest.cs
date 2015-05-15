using JustEatDemo.Core.BL;
using JustEatDemo.Core.Tests.SAL;
using NUnit.Framework;

namespace JustEatDemo.Core.Tests.BL
{
	[TestFixture()]
	public class GPSServiceHelperTest
	{
		private MockGPSService mockGPSService;
		private GPSServiceHelper gpsServiceHelper;

		[SetUp]
		public void SetUp()
		{
			mockGPSService = new MockGPSService();
			gpsServiceHelper = new GPSServiceHelper(mockGPSService);
		}

		[Test]
		public void InitializationComplete()
		{
			Assert.IsNotNull(mockGPSService);
			Assert.IsNotNull(gpsServiceHelper);
		}

		[Test]
		public void GPSHardwareExists()
		{
			mockGPSService.MockSetupHardwareExists(true);
			Assert.IsTrue(gpsServiceHelper.GPSHardwareExists());

			mockGPSService.MockSetupHardwareExists(false);
			Assert.IsFalse(gpsServiceHelper.GPSHardwareExists());
		}

		[Test]
		public void GPSIsEnabled()
		{
			mockGPSService.MockSetupGPSIsEnabled(true);
			Assert.IsTrue(gpsServiceHelper.GPSIsEnabled());

			mockGPSService.MockSetupGPSIsEnabled(false);
			Assert.IsFalse(gpsServiceHelper.GPSIsEnabled());
		}

		[Test]
		public void GetPostcodeOfLocation()
		{
			mockGPSService.MockSetupReturnsValidPostcode(true);
			Assert.AreEqual(MockGPSService.ValidPostcode, gpsServiceHelper.GetPostcodeOfLocation(new JustEatDemo.Core.BL.DataModels.GPSExactLocation(1, 1)));

			mockGPSService.MockSetupReturnsValidPostcode(false);
			Assert.AreNotEqual(MockGPSService.ValidPostcode, gpsServiceHelper.GetPostcodeOfLocation(new JustEatDemo.Core.BL.DataModels.GPSExactLocation(1, 1)));
		}
	}
}