using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class ToolbarViewModel:BaseVM, INotifyPropertyChanged
    {
        public ToolbarViewModel()
        {
            GetCartCount();
            GetCarts();
            GetNotificationCount();
        }

        private ObservableCollection<Cart> cartCountList;
        public ObservableCollection<Cart> CartCountList
        {
            get { return cartCountList; }
            set { SetProperty(ref cartCountList, value); }
        }

        public int cartcount;
        public int CartCount
        {
            get { return cartcount; }
            set { SetProperty(ref cartcount, value); }
        }

        private int _notificationCount;
        public int NotificationCount
        {
            get => _notificationCount;
            set {
                SetProperty(ref _notificationCount, value);
                OnPropertyChanged("NotificationCount");
            }
            
        }
        public async Task<bool> GetCartCount()
        {
            bool Response = false;
            await Task.Run(() =>
            {
                HttpClient client = new HttpClient();
                var CartCountEndpoint = Constants.GetCartCount + Settings.id;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);

                var response = client.GetStringAsync(CartCountEndpoint);
                var responsee = client.GetAsync(CartCountEndpoint);
                var result = response.GetAwaiter().GetResult();
                var CartCountResult = JsonConvert.DeserializeObject<CartCount>(result);
                //var CartCountResult2 = JsonConvert.DeserializeObject<List<CartCount>>(result);
                CartCount = CartCountResult.cartcount;
                //CartCountList = new ObservableCollection<CartCount>(CartCountResult2);

                if (responsee.Result.IsSuccessStatusCode)
                {
                    Response = true;
                }
                else
                {
                    MessagingCenter.Send(this, "NetworkFailed");
                }
            });
            return Response;
        }

        public async Task GetNotificationCount()
        {
            try
            {

                HttpClient client = new HttpClient();
                //var url = Constants.MyNotificationsUrl + Settings.id;
                var url = Constants.MyNotificationsUrl;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var response = await client.GetAsync(url);

                var json = await response.Content.ReadAsStringAsync();

                //List<MyNotification> userTransactions = JsonConvert.DeserializeObject<List<MyNotification>>(json);

                Notification userTransactions = JsonConvert.DeserializeObject<Notification>(json);
                if (userTransactions == null)
                {
                    return;
                }
                else
                {
                    NotificationCount = userTransactions.countunread;
                }
                // await PopupNavigation.Instance.PopAsync(true);
                //return userTransactions;
            }
            catch (Exception)
            {
                return;
            }
        }
        public async void GetCarts()
        {
            var cartItems = new Cart();
            //IsBusy = true;
                HttpClient client = new HttpClient();
                var cartEndpoint = Constants.GetCart + Settings.id;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var responsee = client.GetAsync(cartEndpoint);
            var result = await client.GetStringAsync(cartEndpoint);
                var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                CartCountList = new ObservableCollection<Cart>(CartList);
            if (responsee.Result.IsSuccessStatusCode)
            {
                MessagingCenter.Send(this, "Success");
            }
            else
            {
                MessagingCenter.Send(this, "NetworkFailed");
            }

            //IsBusy = false;


        }

        //#region INotifyPropertyChanged

        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged(string propertyName)
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
            
        //}

        //#endregion
    }
}
