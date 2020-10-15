﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderConPage : ContentPage
    {
        public OrderConPage()
        {
            InitializeComponent();
        }

        public async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPaymentPage());
        }
    }
}