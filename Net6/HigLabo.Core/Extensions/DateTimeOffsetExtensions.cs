using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class DateTimeOffsetExtensions
    {
        public static DateOnly ToDateOnly(this DateTimeOffset value)
        {
            return DateOnly.FromDateTime(value.Date);
        }
        public static DateTimeOffset ToOffset(this DateTimeOffset value, Int32 hours)
        {
            return ToOffset(value, hours, 0);
        }
        public static DateTimeOffset ToOffset(this DateTimeOffset value, Int32 hours, Int32 minutes)
        {
            return value.ToOffset(new TimeSpan(hours, minutes, 0));
        }
        public static DateTimeOffset ChangeTimeZone(this DateTimeOffset value, TimeOnly timeZone)
        {
            return ChangeTimeZone(value, timeZone.ToTimeSpan());
        }
        public static DateTimeOffset ChangeTimeZone(this DateTimeOffset value, TimeSpan timeZone)
        {
            var ts = timeZone - value.Offset;
            var dtime = new DateTimeOffset((value + ts).Ticks, timeZone);
            return dtime;
        }
    }
}
