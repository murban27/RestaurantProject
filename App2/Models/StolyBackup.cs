using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App2.Models
{
    public class StolyBackup
    {

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public int Kapacita { get; set; }
        [DefaultValue(false)]
        public bool Obsazeno { get; set; }
        public ICollection<Orders>Orders { get; set; }
    

    }
}
