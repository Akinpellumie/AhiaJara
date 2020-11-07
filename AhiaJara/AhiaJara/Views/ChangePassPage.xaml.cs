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
    public partial class ChangePassPage : ContentPage
    {
        public ChangePassPage()
        {
            InitializeComponent();
        }

        public async void ChangePassword_Clicked(object sender, EventArgs e)
        {
            ModifyPassword modifyPassword = new ModifyPassword()
            {
                oldPassword = oldPassword.Text,
                newPassword = newPassword.Text
            };
            var json = JsonConvert.SerializeObject(modifyPassword);
            if(oldPassword.Text == newPassword.Text)
            {
                try
                {


                    HttpClient client = new HttpClient();
                    var url = Constants.changePassword;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(url, content);
                    //await PopupNavigation.Instance.PopAsync(true);
                    if (result.IsSuccessStatusCode)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Success", "Password changed successfully", "Ok");
                    }
                    else
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Failed", "Incorrect old password", "Try Again");
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                await DisplayAlert("Password Mismatch", "Please confirm new password", "Try Again");
            }
            
        }
    }
}