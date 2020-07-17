using App2.Models;
using App2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App2.ViewModels
{
   public class EditItemsPageViewModel:BaseViewModel
    {

        public IObservable<VAT> VAT { get; set; }
         public ObservableCollection<Items> Items { get; set; }

        private VatServices VatServices { get; set; }
        private PolozkasService PolozkasService { get; set; }



        public EditItemsPageViewModel()
        {
            VatServices = new VatServices();
            PolozkasService = new PolozkasService();
        }
    }
}
