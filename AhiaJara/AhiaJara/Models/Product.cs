using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using Newtonsoft.Json;

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

                var pel = Math.Round(Convert.ToDouble(this.price), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
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

    public class ProductModel
    {
        public string name { get; set; }
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

                var pel = Math.Round(Convert.ToDouble(this.price), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
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
        
    }
}
