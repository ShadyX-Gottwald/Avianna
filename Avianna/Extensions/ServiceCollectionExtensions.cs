// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avianna.AppLayer.Location.Interfaces;
using Avianna.AppLayer.Location.Repository;
using Avianna.Features.LoginRegister;
using Avianna.presentation;
using Avianna.ReUseComponents.Controls.CustomAppBar;
using Avianna.presentation.ViewModels;
using Avianna.presentation.ViewModels.Location;

namespace Avianna.Extensions {
      internal static class ServiceCollectionExtensions {

            // Basic service registration with lifetime
            public static IServiceCollection AddService<TService, TImplementation>(
                this IServiceCollection services,
                ServiceLifetime lifetime = ServiceLifetime.Transient)
                where TService : class
                where TImplementation : class, TService {
                  return lifetime switch {
                        ServiceLifetime.Singleton => services.AddSingleton<TService, TImplementation>(),
                        ServiceLifetime.Scoped => services.AddScoped<TService, TImplementation>(),
                        ServiceLifetime.Transient => services.AddTransient<TService, TImplementation>(),
                        _ => throw new ArgumentException("Invalid service lifetime")
                  };
            }

            // Factory-based registration
            public static IServiceCollection AddService<TService>(
                this IServiceCollection services,
                Func<IServiceProvider, TService> factory,
                ServiceLifetime lifetime = ServiceLifetime.Transient)
                where TService : class {
                  return lifetime switch {
                        ServiceLifetime.Singleton => services.AddSingleton(factory),
                        ServiceLifetime.Scoped => services.AddScoped(factory),
                        ServiceLifetime.Transient => services.AddTransient(factory),
                        _ => throw new ArgumentException("Invalid service lifetime")
                  };
            }

            // Conditional registration
            public static IServiceCollection TryAddService<TService, TImplementation>(
                this IServiceCollection services,
                ServiceLifetime lifetime = ServiceLifetime.Transient)
                where TService : class
                where TImplementation : class, TService {
                  if (services.Any(sd => sd.ServiceType == typeof(TService)))
                        return services;

                  return services.AddService<TService, TImplementation>(lifetime);
            }

            // Auto-register view models from assembly
            public static IServiceCollection AddViewModels(this IServiceCollection services) {

                  services.AddSingleton<LoginRegisterViewModel>();
                  services.AddSingleton<MainViewModel>();
                  services.AddSingleton<HomeViewmodel>();



                  return services;
            }

            // Auto-register pages from assembly
            public static IServiceCollection AddPages(this IServiceCollection services ) {

                  services.AddTransient<LoginPage>();

                services.AddTransient<RegisterPage>();
                services.AddTransient<LoginPage>();
                services.AddTransient<MainPage>();
                services.AddTransient<Reference.Reference>();
                services.AddSingleton<HomePage>();
                services.AddSingleton<BirdsPage>();
                services.AddSingleton<ProfilePage>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<CustomAppbar>();

                  return services;
            }

            // Register multiple implementations of an interface
            public static IServiceCollection AddAllImplementations<TService>(
                this IServiceCollection services,
                ServiceLifetime lifetime = ServiceLifetime.Transient
               )
                where TService : class {
                 

                 

                 

                  return services;
            }

            // Platform-specific service registration
            public static IServiceCollection AddPlatformService<TService, TAndroidImpl, TIosImpl>(
                this IServiceCollection services,
                ServiceLifetime lifetime = ServiceLifetime.Singleton)
                where TService : class
                where TAndroidImpl : class, TService
                where TIosImpl : class, TService {
#if ANDROID
           // services.AddService<TService, TAndroidImpl>(lifetime);
#elif IOS
           // services.AddService<TService, TIosImpl>(lifetime);
#endif
                  return services;
            }

            // Auto-register Services
            public static IServiceCollection AddRegisterServices(this IServiceCollection services) {

                  services.AddSingleton<IEbirdLocationRepo, HotspotService>();



                  return services;
            }
      } 

      }


