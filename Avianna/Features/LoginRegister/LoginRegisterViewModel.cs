using Avianna.presentation;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Avianna.Features.LoginRegister;

public partial class LoginRegisterViewModel : ObservableObject {


      public LoginRegisterViewModel() {

      }

      [RelayCommand]
      public async Task NavToRegisterPage() => await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");

      [RelayCommand]
      public async Task NavToLoginPage() => await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

      [RelayCommand]
      public async Task NavToHomePage() => await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
}
