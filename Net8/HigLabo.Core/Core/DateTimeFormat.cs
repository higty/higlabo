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
    }
    public static class DateTimeFormatExtensions
    {
        public static string GetFormat(this DateTimeFormat format)
        {
            switch (format)
            {
                case DateTimeFormat.yyyyMMdd: return "yyyy/MM/dd";
                case DateTimeFormat.MMddyyyy: return "MM/dd/yyyy";
                case DateTimeFormat.ddMMyyyy: return "dd/MM/yyyy";
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
        public static string ToString(this DateTimeOffset value, DateTimeFormat format, DateTimePart dateTimePart)
        {
            return ToString(value, format, dateTimePart, false);
        }
        public static string ToString(this DateTimeOffset value, DateTimeFormat format, DateTimePart dateTimePart, bool displayDayOfWeek)
        {
            if (displayDayOfWeek)
            {
                switch (dateTimePart)
                {
                    case DateTimePart.Date: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd")}";
                    case DateTimePart.MonthDay: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd")}";
                    case DateTimePart.DateHourMinute: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd HH:mm")}";
                    case DateTimePart.DateHourMinuteSecond: return $"{value.ToString(format.GetFormat())}{value.ToString("ddd HH:mm:ss")}";
                    case DateTimePart.MonthDayHourMinute: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd HH:mm")}";
                    case DateTimePart.MonthDayHourMinuteSecond: return $"{value.ToString(format.GetMonthDayFormat())}{value.ToString("ddd HH:mm:ss")}";
                    default: throw new InvalidOperationException();
                }
            }
            else
            {
                switch (dateTimePart)
                {
                    case DateTimePart.Date: return value.ToString(format.GetFormat());
                    case DateTimePart.MonthDay: return value.ToString(format.GetMonthDayFormat());
                    case DateTimePart.DateHourMinute: return $"{value.ToString(format.GetFormat())} {value.ToString("HH:mm")}";
                    case DateTimePart.DateHourMinuteSecond: return $"{value.ToString(format.GetFormat())} {value.ToString("HH:mm:ss")}";
                    case DateTimePart.MonthDayHourMinute: return $"{value.ToString(format.GetMonthDayFormat())} {value.ToString("HH:mm")}";
                    case DateTimePart.MonthDayHourMinuteSecond: return $"{value.ToString(format.GetMonthDayFormat())} {value.ToString("HH:mm:ss")}";
                    default: throw new InvalidOperationException();
                }
            }
        }
    }
}
