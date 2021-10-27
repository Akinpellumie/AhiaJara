using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using Newtonsoft.Json;
using AhiaJara.ViewModel;

namespace AhiaJara.Models
{
    public class Product
    {
       
        public string imgUrl { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }
      
        public int OrderId { get; set; }
        public string Name { get; set; }
        //public String Image { get; set; }
        public string price { get; set; }
        public string Price
        {
            get
            {

                double temp = 0;
                double.TryParse(this.price, out temp);

                var pel = Math.Round(temp, 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {;} 
        }

        public string TotalPrice
        {
            get
            {
                int newPrice = Int32.Parse(price);
                int[] arr = new int[] { newPrice++ };
                int sum = arr.Sum();
                
                string totalPrice = sum.ToString();
                return "NGN " + totalPrice;
            }
            set {TotalPrice = value; }
        }
        public string quantity { get; set; }
        public string Quantity
        {
            get
            {
                var qty = "Quality: " + quantity;
                return qty;
            }
            set { Quantity = value; }
        }
        public string Status { get; set; }
        public string dateDispatched { get; set; }
        public string Date { get; set; }
        public Color BtnColor
        {
            get
            {
                if (Status.Contains("pending"))
                {
                    return Color.FromHex("E5E5E5");
                }
                return Color.Accent;
            }
        }

        public ImageSource Image
        {

            get
            {
                var source = new Uri(imgUrl);

                return source;
            }
            set { Image = value; }
        }
    }


    public class RequestModel
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public string quantitySelected { get; set; }
    }

    public class SupportModel
    {
        public string subject { get; set; }
        public string email { get; set; }
        public string phoneNo { get; set; }
        public string fullName { get; set; }
        public string text { get; set; }
    }

    public class ProductModel : BaseVM

    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public string imgUrl { get; set; }
        public int quantityAvailable { get; set; }
        //[JsonProperty("price")]
        public string price { get; set; }
        public string category { get; set; }
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

        public string Price
        {
            get
            {
                double temp = 0;
                double.TryParse(this.price, out temp);

                var pel = Math.Round(temp, 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {; }
        }

        public string tempPrice
        {
            get; set;
        }

        public string TotalPrice
        {
            get
            {
                int newPrice = Int32.Parse(tempPrice);
                int[] arr = new int[] { newPrice++ };
                int sum = arr.Sum();

                string totalPrice = sum.ToString();
                return "NGN " + totalPrice;
            }
            set { TotalPrice = value; }
        }

        public int quantity { get; set; }
        
        public string Quantity
        {
            get
            {
                string qty = "1";
                int x = 1;
                if (quantity < 2)
                {
                    qty = "Quantity: " + x.ToString();
                }
                else
                {
                    qty = "Quantity: " + quantity.ToString();
                }
                
                return qty;
            }
            set { Quantity = value; }
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
                else if(firstFrameBackColor == Color.White)
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

        private Color secondFrameBackColor;
        public Color SecondFrameBackColor
        {
            set
            {
                if (secondFrameBackColor != value)
                {
                    secondFrameBackColor = value;
                    OnPropertyChanged(nameof(SecondFrameBackColor));
                }
            }
            get => secondFrameBackColor;
        }

    }
}
