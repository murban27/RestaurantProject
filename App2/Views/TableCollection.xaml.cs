﻿using App2.Models;
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
    public partial class TableCollection : ContentPage
    {
        OrderInfoViewModel viewmModel;
        public TableCollection(Tables tables)
        {

            BindingContext = this.viewmModel = new OrderInfoViewModel(tables);
            viewmModel.Sekce();

            InitializeComponent();





        }
       
      async  protected override void OnAppearing()
        {
          

                await viewmModel.GetOrderDetail();
            await viewmModel.GetPolozkas();
           
        }
      

        private void SfTabView_TabItemTapped(object sender, Syncfusion.XForms.TabView.TabItemTappedEventArgs e)
        {

        }

        private void SfTabView_CenterButtonTapped(object sender, EventArgs e)
        {

        }

        private void SfTabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {

        }
    }
}