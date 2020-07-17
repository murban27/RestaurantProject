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
    public partial class NewTable : ContentPage
    {
        public ViewModels.NewTableItemViewModel NewTableItemViewModel { get; set; }
        public NewTable()
        {
            InitializeComponent();
            BindingContext = NewTableItemViewModel = new ViewModels.NewTableItemViewModel();


        }

        private void dataForm_AutoGeneratingDataFormItem(object sender, Syncfusion.XForms.DataForm.AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem.Name == "capacity")
            {
                e.DataFormItem.LabelText = "Kapacita";
                e.DataFormItem.IsVisible = true;
                
            }
            else
            {
                e.DataFormItem.IsVisible = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(100);
            if (NewTableItemViewModel.Table.capacity > 0)
            {

                MessagingCenter.Send(this, "AddTable", NewTableItemViewModel.Table);//Pošli zprávu
                await Navigation.PushAsync(new EditTablePage());//Otevři edit stránku
                Navigation.RemovePage(this);//Zruš stránku
            }
            else
            {
               await DisplayAlert("Error while creating", "Please fill capacity", "Cancel");
            }

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}