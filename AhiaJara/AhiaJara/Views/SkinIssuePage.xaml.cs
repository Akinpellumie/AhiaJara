﻿using AhiaJara.Helpers;
using AhiaJara.PopUps;
using AhiaJara.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AhiaJara.Models.FormsModel;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkinIssuePage : ContentPage
    {
        private MediaFile _mediaFile;
        String _answer2, _answer6, _answer7;
        private string _answer3;
        private string _answer5;
        private string _answer14;
        private string _answer12;
        private string _answer11;
        private string _answer10;
        private string _answer9;
        private string _answer8;

        ProductViewModel productViewModel;
        public SkinIssuePage()
        {
            productViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = productViewModel;

        }

        void OnfirstNext_Clicked(object sender, EventArgs e)
        {
            defaultScreen.IsVisible = false;
            secondScreen.IsVisible = true;
        }

         void OnSecondNext_Clicked(object sender, EventArgs e)
        {
            defaultScreen.IsVisible = false;
            secondScreen.IsVisible = false;
            thirdScreen.IsVisible = true;
            SendData();
            //await DisplayAlert("Info","Long-press image to select.","Ok");
        }

        public async void OnThirdScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PopLoader());
            
            //await Task.Delay(6000);
            await PopupNavigation.Instance.PopAsync(true);
            //await Navigation.PushAsync(new SkinIssueReviewPage());

        }

        async void Permission()
        {
            await Permissions.RequestAsync<Permissions.Camera>();
            await Permissions.RequestAsync<Permissions.StorageRead>();
            await Permissions.RequestAsync<Permissions.StorageWrite>();
        }

        public async void SelectImage(object sender, EventArgs e)
        {
            Permission();
            await CrossMedia.Current.Initialize();
            try
            {


                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Warning", "Allow system permission for this App", "Ok");

                }

                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    Name = "SkinIssueUpload.jpg",
                    CompressionQuality = 50,
                    SaveToAlbum = true
                });
            }
            catch (Exception)
            {
                return;
            }
            //    await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("Warning", "Picking  a photo is not supported", "OK");

            //    return;
            //}

            //_mediaFile = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            //{
            //    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
            //    CompressionQuality = 40
            //});

            //userImage.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

            //imageName.Text = System.IO.Path.GetFileName(_mediaFile.Path);

        }
        public async void SendData()
        {
            try
            {
                HttpClient client = new HttpClient();

                var url = Constants.postSkinIssue;
                var sampleurl = "http://192.168.88.75:5000/newskinissue";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                if (_mediaFile != null)
                {
                    var file = _mediaFile.Path;
                    if (string.IsNullOrEmpty(file) == false)
                    {
                        var upfilebytes = System.IO.File.ReadAllBytes(file);
                        MultipartFormDataContent content = new MultipartFormDataContent();
                        ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                        SkinIssuesQuestionAndAnswer queAndAnswer;
                        var name = System.IO.Path.GetFileName(file);
                        baContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/" + System.IO.Path.GetExtension(name).Remove(0, 1));
                        baContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                        {
                            Name = "files",
                            FileName = name,

                        };

                        //var categorynew = new List<string>();
                        //categorynew.Add(((Categorypicker.SelectedItem as CategoriesModel).category));
                        //                var categoryArray = categorynew.ToArray();
                        //var jsoncategoryArray = JsonConvert.SerializeObject(categoryArray);
                        content.Add(baContent, "files", name);
                        //new QuestionAndAnswer(question1.Text, _answer1),
                        content.Add(new StringContent(answer1.Text), question1.Text);
                        content.Add(new StringContent(_answer2), question2.Text);
                        content.Add(new StringContent(_answer3), question3.Text);
                        content.Add(new StringContent(answer4.Text), question4.Text);
                        content.Add(new StringContent(_answer5), question5.Text);
                        content.Add(new StringContent(_answer6), question6.Text);
                        content.Add(new StringContent(_answer7), question7.Text);
                        content.Add(new StringContent(_answer8), question8.Text);
                        content.Add(new StringContent(_answer9), question9.Text);
                        content.Add(new StringContent(_answer10), question10.Text);
                        //content.Add(new StringContent(_answer11), question11.Text);
                        content.Add(new StringContent(_answer12), question12.Text);
                        content.Add(new StringContent(answer13.Text), question13.Text);
                        content.Add(new StringContent(_answer14), question14.Text);
                        //content.Add(new StringContent(jsoncategoryArray),"category");


                        var response = await client.PostAsync(url, content);
                        //if (response.IsSuccessStatusCode)
                        //{
                        //    //actindicator.IsVisible = false;
                        //    //actindicator.IsRunning = false;
                        //    //await DisplayAlert("Success", "Skin Issue" + "Created Successful", "ok");
                        //    //await Shell.Current.Navigation.PopModalAsync();

                        //}

                    }



                }

            }
            catch (Exception)
            {
                return;
            }
           
                answer1.Text = "";
                answer2.SelectedIndex = -1; 
                answer3.SelectedIndex = -1; 
                answer4.Text = "";
                answer5.SelectedIndex = -1;
                answer6.SelectedIndex = -1;
                answer7.SelectedIndex = -1;
                answer8.SelectedIndex = -1;
                answer9.SelectedIndex = -1;
                answer10.SelectedIndex = -1;
                //answer11.SelectedIndex = -1;
                answer12.SelectedIndex = -1;
                answer13.Text = "";
                answer14.SelectedIndex = -1;
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

        private void OnPickerSelected14(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            _answer14 = selectedItem.ToString();// This is the model selected in the picker
        }



    }
}