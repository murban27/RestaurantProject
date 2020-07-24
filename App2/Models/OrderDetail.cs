using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace App2.Models
{
    public class OrderDetail
    {

        public int id { get; set; }
        public int orderId { get; set; }
        public int itemId { get; set; }
        public object item { get; set; }
        [JsonIgnore]
        public string ItemName { get; set; }
        [JsonIgnore]
        public float Price { get; set; }



    }
}
