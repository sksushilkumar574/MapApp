using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnGetLocation.Clicked += BtnGetLocation_Clicked;
        }

        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();
        }

        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync();

            txtLat.Text = "Latitude: " + position.Latitude.ToString();
            txtLong.Text = "Longitude: " + position.Longitude.ToString();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));

            var newposition = new Position(position.Latitude, position.Longitude); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = newposition,
                Label = "custom pin",
                Address = "custom detail info"
            };
            MyMap.Pins.Add(pin);


            //CLLocationCoordinate2D coord = new CLLocationCoordinate2D(lat, longi);
            //var marker = Marker.FromPosition(coord);
            //marker.Title = string.Format("Marker 1");
            //marker.Animated = true;
            //marker.Map = mapView; // this is the line that I could not find anywhere else!
        }

    }
}
