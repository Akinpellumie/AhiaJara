using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.Utils;
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
            GetCarts();
            NavigateToDetailPageCommand = new Command<Product>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            CallAddToCartPopUpCommand = new Command<Product>(async (model) => await ExecuteCallPopUpCommand());
            NavigateToCheckOutCommand = new Command<Product>(async (model) => await ExecuteCheckOutCommand(model));
            NavigateToCartPageCommand = new Command(async => CartPage_Clicked());
            PlusBtnCommand = new Command(PlusBtn_Clicked);
            MinusBtnCommand = new Command(MinusBtn_Clicked);
            TextChangedCommand = new Command<TextChangedEventArgs>(textChanged => Entry_TextChangedCommand(textChanged));
        }

        #region Properties

        public Command NavigateToDetailPageCommand { get; }
        public Command PlusBtnCommand { get; }
        public Command MinusBtnCommand { get; }
        public Command TextChangedCommand { get; }
        public Command NavigateToCartPageCommand { get; }
        public Command CallAddToCartPopUpCommand { get; }
        public Command NavigateToCheckOutCommand{get; }
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
               propertyName: "Text",
                returnType: typeof(int),
                declaringType: typeof(CustomStepperView),
                defaultValue: 1,
                defaultBindingMode: BindingMode.TwoWay);

        private int text = 1;
        public int Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }

        }
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

        private ObservableCollection<Product> cartModelList;
        public ObservableCollection<Product> CartModelList
        {
            get => cartModelList;
            set
            {
                cartModelList = value;
                OnPropertyChanged(nameof(CartModelList));

            }
        }
        Product productModel;
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

        private int _selectedViewModelIndex = 0;
        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set => SetAndRaise(ref _selectedViewModelIndex, value);
        }

        private ObservableCollection<Product> orderModelList;
        public ObservableCollection<Product> OrderModelList
        {
            get => orderModelList;
            set
            {
                orderModelList = value;
                OnPropertyChanged(nameof(OrderModelList));

            }
        }

        #endregion

        public void GetProducts()
        {
            productModelList = new ObservableCollection<Product>();
            productModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, quantity = "2" });
            productModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10000", Status = "completed", Date = "2, September, 2020", OrderId = 2133453, quantity = "1" });
            productModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", price = "22000", Status = "pending", Date = "22, September, 2020", OrderId = 2133558, quantity = "2" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProo", price = "39999", Status = "completed", Date = "22, September, 2020", OrderId = 2133563, quantity = "2" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProd", price = "5000", Status = "completed", Date = "22, September, 2020", OrderId = 2133514, quantity = "2" });
            productModelList.Add(new Product { Name = "FreshMe Cream", Image = "ListPro.png", price = "2000", Status = "pending", Date = "22, September, 2020", OrderId = 2133578, quantity = "2" });

        }

        public void GetCarts()
        {
            cartModelList = new ObservableCollection<Product>();
            cartModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, quantity = "2" });
            cartModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10000", Status = "completed", Date = "2, September, 2020", OrderId = 2133453, quantity = "1" });
            cartModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", price = "22000", Status = "pending", Date = "22, September, 2020", OrderId = 2133558, quantity = "2" });

        }

        public void GetAdverts()
        {
            carouselModelList = new ObservableCollection<Product>();
            carouselModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "CaroPro", price = "6999" });
            carouselModelList.Add(new Product { Name = "FreshYo Soap", Image = "CaroProd", price = "10000" });
            carouselModelList.Add(new Product { Name = "Skin Tone", Image = "CaroProduct", price = "22000" });

        }

        public void GetOrders()
        {
            orderModelList = new ObservableCollection<Product>();
            orderModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, Quantity = "2" });
            orderModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10,000", Status = "completed", Date = "15, September, 2020", OrderId = 2133786, Quantity = "1" });
            orderModelList.Add(new Product { Name = "Skin Tone", Image = "ListProd", price = "22000", Status = "completed", Date = "25, August, 2020", OrderId = 2135648, Quantity = "3" });
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

        public async Task CartPage_Clicked()
        {
            var txt = Text;
            await Navigation.PushAsync(new CartPage());
        }

        private async Task ExecuteCallPopUpCommand()
        {
            var txt = Text;
            await PopupNavigation.Instance.PushAsync(new AddToCartPop(txt));
        }

        private void Entry_TextChangedCommand(TextChangedEventArgs textChanged)
        {
            if (!string.IsNullOrEmpty(textChanged.NewTextValue))
                this.Text = int.Parse(textChanged.NewTextValue);
        }

        private void MinusBtn_Clicked()
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked()
        {
            Text++;
        }
        #endregion
    }
}
