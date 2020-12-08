using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        public async void RequestPage_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage());
        }

        public async void QuestionBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionnairePage());
        }

        public async void SupportBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new SupportPage());
        }
        public async void ProfileBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        public async void NewsBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new NewsUpdatePage());
        }
        public async void FaqBtn_Clicked(object obj, EventArgs e)
        {
           //await DisplayAlert("Check Later", "We are getting our FAQs page ready", "Ok");
            await Navigation.PushAsync(new FaqPage());
        }
        public async void ResetBtn_Clicked(object obj, EventArgs e)
        {

            await Navigation.PushAsync(new ResetPassPage());
        }

        public void LogOutBtn_Clicked(object obj, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            Application.Current.MainPage = new LoginPage();
            //await Navigation.PushAsync(new LoginPage());
        }
    }
}