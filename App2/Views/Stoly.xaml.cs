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

    public partial class Stoly : ContentPage
    {
        private StolyViewModel stoly;
        public Stoly()
        {
            
            InitializeComponent();
            BindingContext = stoly = new StolyViewModel();

           
        }
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new StolyNewPage()));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (stoly.Stolies.Count == 0)
                stoly.LoadItemsCommand.Execute(null);
        }


    }
}