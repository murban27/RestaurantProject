using App2.Models;
using App2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App2.ViewModels
{
   public class TableesViewModel:BaseViewModel
    {
        public Xamarin.Forms.Command LoadItemsCommand { get; set; }
        public Xamarin.Forms.Command PutItemsCommand { get; set; }
        public ObservableCollection<Models.Tables> Stolies { get; set; }
        public Tables Stul { get; set; }

        public TableesViewModel()
        {
            Stolies = new ObservableCollection<Models.Tables>();
            PutItemsCommand = new Xamarin.Forms.Command(async () => await PutTask(Stul));
            LoadItemsCommand = new Xamarin.Forms.Command(async () => await GetTask());
        }

        public async Task PutTask(Tables table)
        {
           
                StolyDataService stolyDataService = new StolyDataService();

                if (IsBusy)
                    return;

                IsBusy = true;
                Stolies.Clear();
                table.isAvailable = false;
              var result=  await stolyDataService.UpdateItemAsync(table);

            IsBusy = false;


        }

        public async Task GetTask()
        {
            StolyDataService stolyDataService = new StolyDataService();
          
            if (IsBusy)
                return;

            IsBusy = true;
            Stolies.Clear();
            var items = await stolyDataService.GetItemsAsync(true);
            try
            {
                foreach (var item in items)
                {
                    Stolies.Add(item);
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
