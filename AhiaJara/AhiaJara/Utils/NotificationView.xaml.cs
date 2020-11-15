using AhiaJara.Helpers;
using AhiaJara.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationView : ContentView
    {
        public NotificationView()
        {
            InitializeComponent();
            GetNotifications();
        }

        public async void GetNotifications()
        {
            try
            {
                indic.IsVisible = true;
                indic.IsRunning = true;

                HttpClient client = new HttpClient();
                var url = Constants.MyNotificationsUrl + Settings.id;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var response = await client.GetAsync(url);

                var json = await response.Content.ReadAsStringAsync();

                //List<MyNotification> userTransactions = JsonConvert.DeserializeObject<List<MyNotification>>(json);

                Notification userTransactions = JsonConvert.DeserializeObject<Notification>(json);
                if(userTransactions == null)
                {
                    indic.IsVisible = false;
                    indic.IsRunning = false;
                }
                else
                {
                    NotificationsList.ItemsSource = userTransactions.allNotification;
                }
                

                indic.IsVisible = false;
                indic.IsRunning = false;
                // await PopupNavigation.Instance.PopAsync(true);
                //return userTransactions;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}