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
    public partial class CardPaymentPage : ContentPage
    {
        public ProductViewModel ProductViewModel;
        ProductModel prodModel;
        public CardPaymentPage(ProductModel productModel)
        {
            ProductViewModel = new ProductViewModel(Navigation);
            prodModel = productModel;
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Yoo", "Your payment is successful", "Ok");
            await Navigation.PushAsync(new PayStackPage(prodModel));
        }
    }
}