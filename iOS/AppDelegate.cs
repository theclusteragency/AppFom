using System;
using System.Collections.Generic;
using System.Linq;
using AppFom.Helpers;
using Foundation;
using UIKit;
using Xamarin;

namespace AppFom.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            FormsMaps.Init();

            //-----------------------------------------------------------//
            //----------------SCREEN WIDTH & HEIGTH----------------------//
            //-----------------------------------------------------------//           
            Fom.Screen.Width = (int)UIScreen.MainScreen.Bounds.Width;
            Fom.Screen.Height = (int)UIScreen.MainScreen.Bounds.Height;



            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
