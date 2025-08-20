namespace Avianna.ReUseComponents.Controls.AppHeader;

public partial class AppHeader : ContentView {
      public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(AppHeader), string.Empty);

      public string Title {
            get
                  => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value);
      }

      public AppHeader() {
            // InitializeComponent();
      }
}
