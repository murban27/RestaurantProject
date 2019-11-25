﻿using App2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App2.ConvertClass
{
    public class TableConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (Stoly)value;
            switch (val.Obsazeno)
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
