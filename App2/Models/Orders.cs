using System;
using System.Collections;
using System.Collections.Generic;

namespace App2.Models
{
    public class Orders
    {

            public int id { get; set; }
            public DateTime startTime { get; set; }
            public DateTime? endTime { get; set; }
            public int tableId { get; set; }
            public OrderDetail[] orderDetail { get; set; }
        }

    }

