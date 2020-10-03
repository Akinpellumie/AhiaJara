using AhiaJara.Models;
using AhiaJara.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.ViewModels
{
    public class ProductViewModel : BaseVM
    {

        public ProductViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetProducts();

        }

        private ObservableCollection<Product> productModelList;
        public ObservableCollection<Product> ProductModelList
        {
            get => productModelList;
            set
            {
                productModelList = value;
                OnPropertyChanged(nameof(ProductModelList));

            }
        }

        public void GetProducts()
        {
            productModelList = new ObservableCollection<Product>();
            productModelList.Add(new Product { Name = "Hand Sanitizer ", Image = "ListPr", Price = "NGN 6,999.00" });
            productModelList.Add(new Product { Name = "FreshYo Soap", Image = "ListProo", Price = "NGN 10,000.00" });
            productModelList.Add(new Product { Name = "Skin Tone", Image = "ListProo", Price = "NGN 22,000.00" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProo", Price = "NGN 3,999.99" });
            productModelList.Add(new Product { Name = "Hand Sanitizer", Image = "ListProd", Price = "NGN 5,000.00" });
            productModelList.Add(new Product { Name = "FreshMe Cream", Image = "ListPro.png", Price = "NGN 2,000.00" });

        }
    }
}
