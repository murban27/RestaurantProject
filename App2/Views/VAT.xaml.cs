using App2.Models;
using App2.ViewModels;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VAT : ContentPage
    {
        public VatSettingsViewModel viewModel;
        public VAT()
        {
            BindingContext = viewModel = new VatSettingsViewModel();

            InitializeComponent();

     

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Dane.Count() == 0)
                viewModel.Command.Execute(null);



        }

        private async void SfDataGrid_CurrentCellEndEdit(object sender, Syncfusion.SfDataGrid.XForms.GridCurrentCellEndEditEventArgs e)
        {

            var ItemObject = sender as Syncfusion.SfDataGrid.XForms.SfDataGrid;
           
             
                if (e.OldValue.ToString() != e.NewValue.ToString() && e.NewValue != null&&ItemObject.CurrentItem!=null)
                {
                sfGrid.IsBusy = true;

                var VATItem = ItemObject.CurrentItem as Models.VAT;
                if (e.RowColumnIndex.ColumnIndex == 0)
                    {

                        VATItem.name = e.NewValue.ToString();
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 1)
                    {
                        VATItem.percentage = int.Parse(e.NewValue.ToString());
                    }
                    sfGrid.UpdateDataRow(e.RowColumnIndex.RowIndex);
                    
                    await viewModel.UpdateVat(VATItem);
             sfGrid.Refresh();
                sfGrid.IsBusy = false;
            }

            

        }

        private void sfGrid_ValueChanged(object sender, Syncfusion.SfDataGrid.XForms.ValueChangedEventArgs e)
       {

        }
    }
}