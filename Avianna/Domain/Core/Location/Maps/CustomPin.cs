// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

using Microsoft.Maui.Devices.Sensors;

namespace Avianna.Domain.Core.Location.Maps; 

public class CustomPin {
      public PinType PinType { get; set; }
      public string SpeciesCode { get; set; }
      public string Label { get; set; } 
      public Microsoft.Maui.Devices.Sensors.Location MyLocation { get; set; }
    //  public DateTime ObservationDate { get; set; }
    //  public string ImageUrl { get; set; }
}
