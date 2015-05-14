using System;

namespace JustEatDemo.Core.BL.DataModels
{
	public class RestaurantDataToDisplay
	{
		public int Id;
		public string Name;
		public double DefaultDisplayRank;
		public double RatingStars;
		public int NumberOfRatings;
		public string CuisineTypes;
		public string LogoPath;

		public RestaurantDataToDisplay(int id, string name, double defaultDisplayRank, double ratingStars, int numberOfRatings)
		{
			this.Id = id;
			this.Name = name;
			this.DefaultDisplayRank = defaultDisplayRank;
			this.RatingStars = ratingStars;
			this.NumberOfRatings = numberOfRatings;
		}
	}
}

