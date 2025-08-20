// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Avianna.AppLayer.Location.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;
using CommunityToolkit.Maui.Maps;

using Microsoft.Maui.Maps;
using Microsoft.Maui.Devices.Sensors;
using Avianna.Domain.Core.Location;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using Avianna.AppLayer.Location.Interfaces;
using System.Diagnostics;

namespace Avianna.presentation.ViewModels.Location; 

public partial class HomeViewmodel : ObservableObject {
    //  private readonly HotspotService _birdService;
      private bool _isBusy;
      private string _label;
      private Microsoft.Maui.Devices.Sensors.Location _userLocation;


      private ILogger<HomeViewmodel> _logger { get; set; }
      private IEbirdLocationRepo _locationService { get; set; }

      public ObservableCollection<BirdHotspot> _birdHotspots = new();
      public bool IsBusy {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
      }

      public string Label {
            get => _label;
            set => SetProperty(ref _label, value);
      }

      public Microsoft.Maui.Devices.Sensors.Location UserLocation {
            get => _userLocation;
            set => SetProperty(ref _userLocation, value);
      }

      public bool IsNotBusy => !IsBusy;

     public HomeViewmodel() {
           

      }

      

      public async Task<List<BirdHotspot>> GetBirdHotspotsAsync() {
            try {
                  Debug.WriteLine(UserLocation.Longitude.ToString() + "Longitude");
                 // logger.LogInformation(UserLocation.Longitude.ToString());
               var res =    await _locationService.GetNearbyHotspotsAsync(lat:UserLocation.Latitude ,lng:UserLocation.Longitude,distKm: 30,maxResults:35);
                  return res;
      }catch(Exception e) {
                  throw new Exception(e.Message);
      }
      }

      private async Task InitializeMapAsync() {
            try {
                /*  IsBusy = true;
                  _userLocation = await GetCurrentLocation();

                  if (_userLocation == null) return;

                  // Set initial map region
                  VisibleRegion = MapHelper.GetMapSpan(_userLocation);

                  // Add user location pin
                  Pins.Add(new CustomPin {
                        Label = "You are here",
                        Location = _userLocation,
                        Type = PinType.Generic
                  });

                  await LoadSightingsAsync();*/
            }
            finally {
                  IsBusy = false;
            }
      }


}
