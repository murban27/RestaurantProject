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
    public partial class StolyNewPage : ContentPage

    {
        public Models.Stoly Stul { get; set; }
        public StolyNewPage()
        {
            InitializeComponent();

            Stul = new Models.Stoly { Kapacita = 24 };

            BindingContext = this;

          

        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTable", Stul);
            await Navigation.PopModalAsync();
        }
    }
}