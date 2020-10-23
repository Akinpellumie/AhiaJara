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
    public partial class ToolBarView : ContentView
    {
        Product productModel;
        Cart cartModel;
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
           nameof(Title),
           typeof(string),
           typeof(ToolBarView),
           string.Empty);
        public ToolBarView()
        {
            InitializeComponent();
            BindingContext = new ToolbarViewModel();
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
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