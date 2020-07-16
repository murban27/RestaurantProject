using Android.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App2.ViewModels
{
    public class NewTableItemViewModel : BaseViewModel
    {
        
        private Models.Tables _Table;
        public Models.Tables Table
        {
            get
            {
                return _Table;
            }
            set
            {
                _Table = value;
                this.OnPropertyChanged("Table");
            }
        }
        public int Capacity
        {
            get
            {
                return Table.capacity;
            }
            set
            {
                Table.capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }
        public NewTableItemViewModel()
        {
            _Table = new Models.Tables();
               
        }

    }
}
