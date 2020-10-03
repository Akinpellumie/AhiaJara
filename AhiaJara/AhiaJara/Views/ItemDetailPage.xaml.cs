using System.ComponentModel;
using Xamarin.Forms;
using AhiaJara.ViewModels;

namespace AhiaJara.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}