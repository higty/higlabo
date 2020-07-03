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
        TimeTZ = 31
    }
}
