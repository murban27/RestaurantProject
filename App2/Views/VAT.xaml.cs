using App2.ViewModels;
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
    public partial class VAT : ContentPage
    {
        public VatSettingsViewModel viewModel;
        public VAT()
        {

            InitializeComponent();
            BindingContext = viewModel = new VatSettingsViewModel();
     

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Dane.Count() == 0)
                viewModel.Command.Execute(null);



        } 
    }
}