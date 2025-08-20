// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Logging;
using UraniumUI;
using CommunityToolkit;
using CommunityToolkit.Maui.Maps;
using Avianna.presentation;
using Avianna.Features.LoginRegister;
using Avianna.Reference;
using Refit;
using Avianna.ReUseComponents.Controls.CustomAppBar;
using Avianna.Extensions;
using System.Text.Json.Serialization;
using System.Text.Json;
using Avianna.AppLayer.Location.Interfaces;


namespace Avianna {
      public static class MauiProgramExtensions {
            public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder) {
                  builder
                      .UseMauiApp<App>()
                      .UseUraniumUI()
                      .UseUraniumUIMaterial()
                      .UseMauiMaps()
                      .ConfigureFonts(fonts => {
                            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                      });


                  // Register Refit client
                  builder.Services.AddRefitClient<IEbirdLocationRepo>(provider => new RefitSettings {
                        ContentSerializer = new SystemTextJsonContentSerializer(
                              new JsonSerializerOptions {
                                    PropertyNameCaseInsensitive = true,
                                    Converters = { new JsonStringEnumConverter() }
                              })
                  }).ConfigureHttpClient(c =>
                  {
                        c.BaseAddress = new Uri("https://api.ebird.org/v2");
                        c.DefaultRequestHeaders.Add("X-eBirdApiToken", "rhj2pqdjsgpu");
                  });


                  builder.Services.AddPages();
                  builder.Services.AddViewModels();
                  builder.Services.AddRegisterServices();
                  
#if DEBUG
                  builder.Logging.AddDebug();
#endif

                  return builder;
            }
      }
}
