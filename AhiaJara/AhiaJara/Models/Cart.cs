using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AddCartItem
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public int quantitySelected { get; set; }
        public string productName { get; set; }
        public string productImgUrl { get; set; }
        public string productPrice { get; set; }
        public string productCategory { get; set; }

    }

    public class CartCount
    {
        public int cartcount { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Cart
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public int quantitySelected { get; set; }

        public string productName { get; set; }
        public string productImgUrl { get; set; }
        public string productPrice { get; set; }
        public string productCategory { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }

        public string Price
        {
            get
            {

                var pel = Math.Round(Convert.ToDouble(this.productPrice), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {; }
        }

        public string qtySelected
        {
            get
            {
                string quantity = this.quantitySelected.ToString();
                var quantityText = "Quantity: " + quantity;
                return quantityText;
            }
            set { qtySelected = value; }
        }

        public string TotalPrice
        {
            get
            {
                int newPrice = Int32.Parse(productPrice);
                int[] arr = new int[] { newPrice++ };
                int sum = arr.Sum();

                string totalPrice = sum.ToString();
                return "NGN " + totalPrice;
            }
            set { TotalPrice = value; }
        }
        public ImageSource ProductImage
        {

            get
            {
                var source = new Uri(productImgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { ProductImage = value; }
        }
    }


}
