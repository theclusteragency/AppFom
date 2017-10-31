using System;
using AppFom.Helpers;
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
            //var NoUser = new Image { 
            //Source = ImageSource.FromResource("GoodLook.Images.gl_img_girl.png"),
            //HeightRequest = 45, WidthRequest = 45 };
            var Sl_Wrap_Photo = new StackLayout
            { //BackgroundColor = Color.Red, 
                VerticalOptions = LayoutOptions.Center
            };
            //var NoUser = new CircleImage
            //{
            //    BorderColor = Color.White,
            //    BorderThickness = 1,
            //    HeightRequest = 45,
            //    WidthRequest = 45,
            //    Aspect = Aspect.AspectFill,
            //    HorizontalOptions = LayoutOptions.Center,
            //    //Source = UriImageSource.FromUri(new Uri("http://lorempixel.com/80/80/"))
            //};
            //NoUser.SetBinding(Image.SourceProperty, "Source_Photo");
            //Sl_Wrap_Photo.Children.Add(NoUser);
            var Lbl_Name = new Label
            {
                //Text = string.Format("{0} {1}", Look.Globals.NAME, Look.Globals.LASTNAME),
                Text = "Sabrina",
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.TailTruncation

            };
            Sl_Head.Children.Add(Sl_Wrap_Photo);
            Sl_Head.Children.Add(Lbl_Name);
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