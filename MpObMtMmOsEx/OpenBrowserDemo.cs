using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MpObMtMmOsEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class OpenBrowserDemo : Activity
    {
        private Button buttonOpenBrowser;
        private Button buttonbrowser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.openbrowserDemo);

            buttonOpenBrowser = FindViewById<Button>(Resource.Id.openBrowser);
            buttonbrowser = FindViewById<Button>(Resource.Id.customBrowser);
            buttonOpenBrowser.Click += ButtonOpenBrowser_Click;
            buttonbrowser.Click += Buttonbrowser_Click;

        }

        private async void Buttonbrowser_Click(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.swedishnomad.com/turkish-food/", new BrowserLaunchOptions
            {
                Flags = BrowserLaunchFlags.PresentAsFormSheet,
                LaunchMode= BrowserLaunchMode.SystemPreferred,
                TitleMode=BrowserTitleMode.Show,
                PreferredToolbarColor= Color.AliceBlue,
                PreferredControlColor=Color.CadetBlue
            
            
            });
            
        }

        private async void ButtonOpenBrowser_Click(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.swedishnomad.com/turkish-food/", BrowserLaunchMode.SystemPreferred);
        }


    }
}