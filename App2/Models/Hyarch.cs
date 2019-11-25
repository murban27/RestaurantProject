using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App2.Models
{
  public  class Hyarch
    {

        [PrimaryKey]
        public int ID { get; set; }
        [Required, SQLite.MaxLength(10)]
        public string nazev { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
