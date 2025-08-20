// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows.Input;

namespace Avianna.ReUseComponents.Controls.CustomAppBar;

public partial class CustomAppbar : ContentView {
      //  public static readonly BindableProperty TitleProperty =
      //  <summary>
      ///    BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomAppbar), string.Empty);
      /// </summary>

      //  public static readonly BindableProperty ShowBackButtonProperty =
      //   BindableProperty.Create(nameof(ShowBackButton), typeof(bool), typeof(CustomAppbar), false);

      /*  public string Title {
              get => (string)GetValue(TitleProperty);
              set => SetValue(TitleProperty, value);
        }*/

      /* public bool ShowBackButton {
             get => (bool)GetValue(ShowBackButtonProperty);
             set => SetValue(ShowBackButtonProperty, value);
       }*/

      // public ICommand BackCommand { get; set; }
      public CustomAppbar() {
            //InitializeComponent();

            // BackCommand = new Command(async () => await Navigation.PopAsync());
            // BindingContext = this; // Set binding context to itself
      }
}
