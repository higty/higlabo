using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.Mapper.PerformanceTest
{
    public enum TUndefinedABCEnum
    {
        Undefined,
        A,
        B,
        C
    }
    public enum TABCEnum
    {
        A,
        B,
        C
    }

    public class TC0_Members : IComparable<TC0_Members>
    {
        public int Id { get; set; }
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime DateTimeMember { get; set; }
        public DateTimeOffset DateTimeOffsetMember { get; set; }
        public TimeSpan TimeSpanMember { get; set; }

        public Guid GuidMember { get; set; }

        public TUndefinedABCEnum UndefinedEnumMember { get; set; }
        public TABCEnum EnumMember { get; set; }

        public int CompareTo(TC0_Members other)
        {
            return Id.CompareTo(other.Id);
        }

        public static TC0_Members Create()
        {
            var s = new TC0_Members();
            s.Id = 1;
            s.BooleanMember = true;
            s.CharMember = 'a';
            s.SByteMember = 3;
            s.ByteMember = 8;
            s.Int16SMember = -16;
            s.UInt16Member = 16;
            s.Int32Member = -32;
            s.UInt32Member = 32;
            s.Int64Member = -64;
            s.UInt64Member = 64;
            s.SingleMember = 123f;
            s.DoubleMember = 256d;
            s.DecimalMember = 512m;
            s.StringMember = "str";

            s.DateTimeMember = new DateTime(2020, 10, 17);
            s.DateTimeOffsetMember = new DateTimeOffset(s.DateTimeMember, TimeSpan.FromHours(9));
            s.TimeSpanMember = TimeSpan.FromHours(4);
            s.GuidMember = Guid.Parse("6987f244-0ab2-4998-b6cf-39dc2a014ee0");
            s.UndefinedEnumMember = TUndefinedABCEnum.A;
            s.EnumMember = TABCEnum.B;

            return s;
        }
    }
    public class TC0_I0_Members : IComparable<TC0_I0_Members>
    {
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public int CompareTo(TC0_I0_Members other)
        {
            return Int32Member.CompareTo(other.Int32Member);
        }
    }
    public class TC0_I1_Members : IComparable<TC0_I1_Members>
    {
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime DateTimeMember { get; set; }
        public DateTimeOffset DateTimeOffsetMember { get; set; }
        public TimeSpan TimeSpanMember { get; set; }

        public Guid GuidMember { get; set; }

        public TUndefinedABCEnum UndefinedEnumMember { get; set; }
        public TABCEnum EnumMember { get; set; }

        public int CompareTo(TC0_I1_Members other)
        {
            return Int32Member.CompareTo(other.Int32Member);
        }
    }
    public class TC0_I2_Nullable_Members : IComparable<TC0_I2_Nullable_Members>
    {
        public bool? BooleanMember { get; set; }
        public char? CharMember { get; set; }
        public sbyte? SByteMember { get; set; }
        public byte? ByteMember { get; set; }
        public short? Int16SMember { get; set; }
        public ushort? UInt16Member { get; set; }
        public int? Int32Member { get; set; }
        public uint? UInt32Member { get; set; }
        public long? Int64Member { get; set; }
        public ulong? UInt64Member { get; set; }
        public float? SingleMember { get; set; }
        public double? DoubleMember { get; set; }
        public decimal? DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime? DateTimeMember { get; set; }
        public DateTimeOffset? DateTimeOffsetMember { get; set; }
        public TimeSpan? TimeSpanMember { get; set; }

        public Guid? GuidMember { get; set; }

        public TUndefinedABCEnum? UndefinedEnumMember { get; set; }
        public TABCEnum? EnumMember { get; set; }

        public int CompareTo(TC0_I2_Nullable_Members other)
        {
            return (Int32Member != null ? Int32Member.Value : 0)
                .CompareTo(other.Int32Member != null ? other.Int32Member.Value : 0);
        }
    }

    public struct TS0_Members : IComparable<TS0_Members>
    {
        public int Id { get; set; }
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime DateTimeMember { get; set; }
        public DateTimeOffset DateTimeOffsetMember { get; set; }
        public TimeSpan TimeSpanMember { get; set; }

        public Guid GuidMember { get; set; }

        public TUndefinedABCEnum UndefinedEnumMember { get; set; }
        public TABCEnum EnumMember { get; set; }

        public int CompareTo(TS0_Members other)
        {
            return Id.CompareTo(other.Id);
        }
    }
    public struct TS0_I0_Members : IComparable<TS0_I0_Members>
    {
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public int CompareTo(TS0_I0_Members other)
        {
            return Int32Member.CompareTo(other.Int32Member);
        }
    }
    public struct TS0_I1_Members : IComparable<TS0_I1_Members>
    {
        public bool BooleanMember { get; set; }
        public char CharMember { get; set; }
        public sbyte SByteMember { get; set; }
        public byte ByteMember { get; set; }
        public short Int16SMember { get; set; }
        public ushort UInt16Member { get; set; }
        public int Int32Member { get; set; }
        public uint UInt32Member { get; set; }
        public long Int64Member { get; set; }
        public ulong UInt64Member { get; set; }
        public float SingleMember { get; set; }
        public double DoubleMember { get; set; }
        public decimal DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime DateTimeMember { get; set; }
        public DateTimeOffset DateTimeOffsetMember { get; set; }
        public TimeSpan TimeSpanMember { get; set; }

        public Guid GuidMember { get; set; }

        public TUndefinedABCEnum UndefinedEnumMember { get; set; }
        public TABCEnum EnumMember { get; set; }

        public int CompareTo(TS0_I1_Members other)
        {
            return Int32Member.CompareTo(other.Int32Member);
        }
    }
    public struct TS0_I2_Nullable_Members : IComparable<TS0_I2_Nullable_Members>
    {
        public bool? BooleanMember { get; set; }
        public char? CharMember { get; set; }
        public sbyte? SByteMember { get; set; }
        public byte? ByteMember { get; set; }
        public short? Int16SMember { get; set; }
        public ushort? UInt16Member { get; set; }
        public int? Int32Member { get; set; }
        public uint? UInt32Member { get; set; }
        public long? Int64Member { get; set; }
        public ulong? UInt64Member { get; set; }
        public float? SingleMember { get; set; }
        public double? DoubleMember { get; set; }
        public decimal? DecimalMember { get; set; }
        public string StringMember { get; set; }

        public DateTime? DateTimeMember { get; set; }
        public DateTimeOffset? DateTimeOffsetMember { get; set; }
        public TimeSpan? TimeSpanMember { get; set; }

        public Guid? GuidMember { get; set; }

        public TUndefinedABCEnum? UndefinedEnumMember { get; set; }
        public TABCEnum? EnumMember { get; set; }

        public int CompareTo(TS0_I2_Nullable_Members other)
        {
            return (Int32Member != null ? Int32Member.Value : 0)
                .CompareTo(other.Int32Member != null ? other.Int32Member.Value : 0);
        }
    }
    public class TC1
    {
        public TC0_Members I0 { get; set; }
        public TC0_Members I1 { get; set; }
        public TC0_Members I2 { get; set; }
    }

    public class TC1_0
    {
        public TC0_I0_Members I0 { get; set; }
        public TC0_I1_Members I1 { get; set; }
        public TC0_I2_Nullable_Members I2 { get; set; }
    }

    public class TS1
    {
        public TS0_Members I0 { get; set; }
        public TS0_Members I1 { get; set; }
        public TS0_Members I2 { get; set; }
    }

    public class TS1_0
    {
        public TS0_I0_Members I0 { get; set; }
        public TS0_I1_Members I1 { get; set; }
        public TS0_I2_Nullable_Members I2 { get; set; }
    }
}
