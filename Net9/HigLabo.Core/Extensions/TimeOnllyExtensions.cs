using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public static class TimeOnllyExtensions
{
    public static String ToTimeZoneText(this TimeOnly value)
    {
        if (value.Ticks < 0)
        {
            return $"-{value.Hour.ToString("00")}:{value.Minute.ToString("00")}";
        }
        return $"{value.Hour.ToString("00")}:{value.Minute.ToString("00")}";
    }
}
