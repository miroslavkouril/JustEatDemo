using System;
using NUnit.Framework;
using Xamarin.UITest.Android;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace JustEatDemo.UITests
{
	[TestFixture]
	public class InsetLocationActivityTestManualInsert
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
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
			app.EnterText(c => c.Marked("postcode"), "RG20");
			app.Tap(c => c.Marked("find_takeaways"));
			app.WaitForElement(c => c.Marked("list"));
		}
	}
}

