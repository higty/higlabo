using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class UnixDateTime
    {
        public static DateTime? ToDateTime(String milliSeconds)
        {
            var x = milliSeconds.ToInt32();
            if (x == null) { return null; }
            var ts = new TimeSpan(0, 0, 0, x.Value);
            return DateTime.UnixEpoch + ts;
        }
        public static DateTime ToDateTime(Int32 milliSeconds)
        {
            var ts = new TimeSpan(0, 0, 0, milliSeconds);
            return DateTime.UnixEpoch + ts;
        }
        public static DateTime ToDateTime(double milliSeconds)
        {
            var ts = TimeSpan.FromMicroseconds(milliSeconds);
            return DateTime.UnixEpoch + ts;
        }
    }
}
