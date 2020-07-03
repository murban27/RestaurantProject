using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class Sekce
    {

            public int id { get; set; }
            public string name { get; set; }
            public IEnumerable<Item> item { get; set; }

    }
}
