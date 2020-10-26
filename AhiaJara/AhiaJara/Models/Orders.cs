using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{
    public class Orders
    {
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string productId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }
        public Color BtnColor
        {
            get
            {
                if (status.Contains("pending"))
                {
                    return Color.FromHex("E5E5E5");
                }
                return Color.Accent;
            }
        }
        public DateTime dispatchedDate
        {
            get
            {
                if (status.Contains("Dispatched"))
                {
                    return updatedAt;
                }
                return updatedAt;
            }
        }



        public string Price
        {
            get
            {

                var pel = Math.Round(Convert.ToDouble(this.TotalPrice), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                var pelTotal = "TotalPrice " + pel;
                return pelTotal;
            }
            set {; }
        }

        public string Quantity
        {
            get
            {
                var qty = "Quantity " + this.quantity;
                return qty;
            }
            set {; }
        }

        public string TotalPrice
        {
            get
            {
                int newPrice = Int32.Parse(price);

                int totalPrice = newPrice * quantity;
                //return "NGN " + totalPrice;
                return totalPrice.ToString();
            }
            set { TotalPrice = value; }
        }

        public ImageSource Image
        {

            get
            {
                var source = new Uri(imgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { Image = value; }
        }
    }
}
