using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.Utils;
using AhiaJara.ViewModel;
using AhiaJara.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
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
            //GetCarts();
            NavigateToDetailPageCommand = new Command<ProductModel>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            CallAddToCartPopUpCommand = new Command<ProductModel>(async (model) => await ExecuteCallPopUpCommand());
            NavigateToCheckOutCommand = new Command<ProductModel>(async (model) => await ExecuteCheckOutCommand(model));
            NavigateToCartPageCommand = new Command(async => CartPage_Clicked());
            PlusBtnCommand = new Command(PlusBtn_Clicked);
            MinusBtnCommand = new Command(MinusBtn_Clicked);
            TextChangedCommand = new Command<TextChangedEventArgs>(textChanged => Entry_TextChangedCommand(textChanged));
        }

        #region Properties
        public bool IsBusy { get; set; }
        public Command NavigateToDetailPageCommand { get; }
        public Command PlusBtnCommand { get; }
        public Command MinusBtnCommand { get; }
        public Command TextChangedCommand { get; }
        public Command NavigateToCartPageCommand { get; }
        public Command CallAddToCartPopUpCommand { get; }
        public Command NavigateToCheckOutCommand{get; }
        
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
        ProductModel productModel;
        private ObservableCollection<ProductModel> productModelList;
        public ObservableCollection<ProductModel> ProductModelList
        {
            get => productModelList;
            set
            {
                productModelList = value;
                OnPropertyChanged(nameof(ProductModelList));

            }
        }

        private ObservableCollection<CartItemDetails> cartModelList;
        public ObservableCollection<CartItemDetails> CartModelList
        {
            get => cartModelList;
            set
            {
                cartModelList = value;
                OnPropertyChanged(nameof(CartModelList));

            }
        }
        //Product productModel;
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

        public async void GetProducts()
        {
            //productModelList = new ObservableCollection<Product>();
            //productModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, quantity = "2" });
            //productModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10000", Status = "completed", Date = "2, September, 2020", OrderId = 2133453, quantity = "1" });
            //productModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", price = "22000", Status = "pending", Date = "22, September, 2020", OrderId = 2133558, quantity = "2" });
            //productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProo", price = "39999", Status = "completed", Date = "22, September, 2020", OrderId = 2133563, quantity = "2" });
            //productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProd", price = "5000", Status = "completed", Date = "22, September, 2020", OrderId = 2133514, quantity = "2" });
            //productModelList.Add(new Product { Name = "FreshMe Cream", Image = "ListPro.png", price = "2000", Status = "pending", Date = "22, September, 2020", OrderId = 2133578, quantity = "2" });


            if (Constants.ProductsList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var dashboardEndpoint = Constants.AllProductsUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(Constants.AllProductsUrl);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                ProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                Constants.ProductsList = ProductsList;
                //IsBusy = false;
            }
            else
            {
                ProductModelList = new ObservableCollection<ProductModel>(Constants.ProductsList);
            }

        }

        public async void GetCarts()
        {
            cartModelList = new ObservableCollection<CartItemDetails>();
            IList<CartItemDetails> deliveredTaskModel = new List<CartItemDetails>();
            var cartItems = new CartItemDetails();
            //cartModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, quantity = "2" });
            //cartModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10000", Status = "completed", Date = "2, September, 2020", OrderId = 2133453, quantity = "1" });
            //cartModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", price = "22000", Status = "pending", Date = "22, September, 2020", OrderId = 2133558, quantity = "2" });
            if (Constants.CartItemList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var cartEndpoint = Constants.GetCart + Settings.id;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(cartEndpoint);
                //var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                //var CartList=JsonConvert.DeserializeObject<List<CartClass>>(result);
                //var items = CartList[0].cartDetails;
                var CartList = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                //CartList Cartlist = JsonConvert.DeserializeObject<CartList>(result);
                //CartDetails cartdetails = Cartlist.cartDetails[0];
                //CartDetails cartdetails2 = Cartlist.cartDetails[1];

                //foreach (var value1 in Cartlist)
                //{
                    //Console.WriteLine(value1.cartDetails);
                    //Console.WriteLine(value1.productDetails);

                    
                    //cartItems.productId = value1.cartDetails.productId;
                    //cartItems.userId = value1.cartDetails.userId;
                    //cartItems.quantitySelected = value1.cartDetails.quantitySelected;
                    //cartItems.id = value1.cartDetails.id;
                    //cartItems.name = value1.productDetails.name;
                    //cartItems.imgUrl = value1.productDetails.imgUrl;
                    //cartItems.quantityAvailable = value1.productDetails.quantityAvailable;
                    //cartItems.price = value1.productDetails.price;
                    //cartItems.category = value1.productDetails.category;
                    //cartItems.description = value1.productDetails.description;

                    //deliveredTaskModel.Add(cartItems);

               // }
                //CartModelList = new ObservableCollection<CartItemDetails>(cartItems);
                //Constants.CartItemList = CartList;
                IsBusy = false;
            }
            else
            {
               // CartModelList = new ObservableCollection<CartList>(Constants.CartItemList);
            }
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

        //#region realData

        //public async void GetAllProducts()
        //{
           
        //}
        //#endregion

        #region Navigations
        private async Task ExecuteNavigateToDetailPageCommand(ProductModel model)
        {
            
            await Navigation.PushAsync(new DetailPage(model));
            
        }

        private async Task ExecuteCheckOutCommand(ProductModel model)
        {
            //model.quantity = Text;
            Constants.cartCount = Text;
            await Navigation.PushAsync(new CheckOutPage(model));
            
        }

        public async Task CartPage_Clicked()
        {
            var txt = Text;
            Constants.cartCount = Text;
            await Navigation.PushAsync(new CartPage());
        }

        

        private async Task ExecuteCallPopUpCommand()
        {
            //IsBusy = true;
            var txt = Text;
            //var productModel = model;
            var cartData = new AddCartItem()
            {

                productId = DetailPage.newProductModel.id,
                userId = Settings.id,
                quantitySelected = txt.ToString()

            };

            if(cartData != null)
            {
                HttpClient client = new HttpClient();
                var url = Constants.AddToCart;
              
                var json = JsonConvert.SerializeObject(cartData);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent item = new StringContent(json);
                item.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var response = client.PostAsync(url, item);
                var result = response.GetAwaiter().GetResult();

                if (response.Result.IsSuccessStatusCode)
                {
                    //IsBusy = false;
                    ToolbarViewModel toolbarView = new ToolbarViewModel();
                    await toolbarView.GetCartCount();
                    await PopupNavigation.Instance.PushAsync(new AddToCartPop(txt));
                }
                
            }
            
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
            Constants.cartCount = Text;
            var productCount = new ProductModel();
            productCount.quantity = Constants.cartCount;
        }

        private void PlusBtn_Clicked()
        {
            Text++;
            Constants.cartCount = Text;
            var productCount = new ProductModel();
            productCount.quantity = Constants.cartCount;
        }
        #endregion
    }
}
