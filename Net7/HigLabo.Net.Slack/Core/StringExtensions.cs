using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public static class StringExtensions
    {
        public static DateTimeOffset? GetDateTimeOffsetFromTs(this String? value)
        {
            if (value == null) { return null; }
            if (value.IsNullOrEmpty()) { return null; }
            var xx = value.Split('.').Select(el => Int32.Parse(el)).ToArray();
            if (xx.Length > 0)
            {
                return UnixDateTime.ToDateTime(xx[0]);
            }
            return null;
        }
    }
}
