using App2.Models;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

            BindingContext = this.viewmModel = new OrderInfoViewModel(tables); //Nastaví Context pro stránku TableCollection na třídu OrderInfo
            viewmModel.Sekce(); //načte Sekce - nealko,alko,menu,atp

            InitializeComponent();
        }
        //Načti kolekce
        async protected override void OnAppearing()
        {

            await viewmModel.GetPolozkas();
            await viewmModel.GetOrderDetail();


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
            var s = viewmModel.Polozkas.Where(x => x.sectionId == sectionId).Select(x => x);   //aplikuj filtr
            SfGrid.ItemsSource = s;

            SfGrid.IsBusy = false;
        }

        private async void ImageButton_ClickedAsync(object sender, EventArgs e)
        {

            var obj = (Xamarin.Forms.ImageButton)sender;//dostan object
            var rodic = (Syncfusion.SfDataGrid.XForms.GridCell)obj.Parent;//rodic
            var item = (App2.Models.Items)rodic.DataColumn.RowData;//cast na Item
            await viewmModel.AddOrderItem(item.itemId);



        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
          
            var Responce = await DisplayAlert("Zaplaceno", string.Format($"{viewmModel.OrderDetails.Sum(x => x.Price)}?"), "Ano", "Ne");
            if (Responce == true)
            {
                await viewmModel.EndOrder();

                Application.Current.MainPage = new MainPage();
            }
        }
    }
}