using Plugin.FilePicker;
using Plugin.FileUploader.Abstractions;
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
    public partial class ProfilePage : ContentPage
    {
        string filename;
        FileBytesItem bfitem;
        private string fileName;
        public ProfilePage()
        {
            InitializeComponent();
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
    }
}