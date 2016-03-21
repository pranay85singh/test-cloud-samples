using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace BackdoorActivity
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
        [Java.Interop.Export("StartActivityTwo")]
        public void StartActivityTwo()
	    {
            Intent i = new Intent(this, typeof(SecondActivity));
            StartActivity(i);
        }

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.first_activity);

		    FindViewById<Button>(Resource.Id.button1).Click += (sender, args) =>
		                                                       {
                                                                   Intent i = new Intent(this, typeof(SecondActivity));
                                                                   StartActivity(i);
		                                                       };
		}
	}
}


