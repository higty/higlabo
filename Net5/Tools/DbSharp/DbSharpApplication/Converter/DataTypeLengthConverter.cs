using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.IO;

namespace HigLabo.DbSharpApplication
{
    public class DataTypeLengthConverter : System.Windows.Data.IValueConverter
    {
        public DataTypeLengthConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }

            Int32 x = 0;
            if (Int32.TryParse(value.ToString(), out x) == true)
            {
                if (x == -1) { return "max"; }
                return x;
            }
            throw new InvalidOperationException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
