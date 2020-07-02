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
    public class TimeOrderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Stul = (Tables)value;
            if(Stul.orders==null)
            {
                return " ";
            }
            else if(Stul.orders.Where(x=>x.startTime!=null && x.endTime==null).FirstOrDefault()!=null)
                {
                return string.Format($"{Stul.orders.Select(s => s.startTime).FirstOrDefault().ToString()}");

            }
            else
            {
                return " ";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
