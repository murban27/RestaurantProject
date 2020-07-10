﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Stoly,
        Zkouska,
        Tables,
        CollectionTables,
        Vat
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
