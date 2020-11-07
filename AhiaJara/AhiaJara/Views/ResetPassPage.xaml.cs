using AhiaJara.Helpers;
using AhiaJara.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassPage : ContentPage
    {
        public ResetPassPage()
        {
            InitializeComponent();
        }


        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void ResetPassword_Clicked(object sender, EventArgs e)
        {
            ModifyPassword modifyPassword = new ModifyPassword()
            {
                email = accountEmail.Text,
            };
            var json = JsonConvert.SerializeObject(modifyPassword);

            try
            {


                HttpClient client = new HttpClient();
                var url = Constants.resetPassword;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                //await PopupNavigation.Instance.PopAsync(true);
                if (result.IsSuccessStatusCode)
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    await DisplayAlert("Success", "A new password has been sent to your email", "Ok");
                }
                else
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    await DisplayAlert("Failed", "Email not found in our records", "Try Again");
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}