using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MpObMtMmOsEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class OrientationSensorDemo : Activity
    {

        private Button mstart;
        private Button mstop;
        private TextView mtextV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           
            SetContentView(Resource.Layout.orientationSensor);

            UIReference();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            mstart.Click += mStart_Click;
            mstop.Click += mStop_Click;
        }

        private void mStop_Click(object sender, EventArgs e)
        {
            if (OrientationSensor.IsMonitoring)
            {
                OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
                OrientationSensor.Stop();
            }
        }



        private void mStart_Click(object sender, EventArgs e)
        {
            if (!OrientationSensor.IsMonitoring)
            {
                OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
                OrientationSensor.Start(SensorSpeed.Fastest);

            }
        }

        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>

              mtextV.Text = $"Reading X: {e.Reading.Orientation.X}, Reading Y: {e.Reading.Orientation.Y}, Reading Z: {e.Reading.Orientation.Z}");
        }

       
    


        private void UIReference()
        {
            mstart = FindViewById<Button>(Resource.Id.buttonStartMM);
            mstop = FindViewById<Button>(Resource.Id.buttonStopMM);
            mtextV = FindViewById<TextView>(Resource.Id.textViewmMM);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}