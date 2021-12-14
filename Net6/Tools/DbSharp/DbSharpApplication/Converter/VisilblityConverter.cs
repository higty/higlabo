using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace HigLabo.Wpf.Converter
{
    public class BooleanVisibilityConverter : System.Windows.Data.IValueConverter
    {
        public Visibility FalseVisibility { get; set; }
        public BooleanVisibilityConverter()
        {
            this.FalseVisibility = Visibility.Collapsed;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }
            Boolean bl = false;
            if (Boolean.TryParse(value.ToString(), out bl) == true)
            {
                if (bl == true)
                {
                    return Visibility.Visible.ToString();
                }
                else
                {
                    return this.FalseVisibility.ToString();
                }
            }
            return this.FalseVisibility;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                var v = (Visibility)value;
                return v == Visibility.Visible;
            }
            return null;
        }
    }
}
