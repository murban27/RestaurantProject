using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class Polozka
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Nazev { get; set; }
        public float Cena { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Hyarch")]
        public int HyarchId { get; set; }
        public Hyarch Hyarch { get; set; }
        
    }
}
