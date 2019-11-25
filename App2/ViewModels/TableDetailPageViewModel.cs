using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App2.ViewModels
{
   public class TableDetailPageViewModel:BaseViewModel
    {
        public ObservableCollection<Stoly> Stoly { get; set; }
        public TableDetailPageViewModel(Stoly stul)
        {

        }
    }
}
