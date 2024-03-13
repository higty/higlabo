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

        /// <summary>
        /// Get age of now in specified timezone.
        /// </summary>
        /// <param name="birthDay"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static Int32 GetAge(this DateOnly birthDay, TimeOnly timeZone)
        {
            var now = DateTimeOffset.UtcNow.ChangeTimeZone(timeZone);
            return GetAge(birthDay, now);
        }
        /// <summary>
        /// Get age of specified datetime.
        /// </summary>
        /// <param name="birthDay"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static Int32 GetAge(this DateOnly birthDay, DateTimeOffset dateTime)
        {
            var date = dateTime.ToDateOnly();

            if (DateTime.IsLeapYear(date.Year) == false)
            {
                if (birthDay.Month == 2 && birthDay.Day == 29)
                {
                    if (date < new DateOnly(date.Year, 3, 1))
                    {
                        return date.Year - birthDay.Year - 1;
                    }
                    else
                    {
                        return date.Year - birthDay.Year;
                    }
                }
            }
            {
                if (date < new DateOnly(date.Year, birthDay.Month, birthDay.Day))
                {
                    return date.Year - birthDay.Year - 1;
                }
                else
                {
                    return date.Year - birthDay.Year;
                }
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
