using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class ISO8601Parser
    {
        public TimeSpan Parse(String duration)
        {
            TimeSpan ts = TimeSpan.Zero;
            var ss = "";
            for (int i = 0; i < duration.Length; i++)
            {
                var c = duration[i];

                if (Char.IsDigit(c) == true)
                {
                    ss += c;
                }
                else
                {
                    if (c == 'H') ts += TimeSpan.FromHours(Int32.Parse(ss));
                    else if (c == 'M') ts += TimeSpan.FromMinutes(Int32.Parse(ss));
                    else if (c == 'S') ts += TimeSpan.FromSeconds(Int32.Parse(ss));
                    ss = "";
                }
            }
            return ts;
        }
    }
}
