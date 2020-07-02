using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App2.Models
{
    public class Tables
    {

            public int id { get; set; }
            public int capacity { get; set; }
            public bool isAvailable { get; set; }
            public ObservableCollection<Orders> orders { get; set; }
        }


    }

