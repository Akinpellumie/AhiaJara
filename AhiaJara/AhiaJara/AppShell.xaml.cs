using System;
using System.Collections.Generic;
using AhiaJara.ViewModels;
using AhiaJara.Views;
using Xamarin.Forms;

namespace AhiaJara
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

      
    }
}
