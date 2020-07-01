using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
   public  class Tables
    {

        public long Id { get; set; }
        public int? Capacity { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
