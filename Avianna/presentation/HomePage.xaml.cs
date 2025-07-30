using CommunityToolkit.Maui.Maps;
using Microsoft.Maui.Maps;
namespace Avianna.presentation;

public partial class HomePage : ContentPage {
      
      public HomePage() {
            InitializeComponent();
            
      }

      protected override async void OnAppearing() {
            base.OnAppearing();
            PermissionStatus result = await CheckAndRequestPermission();

            if (result == PermissionStatus.Granted) { 
                  Location location = await Geolocation.Default.GetLocationAsync();
                  if (location != null) { 
                        Location position = new Location(location.Latitude, location.Longitude);

                        //Add Map span programmatically 
                        MapSpan span = MapSpan.FromCenterAndRadius(position,Distance.FromKilometers(1));

                       //  var zoomLevel = 0.5;
                      //  var latlongDegrees = 360 / (Math.Pow(2, zoomLevel));



                     //   map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));

                        map.MoveToRegion(span);
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
}
