using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConvTeploobmen.Client.Converters
{
    public class StringToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string strVal)
                throw new InvalidCastException();

            return double.TryParse(strVal, out var numVal) 
                ? numVal 
                : throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double dblVal) 
                throw new InvalidCastException();

            return dblVal.ToString();
        }
    }
}
