using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhiaJara.Services;
using AhiaJara.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
            BindingContext = new LoginViewModel();

            //MessagingCenter.Subscribe<UserAccessService>(this, "SuccessLogin", (sender) =>
            //{
            //    OnSuccessLogin();
            //});
        }

        public async void ResetPassClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        void Init()
        {
            App.StartCheckIfInternet(lbl_NoInternet, this);
        }

        public async void OnSuccessLogin()
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//main");
        }
        //public void OnLoginBtn_Clicked(object sender, EventArgs e)
        //{
        //    AppShell fpm = new AppShell();
        //    Application.Current.MainPage = fpm;
        //}
    }
}