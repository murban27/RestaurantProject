using App2.ViewModels;
using Syncfusion.Data.Extensions;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App2.Views
{

[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewVatPage : ContentPage
    {

        public ViewNewVatModel viewModel { get; set; }


     

        public NewVatPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ViewNewVatModel();

        }

        /// <summary>
        /// Uživatel uložil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();//Zruš stránku
        }


        private async void SaveItem_ClickAsync(object sender, EventArgs e)
        {
     

            MessagingCenter.Send(this, "AddTax", viewModel.Dane);//Pošli zprávu
            await Navigation.PushAsync(new VAT());//Zruš stránku
            Navigation.RemovePage(this);


        }

        private void name_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}