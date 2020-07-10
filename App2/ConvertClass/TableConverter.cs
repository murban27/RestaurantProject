using App2.Models;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App2.ConvertClass
{
    public class TableConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (Tables)value;
            if(val.isAvailable==false)
            {
                 return (Style)Application.Current.Resources["SfTableButtonRed"];
            }
            switch ((from s in val.orders where s.orderDetail!=null select s.id).Count()>0)
            {
                case true:
                    return (Style)Application.Current.Resources["SfTableButtonGreen"];
                 
                case false:
                    return (Style)Application.Current.Resources["SfTableButtonRed"];
                default:
                    return (Style)Application.Current.Resources["SfTableButtonRed"];
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
