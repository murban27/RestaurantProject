using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App2.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public ICollection<Polozka> Polozky { get; set; }
        [ForeignKey("Stul")]
        public int StulId { get; set; }
        public StolyBackup Stul { get; set; }
        public bool IsClosed { get; set; }

        public DateTime CreaterTime { get; set; } = DateTime.Now;
     
        public DateTime ClosedTime { get; set; }


    }
}
