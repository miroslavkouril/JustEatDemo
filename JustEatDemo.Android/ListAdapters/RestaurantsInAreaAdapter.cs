﻿using System;
using Android.Widget;
using JustEatDemo.Core.BL.DataModels;
using System.Collections.Generic;
using Android.Views;
using Android.Content;
using Android.App;
using Java.IO;
using Android.Graphics;

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
