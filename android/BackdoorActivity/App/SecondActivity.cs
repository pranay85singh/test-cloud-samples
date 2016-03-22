using Android.App;
using Android.OS;

namespace BackdoorActivity
{
    [Activity(Label = "@string/second_activity_title")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_activity);
        }
    }
}