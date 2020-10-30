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
using System.Linq;
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
            GetCarts();
            GetLatestProducts();
            GetHairProducts();
            GetSkinProducts();
            NavigateToDetailPageCommand = new Command<ProductModel>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            CallAddToCartPopUpCommand = new Command<ProductModel>(async (model) => await ExecuteCallPopUpCommand());
            NavigateToCheckOutCommand = new Command<ProductModel>(async (model) => await ExecuteCheckOutCommand(model));
            NavigateToCartPageCommand = new Command<Cart>(async(model) => await CartPage_Clicked(model));
            SelectedImageCommand = new Command<ProductModel>(model => CardImage_SelectionChanged(model));
            PlusBtnCommand = new Command(PlusBtn_Clicked);
            MinusBtnCommand = new Command(MinusBtn_Clicked);
            LongClickedCommand = new Command(LongClicked);
            TextChangedCommand = new Command<TextChangedEventArgs>(textChanged => Entry_TextChangedCommand(textChanged));
        }

        #region Properties
        public bool IsBusy { get; set; }
        public Command NavigateToDetailPageCommand { get; }
        public Command LongClickedCommand { get; }
        public Command PlusBtnCommand { get; }
        public Command MinusBtnCommand { get; }
        public Command TextChangedCommand { get; }
        public Command SelectedImageCommand { get; }
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

        private Color firstFrameBackColor;
        public Color FirstFrameBackColor
        {
            get => firstFrameBackColor;
            set
            {
                firstFrameBackColor = value;
                OnPropertyChanged(nameof(FirstFrameBackColor));
            }
        }

        private Color secondFrameBackColor;
        public Color SecondFrameBackColor
        {
            set
            {
                if (secondFrameBackColor != value)
                {
                    secondFrameBackColor = value;
                    OnPropertyChanged(nameof(SecondFrameBackColor));
                }
            }
            get => secondFrameBackColor;
        }
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


        private ObservableCollection<ProductModel> hairProductModelList;
        public ObservableCollection<ProductModel> HairProductModelList
        {
            get => HairProductModelList;
            set
            {
                hairProductModelList = value;
                OnPropertyChanged(nameof(HairProductModelList));

            }
        }

        public ObservableCollection<ProductModel> SkinProductModelList
        {
            get => productModelList;
            set
            {
                productModelList = value;
                OnPropertyChanged(nameof(SkinProductModelList));

            }
        }

        private ObservableCollection<ProductModel> latestProductModelList;
        public ObservableCollection<ProductModel> LatestProductModelList
        {
            get => latestProductModelList;
            set
            {
                latestProductModelList = value;
                OnPropertyChanged(nameof(LatestProductModelList));

            }
        }

        private ObservableCollection<Cart> cartModelList;
        public ObservableCollection<Cart> CartModelList
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

        int Count = 0;
        short Counter = 0;
        int SlidePosition = 0;

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

        public async void GetHairProducts()
        {
            if (Constants.ProductsList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var url = Constants.getHairProducts;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(url);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                HairProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                Constants.HairProductsList = ProductsList;
                //IsBusy = false;
            }
            else
            {
                HairProductModelList = new ObservableCollection<ProductModel>(Constants.ProductsList);
            }
        }

        public async void GetSkinProducts()
        {
            if (Constants.ProductsList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var url = Constants.getSkinProducts;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(url);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                SkinProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                Constants.HairProductsList = ProductsList;
                //IsBusy = false;
            }
            else
            {
                SkinProductModelList = new ObservableCollection<ProductModel>(Constants.ProductsList);
            }
        }

        public async void GetLatestProducts()
        {

            if (Constants.LatestProductsList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var url = Constants.LatestProductsUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(url);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                LatestProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                Constants.LatestProductsList = ProductsList;
                //IsBusy = false;
            }
            else
            {
                LatestProductModelList = new ObservableCollection<ProductModel>(Constants.LatestProductsList);
            }

        }

        public async void GetCarts()
        {
            cartModelList = new ObservableCollection<Cart>();
            var cartItems = new Cart();
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
                var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                CartModelList = new ObservableCollection<Cart>(CartList);
               
                IsBusy = false;
            }
            else
            {
               CartModelList = new ObservableCollection<Cart>(Constants.CartItemList);
            }
        }

        public async void GetAdverts()
        {
            //carouselModelList = new ObservableCollection<Product>();
            //carouselModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "CaroPro", price = "6999" });
            //carouselModelList.Add(new Product { Name = "FreshYo Soap", Image = "CaroProd", price = "10000" });
            //carouselModelList.Add(new Product { Name = "Skin Tone", Image = "CaroProduct", price = "22000" });
            if (CarouselModelList == null)
            {
                //IsBusy = true;
                HttpClient client = new HttpClient();
                var carouselEndpoint = Constants.GetAdverts;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(carouselEndpoint);
                var CartList = JsonConvert.DeserializeObject<List<Product>>(result);
                CarouselModelList = new ObservableCollection<Product>(CartList);

                Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                {
                    SlidePosition++;
                    if (SlidePosition == CarouselModelList.Count) SlidePosition = 0;
                    //cv.Position = SlidePosition;
                    return true;
                });


                IsBusy = false;
            }
            else
            {
                carouselModelList = new ObservableCollection<Product>(Constants.CarouselItemList);
            }

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

        void LongClicked()
        {
            MessagingCenter.Send(this, "longClick");
            //MessagingCenter.Send<MainPage>(this, "Hi");
        }
        private async Task ExecuteCheckOutCommand(ProductModel model)
        {
            //model.quantity = Text;
            Constants.cartCount = Text;
            await Navigation.PushAsync(new CheckOutPage(model));
            
        }

        public async Task CartPage_Clicked(Cart model)
        {
            var txt = Text;
            Constants.cartCount = Text;
            await Navigation.PushAsync(new CartPage(model));
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
                quantitySelected = txt,
                productName = DetailPage.newProductModel.name,
                productImgUrl = DetailPage.newProductModel.imgUrl,
                productPrice = DetailPage.newProductModel.price,
                productCategory = DetailPage.newProductModel.category,
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

        private void CardImage_SelectionChanged(ProductModel model)
        {

            model.FirstFrameBackColor = Color.FromHex("4DC503");
            //ProductModel previous = model.la as ProductModel;
            //ProductModel current = (eve.CurrentSelection.FirstOrDefault() as ProductModel);

            ////Set the current to the color you want
            //current.FirstFrameBackColor = Color.Pink;
            //current.SecondFrameBackColor = Color.Green;

            //if (previous != null)
            //{
            //    //Reset the previous to defaulr color
            //    previous.FirstFrameBackColor = Color.White;
            //    previous.SecondFrameBackColor = Color.Purple;
            //}

        }
        #endregion
    }
}
