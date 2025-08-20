// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avianna.Domain.Core.Location {
      public class BirdHotspot {
            public string LocId { get; set; } 
            public string Name { get; set; } 
            public double Latitude { get; set; }
            public double Longitude { get; set; }  
            public string CountryCode { get; set; }
            public string Subnational1Name { get; set; }
            public string LatestObservationDate { get; set; } 
            public int NumSpeciesAllTime {  get; set; }

            

      }
}
