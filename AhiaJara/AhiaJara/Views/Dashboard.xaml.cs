using AhiaJara.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        ProductViewModel ProductViewModel;
        public Dashboard()
        {
            ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = ProductViewModel;
        }

    }
}