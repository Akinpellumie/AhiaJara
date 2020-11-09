using AhiaJara.Helpers;
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
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            ShowUserDetails();
        }

        private void ShowUserDetails()
        {
            //fullName.Text = Settings.firstName + " " + Settings.lastName;
            PhoneEntry.Text = Settings.phone;
            emailEntry.Text = Settings.email;
        }
    }
}