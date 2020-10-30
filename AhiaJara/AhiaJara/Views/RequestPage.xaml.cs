using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModels;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RequestPage : ContentPage
    {
        ProductViewModel ProductViewModel;
        private string selectedCategory;
        private string _productId;
        private string selectedProductName;
        public RequestPage()
        {
            //ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            //this.BindingContext = ProductViewModel;
        }

        private void OnCategorySelected(object sender, EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                selectedCategory = picker.SelectedItem.ToString();
                //_answer2 = selectedItem.ToString();// This is the model selected in the picker
                if (selectedCategory == "Skin Products")
                {
                    var prod = Constants.SkinProductsList;
                    var newProd = new ObservableCollection<ProductModel>(prod);
                    ProductPicker.ItemsSource = newProd;
                }
                else
                {
                    var prod = Constants.HairProductsList;
                    var newProd = new ObservableCollection<ProductModel>(prod);
                    ProductPicker.ItemsSource = newProd;

                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void OnProductSelected(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            selectedProductName = picker.SelectedItem.ToString();
            var idx = picker.SelectedIndex;
            //_answer2 = selectedItem.ToString();// This is the model selected in the picker
                var prod = Constants.HairProductsList;
                var newProd = new ObservableCollection<ProductModel>(prod);
                descEntry.Text = newProd[idx].description;
                _productId = newProd[idx].id;

            //var a = newProd[idx].name;
        }

        private async void request_Clicked(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new PopLoader());
                RequestModel requestProduct = new RequestModel()
                {
                    quantitySelected = qtyEntry.Text,
                    productId = _productId,
                    userId = Settings.id,
                };

                HttpClient client = new HttpClient();

                var url = Constants.RequestProduct;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);

                var json = JsonConvert.SerializeObject(requestProduct);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent result = new StringContent(json);
                result.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(url, result);

                if (response.IsSuccessStatusCode)
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    await DisplayAlert("Success", "Product request Successful", "ok");
                    await Shell.Current.Navigation.PopModalAsync();

                }

            }
            catch(Exception)
            {
                return;
            }

            CategoryPicker.SelectedIndex = -1;
            ProductPicker.SelectedIndex = -1;
            qtyEntry.Text = "";
            descEntry.Text = "";

        
    }
            
    }
}

