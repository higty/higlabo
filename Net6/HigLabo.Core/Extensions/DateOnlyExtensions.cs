using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class DateOnlyExtensions
    {
        public static DateTime ToDateTime(this DateOnly value)
        {
            return value.ToDateTime(TimeOnly.MinValue);
        }
        public static DateTime? ToDateTime(this DateOnly? value)
        {
            if (value == null) { return null; }
            return value.Value.ToDateTime(TimeOnly.MinValue);
        }
        public static DateTimeOffset ToDateTimeOffset(this DateOnly value, TimeSpan timeZone)
        {
            return new DateTimeOffset(value.ToDateTime(TimeOnly.MinValue), timeZone);
        }
        public static DateTimeOffset? ToDateTimeOffset(this DateOnly? value, TimeSpan timeZone)
        {
            if (value == null) { return null; }
            return new DateTimeOffset(value.Value.ToDateTime(TimeOnly.MinValue), timeZone);
        }
        public static DateTimeOffset ToDateTimeOffset(this DateOnly value, TimeOnly timeZone)
        {
            return new DateTimeOffset(value.ToDateTime(TimeOnly.MinValue), timeZone.ToTimeSpan());
        }
        public static DateTimeOffset? ToDateTimeOffset(this DateOnly? value, TimeOnly timeZone)
        {
            if (value == null) { return null; }
            return new DateTimeOffset(value.Value.ToDateTime(TimeOnly.MinValue), timeZone.ToTimeSpan());
        }
    }
}
