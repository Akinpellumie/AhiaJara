using AhiaJara.Services;
using AhiaJara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpViewModel();

            MessagingCenter.Subscribe<UserAccessService>(this, "SuccessRegister", (sender) =>
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            });

            MessagingCenter.Subscribe<SignUpViewModel>(this, "FillAllFields", async (sender) =>
            {
                await DisplayAlert("Enter Data Alert", "Please fill all fields", "Ok");
            });
        }
    }
}