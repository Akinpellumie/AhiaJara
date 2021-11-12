using AhiaJara.Helpers;
using AhiaJara.PopUps;
using Plugin.FileUploader.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            ShowUserDetailsAsync();
        }

        public async void CallPrfUploadAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
                // canceled
                if (photo == null)
                {
                    return;
                }
                else
                {
                    // save the file into local storage
                    var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(newFile))
                        await stream.CopyToAsync(newStream);

                    userImagePro.Source = newFile;
                    backgrndImg.Source = newFile;
                    //remove old picture if available
                    bool rem = SecureStorage.Remove("ProfileImage");

                    //set new picture
                    await SecureStorage.SetAsync("ProfileImage", newFile);
                    await DisplayAlert("Success", "Profile image saved successfully", "Ok");

                }
                //var file2 = await CrossFilePicker.Current.PickFile();
                //set new picture

                //bfitem = new FileBytesItem("fileName", file2.DataArray, file2.FileName);

                //FilePathItem fpitem = new FilePathItem("fileName", file2.FilePath);
                //if (file2 != null)
                //{
                //    filename = file2.FilePath;
                //    HttpClient client = new HttpClient();
                //    MultipartFormDataContent content = new MultipartFormDataContent();
                //    if (file2 != null)
                //    {
                //        if (string.IsNullOrEmpty(filename) == false)
                //        {
                //            await PopupNavigation.Instance.PushAsync(new UploadImagePopup());
                //            var upfilebytes = System.IO.File.ReadAllBytes(filename);

                //            ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                //            var name = System.IO.Path.GetFileName(filename);
                //            baContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/" + System.IO.Path.GetExtension(name).Remove(0, 1));
                //            baContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                //            {
                //                Name = "files",
                //                FileName = name
                //            };
                //            content.Add(baContent, "files", name);

                //            //var httpClient = new HttpClient();
                //            var updateImageUrl = Constants.uploadImage + Settings.id;


                //            var finalresponse = await client.PutAsync(updateImageUrl, content);
                //            await PopupNavigation.Instance.PopAsync(true);
                //            if (finalresponse.IsSuccessStatusCode)
                //            {
                //                userImagePro.Source = ImageSource.FromStream(() => file2.GetStream());
                //                backgrndImg.Source = ImageSource.FromStream(() => file2.GetStream());
                //                await DisplayAlert("Image Uploaded", "Your Profile image has been updated successfully", "ok");
                //            }
                //            else
                //            {
                //                await DisplayAlert("Image Upload Failed", "Check your internet and try again later", "ok");
                //            }

                //        }
                //    }
                //}
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
                Console.WriteLine(fnsEx.Message);
                await DisplayAlert("Error", "Feature is not supported on the device", "Ok");
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
                Console.WriteLine(pEx.Message);
                await DisplayAlert("Error", "Permissions not granted", "Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
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

        private async Task ShowUserDetailsAsync()
        {
            fullName.Text = Settings.firstName + " " + Settings.lastName;
            phone.Text = Settings.phone;
            email.Text = Settings.email;
            var _userImage = await SecureStorage.GetAsync("ProfileImage");
            if (!string.IsNullOrEmpty(_userImage))
            {
                userImagePro.Source = _userImage;
                backgrndImg.Source = _userImage;
            }
        }
    }
}