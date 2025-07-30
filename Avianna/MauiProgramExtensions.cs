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

                      

                  builder.Services.AddSingleton<RegisterPage>();
                  builder.Services.AddSingleton<LoginPage>();
                  builder.Services.AddSingleton<MainPage>();
                  builder.Services.AddSingleton<Reference.Reference>();
                  builder.Services.AddSingleton<LoginRegisterViewModel>();
                  builder.Services.AddSingleton<MainViewModel>();
                  builder.Services.AddSingleton<HomePage>();
                  builder.Services.AddSingleton<BirdsPage>();
                  builder.Services.AddSingleton<ProfilePage>(); 
                  builder.Services.AddSingleton<SettingsPage>();


#if DEBUG
                  builder.Logging.AddDebug();
#endif

                  return builder;
            }
      }
}
