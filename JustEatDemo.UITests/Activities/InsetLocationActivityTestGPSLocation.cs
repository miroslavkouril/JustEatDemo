using System;
using NUnit.Framework;
using Xamarin.UITest.Android;
using Xamarin.UITest;

namespace JustEatDemo.UITests
{
	[TestFixture]
	public class InsetLocationActivityTestGPSLocation
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
			app.Device.SetLocation(51.36822357, -1.32466716);
		}

		[Test]
		public void DisplayReplConsole()
		{
			app.Repl();
		}

		[Test]
		public void InsertLocationScreenVisible()
		{
			app.WaitForElement(c => c.Marked("subtitle"));
		}

		[Test]
		public void HappyPathFunctionalityManualPostcode()
		{
			app.Tap(c => c.Marked("postcode_from_gps"));
			app.WaitForElement(c => c.Marked("postcode").Text("RG20 9DA"), "Postcode from GPS timeout", TimeSpan.FromMinutes(1));
		}
	}
}

