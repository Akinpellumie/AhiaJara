using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class OrdersViewModel : BaseVM
    {
        #region Properties

        //public Command NavigateToDetailPageCommand { get; }
        private bool isBusy { get; set; }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));

            }
        }

        private ObservableCollection<Orders> completedOrders;
        public ObservableCollection<Orders> CompletedOrders
        {
            get => completedOrders;
            set
            {
                completedOrders = value;
                OnPropertyChanged(nameof(CompletedOrders));

            }
        }

        private ObservableCollection<Orders> inCompleteOrders;
        public ObservableCollection<Orders> InCompleteOrders
        {
            get => inCompleteOrders;
            set
            {
                inCompleteOrders = value;
                OnPropertyChanged(nameof(InCompleteOrders));

            }
        }

        #endregion

        #region constructor
        public OrdersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetCompletedOrders();
            GetPendingOrders();
        }
        #endregion

        private async void GetPendingOrders()
        {

                    IsBusy = true;
                    HttpClient client = new HttpClient();
                    var url = Constants.getIncompleteOrder+Settings.id;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    var result = await client.GetStringAsync(url);
                    var IncompletedOrderList = JsonConvert.DeserializeObject<List<Orders>>(result);
                    InCompleteOrders = new ObservableCollection<Orders>(IncompletedOrderList);
                    IsBusy = false;
            
        }

        private async void GetCompletedOrders()
        {
            IsBusy = true;
            HttpClient client = new HttpClient();
            var url = Constants.getcompletedOrder+Settings.id;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
            var result = await client.GetStringAsync(url);
            var CompletedOrderList = JsonConvert.DeserializeObject<List<Orders>>(result);
            CompletedOrders= new ObservableCollection<Orders>(CompletedOrderList);
            IsBusy = false;
        }

        private int _selectedViewModelIndex = 0;
        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set => SetAndRaise(ref _selectedViewModelIndex, value);
        }

    }
}
