using System;

using Xamarin.Forms;

namespace AppFom.Pages
{
    public class PageTest : ContentPage
    {
        public PageTest()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Test" }
                }
            };
        }
    }
}

