using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public enum NpgsqlDbType
    {
        Array = int.MinValue,
        Bigint = 1,
        Boolean = 2,
        Box = 3,
        Bytea = 4,
        Circle = 5,
        Char = 6,
        Date = 7,
        Double = 8,
        Integer = 9,
        Line = 10,
        LSeg = 11,
        Money = 12,
        Numeric = 13,
        Path = 14,
        Point = 15,
        Polygon = 16,
        Real = 17,
        Smallint = 18,
        Text = 19,
        Time = 20,
        Timestamp = 21,
        Varchar = 22,
        Refcursor = 23,
        Inet = 24,
        Bit = 25,
        TimestampTZ = 26,
        Uuid = 27,
        Xml = 28,
        Oidvector = 29,
        Interval = 30,
        TimeTZ = 31,
        TimeTz = 31,
        Name = 32,
        Abstime = 33,
        MacAddr = 34,
        Json = 35,
        Jsonb = 36,
        Hstore = 37,
        InternalChar = 38,
        Varbit = 39,
        Unknown = 40,
        Oid = 41,
        Xid = 42,
        Cid = 43,
        Cidr = 44,
        TsVector = 45,
        TsQuery = 46,
        Regtype = 49,
        Geometry = 50,
        Citext = 51,
        Int2Vector = 52,
        Tid = 53,
        MacAddr8 = 54,
        Geography = 55,
        Regconfig = 56,
        Range = 1073741824
    }

}