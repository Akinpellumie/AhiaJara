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
    public partial class CartPage : ContentPage
    {
        ProductViewModel productViewModel;
        Cart newCartModel;
        //Product prodModel;
        public CartPage(Cart cartModel)
        {
            productViewModel = new ProductViewModel(Navigation);
            cartModel = newCartModel;
            //prodModel = productModel;
            InitializeComponent();
            this.BindingContext = productViewModel;
        }

        public async void ContinueBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderConPage(productModel: null, cartModel:newCartModel));
        }
    }
}