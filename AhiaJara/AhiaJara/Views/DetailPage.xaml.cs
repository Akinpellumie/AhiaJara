using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModels;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
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
            if (Constants.cartCount == 0)
            {
                newProductModel.quantity = 1;
            }
            else
            {
                newProductModel.quantity = Constants.cartCount;
            }
            var x = newProductModel.quantity * Int32.Parse(newProductModel.price);
            newProductModel.tempPrice = x.ToString();

            var productOrdered = new Cart()
            {
                createdAt = newProductModel.createdAt,
                id = newProductModel.id,
                productCategory = newProductModel.category,
                productId = newProductModel.id,
                productImgUrl =newProductModel.imgUrl,
                productName =newProductModel.Name,
                productPrice =newProductModel.price,
                quantitySelected =newProductModel.quantity,
                updatedAt = newProductModel.updatedAt,
                //userId = newProductModel.user
            };
            string json = JsonConvert.SerializeObject(productOrdered);
            //List<String> cart = new List<String>();
            ArrayList cart = new ArrayList();
            cart.Add(productOrdered);
            Constants.singleOrder = cart;
            //cart.Add(new Cart() { "products", json });

            //parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });


            await Navigation.PushAsync(new CheckOutPage(newProductModel));
            Constants.cartCount = 0;
        }
    }
}