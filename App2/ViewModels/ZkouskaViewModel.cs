using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class ZkouskaViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<Models.Stoly> Stolies{get;set;}
        public ZkouskaViewModel()
        {

            Stolies = new ObservableCollection<Models.Stoly>();
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = true });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = true });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = false });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 40, Obsazeno = false });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = true });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 10, Obsazeno = false });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 80, Obsazeno = false });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = true });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = false });
            Stolyies.AddItemAsync(new Models.Stoly { Kapacita = 20, Obsazeno = false });

            Polozky.AddItemAsync(new Models.Polozka { Cena = 2, Nazev = "Pivo" });
            


           

              

            LoadItemsCommand = new Command(async() =>await GetTask());
          
        }


            async Task GetTask()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Stolies.Clear();
            var items = await Stolyies.GetItemsAsync(true);
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

