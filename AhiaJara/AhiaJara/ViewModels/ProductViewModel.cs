using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.ViewModel;
using AhiaJara.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class ProductViewModel : BaseVM
    {

        public ProductViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetProducts();
            GetAdverts();
            NavigateToDetailPageCommand = new Command<Product>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            CallAddToCartPopUpCommand = new Command<Product>(async (model) => await ExecuteCallPopUpCommand());
            NavigateToCheckOutCommand = new Command<Product>(async (model) => await ExecuteCheckOutCommand(model));

        }

        #region Properties

        public Command NavigateToDetailPageCommand { get; }
        public Command CallAddToCartPopUpCommand { get; }
        public Command NavigateToCheckOutCommand{get; }
        private ObservableCollection<Product> productModelList;
        public ObservableCollection<Product> ProductModelList
        {
            get => productModelList;
            set
            {
                productModelList = value;
                OnPropertyChanged(nameof(ProductModelList));

            }
        }

        private ObservableCollection<Product> carouselModelList;
        public ObservableCollection<Product> CarouselModelList
        {
            get => carouselModelList;
            set
            {
                carouselModelList = value;
                OnPropertyChanged(nameof(CarouselModelList));

            }
        }

        #endregion

        public void GetProducts()
        {
            productModelList = new ObservableCollection<Product>();
            productModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", Price = "NGN 6,999.00" });
            productModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", Price = "NGN 10,000.00" });
            productModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", Price = "NGN 22,000.00" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProo", Price = "NGN 3,999.99" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProd", Price = "NGN 5,000.00" });
            productModelList.Add(new Product { Name = "FreshMe Cream", Image = "ListPro.png", Price = "NGN 2,000.00" });

        }

        public void GetAdverts()
        {
            carouselModelList = new ObservableCollection<Product>();
            carouselModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "CaroPro", Price = "NGN 6,999.00" });
            carouselModelList.Add(new Product { Name = "FreshYo Soap", Image = "CaroProd", Price = "NGN 10,000.00" });
            carouselModelList.Add(new Product { Name = "Skin Tone", Image = "CaroProduct", Price = "NGN 22,000.00" });

        }

        #region Navigations
        private async Task ExecuteNavigateToDetailPageCommand(Product model)
        {
            await Navigation.PushAsync(new DetailPage(model));
        }

        private async Task ExecuteCheckOutCommand(Product model)
        {
            await Navigation.PushAsync(new CheckOutPage(model));
        }

        private async Task ExecuteCallPopUpCommand()
        {
            await PopupNavigation.Instance.PushAsync(new AddToCartPop());
        }
        #endregion
    }
}
