using System.Linq;
using JustEatDemo.Core.BL;
using JustEatDemo.Core.Tests.DAL;
using JustEatDemo.Core.Tests.SAL;
using NUnit.Framework;

namespace JustEatDemo.Core.Tests.BL
{
	[TestFixture()]
	public class RestaurantsInAreaTest
	{
		private MockFileHelper mockFileHelper;
		private MockWebService mockWebService;

		private RestaurantsInArea restaurantsInArea;

		[SetUp]
		public void SetUp()
		{
			mockFileHelper = new MockFileHelper();
			mockWebService = new MockWebService();

			restaurantsInArea = new RestaurantsInArea(mockFileHelper, mockWebService);
		}

		[Test]
		public void InitializationComplete()
		{
			Assert.IsNotNull(mockFileHelper);
			Assert.IsNotNull(mockWebService);
			Assert.IsNotNull(restaurantsInArea);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseEverythingIsWorking()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFileSaved);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbOkFileOk);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(mockWebService.ValidResponseRecordCount, result.Count);

			var record = result.FirstOrDefault(x => x.Id == mockWebService.ValidResponseRecordId);
			Assert.IsNotNull(record);

			Assert.AreEqual(mockWebService.ValidResponseRecordNumberOfRatings, record.NumberOfRatings);

			string expectedFilePath = mockFileHelper.GetMockFilePath(mockWebService.ValidResponseRecordId);
			Assert.AreEqual(expectedFilePath, record.LogoPath);

			Assert.AreEqual(mockWebService.ValidResponseRecordCouisineTypes, record.CuisineTypes);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseWebServiceOkRecordWithoutLogo()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFileSaved);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbOkFileFailed);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(mockWebService.ValidResponseRecordCount, result.Count);

			var record = result.FirstOrDefault(x => x.Id == mockWebService.ValidResponseRecordId);
			Assert.IsNotNull(record);

			Assert.AreEqual(mockWebService.ValidResponseRecordNumberOfRatings, record.NumberOfRatings);

			Assert.IsNull(record.LogoPath);

			Assert.AreEqual(mockWebService.ValidResponseRecordCouisineTypes, record.CuisineTypes);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseWebServiceOkFileSaveFailed()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFailed);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbOkFileOk);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(mockWebService.ValidResponseRecordCount, result.Count);

			var record = result.FirstOrDefault(x => x.Id == mockWebService.ValidResponseRecordId);
			Assert.IsNotNull(record);

			Assert.AreEqual(mockWebService.ValidResponseRecordNumberOfRatings, record.NumberOfRatings);

			Assert.IsNull(record.LogoPath);

			Assert.AreEqual(mockWebService.ValidResponseRecordCouisineTypes, record.CuisineTypes);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseWebServiceOkResponseEmpty()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFileSaved);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbWebEmptyStructure);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(0, result.Count);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseWebServiceOkResponseInvalid()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFileSaved);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbWebInvalidStructure);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(0, result.Count);
		}

		[Test]
		public void GetListOfRestaurantsInAreaCaseWebServiceOkResponseNull()
		{
			mockFileHelper.SetMockServiceBehaviour(MockFileHelper.MockFileHelperBehaviour.fhFileSaved);
			mockWebService.SetMockServiceBehaviour(MockWebService.MockWebServiceBehaviour.sbWebNullResponse);

			var result = restaurantsInArea.GetListOfRestaurantsInArea("ABS12");

			Assert.IsNotNull(result);

			Assert.AreEqual(0, result.Count);
		}
	}
}