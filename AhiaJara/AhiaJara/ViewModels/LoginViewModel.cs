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

        public void OnLoginBtn_Clicked(object sender)
        {
            Application.Current.MainPage = new NavigationPage(new AppShell());
            //AppShell fpm = new AppShell();
            //Application.Current.MainPage = fpm;
        }

        private void OnSignUpClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }
    }
}
