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
    public partial class ProductListView : ContentView
    {
        ProductViewModel ProductViewModel;
        public ProductListView()
        {
            ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = ProductViewModel;
        }
    }
}