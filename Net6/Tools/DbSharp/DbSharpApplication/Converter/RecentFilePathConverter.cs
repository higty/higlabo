using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.IO;

namespace HigLabo.Wpf.Converter
{
    public class RecentFilePathConverter : System.Windows.Data.IValueConverter
    {
        public RecentFilePathConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }

            String[] ss = value.ToString().Split('\\', '/');
            if (ss.Length < 5)
            {
                return value.ToString();
            }
            return String.Format("{0}\\...\\{1}\\{2}\\{3}", ss[0], ss[ss.Length - 3], ss[ss.Length - 2], ss[ss.Length - 1]);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
