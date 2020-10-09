using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;

namespace AhiaJara.Models
{
    public class Product
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public String Image { get; set; }
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
    }
}
