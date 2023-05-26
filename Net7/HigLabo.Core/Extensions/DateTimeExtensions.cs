using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class DateTimeExtensions
    {
        public static DateOnly ToDateOnly(this DateTime value)
        {
            return DateOnly.FromDateTime(value);
        }
        public static DateOnly? ToDateOnly(this DateTime? value)
        {
            if (value == null) { return null; }
            return DateOnly.FromDateTime(value.Value);
        }
    }
}
