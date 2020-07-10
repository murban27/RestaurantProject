using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
   public class VAT
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string name { get; set; }
        public int Value { get; set; }
    }
}
