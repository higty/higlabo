using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public static class DayOfWeekExtensions
{
    public static int GetSortOrder(this DayOfWeek dayOfWeek, DayOfWeek startDayOfWeek)
    {
        return ((int)dayOfWeek + 7 - (int)startDayOfWeek) % 7;
    }
}
