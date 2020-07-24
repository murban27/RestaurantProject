using System;
using System.Collections.Generic;
using System.Text;

namespace App2.ViewModels
{
    public class ViewNewVatModel : BaseViewModel
    {
        private Models.VAT vAT { get; set; }
        public Models.VAT Dane
        {
            get { return this.vAT; }
            set { this.vAT = value; OnPropertyChanged();
            }



        }

        public ViewNewVatModel()
        {
            this.vAT = new Models.VAT();
            
        }


    }
}