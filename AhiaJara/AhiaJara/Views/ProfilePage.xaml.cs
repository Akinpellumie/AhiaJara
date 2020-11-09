using AhiaJara.Helpers;
using Plugin.FilePicker;
using Plugin.FileUploader.Abstractions;
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
    public partial class ProfilePage : ContentPage
    {
        string filename;
        FileBytesItem bfitem;
        private string fileName;
        public ProfilePage()
        {
            InitializeComponent();
            ShowUserDetails();
        }

        public async void CallPrfUploadAsync(object sender, EventArgs e)
        {
            try
            {
                var file2 = await CrossFilePicker.Current.PickFile();

                bfitem = new FileBytesItem("fileName", file2.DataArray, file2.FileName);

                FilePathItem fpitem = new FilePathItem("fileName", file2.FilePath);

                userImagePro.Source = ImageSource.FromStream(() => file2.GetStream());
                backgrndImg.Source = ImageSource.FromStream(() => file2.GetStream());

                if (file2 != null)
                {
                    filename = file2.FilePath;
                    HttpClient client = new HttpClient();
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    if (file2 != null)
                    {
                        if (string.IsNullOrEmpty(filename) == false)
                        {
                            var upfilebytes = System.IO.File.ReadAllBytes(filename);

                            ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                            var name = System.IO.Path.GetFileName(filename);
                            baContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/" + System.IO.Path.GetExtension(name).Remove(0, 1));
                            baContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                            {
                                Name = "files",
                                FileName = name
                            };
                            content.Add(baContent, "files", name);

                            //var httpClient = new HttpClient();
                            var updateImageUrl = Constants.uploadImage + Settings.id;

                            var finalresponse = await client.PutAsync(updateImageUrl, content);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private async void ChangePass_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePassPage());
        }
        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void ShowUserDetails()
        {
            fullName.Text = Settings.firstName + " " + Settings.lastName;
            phone.Text = Settings.phone;
            email.Text = Settings.email;
        }
    }
}