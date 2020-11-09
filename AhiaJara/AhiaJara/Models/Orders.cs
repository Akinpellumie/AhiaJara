using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{
    public class shippingData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
    public class Orderss
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
                if (status.Contains("Dispatched"))
                {
                    return Color.FromHex("E5E5E5");
                }
                return Color.FromHex("F0F0F0");
            }
            set {; }
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

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Dispatcher
    {
        public bool IsInvokeRequired { get; set; }
    }

    public class ProductImage
    {
        public bool IsEmpty { get; set; }
        public string CacheValidity { get; set; }
        public bool CachingEnabled { get; set; }
        public string Uri { get; set; }
        public object AutomationId { get; set; }
        public object ClassId { get; set; }
        public List<object> Effects { get; set; }
        public string Id { get; set; }
        public object ParentView { get; set; }
        public object StyleId { get; set; }
        public List<object> LogicalChildren { get; set; }
        public object RealParent { get; set; }
        public object Parent { get; set; }
        public object EffectControlProvider { get; set; }
        public object Platform { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public object BindingContext { get; set; }
    }

    public class OrderedProduct
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
        public string Price { get; set; }
        public string newTest { get; set; }
        public string qtySelected { get; set; }
        public ProductImage ProductImage { get; set; }

       



        public string PriceConvert
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
                var qty = "Quantity " + this.quantitySelected;
                return qty;
            }
            set {; }
        }

        ArrayList priceArray = new ArrayList();
        public string TotalPrice
        {
            get
            {
                int newPrice = Int32.Parse(Price);
                

                int totalPrice = newPrice * this.quantitySelected;
                priceArray.Add(totalPrice);
                //int sum = priceArray.Sum();
                int sumx = 0;
                for (var i = 0; i < priceArray.Count; i++)
                {
                    sumx = sumx + Int32.Parse(priceArray[i].ToString());
                }

                string totalPricex =  sumx.ToString();
                return "NGN " + totalPrice;
            }
            set { TotalPrice = value; }
        }

        public ImageSource Image
        {

            get
            {
                var source = new Uri(productImgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { Image = value; }
        }
    }

    public class shippinDetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }

    public class Orders
    {
        
        public List<OrderedProduct> products { get; set; }
        public string paymentId { get; set; }
        public string totalPrice { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public shippinDetails shippinDetails { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }

        public Color BtnColor
        {
            get
            {
                if (status.Contains("Pending"))
                {
                    return Color.FromHex("E5E5E5");
                }
                return Color.Accent;
            }
        }
        public string dispatchedDate
        {
            get
            {
                if (status.Contains("Dispatched"))
                {
                    var date = updatedAt.ToString("dd/MM/yyyy");
                    return "Date Dispatched: " +date;
                }
                else
                {
                    //var date = createdAt.Date;
                    var date = createdAt.ToString("dd/MM/yyyy");
                     return "Date Ordered: " + date;
                }
                
            }
        }

        public string Price
        {
            get
            {

                var pel = Math.Round(Convert.ToDouble(this.totalPrice), 2).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "NGN ");
                return pel;
            }
            set {; }
        }


    }


}
