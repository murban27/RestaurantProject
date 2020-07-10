using App2.Models;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableCollection : ContentPage
    {
        OrderInfoViewModel viewmModel;
        public TableCollection(Tables tables)
        {

            BindingContext = this.viewmModel = new OrderInfoViewModel(tables);
            viewmModel.Sekce();

            InitializeComponent();





        }
       
      async  protected override void OnAppearing()
        {
          

                await viewmModel.GetOrderDetail();
            await viewmModel.GetPolozkas();
           
        }
      

        private void SfTabView_TabItemTapped(object sender, Syncfusion.XForms.TabView.TabItemTappedEventArgs e)
        {
            

        }

        private void SfTabView_CenterButtonTapped(object sender, EventArgs e)
        {

        }/// <summary>
        /// Metoda která filtruje na základě změny selectoru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SfTabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            int sectionId = viewmModel.Sekces.Where(x => x.name == e.Name).Select(x => x.id).FirstOrDefault();//načti id z listu
            SfGrid.IsBusy = true;//zastav grid
           var s= viewmModel.Polozkas.Where(x => x.sectionId == sectionId).Select(x=>x);   //aplikuj filtr
            SfGrid.ItemsSource = s;

            SfGrid.IsBusy = false;
        }
    }
}