using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp;

public static class GuidTableExtensions
{
    public static void AddRecord(this GuidTable table, Guid value)
    {
        var r = new GuidTable.Record();
        r.Value = value;
        table.AddRecord(r);
    }
    public static void AddRecords(this GuidTable table, IEnumerable<Guid> values)
    {
        foreach (var value in values)
        {
            var r = new GuidTable.Record();
            r.Value = value;
            table.AddRecord(r);
        }
    }
}
