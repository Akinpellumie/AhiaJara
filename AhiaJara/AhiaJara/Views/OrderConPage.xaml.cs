using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AhiaJara.Models.FormsModel;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderConPage : ContentPage
    {
        ProductViewModel productViewModel;
        ProductModel prodModel;
        string res;
        private string _answer1;

        public OrderConPage(ProductModel productModel, string cartModel)
        {
            productViewModel = new ProductViewModel(Navigation);
            prodModel = productModel;
            res = cartModel;
            InitializeComponent();
        }

        public async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            getShippingData();
            await Navigation.PushAsync(new CardPaymentPage(prodModel, res));
        }

        private void getShippingData()
        {
            var shippingData = new List<QuestionAndAnswer>
                {
                    new QuestionAndAnswer(question1.Text, firstNameEnrty.Text),
                    new QuestionAndAnswer(question2.Text, lastNameEnrty.Text),
                    new QuestionAndAnswer(question3.Text, phoneNoEnrty.Text),
                    new QuestionAndAnswer(question4.Text, addressEnrty.Text),
                    new QuestionAndAnswer(question5.Text, _answer1),
                    new QuestionAndAnswer(question6.Text, cityEntry.Text),
                };
            string json = JsonConvert.SerializeObject(shippingData);
            Constants.ShippingDetails = json;
        }

        private void OnPickerSelected1(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer1 = selectedItem.ToString();// This is the model selected in the picker
        }
    }
}