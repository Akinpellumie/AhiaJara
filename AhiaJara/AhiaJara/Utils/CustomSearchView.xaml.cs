﻿using AhiaJara.ViewModels;
using AhiaJara.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSearchView : ContentView
    {
        public CustomSearchView()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();
            searchBar.Focus();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}