using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace HigLabo.Wpf.Converter
{
    public class BooleanTextConverter : System.Windows.Data.IValueConverter
    {
        public String ValueWhenFalse { get; set; }
        public String ValueWhenTrue { get; set; }
        public BooleanTextConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean bl = false;
            if (Boolean.TryParse(value.ToString(), out bl) == true)
            {
                if (bl == true)
                {
                    return this.ValueWhenTrue;
                }
                else
                {
                    return this.ValueWhenFalse;
                }
            }
            throw new InvalidOperationException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
