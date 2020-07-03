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
    public class StringBrushConverter : System.Windows.Data.IValueConverter
    {
        public Dictionary<String, Brush> MappingData { get; private set; }
        public StringBrushConverter()
        {
            this.MappingData = new Dictionary<string, Brush>();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }

            String key = value.ToString();

            if (this.MappingData.ContainsKey(key) == true)
            {
                return this.MappingData[key];
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
