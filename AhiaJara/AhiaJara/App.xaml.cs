using AhiaJara.Helpers;
using AhiaJara.Services;
using AhiaJara.Views;
using DLToolkit.Forms.Controls;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara
{
    public partial class App : Application
    {

        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentpage;
        private static Timer timer;
        private static bool noInterShow;
        private static bool tokenAccess;
        public App()
        {
            InitializeComponent();
            FlowListView.Init();

            //MainPage = new NavigationPage(new LoginPage());
            //MainPage = new AppShell();
            DependencyService.Register<MockDataStore>();
            //TestCall();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLoogged == "1")
            {
                //var savedToken = Xamarin.Essentials.SecureStorage.GetAsync("Token").Result;
                //Settings.Token = savedToken;
                //int y = TestCall().Result;
                //if(y > 0)
                //{
                    MainPage = new AppShell();
                //}
                //else
                //{
                //    MainPage = new NavigationPage(new LoginPage());
                //}
                
                
                
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = NoInternet.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentpage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOvertime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        //public async Task<int> TestCall()
        //{
        //    int x=0;
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        var url = Constants.getSkinIssue;
        //        var savedToken = Xamarin.Essentials.SecureStorage.GetAsync("Token").Result;
        //        Settings.Token = savedToken;
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
        //        var response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            x = 1;  

        //        }
        //        else
        //        {
                    
        //        }


        //    }
        //    catch (Exception)
        //    {
                
        //    }
        //    return x;
        //}

        private static void CheckIfInternetOvertime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await showDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }
        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await showDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task showDisplayAlert()
        {
            noInterShow = false;
            await currentpage.DisplayAlert("Internet", "No internet connection, try again", "OK");
            noInterShow = false;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
