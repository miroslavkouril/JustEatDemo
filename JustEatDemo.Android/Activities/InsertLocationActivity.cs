using Android.OS;
using Android.App;

namespace JustEatDemo
{
	[Activity(Label = "@string/insert_location_title")]
	public class InsertLocationActivity : FindGPSLocationActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (savedInstanceState == null)
			{
				FragmentManager
					.BeginTransaction()
					.Add(global::Android.Resource.Id.Content, new InsertLocationFragment())
					.Commit();
			}
		}
	}
}


