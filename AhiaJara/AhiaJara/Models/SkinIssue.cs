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
        public string id { get; set; }

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
        public List<RecommendedProduct> recommendedProducts { get; set; }
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

        private Color firstFrameBackColor = Color.White;

        public Color FirstFrameBackColor
        {
            get
            {
                if (firstFrameBackColor != Color.White)
                {
                    firstFrameBackColor = Color.White;
                }
                else if (firstFrameBackColor == Color.White)
                {
                    firstFrameBackColor = Color.FromHex("4DC503");
                }
                return firstFrameBackColor;
            }
            set
            {
                firstFrameBackColor = value;
                OnPropertyChanged(nameof(FirstFrameBackColor));
            }
        }
    }

    public class Root
    {
        public List<SkinIssue> MyArray { get; set; }
    }

}
