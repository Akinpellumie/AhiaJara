using AhiaJara.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginBtn_Clicked);
            SignUpCommand = new Command(OnSignUpClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AppShell)}");
        }

        public async void OnLoginBtn_Clicked(object sender)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//main");
        }

        private void OnSignUpClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }
    }
}
