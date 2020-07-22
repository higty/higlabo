using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class GuidExtensions
    {
        public static String ToBase64String(this Guid value)
        {
            var bb = value.ToByteArray();
            var s = Convert.ToBase64String(bb);
            return s.Replace("/", "_").Replace("+", "-").Substring(0, 22);
        }
    }
}
