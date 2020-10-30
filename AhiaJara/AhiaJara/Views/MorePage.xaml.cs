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
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        public async void OrderPage_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new BeSpokePage());
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
            await Navigation.PushAsync(new FaqPage());
        }
        public async void ResetBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassPage());
        }
    }
}