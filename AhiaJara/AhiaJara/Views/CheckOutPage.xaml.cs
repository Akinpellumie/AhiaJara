﻿using AhiaJara.Models;
using AhiaJara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckOutPage : ContentPage
    {
        ProductViewModel ProductViewModel;
        public CheckOutPage(Product productModel)
        {
            ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            BindingContext = productModel;
        }

    }
}