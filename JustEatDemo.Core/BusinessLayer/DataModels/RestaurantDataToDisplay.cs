﻿namespace JustEatDemo.Core.BL.DataModels
{
	public class RestaurantDataToDisplay
	{
		public RestaurantDataToDisplay(int id, string name, double defaultDisplayRank, double ratingStars, int numberOfRatings, bool isOpen)
		{
			this.Id = id;
			this.Name = name;
			this.DefaultDisplayRank = defaultDisplayRank;
			this.RatingStars = ratingStars;
			this.NumberOfRatings = numberOfRatings;
			this.IsOpen = isOpen;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public double DefaultDisplayRank { get; private set; }
		public double RatingStars { get; private set; }
		public int NumberOfRatings { get; private set; }
		public bool IsOpen { get; private set; }
		public string CuisineTypes  { get; set; }
		public string LogoPath  { get; set; }

	}
}