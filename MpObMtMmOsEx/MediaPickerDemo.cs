using Android.App;
using Android.Content;
using Android.Graphics;
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
    public class MediaPickerDemo : Activity
    {
        private Button captureB;
        private Button pickB;
        private TextView mytextView;
        private ImageView myimageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.mediapickerDemo);
            UIReference();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            captureB.Click += CaptureB_Click;
            pickB.Click += PickB_Click;
        }

        private async void PickB_Click(object sender, EventArgs e)
        {
            var pic = await MediaPicker.PickPhotoAsync();
            if (pic != null)
            { 
                mytextView.Text= $"File Name: { pic.FileName} " ;

                if (pic.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || (pic.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)))
                {
                    var stream = await pic.OpenReadAsync();
                    myimageView.SetImageBitmap(BitmapFactory.DecodeStream(stream));
                
                
                }
            
            
            }
        }

        private async void CaptureB_Click(object sender, EventArgs e)
        {
            var res = await MediaPicker.CapturePhotoAsync();

            using (var stream = await res.OpenReadAsync())
            {
                mytextView.Text = $"File Name: {res.FileName} ";
                myimageView.SetImageBitmap(BitmapFactory.DecodeStream(stream));
            }
        }

        private void UIReference()
        {
            captureB = FindViewById<Button>(Resource.Id.buttonMP1);
            pickB = FindViewById<Button>(Resource.Id.buttonMP2);
            myimageView = FindViewById<ImageView>(Resource.Id.imageViewMP);
            mytextView = FindViewById<TextView>(Resource.Id.textViewMP);
            
        }
    }
}