using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AhiaJara.Helpers;
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

    public class SendCart
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
        public int TotalPrice { get; set; }
        public int SingleProductPrice { get; set; }

        public string newTotal
        {
            get
            {
                var pele = Settings.CartTotalPrice.ToString();
                var pel = Math.Round(Convert.ToDouble(pele), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {newTotal = value; }
        }
        public string Price
        {
            get
            {

                var pel = Math.Round(Convert.ToDouble(this.productPrice), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {; }
        }
        public string newTest {
            get {
                int newxx = Int32.Parse(this.productPrice);
                return newxx.ToString();
                    }
            set
            {
                newTest = value;
            }
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

        //int i = 0;
        //int[] arr = new int[] { i++ };
        //ArrayList arr = new ArrayList();

        //var tempList = arr.ToList();

        //public string TotalPrice
        //{
        //    get
        //    {
        //        int newPrice = Int32.Parse(productPrice);
        //        ArrayList arr = new ArrayList();
        //        arr.Add(newPrice);
        //        //arr = tempList.ToArray();
        //        //int[] arr = new int[] { newPrice++ };
        //        int sum = arr.Cast<int>().Sum();
        //        //int sum = arr.Sum();

        //        string totalPrice = sum.ToString();
        //        return "NGN " + totalPrice;
        //    }
        //    set { TotalPrice = value; }
        //}
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
