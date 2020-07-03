using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using App2.Services;
using App2.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using StolyBackup = App2.Models.StolyBackup;

namespace App2.ViewModels
{
   public class OrderInfoViewModel:BaseViewModel
    {
        public Xamarin.Forms.Command LoadItemsCommand { get; set; }
        public ObservableCollection<Models.StolyBackup> Stolies { get; set; }
        public ObservableCollection<Models.Polozka> Polozkas { get; set; }
        public Order Order { get; set; }
        public ObservableCollection<Sekce> Sekces { get; set; }

        public StolyBackup stoly { get; set; }
        public OrderInfoViewModel(Tables table=null)

        {
            // Order = table.Orders.FirstOrDefault();
            Sekces = new ObservableCollection<Sekce>();
                LoadItemsCommand = new Xamarin.Forms.Command(async () => await GetTask());
        }
             async Task GetTask()
        {
            if (IsBusy)
                return;

            SekcesService sekcesService = new SekcesService();
            var s =await sekcesService.GetItemsAsync(true);

            foreach (var item in s)
            {
                Sekces.Add(item);
            }
            IsBusy = false;
      


        }




    }
}
