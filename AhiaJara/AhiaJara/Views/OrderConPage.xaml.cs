using AhiaJara.Models;
using AhiaJara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderConPage : ContentPage
    {
        ProductViewModel productViewModel;
        ProductModel prodModel;
        public OrderConPage(ProductModel productModel, Cart cartModel)
        {
            productViewModel = new ProductViewModel(Navigation);
            prodModel = productModel;
            InitializeComponent();
        }

        public async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPaymentPage(prodModel));
        }
    }
}