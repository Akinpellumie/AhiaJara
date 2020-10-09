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
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        public async void OrderPage_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }

        public async void QuestionBtn_Clicked(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionnairePage());
        }
    }
}