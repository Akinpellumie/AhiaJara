using AhiaJara.Helpers;
using AhiaJara.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhiaJara.Services
{
    public class UserAccessService
    {
        public async Task<bool> RegisterUser(UserDetails loginData)
        {
            bool Response = false;
            await Task.Run(() =>
            {
                String url = Constants.RegisterUrl;
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(loginData);
                HttpContent registerDetails = new StringContent(json);
                registerDetails.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(url, registerDetails);
                var result = response.GetAwaiter().GetResult();

                if (response.Result.IsSuccessStatusCode)
                {
                    MessagingCenter.Send(this, "SuccessRegister");
                    Response = true;
                    //AppShell fpm = new AppShell();
                    //Application.Current.MainPage = fpm;
                }
            });
            return Response;
        }


        public async Task<bool> LoginUser(UserDetails userDetails)
        {
            bool Response = false;
            await Task.Run(() =>
            {
                String url = Constants.LoginUrl;
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(userDetails);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent loginDetails = new StringContent(json);
                loginDetails.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Token", Settings.Token);
                var response = client.PostAsync(url, loginDetails);
                var result = response.GetAwaiter().GetResult();

                if (response.Result.IsSuccessStatusCode)
                {
                    Response = true;
                    //MessagingCenter.Send(this, "SuccessLogin");
                    UserProfile userProfile = JsonConvert.DeserializeObject<Models.UserProfile>(result.Content.ReadAsStringAsync().Result);
                    Constants.userprofile = userProfile;
                    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


                    Settings.Token = userProfile.token;
                    Settings.cartcount = userProfile.cartcount;

                    Settings.id = userProfile.profile.id;
                    Settings.lastName = userProfile.profile.lastName;
                    Settings.firstName = userProfile.profile.firstName;
                    Settings.userName = userProfile.profile.username;
                    Settings.email = userProfile.profile.email;
                    Settings.isAdmin = userProfile.profile.isAdmin;  

                }
            });
            return Response;
        }
    }
}
