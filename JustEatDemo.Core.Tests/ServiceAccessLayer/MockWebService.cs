using System;
using JustEatDemo.Core.SAL;
using JustEatDemo.Core.BL.DataModels;
using Newtonsoft.Json;

namespace JustEatDemo.Core.Tests.SAL
{
	public class MockWebService : IWebService
	{
		public enum MockWebServiceBehaviour { 
			sbOkFileOk,
			sbOkFileFailed,
			sbWebEmptyStructure,
			sbWebInvalidStructure,
			sbWebNullResponse
		};

		private MockWebServiceBehaviour mockServiceBehaviour;

		private readonly byte[] fakeImageData = { 
			96, 160, 76, 144, 111, 125, 149, 204, 235, 92, 173, 34, 96, 223, 244, 165,
			95, 154, 85, 31, 255, 112, 216, 142, 99, 157, 229, 124, 137, 24, 248, 188, 
			95, 128, 252, 158, 190, 200,  93, 240 
		};

		private readonly string ValidResponseWithData = "{\"ShortResultText\":\"RG20\",\"Restaurants\":[{\"Id\":12407,\"Name\":\"Herbies Pizza\",\"Address\":\"7 New Street\",\"Postcode\":\"RG21 7DE\",\"City\":\"Basingstoke\",\"CuisineTypes\":[{\"Id\":27,\"Name\":\"Italian\",\"SeoName\":null},{\"Id\":82,\"Name\":\"Pizza\",\"SeoName\":null}],\"Url\":\"http://herbies-pizza-rg21.just-eat.co.uk\",\"IsOpenNow\":true,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"Proactive Temp Offline - Onlined\",\"UniqueName\":\"herbies-pizza-rg21\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":1,\"IsOpenNowForDelivery\":true,\"IsOpenNowForCollection\":true,\"RatingStars\":4.42,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/12407.gif\"}],\"Deals\":[],\"NumberOfRatings\":58},{\"Id\":16052,\"Name\":\"New Greenham Tandoori\",\"Address\":\"The Arts Centre 113 New Greenham Park\",\"Postcode\":\"RG19 6HW\",\"City\":\"Reading\",\"CuisineTypes\":[{\"Id\":31,\"Name\":\"Indian\",\"SeoName\":null}],\"Url\":\"http://newgrennhamtandoori.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"\",\"UniqueName\":\"newgrennhamtandoori\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":6,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":4.09,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/16052.gif\"}],\"Deals\":[],\"NumberOfRatings\":58},{\"Id\":32839,\"Name\":\"Botan Kebab & Pizza House\",\"Address\":\"48 Bartholomew Street\",\"Postcode\":\"RG14 5QA\",\"City\":\"Newbury\",\"CuisineTypes\":[{\"Id\":81,\"Name\":\"Kebab\",\"SeoName\":null}],\"Url\":\"http://botan-rg14.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"Proactive Temp Offline - Onlined\",\"UniqueName\":\"botan-rg14\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":7,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":3.94,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/32839.gif\"}],\"Deals\":[],\"NumberOfRatings\":96},{\"Id\":26780,\"Name\":\"New Standard Tandoori\",\"Address\":\"19 Heathend Road Baughurst\",\"Postcode\":\"RG26 5LX\",\"City\":\"Tadley\",\"CuisineTypes\":[{\"Id\":31,\"Name\":\"Indian\",\"SeoName\":null}],\"Url\":\"http://newstandardtandoori-rg26.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"Proactive Temp Offline - Onlined\",\"UniqueName\":\"newstandardtandoori-rg26\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":4,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":5.1,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/26780.gif\"}],\"Deals\":[],\"NumberOfRatings\":69},{\"Id\":18421,\"Name\":\"Ali Baba\",\"Address\":\"Industrial Units Green Lane\",\"Postcode\":\"RG19 3RG\",\"City\":\"Thatcham\",\"CuisineTypes\":[{\"Id\":31,\"Name\":\"Indian\",\"SeoName\":null},{\"Id\":50,\"Name\":\"Bangladeshi\",\"SeoName\":null}],\"Url\":\"http://alibabarg19.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"TOL:None\",\"UniqueName\":\"alibabarg19\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":5,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":4.8,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/18421.gif\"}],\"Deals\":[],\"NumberOfRatings\":217},{\"Id\":43027,\"Name\":\"Bodrum Kebab & Pizza\",\"Address\":\"41 Bartholomew Street\",\"Postcode\":\"RG14 5QA\",\"City\":\"Berkshire\",\"CuisineTypes\":[{\"Id\":81,\"Name\":\"Kebab\",\"SeoName\":null},{\"Id\":82,\"Name\":\"Pizza\",\"SeoName\":null}],\"Url\":\"http://bodrumkebabandpizza-rg14.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"Proactive Temp Offline - Onlined\",\"UniqueName\":\"bodrumkebabandpizza-rg14\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":3,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":5.39,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/43027.gif\"}],\"Deals\":[],\"NumberOfRatings\":96},{\"Id\":47662,\"Name\":\"A4 Pizza & Kebab\",\"Address\":\"Elcot Park, Lay By Kentbur\",\"Postcode\":\"RG20 8NJ\",\"City\":\"Newbury\",\"CuisineTypes\":[{\"Id\":82,\"Name\":\"Pizza\",\"SeoName\":null},{\"Id\":81,\"Name\":\"Kebab\",\"SeoName\":null}],\"Url\":\"http://a4pizzaandkebab-rg20.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"\",\"UniqueName\":\"a4pizzaandkebab-rg20\",\"IsCloseBy\":true,\"IsHalal\":false,\"DefaultDisplayRank\":2,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":5.77,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/47662.gif\"}],\"Deals\":[],\"NumberOfRatings\":13},{\"Id\":20112,\"Name\":\"Tikka House\",\"Address\":\"85 Bartholomew\",\"Postcode\":\"RG14 5EE\",\"City\":\"Newbury\",\"CuisineTypes\":[{\"Id\":31,\"Name\":\"Indian\",\"SeoName\":null}],\"Url\":\"http://tikkahouse-rg14.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":false,\"IsNew\":false,\"IsTemporarilyOffline\":true,\"ReasonWhyTemporarilyOffline\":\"TOL:TempOffline\",\"UniqueName\":\"tikkahouse-rg14\",\"IsCloseBy\":false,\"IsHalal\":true,\"DefaultDisplayRank\":8,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":4.67,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/20112.gif\"}],\"Deals\":[],\"NumberOfRatings\":27}]}";
		private readonly string ValidResponseNoData = "{\"ShortResultText\":\"RG20\",\"Restaurants\":[]}";
		private readonly string InvalidResponseSome = "{\"Errors\":[{\"ErrorType\":\"Error\",\"Message\":\"Accept-Tenant header must be set to the required country\"}],\"HasErrors\":true}";
		private readonly string InvalidResponseNull = null;

		public readonly int ValidResponseRecordCount = 8;
		public readonly int ValidResponseRecordId = 32839;
		public readonly int ValidResponseRecordNumberOfRatings = 96;
		public readonly string ValidResponseRecordCouisineTypes = "Kebab";

		public void SetMockServiceBehaviour(MockWebServiceBehaviour mockServiceBehaviour)
		{
			this.mockServiceBehaviour = mockServiceBehaviour;
		}

		public ServiceResult DownloadDataFromWeb(string postcode)
		{
			string webResponse = null;

			switch (mockServiceBehaviour)
			{
				case MockWebServiceBehaviour.sbOkFileOk:
				case MockWebServiceBehaviour.sbOkFileFailed:
					webResponse = ValidResponseWithData;
					break;
				case MockWebServiceBehaviour.sbWebEmptyStructure:
					webResponse = ValidResponseNoData;
					break;
				case MockWebServiceBehaviour.sbWebInvalidStructure:
					webResponse = InvalidResponseSome;
					break;
				case MockWebServiceBehaviour.sbWebNullResponse:
					webResponse = InvalidResponseNull;
					break;
			}

			if (webResponse != null)
			{
				return JsonConvert.DeserializeObject<ServiceResult>(webResponse);
			}
			else
			{
				return new ServiceResult();;
			}
			
		}

		public byte[] DownloadImageFromWeb(string url)
		{
			if (mockServiceBehaviour == MockWebServiceBehaviour.sbOkFileOk)
			{
				return fakeImageData;
			}
			else
			{
				return null;
			}
		}
	}
}

