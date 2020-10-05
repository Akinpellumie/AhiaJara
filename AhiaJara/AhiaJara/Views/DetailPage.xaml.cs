using AhiaJara.Models;
using AhiaJara.PopUps;
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
        public DetailPage(Product proModel)
        {
            InitializeComponent();
            BindingContext = proModel;
            //cartBtn.Clicked += ExecuteCallPopUpCommand();
        }

        private async void ExecuteCallPopUpCommand(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new AddToCartPop());
        }
        public async void CheckOutPage_Clicked(object sender, EventArgs e, Product productModel)
        {
            await Navigation.PushAsync(new CheckOutPage(productModel));
        }
    }
}