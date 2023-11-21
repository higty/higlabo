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

        public static Int32 GetAge(this DateOnly birthDay, TimeOnly timeZone)
        {
            var birthDateTime = new DateTime(birthDay.Year, birthDay.Month, birthDay.Day);
            var now = DateTimeOffset.UtcNow.ChangeTimeZone(timeZone);
            var birthNow = new DateTime(birthDay.Year, now.Month, now.Day);
            if (birthNow < birthDateTime)
            {
                return now.Year - birthNow.Year - 1;
            }
            else
            {
                return now.Year - birthNow.Year;
            }
        }
        public static DateOnly GetPreviouseDate(this DateOnly value, DayOfWeek dayOfWeek)
        {
            for (int i = 0; i < 7; i++)
            {
                var dtime = value.AddDays(-i);
                if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
            }
            throw new InvalidOperationException();
        }
        public static DateOnly GetNextDate(this DateOnly value, DayOfWeek dayOfWeek)
        {
            for (int i = 0; i < 7; i++)
            {
                var dtime = value.AddDays(i);
                if (dtime.DayOfWeek == dayOfWeek) { return dtime; }
            }
            throw new InvalidOperationException();
        }
    }
}
