using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapsui;
using Mapsui.Utilities;
using Mapsui.UI;
using Mapsui.UI.Maui;
using Mapsui.Tiling;
using Mapsui.Tiling.Layers;

using Map = Mapsui.Map;
using Mapsui.Projections;
using Mapsui.Extensions;
using Mapsui.Layers;

namespace CrimeAvtoService
{
    public partial class MapPage : ContentPage
    {
        public static Location? location;

        public static MapView mapView;


        private MapControl mapControl;

        private Map map => mapControl.Map;

        public MapPage()
        {
            InitializeComponent();

            Content = GetContent();
            UpdateMyLocation();
        }

        public MapView GetContent()
        {
            if (mapControl == null)
            {
                mapControl = new MapControl();
                map.Layers.Add(OpenStreetMap.CreateTileLayer());
                // map.Layers.Add(new MyLocationLayer(map));

                map.Home = n =>
                {
                    n.CenterOnAndZoomTo(SphericalMercator.FromLonLat(34.100318, 44.948237).ToMPoint(), n.Resolutions[10]);
                };
            }

            mapView = new MapView()
            {
                MyLocationEnabled = true,
                MyLocationFollow = true,
                PanLock = true,
            };

            mapView.Map = map;
            InitPins();

            return mapView;
        }

        public void InitPins()
        {
            foreach(var serv in AvtoServiceDB.avtoServices)
            {
                mapView.Pins.Add(new Pin()
                {
                    Label = serv.Name,
                    Address = serv.Address,
                    Position = new Position(serv.Coords.lat, serv.Coords.lon),
                    Tag = serv,
                });
            }
            mapView.PinClicked += (object obj, PinClickedEventArgs arg) =>
            {
                
                NavigationPage.navigation.LoadTab(1);
            };
        }

        static CancellationTokenSource updateLocationCancleSource = new CancellationTokenSource();

        public async void UpdateMyLocation()
        {
            PermissionStatus status = await UserLocation.CheckAndRequestLocationPermission();

            if (status == PermissionStatus.Granted)
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    mapView.MyLocationLayer.UpdateMyLocation(new Position(location.Latitude, location.Longitude));
                }

                Task update = new Task(async () =>
                {
                    while (true)
                    {
                        var currentLocation = await Geolocation.GetLocationAsync();

                        if (currentLocation != null)
                        {
                            location = currentLocation;

                            mapView.MyLocationLayer.UpdateMyLocation(new Position(currentLocation.Latitude, currentLocation.Longitude), true);
                        }
                        Thread.Sleep(3000);
                    }
                }, updateLocationCancleSource.Token);

                update.Start();
            }
        }


    }
}