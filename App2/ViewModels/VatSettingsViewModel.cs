using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModels
{
   public class VatSettingsViewModel:BaseViewModel
    {
        public Command Command { get; }
        public ObservableCollection<VAT> Dane { get; set; }
        public VatSettingsViewModel()
        {
            Title = "Daňové sazby";
            var anonym = Task.Run(async () => await CreateFewVats());
            System.Threading.Thread.Sleep(200);
            Dane = new ObservableCollection<VAT>();

            Command = new Command(async Dane => await GetTask());
        
        }
        async Task GetTask()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Dane.Clear();
            var items = await VAT.GetItemsAsync(true);
            try
            {
                foreach (var item in items)
                {
                    Dane.Add(item);
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
        public async         Task<bool>
CreateFewVats()
        {
            await VAT.AddItemAsync
                (new Models.VAT()
                {
                    name = "Nealko pití",
                    Value = 15
                });
            return await Task.FromResult(true);
        }

    }
}
