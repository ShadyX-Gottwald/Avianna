using Avianna.presentation.ViewModels.Location;
using CommunityToolkit.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
namespace Avianna.presentation;

public partial class HomePage : ContentPage {

      private readonly HomeViewmodel _homeViewmodel;
      public HomePage(HomeViewmodel homeViewmodel) {
            InitializeComponent();
            _homeViewmodel = homeViewmodel;
            BindingContext = _homeViewmodel;
            

      }

      protected override async void OnAppearing() {
            base.OnAppearing();
            PermissionStatus result = await CheckAndRequestPermission();

            if (result == PermissionStatus.Granted) {
                  Location location = await Geolocation.Default.GetLocationAsync();
                  if (location != null) {
                        Location position = new Location(location.Latitude, location.Longitude);

                        //Use User Location to VM 
                        _homeViewmodel.UserLocation = position;
                        _homeViewmodel.Label = "Motherwell";

                        //Add Map span programmatically 
                        MapSpan span = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1));

                        //  var zoomLevel = 0.5;
                        //  var latlongDegrees = 360 / (Math.Pow(2, zoomLevel));


                        //Circle
                       Circle circle = new Circle {
                              Center = position,
                              StrokeWidth = 8,
                              StrokeColor = Colors.Red.WithAlpha(0.8f),
                              FillColor = Colors.Pink.WithAlpha(0.4f),
                              Radius = Distance.FromKilometers(10)


                        };

                        //user Location Pin 
                        var userPin = new Pin {
                              Label = _homeViewmodel.Label,
                              Location = _homeViewmodel.UserLocation, 
                              Type = PinType.Place
                        };

                        userPin.MarkerClicked += Pin_MarkerClicked;

                        map.Pins.Add(userPin);
                       
                        
                        map.MapElements.Add(circle);
                       // map.MapElements.Add(userPin);

                         //  map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));

                        map.MoveToRegion(span);
                      await Task.Run( () =>  _homeViewmodel.GetBirdHotspotsAsync());
                     //  await  _homeViewmodel.GetBirdHotspotsAsync();
                        // map.MapElements.Add(circle);


                  }
            }
      }

      private async Task<PermissionStatus> CheckAndRequestPermission() {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted) {
                  return status;
            }

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.Android) {
                  return PermissionStatus.Denied;
            }
            return status;
      }

      private async void  Pin_MarkerClicked(object sender, PinClickedEventArgs e) {
         // await  DisplayAlert("Hey","Just Saying Hey" , "Dismiss");
         var pinInfo = (Pin) sender;
        await  DisplayAlert("Hi",pinInfo.Address,"Ok");
      }

     
}
