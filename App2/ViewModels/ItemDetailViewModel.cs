using System;

using App2.Models;

namespace App2.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Items Item { get; set; }
        public ItemDetailViewModel(Items item = null)
        {
         /*   Title = item?.Text;
            Item = item;*/
        }
    }
}
