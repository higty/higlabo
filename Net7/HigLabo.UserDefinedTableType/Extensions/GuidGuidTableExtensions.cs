using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class GuidGuidTableExtensions
    {
        public static void AddRecord(this GuidGuidTable table, Guid value0, Guid value1)
        {
            var r = new GuidGuidTable.Record();
            r.Value0 = value0;
            r.Value1 = value1;
            table.AddRecord(r);
        }
    }
}
