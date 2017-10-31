using System;

using Xamarin.Forms;

namespace AppFom.Pages
{
    public class PageCalendar : ContentPage
    {
        public PageCalendar()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Calendar" }
                }
            };
        }
    }
}

