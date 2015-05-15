using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.IO;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo
{
	public class RestaurantsInAreaAdapter : BaseAdapter
	{
		private Activity context;
		private readonly List<RestaurantDataToDisplay> dataToDisplay;

		public RestaurantsInAreaAdapter(Activity context, List<RestaurantDataToDisplay> dataToDisplay)
		{
			this.context = context;
			this.dataToDisplay = dataToDisplay;
		}

		public override Java.Lang.Object GetItem(int position)
		{
			throw new NotImplementedException();
		}

		public override long GetItemId(int position)
		{
			return dataToDisplay[position].Id;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			if (view == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.ListOfRestaurantsListItem, null);
			}

			var name = view.FindViewById<TextView>(Resource.Id.name);
			name.Text = dataToDisplay[position].Name;

			var cousine = view.FindViewById<TextView>(Resource.Id.cousine);
			cousine.Text = dataToDisplay[position].CuisineTypes;

			var logo = view.FindViewById<ImageView>(Resource.Id.logo);
			if (!string.IsNullOrEmpty(dataToDisplay[position].LogoPath))
			{
				var imgFile = new File(dataToDisplay[position].LogoPath);
				if (imgFile.Exists())
				{
					Bitmap myBitmap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
					logo.SetImageBitmap(myBitmap);
				}
				else
				{
					logo.SetImageDrawable(context.Resources.GetDrawable(Resource.Drawable.ic_empty_logo));
				}
			}
			else
			{
				logo.SetImageDrawable(context.Resources.GetDrawable(Resource.Drawable.ic_empty_logo));
			}

			var closedIndicator = view.FindViewById<TextView>(Resource.Id.closed_indicator);
			closedIndicator.Visibility = dataToDisplay[position].IsOpen ? ViewStates.Invisible : ViewStates.Visible;

			var rating = view.FindViewById<DisplayRating>(Resource.Id.rating);
			rating.MaxRating = 6;
			rating.Rating = (float)dataToDisplay[position].RatingStars;

			return view;
		}

		public override int Count
		{
			get
			{
				return dataToDisplay.Count;
			}
		}
	}
}