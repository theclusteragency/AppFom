﻿using System;
using AppFom.MasterDetail;
using AppFom.Pages;
using Xamarin.Forms;

namespace AppFom
{
    public class App : Application
    {
        public static INavigation INavPage { get; set; }

        public App()
        {
            // The root page of your application           
            MainPage = new NavigationPage(new PageSession());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
