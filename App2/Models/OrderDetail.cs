using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class OrderDetail
    {

        public int id { get; set; }
        public int orderId { get; set; }
        public int itemId { get; set; }
        public object item { get; set; }



    }
}
