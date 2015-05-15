using System;
using System.Collections.Generic;
using System.Linq;
using JustEatDemo.Core.BL.DataModels;
using JustEatDemo.Core.DAL;
using JustEatDemo.Core.SAL;

namespace JustEatDemo.Core.BL
{
	public class RestaurantsInArea
	{
		private readonly IFileHelper fileHelper;
		private readonly IWebService webService;

		public RestaurantsInArea(IFileHelper fileHelper)
		{
			this.fileHelper = fileHelper;
			this.webService = new WebService();
		}

		public RestaurantsInArea(IFileHelper fileHelper, IWebService webService)
		{
			this.fileHelper = fileHelper;
			this.webService = webService;
		}

		public List<RestaurantDataToDisplay> GetListOfRestaurantsInArea(string postcode)
		{
			var result = new List<RestaurantDataToDisplay>();

			var availableRestaurants = webService.DownloadDataFromWeb(postcode);

			foreach (var restaurant in availableRestaurants.Restaurants ?? Enumerable.Empty<ServiceResultRestaurant>())
			{
				RestaurantDataToDisplay dataToDisplay = new RestaurantDataToDisplay(restaurant.Id, restaurant.Name, restaurant.DefaultDisplayRank, restaurant.RatingStars, restaurant.NumberOfRatings, restaurant.IsOpenNow); 
				dataToDisplay.LogoPath = DownloadAndSaveRestaurantLogo(restaurant.Id, restaurant.Logo);
				dataToDisplay.CuisineTypes = GetRestaurantCuisineTypesFormated(restaurant.CuisineTypes);

				result.Add(dataToDisplay);
			}

			return result;
		}

		private string DownloadAndSaveRestaurantLogo(int restaurantId, List<ServiceResultLogo> logo)
		{
			string savedFilePath = null;
			if ((logo != null) && (logo.Count > 0))
			{
				var rawData = webService.DownloadImageFromWeb(logo[0].StandardResolutionURL);
				savedFilePath = fileHelper.SaveImage(rawData, restaurantId);
			}
			
			return savedFilePath;
		}

		private string GetRestaurantCuisineTypesFormated(List<ServiceResultCuisineType> cuisineTypes)
		{
			string cuisineTypesFormated = null;
			foreach (var cuisineType in cuisineTypes ?? Enumerable.Empty<ServiceResultCuisineType>())
			{
				if (String.IsNullOrEmpty(cuisineTypesFormated))
				{
					cuisineTypesFormated = cuisineType.Name;
				}
				else
				{
					cuisineTypesFormated += string.Format(", {0}", cuisineType.Name);
				}
			}

			return cuisineTypesFormated;
		}
	}
}