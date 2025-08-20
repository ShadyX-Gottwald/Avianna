// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avianna.AppLayer.Location.Interfaces;
using Avianna.Domain.Core.Location;
using Refit;

namespace Avianna.AppLayer.Location.Repository;

/*public class HotspotService(
      IEbirdLocationRepo ebirdLocationRepo
            ) : IEbirdLocationRepo {
     private Task<IEnumerable<BirdHotspot>> IEbirdLocationRepo.GetNearbyHotspotsAsync(double lat, double lng, int distKm, int maxResults) {
            return ebirdLocationRepo.GetNearbyHotspotsAsync(lat, lng, distKm, maxResults);
      }
}*/

public class HotspotService :IEbirdLocationRepo {

      private readonly IEbirdLocationRepo _ebirdLocation;
      private Object Obj {get;set;}
      public HotspotService(IEbirdLocationRepo ebirdLocation) { 
            _ebirdLocation = ebirdLocation;
      }
   

     async Task<List<BirdHotspot>> IEbirdLocationRepo.GetNearbyHotspotsAsync(double lat, double lng, int distKm, int maxResults) {
            return await _ebirdLocation.GetNearbyHotspotsAsync(lat, lng, distKm, maxResults);
      }
}
