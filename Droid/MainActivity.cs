using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AppFom.Helpers;
using Xamarin;

namespace AppFom.Droid
{
    [Activity(Label = "AppFom.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);


            //-----------------------------------------------------------//
            //----------------SCREEN WIDTH & HEIGTH----------------------//
            //-----------------------------------------------------------//
            Fom.Screen.Width = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            Fom.Screen.Height = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);

            LoadApplication(new App());
        }
    }
}
