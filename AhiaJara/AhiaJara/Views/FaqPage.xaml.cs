using AhiaJara.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaqPage : ContentPage
    {
        public FaqPage()
        {
            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            InitializeComponent();
            var astraWeb = Constants.FaqUrl;
            Payview.Source = astraWeb;
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Payview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Indic.IsVisible = true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Indic.ProgressTo(0.9, 900, Easing.SpringIn);
        }

        private void Payview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Indic.IsVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return false;
        }
    }
}