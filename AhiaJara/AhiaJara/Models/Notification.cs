using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhiaJara.Models
{
    public class MyNotification
    {
        public string messageTo { get; set; }
        public bool read { get; set; }
        public string messageFrom { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string id { get; set; }

        public string Date
        {
            get
            {
                var x = this.createdAt.ToString();
                DateTime date = DateTime.Parse(x.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dddd, MMMM d, yyyy");
                return newDate;
            }
        }
    }




    public class Notification
    {
        //public List<MyNotification> Notifications { get; set; }
        public List<MyNotification> allNotification { get; set; }
        public int countunread
        {
            get; set;
        }
    }

}
