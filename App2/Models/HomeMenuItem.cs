using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public enum MenuItemType
    {
        Main,
        About,
        Zkouska,
        Vat,
        EditTablePage
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
