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
    public partial class CheckOutPage : ContentPage
    {
        public static ProductViewModel ProductViewModel;
        ProductModel prodModel;
        public CheckOutPage(ProductModel productModel)
        {
            ProductViewModel = new ProductViewModel(Navigation);
            prodModel = productModel;
            InitializeComponent();
            BindingContext = productModel;
            
            //stackCheckout.BindingContext = productModel;
        }

        public async void ContinueBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderConPage());
        }

    }
}