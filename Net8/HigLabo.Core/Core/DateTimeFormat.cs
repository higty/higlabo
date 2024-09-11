namespace HigLabo.Core
{
    public enum DateTimeFormat
    {
        yyyyMMdd,
        MMddyyyy,
        ddMMyyyy,
    }
    public enum DateTimePart
    {
        Date,
        MonthDay,
        DateHourMinute,
        DateHourMinuteSecond,
        MonthDayHourMinute,
        MonthDayHourMinuteSecond,

        DateDayOfWeek,
        MonthDayDayOfWeek,
        DateDayOfWeekHourMinute,
        DateDayOfWeekHourMinuteSecond,
        MonthDayDayOfWeekHourMinute,
        MonthDayDayOfWeekHourMinuteSecond,
    }
    public static class DateTimeFormatExtensions
    {
        public static string GetFormat(this DateTimeFormat format)
        {
            return GetFormat(format, "/");
        }
        public static string GetFormat(this DateTimeFormat format, string separator)
        {
            switch (format)
            {
                case DateTimeFormat.yyyyMMdd: return $"yyyy{separator}MM{separator}dd";
                case DateTimeFormat.MMddyyyy: return $"MM{separator}dd{separator}yyyy";
                case DateTimeFormat.ddMMyyyy: return $"dd{separator}MM{separator}yyyy";
                default: return "";
            }
        }
        public static string GetMonthDayFormat(this DateTimeFormat format)
        {
            switch (format)
            {
                case DateTimeFormat.yyyyMMdd: return "MM/dd";
                case DateTimeFormat.MMddyyyy: return "MM/dd";
                case DateTimeFormat.ddMMyyyy: return "dd/MM";
                default: return "";
            }
        }
        public static string ToString(this DateOnly value, DateTimeFormat format)
        {
            return value.ToString(format.GetFormat());
        }
        public static string ToString(this DateTime value, DateTimeFormat format)
        {
            return value.ToString(format.GetFormat());
        }
        public static string ToString(this DateTimeOffset value, DateTimeFormat format, DateTimePart dateTimePart)
        {
            switch (dateTimePart)
            {
                case DateTimePart.Date: return value.ToString(format.GetFormat());
                case DateTimePart.MonthDay: return value.ToString(format.GetMonthDayFormat());
                case DateTimePart.DateHourMinute: return $"{value.ToString(format.GetFormat())} {value.ToString("HH:mm")}";
                case DateTimePart.DateHourMinuteSecond: return $"{value.ToString(format.GetFormat())} {value.ToString("HH:mm:ss")}";
                case DateTimePart.MonthDayHourMinute: return $"{value.ToString(format.GetMonthDayFormat())} {value.ToString("HH:mm")}";
                case DateTimePart.MonthDayHourMinuteSecond: return $"{value.ToString(format.GetMonthDayFormat())} {value.ToString("HH:mm:ss")}";
                case DateTimePart.DateDayOfWeek: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd")}";
                case DateTimePart.MonthDayDayOfWeek: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd")}";
                case DateTimePart.DateDayOfWeekHourMinute: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd HH:mm")}";
                case DateTimePart.DateDayOfWeekHourMinuteSecond: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd HH:mm:ss")}";
                case DateTimePart.MonthDayDayOfWeekHourMinute: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd HH:mm")}";
                case DateTimePart.MonthDayDayOfWeekHourMinuteSecond: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd HH:mm:ss")}";
                default: throw new InvalidOperationException();
            }
        }
    }
}
