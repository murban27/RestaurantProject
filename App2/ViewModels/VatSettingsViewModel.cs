using App2.Models;
using App2.Services;
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
        public ObservableCollection<VAT> Dane { get { return _Dane; }set { _Dane = value; OnPropertyChanged("Dane"); } }
        private ObservableCollection<VAT> _Dane { get; set; }
        public VatServices VatServices { get; set; }
        public VatSettingsViewModel()
        {
            Title = "Daňové sazby";
            var anonym = Task.Run(async () => await CreateFewVats(null));
            System.Threading.Thread.Sleep(200);
            _Dane = new ObservableCollection<VAT>();
            Dane = new ObservableCollection<VAT>();

            Command = new Command(async Dane => await GetTask());
        
        }
        async Task GetTask()
        {
            if (IsBusy)
                return;
            VatServices = new VatServices();
            IsBusy = true;
            _Dane.Clear();
            var items = await VatServices.GetItemsAsync(true);
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

        public async Task UpdateVat(VAT item)
        {
       
           await VatServices.UpdateItemAsync(item);

         

        }

        public async         Task<bool>CreateFewVats(VAT vAT)
        {
            await VatServices.AddItemAsync(vAT);
            return await Task.FromResult(true);
        }

    }
}
