using Android.App;
using Android.Content;
using Android.OS;

namespace JustEatDemo
{
	[Activity(MainLauncher = true, NoHistory = true, Theme="@style/SplashScreen")]			
	public class SplashScreenActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			StartFirstApplicationScreen();

			Finish();
		}

		private void StartFirstApplicationScreen()
		{
			var intent = new Intent(this, typeof(InsertLocationActivity));
			StartActivity(intent);
		}
	}
}

