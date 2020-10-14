using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AddCartItem
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public string quantitySelected { get; set; }
    }

    public class CartCount
    {
        public int cartcount { get; set; }
    }

    public class CartDetails
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public int quantitySelected { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }
        public ProductModel productDetails { get; set; }

    }

    public class CartItemDetails
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public int quantitySelected { get; set; }
        public string id { get; set; }

        public string name { get; set; }
        public string imgUrl { get; set; }
        public int quantityAvailable { get; set; }
        //[JsonProperty("price")]
        public string price { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

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
            set {; }
        }

    }


    public class CartList
    {
        public CartDetails[] cartDetails { get; set; }
       // public CartDetails cartDetails { get; set; }
        //public ProductModel productDetails { get; set; }
    }

    //public class CartList
    //{
    //    public List<MyArray> MyArray { get; set; }
    //    ////public Dictionary<string, MyArray>MyArray  { get; set; }
    //}

}
