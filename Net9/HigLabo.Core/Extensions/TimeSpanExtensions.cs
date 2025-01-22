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
}
