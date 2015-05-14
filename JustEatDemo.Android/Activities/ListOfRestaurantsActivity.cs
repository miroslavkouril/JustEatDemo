
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JustEatDemo
{
	[Activity]			
	public class ListOfRestaurantsActivity : Activity
	{
		public const string SelectedPostcode = "SELECTED_POSTCODE";

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (savedInstanceState == null)
			{
				string selectedPostcode = Intent.GetStringExtra(SelectedPostcode);

				FragmentManager
					.BeginTransaction()
					.Add(global::Android.Resource.Id.Content, new ListOfRestaurantsFragment(selectedPostcode))
					.Commit();
			}

			ActionBar.SetDisplayHomeAsUpEnabled(true);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case global::Android.Resource.Id.Home:
					Finish();
					return true;
				default:
					return base.OnOptionsItemSelected(item);	
			}
		}
	}
}

