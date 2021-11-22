using AhiaJara.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class RecommendedProduct
    {
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int quantityAvailable { get; set; }
        public string price { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string _id { get; set; }

        public string Price
        {
            get
            {

                var pel = Math.Round(Convert.ToDouble(this.price), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {; }
        }

        public ImageSource ProductImage
        {

            get
            {
                var source = new Uri(imgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { ProductImage = value; }
        }

    }

    public class SkinIssue : BaseVM
    {
        public List<string> symptom { get; set; }
        //public List<RecommendedProduct> recommendedProducts { get; set; }
        public string recommendedProduct { get; set; }
        public RecommendedProduct recommendedProductId { get; set; }
        public string category { get; set; }
        public string imgUrl { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }

        public ImageSource ProductImage
        {

            get
            {
                var source = new Uri(imgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { ProductImage = value; }
        }

        private bool isChecked;

        public bool IsChecked
        {
            set
            {
                if (value != null)
                {
                    isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
            get
            {
                return isChecked;
            }
        }

        private Color bgColor;
        public Color BGColor
        {
            set
            {
                if (value != null)
                {
                    bgColor = value;
                    OnPropertyChanged(nameof(BGColor));
                }
            }
            get
            {
                return bgColor;
            }
        }
    }

    public class Root
    {
        public List<SkinIssue> MyArray { get; set; }
    }

}
