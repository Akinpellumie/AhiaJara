using AhiaJara.Helpers;
using AhiaJara.PopUps;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AhiaJara.Models.FormsModel;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionnairePage : ContentPage
    {
        public QuestionnairePage()
        {
            InitializeComponent();
            
        }

        String _answer1, _answer6, _answer7;
        private async void getAnswers()
        {
            if(_answer1 != null && answer2.Text != null & _answer6 != null)
            {
                await PopupNavigation.Instance.PushAsync(new PageLoader());
                try
                {
                    var PowerPlants = new List<QuestionAndAnswer>
                {
                    new QuestionAndAnswer(question1.Text, _answer1),
                    new QuestionAndAnswer(question2.Text, answer2.Text),
                    new QuestionAndAnswer(question3.Text, answer3.Text),
                    new QuestionAndAnswer(question4.Text, answer4.Text),
                    new QuestionAndAnswer(question5.Text, answer5.Text),
                    new QuestionAndAnswer(question6.Text, _answer6),
                    new QuestionAndAnswer(question7.Text, _answer7),


                };
                    var json = JsonConvert.SerializeObject(PowerPlants);
                    Console.WriteLine(json);

                    var url = Constants.PostQuestionaire;

                    HttpClient client = new HttpClient();

                    //var content = new FormUrlEncodedContent(dataToSend);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    //HttpContent item = new StringContent(json);
                    //item.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    var response = client.PostAsync(url, content);
                    var result = response.GetAwaiter().GetResult();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Questionnaire Submitted", "We will get back to you soon", "Ok");
                        await PopupNavigation.Instance.PopAsync(true);
                        //IsBusy = false;
                    }
                    else
                    {
                        await DisplayAlert("Failed", "Please fill all fields and check your internet", "Ok");
                        await PopupNavigation.Instance.PopAsync(true);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }

           
        }

        private void OnPickerSelected1(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer1 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected6(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer6 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected7(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer7 = selectedItem.ToString();// This is the model selected in the picker
        }

        public void OnSubmitQuestion(object sender, EventArgs e)
        {
            getAnswers();
        }

    }
}