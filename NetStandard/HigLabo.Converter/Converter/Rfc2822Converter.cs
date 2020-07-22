using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class Rfc2822Converter
    {
        public DateTimeOffset Parse(String input)
        {
            var d = this.TryParse(input);
            if (d == null) { throw new FormatException(); }
            return d.Value;
        }
        public DateTimeOffset? TryParse(String input)
        {
            DateTimeOffset dtime = DateTimeOffset.Now;
            TimeSpan ts = TimeSpan.Zero;

            //Tue, 25 Oct 2011 20:44:24
            if (DateTimeOffset.TryParse(input, out dtime) == true) { return dtime; }

            var firstColonIndex = input.IndexOf(":", StringComparison.OrdinalIgnoreCase);
            if (firstColonIndex == -1) { return null; }
            var timezoneStartIndex = input.IndexOf(" ", firstColonIndex, StringComparison.OrdinalIgnoreCase);

            var dateTimePart = input.Substring(0, timezoneStartIndex);//Tue, 25 Oct 2011 20:44:24
            if (DateTimeOffset.TryParse(dateTimePart, out dtime) == false) { return null; }
            //(CST) or CST or +0600 (Three letter military timezone)
            var timeZonePart = input.Substring(timezoneStartIndex + 1).Trim();//+0600 or GMT (Three letter military timezone)

            //Бывает еще вот такая ерунда Thu, 10 Apr 2014 04:27:37 +0000 (GMT+00:00)
            var timezoneEndIndex = timeZonePart.IndexOf(" ", StringComparison.OrdinalIgnoreCase);
            if (timezoneEndIndex != -1)
                timeZonePart = timeZonePart.Substring(0, timezoneEndIndex);

            if (timeZonePart[0] == '+' || timeZonePart[0] == '-')
            {
                if (timeZonePart.Length < 5) { throw new FormatException(); }
                var hour = Convert.ToInt32(timeZonePart.Substring(1, 2));
                var minute = Convert.ToInt32(timeZonePart.Substring(3, 2));
                if (timeZonePart[0] == '-')
                {
                    hour = -hour;
                    minute = -minute;
                }
                return new DateTimeOffset(dtime.DateTime, new TimeSpan(hour, minute, 0));
            }
            if (timeZonePart[0] == '(')
            {
                timeZonePart = timeZonePart.TrimStart('(');
                timeZonePart = timeZonePart.TrimEnd(')');
            }
            switch (timeZonePart)
            {
                case "A": ts = new TimeSpan(1, 0, 0); break;
                case "B": ts = new TimeSpan(2, 0, 0); break;
                case "C": ts = new TimeSpan(3, 0, 0); break;
                case "D": ts = new TimeSpan(4, 0, 0); break;
                case "E": ts = new TimeSpan(5, 0, 0); break;
                case "F": ts = new TimeSpan(6, 0, 0); break;
                case "G": ts = new TimeSpan(7, 0, 0); break;
                case "H": ts = new TimeSpan(8, 0, 0); break;
                case "I": ts = new TimeSpan(9, 0, 0); break;
                case "K": ts = new TimeSpan(10, 0, 0); break;
                case "L": ts = new TimeSpan(11, 0, 0); break;
                case "M": ts = new TimeSpan(12, 0, 0); break;
                case "N": ts = new TimeSpan(-1, 0, 0); break;
                case "O": ts = new TimeSpan(-2, 0, 0); break;
                case "P": ts = new TimeSpan(-3, 0, 0); break;
                case "Q": ts = new TimeSpan(-4, 0, 0); break;
                case "R": ts = new TimeSpan(-5, 0, 0); break;
                case "S": ts = new TimeSpan(-6, 0, 0); break;
                case "T": ts = new TimeSpan(-7, 0, 0); break;
                case "U": ts = new TimeSpan(-8, 0, 0); break;
                case "V": ts = new TimeSpan(-9, 0, 0); break;
                case "W": ts = new TimeSpan(-10, 0, 0); break;
                case "X": ts = new TimeSpan(-11, 0, 0); break;
                case "Y": ts = new TimeSpan(-12, 0, 0); break;
                case "Z":
                case "UT":
                case "GMT": break;    // It's UTC
                case "EST": ts = new TimeSpan(5, 0, 0); break;
                case "EDT": ts = new TimeSpan(4, 0, 0); break;
                case "CST": ts = new TimeSpan(6, 0, 0); break;
                case "CDT": ts = new TimeSpan(5, 0, 0); break;
                case "MST": ts = new TimeSpan(7, 0, 0); break;
                case "MDT": ts = new TimeSpan(6, 0, 0); break;
                case "PST": ts = new TimeSpan(8, 0, 0); break;
                case "PDT": ts = new TimeSpan(7, 0, 0); break;
                case "JST": ts = new TimeSpan(9, 0, 0); break;
                default: throw new FormatException("invalid time zone");
            }
            return new DateTimeOffset(dtime.DateTime, ts); 
        }
    }
}
