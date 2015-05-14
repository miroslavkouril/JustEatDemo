using System;
using NUnit.Framework;
using Xamarin.UITest.Android;
using Xamarin.UITest;

namespace JustEatDemo.UITests
{
	[TestFixture]
	public class ListOfRestaurantsActivityTest
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
		}
	}
}

