using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public static class TimeSpanExtensions
{
    public static TimeOnly GetTimeOnly(this TimeSpan value)
    {
        return TimeOnly.FromTimeSpan(value);
    }
    public static string ToTimeZoneText(this TimeSpan value)
    {
        if (value >= TimeSpan.Zero)
        {
            return $"+{value.Hours:D2}:{value.Minutes:D2}";
        }
        else
        {
            return $"-{value.Hours:D2}:{value.Minutes:D2}";
        }
    }
}
