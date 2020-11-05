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
    public partial class SearchPage : ContentPage
    {
        ProductViewModel searchViewModel;
        public SearchPage()
        {
            searchViewModel = new ProductViewModel();
            InitializeComponent();
            this.BindingContext = searchViewModel;
        }

        void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                SearchResult.IsVisible = false;
                emptySearch.IsVisible = true;
                SearchProduct.ItemsSource = searchViewModel.ProductModelList;

            }
            else if(e.NewTextValue.Length >= 2)
            {
                SearchResult.IsVisible = true;
                emptySearch.IsVisible = false;
                indic.IsVisible = true;
                indic.IsRunning = true;
                HttpClient client = new HttpClient();
                var dashboardEndpoint = Constants.AllProductsUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(Constants.AllProductsUrl);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                ObservableCollection<ProductModel> ProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                indic.IsVisible = false;
                indic.IsRunning = false;
                var searchHere = ProductModelList;
                var SearchRes = searchHere.Where(x => x.Name.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase));
                SearchProduct.ItemsSource = SearchRes;
            }
        }

    }
}