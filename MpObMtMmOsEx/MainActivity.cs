using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MpObMtMmOsEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button myMediaPickerL;
        private Button myOpenBrowser;
        private Button myMagnetometer;
        private Button myOrientationSensor;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myMediaPickerL = FindViewById<Button>(Resource.Id.button1);
            myOpenBrowser = FindViewById<Button>(Resource.Id.button2);
            myMagnetometer = FindViewById<Button>(Resource.Id.button3);
            myOrientationSensor = FindViewById<Button>(Resource.Id.button4);

            myMediaPickerL.Click += MyMediaPickerL_Click;
            myOpenBrowser.Click += MyOpenBrowser_Click;
            myMagnetometer.Click += MyMagnetometer_Click;
            myOrientationSensor.Click += MyOrientationSensor_Click;
        }

        private void MyOrientationSensor_Click(object sender, System.EventArgs e)
        {
            Intent l = new Intent(Application.Context, typeof(OrientationSensorDemo));
            StartActivity(l);
        }

        private void MyMagnetometer_Click(object sender, System.EventArgs e)
        {
            Intent k = new Intent(Application.Context, typeof(MagnetometerDemo));
            StartActivity(k);
        }

        private void MyOpenBrowser_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(OpenBrowserDemo));
            StartActivity(j);
        }

        private void MyMediaPickerL_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(MediaPickerDemo));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}