using System;
using JustEatDemo.Core.BL;
using NUnit.Framework;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo.Core.Tests.BL
{
	[TestFixture()]
	public class SaveInstanceStateHelperTest
	{
		private readonly string ServiceResultData = "{\"Id\":20112,\"Name\":\"Tikka House\",\"DefaultDisplayRank\":8.0,\"RatingStars\":4.67,\"NumberOfRatings\":27,\"CuisineTypes\":\"Indian\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/20112.gif\"}";
		private readonly string[] ServiceResultRestaurantsData = {
			"{\"Id\":12407,\"Name\":\"Herbies Pizza\",\"DefaultDisplayRank\":1.0,\"RatingStars\":4.42,\"NumberOfRatings\":58,\"CuisineTypes\":\"Italian, Pizza\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/12407.gif\"}",
			"{\"Id\":16052,\"Name\":\"New Greenham Tandoori\",\"DefaultDisplayRank\":6.0,\"RatingStars\":4.09,\"NumberOfRatings\":58,\"CuisineTypes\":\"Indian\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/16052.gif\"}",
			"{\"Id\":32839,\"Name\":\"Botan Kebab & Pizza House\",\"DefaultDisplayRank\":7.0,\"RatingStars\":3.94,\"NumberOfRatings\":96,\"CuisineTypes\":\"Kebab\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/32839.gif\"}",
			"{\"Id\":26780,\"Name\":\"New Standard Tandoori\",\"DefaultDisplayRank\":4.0,\"RatingStars\":5.1,\"NumberOfRatings\":69,\"CuisineTypes\":\"Indian\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/26780.gif\"}",
			"{\"Id\":18421,\"Name\":\"Ali Baba\",\"DefaultDisplayRank\":5.0,\"RatingStars\":4.8,\"NumberOfRatings\":217,\"CuisineTypes\":\"Indian, Bangladeshi\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/18421.gif\"}",
			"{\"Id\":43027,\"Name\":\"Bodrum Kebab & Pizza\",\"DefaultDisplayRank\":3.0,\"RatingStars\":5.39,\"NumberOfRatings\":96,\"CuisineTypes\":\"Kebab, Pizza\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/43027.gif\"}",
			"{\"Id\":47662,\"Name\":\"A4 Pizza & Kebab\",\"DefaultDisplayRank\":2.0,\"RatingStars\":5.77,\"NumberOfRatings\":13,\"CuisineTypes\":\"Pizza, Kebab\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/47662.gif\"}",
			"{\"Id\":20112,\"Name\":\"Tikka House\",\"DefaultDisplayRank\":8.0,\"RatingStars\":4.67,\"NumberOfRatings\":27,\"CuisineTypes\":\"Indian\",\"LogoPath\":\"/data/data/kouril.justeat.demo/files/20112.gif\"}"
		};

		private const int ServiceResultRestaurantsDataCount = 8;

		[Test]
		public void JSONStringToStructureAndBack()
		{
			var structure = SaveInstanceStateHelper.StructureFromJSONString<RestaurantDataToDisplay>(ServiceResultData);
			Assert.IsNotNull(structure);

			var jsonString = SaveInstanceStateHelper.StructureAsJSONString<RestaurantDataToDisplay>(structure);
			Assert.AreEqual(ServiceResultData, jsonString);
		}

		[Test]
		public void JSONStringToListStructureAndBack()
		{
			var listStructure = SaveInstanceStateHelper.StructureListFromJSONString<RestaurantDataToDisplay>(ServiceResultRestaurantsData);			
			Assert.IsNotNull(listStructure);
			Assert.AreEqual(ServiceResultRestaurantsDataCount, listStructure.Count);

			var jsonStringArray = SaveInstanceStateHelper.StructureListAsJSONString<RestaurantDataToDisplay>(listStructure);
			Assert.AreEqual(ServiceResultRestaurantsData, jsonStringArray);
		}
	}
}

