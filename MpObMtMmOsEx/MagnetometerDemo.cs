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
    public class MagnetometerDemo : Activity
    {
        private Button start;
        private Button stop;
        private TextView textV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
 
            SetContentView(Resource.Layout.magnetometerDemo);
            UIReference();
            UIClickEvent();
        }
        private void UIClickEvent()
        {
            start.Click += Start_Click;
            stop.Click += Stop_Click;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Magnetometer.IsMonitoring)
            {
                Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
                Magnetometer.Stop();
            }
        }



        private void Start_Click(object sender, EventArgs e)
        {
            if (!Magnetometer.IsMonitoring)
            {
                Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
                Magnetometer.Start(SensorSpeed.Fastest);

            }
        }


       
        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            
            textV.Text = $"Reading X: {e.Reading.MagneticField.X}, Reading Y: {e.Reading.MagneticField.Y}, Reading Z: {e.Reading.MagneticField.Z}");
        }

      

        private void UIReference()
        {
            start = FindViewById<Button>(Resource.Id.buttonStartMM);
            stop = FindViewById<Button>(Resource.Id.buttonStopMM);
            textV = FindViewById<TextView>(Resource.Id.textViewmMM);

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}