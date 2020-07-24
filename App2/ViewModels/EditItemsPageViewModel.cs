using App2.Models;
using App2.Services;
using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class EditItemsPageViewModel : BaseViewModel
    {

        public ObservableCollection<VAT> VAT { get; set; }
        public ObservableCollection<Items> Items { get; set; }
        
        public ObservableCollection<string> VatNames
        {
            get; set;
        }
        public ObservableCollection<string> SectioName { get; set; }

        private VatServices VatServices { get; set; }
        private PolozkasService PolozkasService { get; set; }

        public ObservableCollection<EditItem> EditItems{get;set; }

        public ObservableCollection<string> SectionNames { get; set; }

        public ObservableCollection<Sekce> Sekces { get; set; }
        public SekcesService sekcesService { get; set; }
        public EditItemsPageViewModel()
        {
            Items = new ObservableCollection<Items>();
            VAT = new ObservableCollection<VAT>();
            VatServices = new VatServices();//Třída, která implementuje API komunikaci pro daně
            PolozkasService = new PolozkasService(); //Třída, která implementuje API komunikaci pro položky
            EditItems = new ObservableCollection<EditItem>();
            VatNames = new ObservableCollection<string>();
            SectionNames = new ObservableCollection<string>();
            Sekces = new ObservableCollection<Sekce>();
            sekcesService = new SekcesService();

        }
        public async Task FillVatAndSectiontNames()
        {
            foreach (var item in EditItems.Select(x => x.VatName).Distinct())
            {
                VatNames.Add(item);
            }
            foreach (var item in Sekces.Select(x => x.name).Distinct())
                {
                SectionNames.Add(item);
            }
        }
        /// <summary>
        /// Get sekce
        /// </summary>
        /// <returns></returns>
        public async Task GetSections()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Sekces.Clear();
                var items = await sekcesService.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Sekces.Add(item);

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
        public async Task GetEditItems()
        {
            var edititems = from items in Items
                            join vat in VAT on items.vatId equals vat.vatId
                            join sekce in Sekces on items.sectionId equals sekce.id
                            select new
                            {
                                ItemId = items.itemId,
                                Name = items.name,
                                VatName = vat.name,
                                Price = items.price,
                                SectionName = sekce.name
                            };
             
            foreach (var item in edititems)
            {
                EditItems.Add(new EditItem()
                {
                    SectionName = item.SectionName,
                    itemId = item.ItemId,
                    Name = item.Name,
                    Price = (int)item.Price,
                    VatName = item.VatName
                }
                ) ;
            }
        }

  
       

        public async Task GetPolozkas()
        {
            if (IsBusy)
                return;  //Pokud už je zaneprázděna nevykonávej činnost

            IsBusy = true;//Nastavení zaneprázdněnosti

            try
            {
                Items.Clear();
                var items = await PolozkasService.GetItemsAsync(true);//Request na API pro položky
                foreach (var item in items)
                {
                    Items.Add(item);//Přidá položky do kolekce

                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;//Odblokuj zaneprázdnění
            }
        }
        public async         Task
GetVatService()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                VAT.Clear();
                var items = await VatServices.GetItemsAsync(true);
                foreach (var item in items)
                {
                    VAT.Add(item);

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
