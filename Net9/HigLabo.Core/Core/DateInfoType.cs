namespace HigLabo.Core;
public enum DateInfoType
{
    YearMonthDay,
    YearMonth,
    Year,
}
public static class DateInfoTypeExtensions
{
    public static string ToString(this DateOnly date, DateInfoType dateInfoType, DateTimeFormat format)
    {
        return ToString(date, dateInfoType, format, "/");
    }
    public static string ToString(this DateOnly date, DateInfoType dateInfoType, DateTimeFormat format, string separator)
    {
        return ToString(dateInfoType, date, format, separator);
    }
    public static string ToString(this DateInfoType dateInfoType, DateOnly date, DateTimeFormat format)
    {
        return ToString(dateInfoType, date, format, "/");
    }
    public static string ToString(this DateInfoType dateInfoType, DateOnly date, DateTimeFormat format, string separator)
    {
        switch (dateInfoType)
        {
            case DateInfoType.YearMonthDay: return date.ToString(format, separator);
            case DateInfoType.YearMonth:
                switch (format)
                {
                    case DateTimeFormat.yyyyMMdd: return $"{date.Year.ToString("0000")}{separator}{date.Month.ToString("00")}";
                    case DateTimeFormat.MMddyyyy: 
                    case DateTimeFormat.ddMMyyyy:
                        return $"{date.Month.ToString("00")}{separator}{date.Year.ToString("0000")}";
                    default: throw SwitchStatementNotImplementException.Create(dateInfoType);
                }
            case DateInfoType.Year: return date.ToString("yyyy");
            default: throw SwitchStatementNotImplementException.Create(dateInfoType);
        }
    }
}
