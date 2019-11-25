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
using Stoly = App2.Models.Stoly;

namespace App2.ViewModels
{
  
    public class StolyViewModel : BaseViewModel
    {

        public ObservableCollection<Stoly> Stolies { get; set; }
        public Command LoadItemsCommand { get; set; }
        public StolyViewModel()
        {
            Stoly s = new Stoly() {Kapacita=5,Obsazeno=true };

            var a = Stolyies.AddItemAsync(s).GetAwaiter();

            
            Title = "Stoly";
            Stolies = new ObservableCollection<Stoly>();
            LoadItemsCommand = new Command(async () => await ExecLoadItemsCommand());

            MessagingCenter.Subscribe<StolyNewPage,Stoly>(this,"AddTable",async(obj,item)=>
                {
                    var newItem = item as Stoly;
                    try
                    {
                        Stolies.Add(newItem);
                        await Stolyies.AddItemAsync(newItem);
                       
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                });
           

        }
        async Task ExecLoadItemsCommand()
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
