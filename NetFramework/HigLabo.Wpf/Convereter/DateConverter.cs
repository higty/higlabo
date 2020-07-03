using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace HigLabo.Wpf.Converter
{
    public class DateConverter : System.Windows.Data.IValueConverter
    {
        public String Format { get; set; }
        public String TextWhenNull { get; set; }
        public DateConverter()
        {
            this.Format = "yyyy/MM/dd";
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return this.TextWhenNull; }
            var tp = value.GetType();
            if (tp != typeof(DateTime) &&
                tp != typeof(DateTimeOffset))
            {
                throw new ArgumentException("Value must be of type DateTime or DateTimeOffset.", "value");
            }

            if (tp == typeof(DateTime))
            {
                var dtime = (DateTime)value;
                return dtime.ToString(this.Format);
            }
            else if (tp == typeof(DateTimeOffset))
            {
                var dtime = (DateTimeOffset)value;
                return dtime.ToString(this.Format);
            }
            throw new ArgumentException("Value must be of type DateTime or DateTimeOffset.", "value");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String text = value as String;
            {
                DateTimeOffset dtime;
                if (DateTimeOffset.TryParse(text, out dtime))
                {
                    return dtime;
                }
            }
            {
                DateTime dtime;
                if (DateTime.TryParse(text, out dtime))
                {
                    return dtime;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
