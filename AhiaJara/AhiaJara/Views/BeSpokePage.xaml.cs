﻿using AhiaJara.Helpers;
using AhiaJara.PopUps;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AhiaJara.Models.FormsModel;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeSpokePage : ContentPage
    {
        private string _answer2;
        private string _answer3;
        private string _answer5;
        private string _answer6, _answer7;
        private string _answer12;
        private string _answer11;
        private string _answer10;
        private string _answer9;
        private string _answer8;
        private string _answer13;

        public BeSpokePage()
        {
            InitializeComponent();
        }

        async void SubmitBespokeClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PopLoader());
            SendData();
            //await Task.Delay(6000);
            
            //await Navigation.PushAsync(new SkinIssueReviewPage());

        }

        private async void SendData()
        {
            var PowerPlants = new List<QuestionAndAnswer>
                {
                    new QuestionAndAnswer(question1.Text, answer1.Text),
                    new QuestionAndAnswer(question2.Text, _answer2),
                    new QuestionAndAnswer(question3.Text, _answer3),
                    new QuestionAndAnswer(question4.Text, answer4.Text),
                    new QuestionAndAnswer(question5.Text, _answer5),
                    new QuestionAndAnswer(question6.Text, _answer6),
                    new QuestionAndAnswer(question7.Text, _answer7),
                    new QuestionAndAnswer(question8.Text, _answer8),
                    new QuestionAndAnswer(question9.Text, _answer9),
                    new QuestionAndAnswer(question10.Text, _answer10),
                    new QuestionAndAnswer(question11.Text, _answer11),
                    new QuestionAndAnswer(question12.Text, _answer12),
                    new QuestionAndAnswer(question13.Text, _answer13),


                };
            var json = JsonConvert.SerializeObject(PowerPlants);
            Console.WriteLine(json);

            var url = Constants.postBespoke;

            HttpClient client = new HttpClient();

            //var content = new FormUrlEncodedContent(dataToSend);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
            var response = await client.PostAsync(url, content);
            //var result = response.GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                await PopupNavigation.Instance.PopAsync(true);
                await DisplayAlert("Bespoke Submitted", "We will get back to you soon", "Ok");
                //await Navigation.PushAsync(new SkinIssueReviewPage());
                //IsBusy = false;
            }
            else
            {
                await PopupNavigation.Instance.PopAsync(true);
                await  DisplayAlert("Failed", "Please fill all fields and check your internet", "Ok");
            }

        }

        private void OnPickerSelected2(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer2 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected3(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer3 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected5(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer5 = selectedItem.ToString();// This is the model selected in the picker
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

        private void OnPickerSelected8(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer8 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected9(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer9 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected10(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer10 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected11(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer11 = selectedItem.ToString();// This is the model selected in the picker
        }

        private void OnPickerSelected12(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer12 = selectedItem.ToString();// This is the model selected in the picker
        }
        private void OnPickerSelected13(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer13 = selectedItem.ToString();// This is the model selected in the picker
        }
    }
}