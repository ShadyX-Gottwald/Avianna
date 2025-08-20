using Avianna.presentation.ViewModels.Location;

namespace Avianna.ReUseComponents.Controls.CustomPin;

public partial class CustomPinView : ContentView
{

      private readonly HomeViewmodel _hvm;
     

      public CustomPinView(HomeViewmodel hvm) {
            // InitializeComponent();
            _hvm = hvm;
            BindingContext = hvm;
      }
}
