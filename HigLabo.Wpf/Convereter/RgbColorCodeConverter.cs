using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace HigLabo.Wpf.Converter
{
    public class RgbColorCodeConverter : System.Windows.Data.IValueConverter
    {
        public RgbColorCodeConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return ""; }

            return "#" + value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
