using AhiaJara.Helpers;
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
        public static ProductModel newProductModel;
        ProductViewModel productViewModel;
        public DetailPage(ProductModel proModel)
        {
            
            newProductModel = proModel;
            InitializeComponent();
            BindingContext = proModel;
            cartBtn.BindingContext = productViewModel;

            MessagingCenter.Subscribe<ToolbarViewModel>(this, "FillAllFields", async (sender) =>
            {
                await DisplayAlert("Network Failed", "Please Check Noetwork Connectivity", "Ok");
            });

            //cartBtn.Clicked += ExecuteCallPopUpCommand();
        }

        //private async void ExecuteCallPopUpCommand(object sender, EventArgs e)
        //{
        //    await PopupNavigation.Instance.PushAsync(new AddToCartPop(txt));
        //    //var nos = north.
        //}
        public async void CheckOutPage_Clicked(object sender, EventArgs e)
        {
            newProductModel.quantity = Constants.cartCount;
            var x = Constants.cartCount * Int32.Parse(newProductModel.price);
            newProductModel.tempPrice = x.ToString();
           
            await Navigation.PushAsync(new CheckOutPage(newProductModel));
        }
    }
}