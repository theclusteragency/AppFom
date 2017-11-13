using System;
using AppFom.Helpers;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace AppFom.MasterDetail
{
    public class MenuPage : ContentPage
    {
        void TG_Close_Tapped(object sender, EventArgs e)
        {

        }

        public ListView Menu { get; set; }

        public MenuPage()
        {
            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Icon = "ico_fom_burger.png";
            Title = "menu"; // The Title property must be set.
            BackgroundColor = Color.White;
            this.BindingContext = Fom.VMmenu;//new VM_MenuPage(this.Navigation);
            //this.BindingContext = new VMMenuPage(this.Navigation);
            Menu = new MenuListView();
            Menu.SeparatorColor = Color.Transparent;
            Menu.BackgroundColor = Color.Transparent;

            var menuLabel = new ContentView
            {
                Padding = new Thickness(10, 36, 0, 5),
                Content = new Label
                {
                    TextColor = Color.White,//Color.FromHex("AAAAAA"),
                    Text = "Fom",
                }
            };

            var Sl_Head = new StackLayout
            {
                HeightRequest = 100,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(15, 15, 0, 0),
                Spacing = 20
            };


            var TgAccount = new TapGestureRecognizer();
            TgAccount.SetBinding(TapGestureRecognizer.CommandProperty, "CommandAccount");

            var SlWrapPhoto = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 10),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 10
            };
            SlWrapPhoto.GestureRecognizers.Add(TgAccount);

            var NoUser = new CircleImage
            {
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                HeightRequest = 50,
                WidthRequest = 50,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                //Source = UriImageSource.FromUri(new Uri("http://lorempixel.com/80/80/"))
            };
            NoUser.SetBinding(Image.SourceProperty, "Source_Photo");

            SlWrapPhoto.Children.Add(NoUser);

            var SlWrapInfo = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
            };

            var LblName = new Label
            {
                //Text = string.Format("{0} {1}", Look.Globals.NAME, Look.Globals.LASTNAME),
                //Text = "Sabrina Torres",
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.TailTruncation

            };
            LblName.SetBinding(Label.TextProperty, "TextName");

            var LblJob = new Label
            {
                //Text = string.Format("{0} {1}", Look.Globals.NAME, Look.Globals.LASTNAME),
                //Text = "Gerente 3er distrito",
                TextColor = Color.LightGray,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation

            };
            LblJob.SetBinding(Label.TextProperty, "TextDesRoll");

            SlWrapInfo.Children.Add(LblName);
            SlWrapInfo.Children.Add(LblJob);

            SlWrapPhoto.Children.Add(SlWrapInfo);

            Sl_Head.Children.Add(SlWrapPhoto);
            layout.Children.Add(Sl_Head);
            layout.Children.Add(Menu);

            var Sl_Wrap_Close = new StackLayout
            {
                HeightRequest = Fom.Screen.Height * .2,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Padding = new Thickness(10)
            };

            var ImgCloseSession = new Image
            {
                Source = ImageSource.FromResource("AppFom.Images.ico_menu_closesession.png"),
                Aspect = Aspect.AspectFit
                //WidthRequest = 43,
                //HeightRequest = 46
            };

            var TG_Close = new TapGestureRecognizer();
            TG_Close.SetBinding(TapGestureRecognizer.CommandProperty, "Command_Close");
            var LblCloseSesion = new Label
            {
                Text = "Terminar sesión",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            };
            LblCloseSesion.GestureRecognizers.Add(TG_Close);

            Sl_Wrap_Close.Children.Add(ImgCloseSession);
            Sl_Wrap_Close.Children.Add(LblCloseSesion);

            layout.Children.Add(Sl_Wrap_Close);

            Content = layout;
        }
    }
}