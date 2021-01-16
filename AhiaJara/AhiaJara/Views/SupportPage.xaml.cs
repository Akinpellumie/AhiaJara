using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        private async void support_Clicked(object sender, EventArgs e)
        {
            if (msgEntry.Text != null)
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new PageLoader());
                    SupportModel supportModel = new SupportModel()
                    {

                        subject = "Support Message from AhiaJara",
                        email = Settings.email,
                        phoneNo = Settings.phone,
                        fullName = Settings.lastName + " " + Settings.firstName,
                        text = msgEntry.Text,
                    };
                
                    HttpClient client = new HttpClient();

                    var url = Constants.sendSupportMessage;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);

                    var json = JsonConvert.SerializeObject(supportModel);
                    //var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpContent result = new StringContent(json);
                    result.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync(url, result);

                    if (response.IsSuccessStatusCode)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Sent", "Our support staff will get back to you shortly", "ok");
                        msgEntry.Text = "";
                        //await Navigation.PushAsync(new RequestPage());
                        await Shell.Current.Navigation.PopAsync();

                    }

                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                await DisplayAlert("Error", "Please fill all fields", "Ok");
            }


            msgEntry.Text = "";


        }
    }
}