using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core;

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
		public static DateTimeOffset TrimSeconds(this DateTime value)
		{
			return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
		}
    public static DateTime GetPreviouseDate(this DateTime value, DayOfWeek dayOfWeek)
    {
        for (int i = 0; i < 7; i++)
        {
            var dtime = value.AddDays(-i);
            if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
        }
        throw new InvalidOperationException();
    }
    public static DateTime GetNextDate(this DateTime value, DayOfWeek dayOfWeek)
    {
        for (int i = 0; i < 7; i++)
        {
            var dtime = value.AddDays(i);
            if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
        }
        throw new InvalidOperationException();
    }
}
