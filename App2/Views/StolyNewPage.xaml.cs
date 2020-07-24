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
        public Models.StolyBackup Stul { get; set; }
        public StolyNewPage()
        {
            InitializeComponent();

            Stul = new Models.StolyBackup { Kapacita = 24 };

            BindingContext = this;

          

        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTable", Stul);
            
        }
    }
}