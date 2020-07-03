using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static partial class StringExtensions
    {
        public static Boolean IsNullOrWhiteSpace(this String text)
        {
            return String.IsNullOrWhiteSpace(text);
        }
        public static Object ToEnum(this String value, Type type)
        {
            return value.ToEnum(type, StringComparison.OrdinalIgnoreCase);
        }
        public static Object ToEnum(this String value, Type type, StringComparison comparisonType)
        {
            return AppEnvironment.Settings.TypeConverter.ToEnum(value, type, comparisonType);
        }
    }
}
