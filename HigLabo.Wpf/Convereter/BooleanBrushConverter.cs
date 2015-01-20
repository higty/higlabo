using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Media;

namespace HigLabo.Wpf.Converter
{
    public class BooleanBrushConverter : System.Windows.Data.IValueConverter
    {
        public Brush ValueWhenFalse { get; set; }
        public Brush ValueWhenTrue { get; set; }
        public BooleanBrushConverter()
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
