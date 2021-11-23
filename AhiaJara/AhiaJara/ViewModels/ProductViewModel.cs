using AhiaJara.Helpers;
using AhiaJara.Models;
using AhiaJara.PopUps;
using AhiaJara.Utils;
using AhiaJara.ViewModel;
using AhiaJara.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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
            SearchResultPro();
            GetLatestProducts();
            GetHairProducts();
            GetSkinProducts();
            GetSkinIssues();
            NavigateToDetailPageCommand = new Command<ProductModel>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            NavigateToRecommendedPageCommand = new Command<SkinIssue>(model => ExecuteNavigateToRecommendedPageCommand());
            CallAddToCartPopUpCommand = new Command<ProductModel>(async (model) => await ExecuteCallPopUpCommand());
            NavigateToCheckOutCommand = new Command<ProductModel>(async (model) => await ExecuteCheckOutCommand(model));
            NavigateToCartPageCommand = new Command<Cart>(async(model) => await CartPage_Clicked(model));
            //SelectedImageCommand = new Command<ProductModel>(model => CardImage_SelectionChanged(model));
            SelectedImageCommand = new Command<SkinIssue>(model => CardImage_SelectionChanged1(model));
            PlusBtnCommand = new Command(PlusBtn_Clicked);
            SearchCommand = new Command<TextChangedEventArgs>(textChanged => SearchBar_TextChanged(textChanged));
            MinusBtnCommand = new Command(MinusBtn_Clicked);
            LongClickedCommand = new Command(LongClicked);
            TextChangedCommand = new Command<TextChangedEventArgs>(textChanged => Entry_TextChangedCommand(textChanged));
            RemoveItem = new Command<Cart>(async (model) => await RemoveItem_Clicked(model)); ;

            ItemTappedCommand = new Command((obj) => {

                //reset the bg color 
                foreach (var model in SkinIssueList)
                {
                    model.BGColor = Color.White;
                    model.IsChecked = false;
                }

                SkinIssue mo = obj as SkinIssue;
                int index = SkinIssueList.IndexOf(mo);
                mo.BGColor = Color.FromHex("4DC503");
                mo.IsChecked = true;

                SkinIssueList.RemoveAt(index);
                SkinIssueList.Insert(index, mo);

                Constants.skinIssue = mo;

            });
        }

        

        public ProductViewModel()
        {
        }

        #region Properties
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
        private bool isVisible { get; set; }
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));

            }
        }
        public Command NavigateToDetailPageCommand { get; }
        public Command RemoveItem { get; }
        public Command SearchCommand { get; }
        public Command LongClickedCommand { get; }
        public Command PlusBtnCommand { get; }
        public Command MinusBtnCommand { get; }
        public Command ItemTappedCommand { get; set; }
        public Command TextChangedCommand { get; }
        public Command SelectedImageCommand { get; }
        public Command NavigateToCartPageCommand { get; }
        public Command CallAddToCartPopUpCommand { get; }
        public Command NavigateToCheckOutCommand{get; }

        public Command NavigateToRecommendedPageCommand { get; }

        private string total;
        public string Total
        {
            get => total;
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
            }

        }

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

        private ObservableCollection<ProductModel> searchData;
        public ObservableCollection<ProductModel> SearchData
        {
            get => searchData;
            set
            {
                searchData = value;
                OnPropertyChanged(nameof(SearchData));

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
            get => hairProductModelList;
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

        public ObservableCollection<SkinIssue> skinIssueList;
        public ObservableCollection<SkinIssue> SkinIssueList
        {
            get => skinIssueList;
            set
            {
                skinIssueList = value;
                OnPropertyChanged(nameof(SkinIssueList));

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

            try
            {
                if (Constants.ProductsList == null)
                {
                    IsBusy = true;
                    HttpClient client = new HttpClient();
                    var dashboardEndpoint = Constants.AllProductsUrl;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    var result = await client.GetStringAsync(Constants.AllProductsUrl);
                    var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                    ProductModelList = new ObservableCollection<ProductModel>(ProductsList);
                    Constants.ProductsList = ProductsList;
                    IsBusy = false;
                }
                else
                {
                    ProductModelList = new ObservableCollection<ProductModel>(Constants.ProductsList);
                    SearchData = ProductModelList;
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        public async void SearchResultPro()
        {

            try
            {
                IsBusy = true;
                HttpClient client = new HttpClient();
                var dashboardEndpoint = Constants.AllProductsUrl;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(Constants.AllProductsUrl);
                var ProductsList = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                SearchData = new ObservableCollection<ProductModel>(ProductsList);
                //Constants.ProductsList = ProductsList;
                IsBusy = false;
                
            }
            catch (Exception)
            {
                return;
            }
        }

        public async void GetHairProducts()
        {

            try
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
            catch (Exception)
            {
                return;
            }
           
        }

        public async void GetSkinProducts()
        {
            try
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
                    Constants.SkinProductsList = ProductsList;
                    //IsBusy = false;
                }
                else
                {
                    SkinProductModelList = new ObservableCollection<ProductModel>(Constants.ProductsList);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public async void GetLatestProducts()
        {
            try
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
            catch (Exception)
            {
                return;
            }
            

        }

        public async void GetCarts()
        {
            // await PopupNavigation.Instance.PushAsync(new PageLoader());

            cartModelList = new ObservableCollection<Cart>();
            var cartItems = new Cart();
            //cartModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", price = "6999", Status = "pending", Date = "22, September, 2020", OrderId = 2133546, quantity = "2" });
            //cartModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", price = "10000", Status = "completed", Date = "2, September, 2020", OrderId = 2133453, quantity = "1" });
            //cartModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", price = "22000", Status = "pending", Date = "22, September, 2020", OrderId = 2133558, quantity = "2" });
            try
            {

               IsBusy = true;
                    HttpClient client = new HttpClient();
                    var cartEndpoint = Constants.GetCart + Settings.id;

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                    var result = await client.GetStringAsync(cartEndpoint);
                    var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                    ArrayList arr = new ArrayList();
                    foreach (var cart in CartList)
                    {
                        int thePrice = Int32.Parse(cart.productPrice);
                        int qty = cart.quantitySelected;
                        int item = thePrice * qty;
                        cart.SingleProductPrice = item;
                        arr.Add(item);

                    }
                    int ourSum = arr.Cast<int>().Sum();
                    int meee = ourSum;
                    Settings.CartTotalPrice = meee;
                    string productTotal = meee.ToString();
                    var pel = Math.Round(Convert.ToDouble(productTotal), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                    Total = pel;
                    MessagingCenter.Send<object, string>(this, "totalPrice", Total);
                    CartModelList = new ObservableCollection<Cart>(CartList);
                    Constants.CartItemList = CartList;
                    IsBusy = false;

                
                //await PopupNavigation.Instance.PopAsync(true);

            }
            catch (Exception)
            {
                return;
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
                try
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
                catch (Exception)
                {
                    return;
                }
               
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

        public async void GetSkinIssues()
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = Constants.getSkinIssue;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.GetStringAsync(url);
                var fetch = JsonConvert.DeserializeObject<List<SkinIssue>>(result);
                SkinIssueList = new ObservableCollection<SkinIssue>(fetch);
                var fileList = fetch.First(); // here we have a single FileList object
                //var test2 = fetch.f
                //var test = fileList.recommendedProducts;
                //var CartList = JsonConvert.DeserializeObject<List<Cart>>(result);
                //CartModelList = new ObservableCollection<Cart>(CartList);



            }
            catch (Exception)
            {
                return;
            }
        }

        private async Task RemoveItem_Clicked(Cart model)
        {
           
                
                
            var SelectedId = model.id;
            var itemToRemove = Constants.CartItemList.Single(r => r.id == SelectedId);
            Constants.CartItemList.Remove(itemToRemove);
            
            try
            {
                HttpClient client = new HttpClient();
                var url = Constants.deleteCartItem + SelectedId;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
                var result = await client.DeleteAsync(url);
                var x = result.StatusCode;
                GetCarts();
            }
            catch(Exception)
            {

            }
           
        }

        //#region realData

        //public async void GetAllProducts()
        //{

        //}
        //#endregion

        #region Navigations
        private async Task ExecuteNavigateToDetailPageCommand([Optional] ProductModel model)
        {
            
            await Navigation.PushAsync(new DetailPage(model));
            
        }

        private async void ExecuteNavigateToRecommendedPageCommand()
        {
            var rootdir = SkinIssueReviewPage.newSkinIssue.recommendedProductId;
            ProductModel productModel = new ProductModel()
            {
                quantityAvailable = rootdir.quantityAvailable,
                Name = rootdir.name,
                imgUrl = rootdir.imgUrl,
                price = rootdir.price,
                category = rootdir.category,
                description = rootdir.description,
                createdAt = rootdir.createdAt,
                updatedAt = rootdir.updatedAt,
                id = rootdir._id,
            };

            await Navigation.PushAsync(new DetailPage(productModel));

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
            await PopupNavigation.Instance.PushAsync(new PageLoader());

            //IsBusy = true;
            var txt = Text;
            //var productModel = model;
            var cartData = new AddCartItem()
            {
                productId = DetailPage.newProductModel.id,
                userId = Settings.id,
                quantitySelected = txt,
                productName = DetailPage.newProductModel.Name,
                productImgUrl = DetailPage.newProductModel.imgUrl,
                productPrice = DetailPage.newProductModel.price,
                productCategory = DetailPage.newProductModel.category,
            };

            if(cartData != null)
            {
                try
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
                        await PopupNavigation.Instance.PopAsync(true);
                        await PopupNavigation.Instance.PushAsync(new AddToCartPop(txt));
                        await Navigation.PushAsync(new SkinIssuePage());
                    }
                }
                catch (Exception ex)
                {

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


        private async void CardImage_SelectionChanged1(SkinIssue model)
        {

            await PopupNavigation.Instance.PushAsync(new PopLoader());
            await Task.Delay(6000);
            await PopupNavigation.Instance.PopAsync(true);
            await Navigation.PushAsync(new SkinIssueReviewPage(model));
            //var descr = model.description;

        }

        private void SearchBar_TextChanged(TextChangedEventArgs textChanged)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(textChanged.NewTextValue))
            {
                SearchData = ProductModelList;
                IsVisible = false;
            }
            else
            {
                //SearchData = (ObservableCollection<BankList>)BankData.Where(x => x.Name.Contains(textChanged.NewTextValue));
                IsVisible = true;
                SearchData = (ObservableCollection<ProductModel>)ProductModelList.Where(x => x.Name.Contains(textChanged.NewTextValue, StringComparison.OrdinalIgnoreCase));
            }
        }
        #endregion
    }
}
