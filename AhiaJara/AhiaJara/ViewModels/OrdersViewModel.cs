using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModel;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class OrdersViewModel : BaseVM
    {
        #region Properties

        public Command CompleteOrder { get; }
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
            //PlusBtnCommand = new Command(PlusBtn_Clicked);
            CompleteOrder = new Command<Orders>(async (model) => await CompleteOrder_Clicked(model)); ;
            //CompleteOrder = new Command<Orders>(async (model) => await CompleteOrder_Clicked(model));
            //CompleteOrder = new Command(() => CompleteOrder_Clicked());
        }

        private async Task CompleteOrder_Clicked(Orders order)
        {
            //await PopupNavigation.Instance.PushAsync(new PopLoader());
            await PopupNavigation.Instance.PushAsync(new PageLoader());
            var SelectedId = order.id;
            try
            {
                
                
                HttpClient client = new HttpClient();
                var url = Constants.postcompleteOrder + SelectedId;
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var content = new StringContent(SelectedId, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                //await PopupNavigation.Instance.PopAsync(true);
                if (result.IsSuccessStatusCode)
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    MessagingCenter.Send(this, "MarkedCompleted");
                }
                else
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    MessagingCenter.Send(this, "NotMarkedComplete");
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        #endregion

        private async void GetPendingOrders()
        {
            try
            {
                IsBusy = true;
                HttpClient client = new HttpClient();
                var url = Constants.getIncompleteOrder + Settings.id;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(url);
                List<Orders> IncompletedOrderList = JsonConvert.DeserializeObject<List<Orders>>(result);
                InCompleteOrders = new ObservableCollection<Orders>(IncompletedOrderList);
                IsBusy = false;
            }
            catch (Exception)
            {
                return;
            }
                  
            
        }

        private async void GetCompletedOrders()
        {
            IsBusy = true;
            HttpClient client = new HttpClient();
            var url = Constants.getcompletedOrder+Settings.id;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
            var result = await client.GetStringAsync(url);
            List<Orders> CompletedOrderList = JsonConvert.DeserializeObject<List<Orders>>(result);
            //var CompletedOrderList = JsonConvert.DeserializeObject<List<Orders>>(result);
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
