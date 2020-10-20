using AhiaJara.Models;
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
    public partial class CartToolBar : ContentView
    {
        Product productModel;
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
           nameof(Title),
           typeof(string),
           typeof(CartToolBar),
           string.Empty);
        public CartToolBar()
        {
            InitializeComponent();
            BindingContext = new ToolbarViewModel();
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

    }
}