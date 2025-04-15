using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core;

public static class DateTimeOffsetExtensions
{
    public static string ToIso8601String(this DateTimeOffset value)
    {
        return value.ToString("yyyy-MM-ddTHH:mm:sszzz");
    }
    public static DateTimeOffset GetPreviouseDate(this DateTimeOffset value, DayOfWeek dayOfWeek)
    {
        for (int i = 0; i < 7; i++)
        {
            var dtime = value.AddDays(-i);
            if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
        }
        throw new InvalidOperationException();
    }
    public static DateTimeOffset GetNextDate(this DateTimeOffset value, DayOfWeek dayOfWeek)
    {
        for (int i = 0; i < 7; i++)
        {
            var dtime = value.AddDays(i);
            if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
        }
        throw new InvalidOperationException();
    }
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
    public static DateTimeOffset ChangeTimeZone(this DateTimeOffset value, Int32 hour)
    {
        return ChangeTimeZone(value, new TimeSpan(hour, 0, 0));
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
    public static DateTimeOffset TrimSeconds(this DateTimeOffset value)
    {
        return new DateTimeOffset(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, value.Offset);
    }
}
