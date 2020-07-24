using App2.Models;
using App2.ViewModels;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTablePage : ContentPage
    {
        private ViewModels.TableesViewModel viewModel { get; set; }
        public EditTablePage()
        {

            InitializeComponent();
            BindingContext = viewModel = new TableesViewModel();
            MessagingCenter.Subscribe<NewTable, Models.Tables>(this, "AddTable", async (obj, item) =>
            {
                var newItem = item as Models.Tables;
                try
                {
      
                    //Přidej do listu
                    await viewModel.AddTableAsync(newItem,true);
                    IsBusy = true;

                    await Navigation.PopModalAsync();
                    IsBusy = false;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            });
            }

        

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.GetTask();



        }

        private async Task sfgrid_CurrentCellEndEditAsync(object sender, Syncfusion.SfDataGrid.XForms.GridCurrentCellEndEditEventArgs e)
        {

            await Task.Delay(100);
            var newCellValue = sfgrid.GetCellValue(viewModel.Stolies[e.RowColumnIndex.RowIndex - 1], sfgrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName);
        }

        private async void sfgrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs e)
        {if (e.OldValue.ToString()!=e.NewValue.ToString())
            {
                sfgrid.IsBusy = true;
                await Task.Delay(100);
                var newCellValue = sfgrid.GetCellValue(viewModel.Stolies[e.RowColumnIndex.RowIndex - 1], sfgrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName);
                var data = sfgrid.GetRowGenerator().Items.FirstOrDefault(x => x.RowIndex == e.RowColumnIndex.RowIndex).RowData as Models.Tables;
                var s = data;
              await viewModel.UpdateTableAsync(s);
                sfgrid.IsBusy = false;

                sfgrid.Refresh();
     

               
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTable()); ///Přidej navigáční stránku
            Navigation.RemovePage(this);
        }
    }
}