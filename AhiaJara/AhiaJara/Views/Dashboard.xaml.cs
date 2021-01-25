using AhiaJara.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        ProductViewModel ProductViewModel;
        long lastPress;
        public Dashboard()
        {
            ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = ProductViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            //Navigation.PushAsync(new Dashboard());
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No").ConfigureAwait(false);
                if (result) System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            });
            return true;
        }

    }
}