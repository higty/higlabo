using Google.Apis.Bigquery.v2.Data;
using System.Globalization;

namespace HigLabo.Core;

public static class QueryResponseExtensions
{
    public static readonly DateTime UnixEpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static readonly DateTimeOffset UnixEpochDateTimeOffset = new DateTimeOffset(UnixEpochDateTime);

    public static List<Dictionary<String, Object?>> CreateRecords(this QueryResponse response)
    {
        var l = new List<Dictionary<String, Object?>>();
        var res = response;
        if (res == null || res.Schema == null || res.Schema.Fields == null) { return l; }

        var cc = res.Schema.Fields.ToList();
        if (res.Rows != null)
        {
            foreach (var item in res.Rows)
            {
                var d = new Dictionary<String, Object?>();
                var oo = item.F;

                for (int i = 0; i < cc.Count; i++)
                {
                    var c = cc[i];
                    var columnName = c.Name;
                    var v = oo[i]?.V?.ToString() ?? "";

                    if (c.Type == "DATE")
                    {
                        if (DateOnly.TryParse(v, out var date))
                        {
                            d[columnName] = date;
                        }
                    }
                    else if (c.Type == "DATETIME")
                    {
                        d[columnName] = v.ToDateTime();
                    }
                    else if (c.Type == "TIMESTAMP")
                    {
                        if (Double.TryParse(v, NumberStyles.AllowExponent | NumberStyles.Float, null, out var dValue))
                        {
                            d[columnName] = FromBigQueryTimestamp(dValue * 1000);
                        }
                        else
                        {
                            d[columnName] = null;
                        }
                    }
                    else if (c.Type == "NUMERIC")
                    {
                        d[columnName] = v.ToDecimal();
                    }
                    else if (c.Type == "FLOAT64")
                    {
                        d[columnName] = v.ToDouble();
                    }
                    else if (c.Type == "INT64")
                    {
                        d[columnName] = v.ToInt64();
                    }
                    else if (c.Type == "BOOL")
                    {
                        d[columnName] = v.ToBoolean();
                    }
                    else
                    {
                        d[columnName] = v;
                    }
                }
                l.Add(d);
            }
        }
        return l;
    }
    private static DateTimeOffset FromBigQueryTimestamp(double timestamp)
    {
        var date = UnixEpochDateTimeOffset.AddMilliseconds(timestamp);
        return date;
    }
}
