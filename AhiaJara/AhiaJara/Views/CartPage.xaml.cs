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
        ProductViewModel ProductViewModel;
        public CartPage()
        {
                ProductViewModel = new ProductViewModel(Navigation);
                BindingContext = ProductViewModel;
                InitializeComponent();
        }
    }
}