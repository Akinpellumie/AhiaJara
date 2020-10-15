using AhiaJara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkinIssueImagesView : ContentView
    {
        ProductViewModel ProductViewModel;
        public SkinIssueImagesView()
        {
            ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = ProductViewModel;
            //SkinIssue.LongClick += Control_Clicked;
            MessagingCenter.Subscribe<object>(this, "longClick", (sender) =>
            {
                // Do something whenever the "Hi" message is received
                Device.BeginInvokeOnMainThread(() =>
                {
                    
                });
            });

        }

        void Control_Clicked()
        {
            //SkinIssue.ge
        }
    }
}