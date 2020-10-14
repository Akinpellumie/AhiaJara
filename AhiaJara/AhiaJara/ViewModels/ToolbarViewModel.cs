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
        }

        private ObservableCollection<CartCount> cartCountList;
        public ObservableCollection<CartCount> CartCountList
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
                CartCount = CartCountResult.cartcount;

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
    }
}
