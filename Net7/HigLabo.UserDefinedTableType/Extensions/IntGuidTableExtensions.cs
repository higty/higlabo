using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class IntGuidTableExtensions
    {
        public static void AddRecord(this IntGuidTable table, Int32 value0, Guid value1)
        {
            var r = new IntGuidTable.Record();
            r.Value0 = value0;
            r.Value1 = value1;
            table.AddRecord(r);
        }
    }
}
