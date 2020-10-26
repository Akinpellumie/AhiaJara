using AhiaJara.ViewModels;
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
    public partial class OrderPage : ContentPage
    {
        //ProductViewModel ProductViewModel;
        OrdersViewModel ordersViewModel;
        public OrderPage()
        {
            ordersViewModel = new OrdersViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = ordersViewModel;
        }

    }
}