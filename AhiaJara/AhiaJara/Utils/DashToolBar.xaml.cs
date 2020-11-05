using AhiaJara.Models;
using AhiaJara.ViewModels;
using AhiaJara.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashToolBar : ContentView
    {

        Cart cartModel;
        public DashToolBar()
        {
            InitializeComponent(); 
            BindingContext = new ToolbarViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        public async void CartIcon_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(cartModel));
        }

        public async void BellIcon_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationPage());
        }
    }
}