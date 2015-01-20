using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class EnumExtensions
    {
        public static String ToStringFromEnum<T>(this Nullable<T> value)
         where T : struct
        {
            if (value.HasValue == true) return ToStringFromEnum(value.Value);
            return "";
        }
        public static String ToStringFromEnum<T>(this T value)
            where T : struct
        {
            return value.ToString();
        }
    }
}
