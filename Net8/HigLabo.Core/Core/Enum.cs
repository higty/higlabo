using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class Enum<T>
            where T : Enum
    {
        public static T Parse(string value)
        {
            return Enum<T>.Parse(value, true);
        }
        public static T Parse(string value, bool ignoreCase)
        {
            var tp = CheckEnumType();
            return (T)Enum.Parse(tp, value, ignoreCase);
        }
        public static bool TryParse(string value, out T? returnedValue)
        {
            return Enum<T>.TryParse(value, true, out returnedValue);
        }
        public static bool TryParse(string value, bool ignoreCase, out T? returnedValue)
        {
            var tp = CheckEnumType();
            try
            {
                returnedValue = (T)Enum.Parse(tp, value, ignoreCase);
                return true;
            }
            catch
            {
                returnedValue = default(T?);
                return false;
            }
        }

        private static Type CheckEnumType()
        {
            Type tp = typeof(T);
#if !NETFX_CORE && !PCL
            if (tp.IsEnum == false) { throw new ArgumentException("T must be Enum type."); }
#endif
            return tp;
        }
    }
}
