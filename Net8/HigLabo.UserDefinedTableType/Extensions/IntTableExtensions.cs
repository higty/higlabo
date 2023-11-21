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
        public static void AddRecords(this IntTable table, IEnumerable<Int32> values)
        {
            foreach (var value in values)
            {
                var r = new IntTable.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
    }
}
