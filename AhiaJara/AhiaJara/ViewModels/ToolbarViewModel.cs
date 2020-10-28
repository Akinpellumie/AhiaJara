using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class ToolbarViewModel:BaseVM
    {
        public ToolbarViewModel()
        {
            GetCartCount();
            GetCarts();
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
    }
}
