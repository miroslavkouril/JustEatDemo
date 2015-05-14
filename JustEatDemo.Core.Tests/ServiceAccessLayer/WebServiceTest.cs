using System;
using NUnit.Framework;
using JustEatDemo.Core.SAL;
using System.Linq;

namespace JustEatDemo.Core.Tests.SAL
{
	[TestFixture()]
	public class WebServiceTest
	{
		private MockHttpClient httpClient;
		private WebService webService;

		[SetUp]
		public void SetUp()
		{
			httpClient = new MockHttpClient();
			webService = new WebService(httpClient);
		}

		[Test]
		public void InitializationComplete()
		{
			Assert.IsNotNull(httpClient);
			Assert.IsNotNull(webService);
		}

		[Test]
		public void DownloadImageFromWeb()
		{
			var result = webService.DownloadImageFromWeb("FAKE");
			Assert.IsNotNull(result);
			Assert.AreEqual(httpClient.ValidByteArrayResponseLength, result.Length);
			Assert.AreEqual(httpClient.ValidByteArrayResponseThirdByte, result[2]);
		}
	}
}

