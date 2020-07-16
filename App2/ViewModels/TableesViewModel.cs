using App2.Models;
using App2.Services;
using App2.Views;
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
        private StolyDataService StolyDataService { get; set; }
        public Tables Stul { get; set; }

        public TableesViewModel()
        {
            Stolies = new ObservableCollection<Models.Tables>();
            StolyDataService = new StolyDataService();
            PutItemsCommand = new Xamarin.Forms.Command(async () => await PutTask(Stul));
            LoadItemsCommand = new Xamarin.Forms.Command(async () => await GetTask());
        }

        /// <summary>
        /// Vrat objednávku a stůl
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task<Tables> PutTask(Tables table)
        {
            OrderInfoServices orderInfoServices = new OrderInfoServices();

         

              

                IsBusy = true;
                Stolies.Clear();
              
              var result=  await StolyDataService.UpdateItemAsync(table);
        
             
                Orders dataStore = new Orders() { tableId = table.id, startTime = DateTime.Now,};
               var s =await orderInfoServices.AddItemAsync(dataStore);
            table.orders = new ObservableCollection<Orders>();


            table.orders.Add(s);
           
            IsBusy = false;
            return table;

        }
        public async Task AddTableAsync(Tables table)

        {
            table.isAvailable = false;
            if (IsBusy)
                return;

            IsBusy = true;
            Stolies.Clear();
            await StolyDataService.AddItemAsync(table);
            var items = await StolyDataService.GetItemsAsync(true);
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
        public async         Task
UpdateTableAsync(Tables tables)
        {
            if(IsBusy)
            { return; }
            try
            {
               await StolyDataService.UpdateItemAsync(tables);
            }
            finally
            {
                IsBusy = false;
            }

        }

        public async Task GetTask()
        {
           
          
            if (IsBusy)
                return;

            IsBusy = true;
            Stolies.Clear();
            var items = await StolyDataService.GetItemsAsync(true);
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
