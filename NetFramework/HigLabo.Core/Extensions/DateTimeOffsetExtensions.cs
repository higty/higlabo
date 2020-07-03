using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset ToOffset(this DateTimeOffset value, Int32 hours)
        {
            return ToOffset(value, hours, 0);
        }
        public static DateTimeOffset ToOffset(this DateTimeOffset value, Int32 hours, Int32 minutes)
        {
            return value.ToOffset(new TimeSpan(hours, minutes, 0));
        }
    }
}
