using System.Collections.Generic;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo.Core.BL.DataModels
{
	public class ServiceResultRestaurant
	{
		public int Id;
		public string Name;
		public double DefaultDisplayRank;
		public double RatingStars;
		public int NumberOfRatings;
		public bool IsOpenNow;
		public List<ServiceResultCuisineType> CuisineTypes;
		public List<ServiceResultLogo> Logo;
	}
}