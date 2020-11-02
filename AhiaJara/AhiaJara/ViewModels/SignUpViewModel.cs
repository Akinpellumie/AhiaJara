using AhiaJara.Models;
using AhiaJara.Services;
using AhiaJara.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class SignUpViewModel:BaseViewModel
    {
        private UserAccessService userAccessService;
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

        

        public string confirmPassowwrd;
        public string ConfirmPassowwrd
        {
            get { return confirmPassowwrd; }
            set { SetProperty(ref confirmPassowwrd, value); }
        }
        public SignUpViewModel()
        {
            SignUpCommand = new Command(() => OnSignUp_Clicked());
        }

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AppShell)}");
        //}

        public async void OnSignUp_Clicked()
        {
            if(Password != ConfirmPassowwrd)
            {
                MessagingCenter.Send(this, "passwordMismatch");
            }
            else
            {
                if (Email == null || Password == null || Lastname == null || Firstname == null || PhoneNo == null)
                {
                    MessagingCenter.Send(this, "FillAllFields");
                }
                else
                {
                    var registerData = new UserDetails()
                    {
                        email = Email,
                        password = Password,
                        lastName = Lastname,
                        firstName = Firstname,
                        phoneNo = PhoneNo,

                    };

                    userAccessService = new UserAccessService();
                    RegisterUser(registerData);

                }

            }
            
            //Application.Current.MainPage = new NavigationPage(new AppShell());
            //AppShell fpm = new AppShell();
            //Application.Current.MainPage = fpm;
        }

        private async void RegisterUser(UserDetails registerData)
        {
            await userAccessService.RegisterUser(registerData);
        }

        private void OnSignUpClicked()
        {
            //(Email == null || Firstname == null || Lastname == null || Password == null || PhoneNo == null)
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }

}
