using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Telephony;
using Android.Views;
using App2.Models;
using App2.Services;
using App2.Views;
using Syncfusion.XForms.TabView;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using StolyBackup = App2.Models.StolyBackup;

namespace App2.ViewModels
{
    public class OrderInfoViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command LoadItemsCommand { get; set; }
        public Xamarin.Forms.Command LoadPolozkasCommand { get; set; }
        private string celkove;
        public string Celkove
        {
            get { return celkove; } set { celkove = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Models.Items> Polozkas { get; set; }
        public ObservableCollection<Sekce> Sekces { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public TabItemCollection Items { get; set; }

        public SekcesService sekcesService { get; set; }
        public OrderInfoServices OrderInfoServices { get; set; }
        public PolozkasService PolozkasService { get; set; }
        public Tables Table { get; set; }
        public ObservableCollection<OrderDetail> OrderDetails { get; set; }
        public OrderInfoViewModel(Tables table = null)

        {
            this.Table = table;

            // Order = table.Orders.FirstOrDefault();
            Sekces = new ObservableCollection<Sekce>();
            Orders = new ObservableCollection<Orders>();
            Items = new TabItemCollection();
            Polozkas = new ObservableCollection<Items>();
            OrderDetails = new ObservableCollection<OrderDetail>();
            LoadItemsCommand = new Xamarin.Forms.Command(async () => await GetOrderDetail());

        }
        public async Task GetPolozkas()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            PolozkasService = new PolozkasService();
            Polozkas.Clear();
            var s = await PolozkasService.GetItemsAsync();
            foreach (var item in s)
            {
                Polozkas.Add(item);
            }

            IsBusy = false;
        }
        /// <summary>
        /// Přidá položku do objednávky
        /// </summary>
        /// <returns></returns>
        public async Task AddOrderItem(int ItemID)
        {
            IsBusy = true;//Informuje view model o nedostupnosti
            OrderDetail orderDetail = new OrderDetail()
            {
                orderId = Table.orders[0].id,
                itemId = ItemID
            };
            OrdeDetailService ordeDetailService = new OrdeDetailService();
            var result = await ordeDetailService.AddItemAsync(orderDetail);
            if (result == true)
            {
                await RebuildOrder(orderDetail);
                Celkove = string.Format($"Položky v objednávce, celková cena:{ OrderDetails.Sum(X => X.Price).ToString()}");//Label  
            }
            else
            {
                throw new Exception("Error during post");

            }
            IsBusy = false;
        }
            /// <summary>
            /// Updatuje objednávku
            /// </summary>
            /// <returns></returns>

            /// <summary>
            /// Ukončí objednávku
            /// </summary>
            /// <returns></returns>
            public async Task EndOrder()
            {
            Table.isAvailable = true;//uvolni stůl
            var date = DateTime.UtcNow;
            Orders[0].endTime = date;//Ukonči objednávku a konvertuj do správného tvaru
            StolyDataService stolyDataService = new StolyDataService();
            await stolyDataService.UpdateItemAsync(Table);
            await OrderInfoServices.UpdateItemAsync(Orders[0]);

            
            }

            public async Task GetOrderDetail()
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
                    Orders.Clear();
                    var s = await OrderInfoServices.GetItemAsync(Table.orders[0].id.ToString());

                    if (s != null)
                    {

                        Orders.Add(s);
                    }







                    //Přidá cenu a název do kolekce
                    foreach (var item in Orders[0].orderDetail)
                    {
                        var query = (from f in Orders[0].orderDetail
                                     join k in Polozkas on f.itemId equals k.itemId
                                     where k.itemId == item.itemId && item.orderId == f.orderId
                                     select new { Price = k.price, Name = k.name }).FirstOrDefault();
                        item.Price = query.Price;
                        item.ItemName = query.Name;
                        OrderDetails.Add(item);

                    }

                    Celkove = string.Format($"Položky v objednávce, celková cena:{ OrderDetails.Sum(X => X.Price).ToString()}");//Label      




                    IsBusy = false;
                }



            }
        public async Task RebuildOrder(OrderDetail orderDetail)
        {
            var L = Polozkas.Where(x => x.itemId == orderDetail.itemId).Select(x => x).FirstOrDefault();//připoj cenu
            orderDetail.Price = L.price;
            orderDetail.ItemName = L.name;
            OrderDetails.Add(orderDetail);
             await Task.FromResult(true);

        }

            public void Sekce()
            {
                sekcesService = new SekcesService();
                var result = Task.Run(async () => await sekcesService.GetItemsAsync()).Result;




                foreach (var item in result)
                {
                    Sekces.Add(item);


                }
                AddSfTabItems();



            }
            public void AddSfTabItems()
            {
                foreach (var item in Sekces)
                {
                    Items.Add(new SfTabItem() { Title = item.name });
                }
            }



        }
    }

