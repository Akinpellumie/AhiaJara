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
    public partial class SkinIssuePage : ContentPage
    {
        public SkinIssuePage()
        {
            InitializeComponent();
        }

        void OnfirstNext_Clicked(object sender, EventArgs e)
        {
            defaultScreen.IsVisible = false;
            secondScreen.IsVisible = true;
        }

        async void OnSecondNext_Clicked(object sender, EventArgs e)
        {
            defaultScreen.IsVisible = false;
            secondScreen.IsVisible = false;
            thirdScreen.IsVisible = true;
            await DisplayAlert("Info","Long-press image to select.","Ok");
        }

        public async void OnThirdScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PopLoader());

            await Task.Delay(6000);
            await PopupNavigation.Instance.PopAsync(true);
            await Navigation.PushAsync(new SkinIssueReviewPage());

        }
    }
}