using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        ProductViewModel productViewModel;
        Cart newCartModel;
        //Product prodModel;
        public CartPage(Cart cartModel)
        {
            GetCarts();
            productViewModel = new ProductViewModel(Navigation);
            cartModel = newCartModel;
            //prodModel = productModel;
            InitializeComponent();
            this.BindingContext = productViewModel;
        }

        public ObservableCollection<Cart> CartModelList { get; private set; }

        public async void ContinueBtn_Clicked(object sender, EventArgs e)
        {
            CartPage carting = new CartPage(newCartModel);
            string res = await carting.GetCarts();

            var cartItems = Constants.CartItemList;
            await Navigation.PushAsync(new OrderConPage(productModel: null, res));
        }

        public async Task<string> GetCarts()
        {
            string result;
            //var cartItems = new Cart();
            try
            {
                    HttpClient client = new HttpClient();
                    var cartEndpoint = Constants.GetCart + Settings.id;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    result = await client.GetStringAsync(cartEndpoint);
                    var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                   // CartModelList = new ObservableCollection<Cart>(CartList);
               
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return result;
        }
    }
}