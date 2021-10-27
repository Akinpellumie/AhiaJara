using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.Services;
using AhiaJara.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserAccessService userAccessService;
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }


        //public string email { get; set; }
        //public string firstName { get; set; }
        //public string lastName { get; set; }
        //public string password { get; set; }
        //public string phoneNo { get; set; }
        public string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string firstName;

        public string Firstname
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        public string lastName;

        public string Lastname
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        public string phoneNo;
        public string PhoneNo
        {
            get { return phoneNo; }
            set { SetProperty(ref phoneNo, value); }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(() => OnLoginBtn_Clicked());
            SignUpCommand = new Command(() => OnSignUpClicked());
        }

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AppShell)}");
        //}

        public async void OnLoginBtn_Clicked()
        {
            if (Email == null || Password == null)
            {
                MessagingCenter.Send(this, "FillAllFields");
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PageLoader());
                var loginData = new UserDetails()
                {
                    email = Email,
                    password = Password
                };

                userAccessService = new UserAccessService();
                UserLogin(loginData);
            }
          
               
            
            //Application.Current.MainPage = new NavigationPage(new AppShell());
            //AppShell fpm = new AppShell();
            //Application.Current.MainPage = fpm;
        }

        private async void UserLogin(UserDetails loginData)
        {
            bool result = await userAccessService.LoginUser(loginData);
            if (result == true)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
                await PopupNavigation.Instance.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

        private void OnSignUpClicked()
        {
            //(Email == null || Firstname == null || Lastname == null || Password == null || PhoneNo == null)
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }
    }
}
