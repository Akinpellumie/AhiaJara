using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayStackPage : ContentPage
    {
        public static ProductViewModel ProductViewModel;
        ProductModel prodModel;
        string res;
        string payCode;
        string amountPaid;
        //string xData;   
        public PayStackPage(ProductModel productModel, string cartModel)
        {
           
           
            decimal totalPrice;

            if (productModel != null)
            {
                prodModel = productModel;

                res = JsonConvert.SerializeObject(Constants.singleOrder);
                //res = JsonConvert.SerializeObject(prodModel);
                Formulars formular = new Formulars();
                string[] ssize = prodModel.TotalPrice.Split(new char[0]);
                string price = ssize[1].ToString();
                amountPaid = price;
                totalPrice = formular.ConvertToDecimal(price);
            }
            else
            {
                res = cartModel;
                var data = JsonConvert.DeserializeObject<List<Cart>>(cartModel);
                Formulars formular = new Formulars();
                //string ssize = data[0].productPrice;
                //int tempPrice = Int32.Parse(ssize);
                //string price = tempPrice.ToString();
                //string[] ssize = Settings.CartTotalPrice.Split(new char[0]);
                string price = Settings.CartTotalPrice.ToString();
                amountPaid = price;
                totalPrice = formular.ConvertToDecimal(price);

                amountPaid = price;
                totalPrice = formular.ConvertToDecimal(price);
            }
               

            InitializeComponent();
            loadingAsync();

            JArray jarray = new JArray();
            dynamic customFieldsArray = new JArray();

            dynamic displayname = new JObject();
            displayname.display_name = "Mobile Number";
            displayname.variable_name = "mobile_number";
            displayname.@value = "+23480000000";

            customFieldsArray.Add(displayname);
            dynamic jobtitlefield = new JObject();
            jobtitlefield.display_name = "Job Title";
            jobtitlefield.variable_name = "job_title";
            jobtitlefield.@value = "Software Developer";

            customFieldsArray.Add(jobtitlefield);



            dynamic custom = new JObject();
            custom.custom_fields = customFieldsArray;

            dynamic product = new JObject();
            product.key = "pk_live_472e7785d2a12c332ef662d659c6007772e5a54b";
            product.email = "ahiajara007@gmail.com";
            product.amount = totalPrice;
            //product.subaccount = "ACCT_zpve61wnc0fbs6b";
            product.bearer = "account";
            product.@ref = Guid.NewGuid();
            product.metadata = custom;

            hybridWebView.Data = product.ToString();


            hybridWebView.RegisterCloseAction(() => DisplayAlert("payment cancelled", "your payment have been cancelled", "ok"));
            hybridWebView.RegisterCallBackAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));

        }

        public async void HybridWebView_PaymentClosed(object sender, string e)
        {
            //await DisplayAlert("WebView Closed", "Close button clicked event", "ok");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                
                  Navigation.PushAsync(new Dashboard());
                
            });           
            
        }


        private async void hybridWebView_PaymentSuccessful(object sender, string e)
        {
            payCode = e;
            postOrder();
            await DisplayAlert("Please keep your payment code", "Payment Code: " + e, "OK");
            await Navigation.PushAsync(new Dashboard());
        }

 
        private async Task loadingAsync()
        {
            await PopupNavigation.Instance.PushAsync(new PageLoader());
            //postOrder();
            await Task.Delay(8000);
            await PopupNavigation.Instance.PopAsync(true);
            
        }

        private async void postOrder()
        {
            try
            {
                HttpClient client = new HttpClient();

                string shippingDetails = Constants.ShippingDetails;
                var url = Constants.postOrder;
                //var url = "http://192.168.43.162:5000/order";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);

                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new StringContent(res), "products");
                content.Add(new StringContent(payCode), "paymentId");
                //content.Add(new StringContent("e344334443rere3433"), "paymentId");

                content.Add(new StringContent(shippingDetails), "shippingDetails");
                content.Add(new StringContent(amountPaid), "amountPaid");

                var response = await client.PostAsync(url, content);
               // var x = "jane";
                //Console.WriteLine(content);
            }
            catch (Exception)
            {
                return;
            }

            //Console.ReadLine();
        }
    }
}