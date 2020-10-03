using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AhiaJara.Droid;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchRenderer))]
namespace AhiaJara.Droid
{
    public class CustomSearchRenderer : SearchBarRenderer
    {
        public CustomSearchRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);

                SearchView searchView = (base.Control as SearchView);
                var searchIconId = searchView.Resources.GetIdentifier("android:id/search_map_icon", null, null);
                var searchIcon = searchView.FindViewById(searchIconId);
                searchView.SetIconifiedByDefault(false);
                searchIcon.RemoveFromParent();

                //int textViewId = Resources.GetIdentifier("android:id/search_src_text", null, null);
                //EditText textView = (Control.FindViewById(textViewId) as EditText);
                //textView.TextAlignment = Android.Views.TextAlignment.ViewStart;
            }
        }
    }
}