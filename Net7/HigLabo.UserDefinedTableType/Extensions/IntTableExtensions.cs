using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class IntTableExtensions
    {
        public static void AddRecord(this IntTable table, Int32 value)
        {
            var r = new IntTable.Record();
            r.Value = value;
            table.AddRecord(r);
        }
    }
}
