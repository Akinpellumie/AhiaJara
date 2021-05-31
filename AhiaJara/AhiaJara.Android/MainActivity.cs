using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms.Platform.Android;
using Android.OS;
using Sharpnado.Presentation.Forms.Droid;
using Xamarin.Forms;
using Plugin.Media;

namespace AhiaJara.Droid
{
    [Activity(Label = "Sekat", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            await CrossMedia.Current.Initialize();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //Forms.SetFlags("CarouselView_Experimental");
            //Forms.SetFlags(new string[] { "CarouselView_Experimental", "SwipeView_Experimental", "IndicatorView_Experimental" });

            Xamarin.Forms.Forms.SetFlags(new string[] { "CarouselView_Experimental", "IndicatorView_Experimental", "CollectionView_Experimental" });
            Forms.Init(this, savedInstanceState);
            SharpnadoInitializer.Initialize();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}