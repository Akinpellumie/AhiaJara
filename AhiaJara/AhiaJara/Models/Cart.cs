using System;
using System.Collections.Generic;
using System.Text;

namespace AhiaJara.Models
{
    public class Cart
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AddCartItem
    {
        public string productId { get; set; }
        public string userId { get; set; }
        public string quantitySelected { get; set; }
    }
}
