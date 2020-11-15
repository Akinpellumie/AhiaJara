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
            
            InitializeComponent();
            ordersViewModel = new OrdersViewModel(Navigation);
            this.BindingContext = ordersViewModel;

            MessagingCenter.Subscribe<OrdersViewModel>(this, "MarkedCompleted", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => { DisplayAlert("Success", "Order Completed ", "Ok"); });
                
            });

            MessagingCenter.Subscribe<OrdersViewModel>(this, "NotMarkedComplete", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => { DisplayAlert("Not Dispatched", "This order cannot be marked Completed ", "Ok"); });
                
            });
            MessagingCenter.Subscribe<OrdersViewModel>(this, "checkInternet", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => { DisplayAlert("Network Failure", "We are having problem connecting to the server", "Try Again"); });

            });
        }

    }
}