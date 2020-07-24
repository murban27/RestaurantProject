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
using StolyBackup = App2.Models.StolyBackup;

namespace App2.ViewModels
{
  
    public class StolyViewModel : BaseViewModel
    {

        public ObservableCollection<StolyBackup> Stolies { get; set; }
        public Command LoadItemsCommand { get; set; }
        public StolyViewModel()
        {
            StolyBackup s = new StolyBackup() {Kapacita=5,Obsazeno=true };

            var a = Stolyies.AddItemAsync(s).GetAwaiter();

            
            Title = "Stoly";
            Stolies = new ObservableCollection<StolyBackup>();
            LoadItemsCommand = new Command(async () => await ExecLoadItemsCommand());
            ///Příjem zprávy
            MessagingCenter.Subscribe<StolyNewPage,StolyBackup>(this,"AddTable",async(obj,item)=>
                {
                    var newItem = item as StolyBackup;
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
