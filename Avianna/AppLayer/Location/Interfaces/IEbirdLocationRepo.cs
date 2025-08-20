// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avianna.Domain.Core.Location;

using Refit;

namespace Avianna.AppLayer.Location.Interfaces;


public interface IEbirdLocationRepo {

        [Get("/ref/hotspot/geo?lat={lat}&lng={lng}&dist={distKm}")]
      Task<List<BirdHotspot>> GetNearbyHotspotsAsync(
                  double lat,
                  double lng,
                  int distKm,
                  int maxResults = 20);


     /* [Get("/v2/ref/hotspot/{region}")]
      Task<List<BirdHotspot>> GetHotspotsAsync(string region, [Query] string fmt = "json");*/

}
