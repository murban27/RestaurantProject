using App2.ViewModels;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        private EditItemsPageViewModel ViewModel;
        public EditItemPage()
        {
            InitializeComponent();
           BindingContext= ViewModel = new EditItemsPageViewModel();
        }
        protected async override void OnAppearing()
        {
            //Po načtení najdi hodnoty
            base.OnAppearing();
            
          await  ViewModel.GetPolozkas();
         await  ViewModel.GetVatService();
            await ViewModel.GetSections();
            await Task.Delay(500);
            await ViewModel.GetEditItems();
 

            await ViewModel.FillVatAndSectiontNames();



        }

        private async void sfgrid_CurrentCellEndEdit(object sender, Syncfusion.SfDataGrid.XForms.GridCurrentCellEndEditEventArgs e)
        {
            await Task.Delay(100);
            sfgrid.IsBusy = true;


            var newCellValue = sfgrid.GetCellValue(ViewModel.EditItems[e.RowColumnIndex.RowIndex - 1], sfgrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName);
            var data = sfgrid.GetRowGenerator().Items.FirstOrDefault(x => x.RowIndex == e.RowColumnIndex.RowIndex).RowData as Models.EditItem;
            var s = data;
            //  await viewModel.UpdateTableAsync(s);

            sfgrid.UpdateDataRow(e.RowColumnIndex.RowIndex);
            sfgrid.Refresh();
            sfgrid.IsBusy = false;

        }
    }
}