using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModels;
using Rg.Plugins.Popup.Services;
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
    public partial class DetailPage : ContentPage
    {
        Product productModel;
        ProductViewModel productViewModel;
        public DetailPage(Product proModel)
        {
            productModel = proModel;
            InitializeComponent();
            BindingContext = proModel;
            cartBtn.BindingContext = productViewModel;
            //cartBtn.Clicked += ExecuteCallPopUpCommand();
        }

        //private async void ExecuteCallPopUpCommand(object sender, EventArgs e)
        //{
        //    await PopupNavigation.Instance.PushAsync(new AddToCartPop(txt));
        //    //var nos = north.
        //}
        public async void CheckOutPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckOutPage(productModel));
        }
    }
}