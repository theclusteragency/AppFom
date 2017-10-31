using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppFom.Pages
{
    public class PageMap : ContentPage
    {
        public PageMap()
        {

            Device.BeginInvokeOnMainThread(async () =>
            {

                var location = await GetCurrentLocation();

                var map = new Map(
                    MapSpan.FromCenterAndRadius(
                        new Position(location.Key, location.Value), Distance.FromMiles(0.3)))
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);


                var positions = new[] {
                    new { latitud = 19.4508296, longitud = -99.1811779,},new { latitud = 19.4608296, longitud = -99.1811779 },
                    new { latitud = 19.4708296, longitud = -99.1811779 },new { latitud = 19.4808296, longitud = -99.1811779 }};

                foreach (var item in positions)
                {

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(item.latitud, item.longitud),
                        Label = "custom pin",
                        Address = "custom detail info"
                    };
                    pin.Clicked += async (sender, e) =>
                    {

                        await PinSelected(pin);
                    };


                    map.Pins.Add(pin);
                }

                var slider = new Slider(1, 18, 1);
                slider.ValueChanged += (sender, e) =>
                {
                    var zoomLevel = e.NewValue; // between 1 and 18
                    var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
                };
                stack.Children.Add(slider);

                Content = stack;

            });

        }

        public async Task<KeyValuePair<double, double>> GetCurrentLocation()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var position = await locator.GetLastKnownLocationAsync();


            return new KeyValuePair<double, double>(position.Latitude, position.Longitude);

        }

        async Task PinSelected(Pin pin)
        {

            Debug.WriteLine(pin.Label);
        }


    }
}
