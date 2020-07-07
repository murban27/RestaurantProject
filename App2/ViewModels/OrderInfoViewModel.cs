using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using App2.Services;
using App2.Views;
using Syncfusion.XForms.TabView;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using StolyBackup = App2.Models.StolyBackup;

namespace App2.ViewModels
{
   public class OrderInfoViewModel:BaseViewModel
    {
        public Xamarin.Forms.Command LoadItemsCommand { get; set; }

        public ObservableCollection<Models.Polozka> Polozkas { get; set; }
        public ObservableCollection<Sekce> Sekces { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public TabItemCollection Items { get; set; }

        public SekcesService sekcesService { get; set; }
        public OrderInfoServices OrderInfoServices { get; set; }
        public Tables Table { get; set; }
        public OrderInfoViewModel(Tables table=null)

        {
            this.Table = table;

            // Order = table.Orders.FirstOrDefault();
            Sekces = new ObservableCollection<Sekce>();
            Orders = new ObservableCollection<Orders>();
                LoadItemsCommand = new Xamarin.Forms.Command(async () => await GetOrderDetail());

        }
          public  async Task GetOrderDetail()
        {
            if (Table == null)
            {

            }
            else
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                OrderInfoServices = new OrderInfoServices();
                var s = await OrderInfoServices.GetItemAsync(Table.orders[0].id.ToString());

                if (s != null)
                {

                    Orders.Add(s);
                }

                IsBusy = false;
            }



        }

        public void CreateTabs()
        {
            sekcesService = new SekcesService();
            var result = Task.Run(async () => await sekcesService.GetItemsAsync()).Result;



            Items = new TabItemCollection();
            foreach (var item in result)
            {
                Items.Add(new SfTabItem() { Title = item.name });

            }



        }



    }
    }

