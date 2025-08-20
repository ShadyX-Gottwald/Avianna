// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avianna.Domain.Core.Location.Maps;
using Microsoft.Maui.Maps;

namespace Avianna.Infrastructure.Helpers; 

public class MapHelper {

      public static CustomPin CreateUserPin(Location location) {
            return new CustomPin {
                  Label = "Your Location",
                  MyLocation = location,
                  PinType = PinType.User
            };
      }

      public static MapSpan GetMapSpan(Location center, double radiusKm = 1) {
            return MapSpan.FromCenterAndRadius(center, Distance.FromKilometers(radiusKm));
      }
}
