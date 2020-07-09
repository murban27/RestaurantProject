using System.Collections.ObjectModel;

namespace App2.Models
{
    public class Items
    {

            public int itemId { get; set; }
            public string name { get; set; }
            public float price { get; set; }
            public int sectionId { get; set; }
            public int vatId { get; set; }
            public Sekce section { get; set; }
            public VAT vat { get; set; }
            public ObservableCollection<OrderDetail> orderDetail { get; set; }
        

    }
}