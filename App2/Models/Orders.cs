using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace App2.Models
{
    public class Orders
    {

        public int id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime? endTime { get; set; }
        public int tableId { get; set; }
        public IEnumerable<OrderDetail> orderDetail { get; set; }
    }

}

