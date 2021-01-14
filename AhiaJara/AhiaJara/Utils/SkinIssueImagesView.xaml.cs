using AhiaJara.Models;
using AhiaJara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkinIssueImagesView : ContentView
    {
        ProductViewModel productViewModel;
        public SkinIssueImagesView()
        {
            productViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = productViewModel;
            //SkinIssue.ItemSelected += productViewModel.SelectedImageCommand;
            //SkinIssue.LongClick += Control_Clicked;
            MessagingCenter.Subscribe<object>(this, "longClick", (sender) =>
            {
                // Do something whenever the "Hi" message is received
                Device.BeginInvokeOnMainThread(() =>
                {
                    
                });
            });

        }

        //public void Control_Clicked(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null) return;
        //    var selectedItem = e.Item as ProductModel;

        //    //MyPanView.BackgroundColor = Color.FromHex("4DC503");
        //}

        //private void SkinIssue_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ProductModel selected = e.SelectedItem as ProductModel;
        //    selected.FirstFrameBackColor = Color.FromHex("4DC503");
        //    OnPropertyChanged();
        //}

        //public void PickUser_Clicked(Object Sender, EventArgs args)
        //{
        //    ImageButton button = (ImageButton)Sender;

        //    var Selecteduser = button.CommandParameter as ProductModel;

        //    if (SkinIssue. .Source == ImageSource.FromFile("uncheck.png"))
        //    {
        //        checkBtn.Source = ImageSource.FromFile("check.png");
        //    }
        //    else if(checkBtn.Source == ImageSource.FromFile("check.png"))
        //    {
        //        checkBtn.Source = ImageSource.FromFile("uncheck.png");
        //    }
        //    //Helper.listUserA.Add(Selecteduser);
        //    //PopupNavigation.Instance.PushAsync(new AssetQtyPopUp());
        //    //MessagingCenter.Subscribe<Models.Data>(this, "PopUpData", (value) =>
        //    //{

        //    //    var index = Helper.listUserA.Count - 1;
        //    //    Helper.listAssetA[index].Quantity = value.Quantity;

        //    //});

        //}
    }
}