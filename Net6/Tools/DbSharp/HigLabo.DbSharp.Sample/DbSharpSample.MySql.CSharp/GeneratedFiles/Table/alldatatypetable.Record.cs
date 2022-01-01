//Generated at 2022/01/01 11:52:05 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Text;
using System.ComponentModel;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class alldatatypetable
    {
        public partial class Record : TableRecord<Record>, IRecord
        {
            private Int64 _PrimaryKeyColumn;
            private DateTime _TimestampColumn;
            private String _CharColumn = null;
            private String _VarCharColumn = null;
            private Boolean? _BitColumn;
            private SByte? _TinyIntColumn;
            private Int16? _SmallIntColumn;
            private Int32? _MediumIntColumn;
            private Int32? _IntColumn;
            private Int64? _BigIntColumn;
            private Byte? _TinyIntUnsignedColumn;
            private UInt16? _SmallIntUnsignedColumn;
            private UInt32? _MediumIntUnsignedColumn;
            private UInt32? _IntUnsignedColumn;
            private UInt64? _BigIntUnsignedColumn;
            private Single? _FloatColumn;
            private Double? _DoubleColumn;
            private Decimal? _DecimalColumn;
            private Decimal? _NumericColumn;
            private DateTime? _DateColumn;
            private DateTime? _DateTimeColumn;
            private TimeSpan? _TimeColumn;
            private Int32? _YearColumn;
            private Byte[] _BinaryColumn;
            private Byte[] _VarBinaryColumn;
            private Byte[] _TinyBlobColumn;
            private Byte[] _MediumBlobColumn;
            private Byte[] _BlobColumn;
            private Byte[] _LongBlobColumn;
            private String _TinyTextColumn = null;
            private String _MediumTextColumn = null;
            private String _TextColumn = null;
            private String _LongTextColumn = null;
            private global::MySql.Data.Types.MySqlGeometry? _GeometryColumn;
            private MyEnum? _EnumColumn;
            private MySet? _SetColumn;
            private String _NotNullCharColumn = "";
            private String _NotNullVarCharColumn = "";
            private Boolean _NotNullBitColumn;
            private SByte _NotNullTinyIntColumn;
            private Int16 _NotNullSmallIntColumn;
            private Int32 _NotNullMediumIntColumn;
            private Int32 _NotNullIntColumn;
            private Int64 _NotNullBigIntColumn;
            private Byte _NotNullTinyIntUnsignedColumn;
            private UInt16 _NotNullSmallIntUnsignedColumn;
            private UInt32 _NotNullMediumIntUnsignedColumn;
            private UInt32 _NotNullIntUnsignedColumn;
            private UInt64 _NotNullBigIntUnsignedColumn;
            private Single _NotNullFloatColumn;
            private Double _NotNullDoubleColumn;
            private Decimal _NotNullDecimalColumn;
            private Decimal _NotNullNumericColumn;
            private DateTime _NotNullDateColumn;
            private DateTime _NotNullDateTimeColumn;
            private TimeSpan _NotNullTimeColumn;
            private Int32 _NotNullYearColumn;
            private Byte[] _NotNullBinaryColumn;
            private Byte[] _NotNullVarBinaryColumn;
            private Byte[] _NotNullTinyBlobColumn;
            private String _NotNullTinyTextColumn = "";
            private Byte[] _NotNullBlobColumn;
            private String _NotNullTextColumn = "";
            private Byte[] _NotNullMediumBlobColumn;
            private String _NotNullMediumTextColumn = "";
            private Byte[] _NotNullLongBlobColumn;
            private String _NotNullLongTextColumn = "";
            private global::MySql.Data.Types.MySqlGeometry _NotNullGeometryColumn;
            private MyEnum _NotNullEnumColumn;
            private MySet _NotNullSetColumn;

            public SaveMode SaveMode
            {
                get
                {
                    return ((ISaveMode)this).SaveMode;
                }
                set
                {
                    ((ISaveMode)this).SaveMode = value;
                }
            }
            public Int64 PrimaryKeyColumn
            {
                get
                {
                    return _PrimaryKeyColumn;
                }
                set
                {
                    _PrimaryKeyColumn = value;
                }
            }
            public DateTime TimestampColumn
            {
                get
                {
                    return _TimestampColumn;
                }
                set
                {
                    _TimestampColumn = value;
                }
            }
            public String CharColumn
            {
                get
                {
                    return _CharColumn;
                }
                set
                {
                    _CharColumn = value;
                }
            }
            public String VarCharColumn
            {
                get
                {
                    return _VarCharColumn;
                }
                set
                {
                    _VarCharColumn = value;
                }
            }
            public Boolean? BitColumn
            {
                get
                {
                    return _BitColumn;
                }
                set
                {
                    _BitColumn = value;
                }
            }
            public SByte? TinyIntColumn
            {
                get
                {
                    return _TinyIntColumn;
                }
                set
                {
                    _TinyIntColumn = value;
                }
            }
            public Int16? SmallIntColumn
            {
                get
                {
                    return _SmallIntColumn;
                }
                set
                {
                    _SmallIntColumn = value;
                }
            }
            public Int32? MediumIntColumn
            {
                get
                {
                    return _MediumIntColumn;
                }
                set
                {
                    _MediumIntColumn = value;
                }
            }
            public Int32? IntColumn
            {
                get
                {
                    return _IntColumn;
                }
                set
                {
                    _IntColumn = value;
                }
            }
            public Int64? BigIntColumn
            {
                get
                {
                    return _BigIntColumn;
                }
                set
                {
                    _BigIntColumn = value;
                }
            }
            public Byte? TinyIntUnsignedColumn
            {
                get
                {
                    return _TinyIntUnsignedColumn;
                }
                set
                {
                    _TinyIntUnsignedColumn = value;
                }
            }
            public UInt16? SmallIntUnsignedColumn
            {
                get
                {
                    return _SmallIntUnsignedColumn;
                }
                set
                {
                    _SmallIntUnsignedColumn = value;
                }
            }
            public UInt32? MediumIntUnsignedColumn
            {
                get
                {
                    return _MediumIntUnsignedColumn;
                }
                set
                {
                    _MediumIntUnsignedColumn = value;
                }
            }
            public UInt32? IntUnsignedColumn
            {
                get
                {
                    return _IntUnsignedColumn;
                }
                set
                {
                    _IntUnsignedColumn = value;
                }
            }
            public UInt64? BigIntUnsignedColumn
            {
                get
                {
                    return _BigIntUnsignedColumn;
                }
                set
                {
                    _BigIntUnsignedColumn = value;
                }
            }
            public Single? FloatColumn
            {
                get
                {
                    return _FloatColumn;
                }
                set
                {
                    _FloatColumn = value;
                }
            }
            public Double? DoubleColumn
            {
                get
                {
                    return _DoubleColumn;
                }
                set
                {
                    _DoubleColumn = value;
                }
            }
            public Decimal? DecimalColumn
            {
                get
                {
                    return _DecimalColumn;
                }
                set
                {
                    _DecimalColumn = value;
                }
            }
            public Decimal? NumericColumn
            {
                get
                {
                    return _NumericColumn;
                }
                set
                {
                    _NumericColumn = value;
                }
            }
            public DateTime? DateColumn
            {
                get
                {
                    return _DateColumn;
                }
                set
                {
                    _DateColumn = value;
                }
            }
            public DateTime? DateTimeColumn
            {
                get
                {
                    return _DateTimeColumn;
                }
                set
                {
                    _DateTimeColumn = value;
                }
            }
            public TimeSpan? TimeColumn
            {
                get
                {
                    return _TimeColumn;
                }
                set
                {
                    _TimeColumn = value;
                }
            }
            public Int32? YearColumn
            {
                get
                {
                    return _YearColumn;
                }
                set
                {
                    _YearColumn = value;
                }
            }
            public Byte[] BinaryColumn
            {
                get
                {
                    return _BinaryColumn;
                }
                set
                {
                    _BinaryColumn = value;
                }
            }
            public Byte[] VarBinaryColumn
            {
                get
                {
                    return _VarBinaryColumn;
                }
                set
                {
                    _VarBinaryColumn = value;
                }
            }
            public Byte[] TinyBlobColumn
            {
                get
                {
                    return _TinyBlobColumn;
                }
                set
                {
                    _TinyBlobColumn = value;
                }
            }
            public Byte[] MediumBlobColumn
            {
                get
                {
                    return _MediumBlobColumn;
                }
                set
                {
                    _MediumBlobColumn = value;
                }
            }
            public Byte[] BlobColumn
            {
                get
                {
                    return _BlobColumn;
                }
                set
                {
                    _BlobColumn = value;
                }
            }
            public Byte[] LongBlobColumn
            {
                get
                {
                    return _LongBlobColumn;
                }
                set
                {
                    _LongBlobColumn = value;
                }
            }
            public String TinyTextColumn
            {
                get
                {
                    return _TinyTextColumn;
                }
                set
                {
                    _TinyTextColumn = value;
                }
            }
            public String MediumTextColumn
            {
                get
                {
                    return _MediumTextColumn;
                }
                set
                {
                    _MediumTextColumn = value;
                }
            }
            public String TextColumn
            {
                get
                {
                    return _TextColumn;
                }
                set
                {
                    _TextColumn = value;
                }
            }
            public String LongTextColumn
            {
                get
                {
                    return _LongTextColumn;
                }
                set
                {
                    _LongTextColumn = value;
                }
            }
            public global::MySql.Data.Types.MySqlGeometry? GeometryColumn
            {
                get
                {
                    return _GeometryColumn;
                }
                set
                {
                    _GeometryColumn = value;
                }
            }
            public MyEnum? EnumColumn
            {
                get
                {
                    return _EnumColumn;
                }
                set
                {
                    _EnumColumn = value;
                }
            }
            public MySet? SetColumn
            {
                get
                {
                    return _SetColumn;
                }
                set
                {
                    _SetColumn = value;
                }
            }
            public String NotNullCharColumn
            {
                get
                {
                    return _NotNullCharColumn;
                }
                set
                {
                    _NotNullCharColumn = value ?? "";
                }
            }
            public String NotNullVarCharColumn
            {
                get
                {
                    return _NotNullVarCharColumn;
                }
                set
                {
                    _NotNullVarCharColumn = value ?? "";
                }
            }
            public Boolean NotNullBitColumn
            {
                get
                {
                    return _NotNullBitColumn;
                }
                set
                {
                    _NotNullBitColumn = value;
                }
            }
            public SByte NotNullTinyIntColumn
            {
                get
                {
                    return _NotNullTinyIntColumn;
                }
                set
                {
                    _NotNullTinyIntColumn = value;
                }
            }
            public Int16 NotNullSmallIntColumn
            {
                get
                {
                    return _NotNullSmallIntColumn;
                }
                set
                {
                    _NotNullSmallIntColumn = value;
                }
            }
            public Int32 NotNullMediumIntColumn
            {
                get
                {
                    return _NotNullMediumIntColumn;
                }
                set
                {
                    _NotNullMediumIntColumn = value;
                }
            }
            public Int32 NotNullIntColumn
            {
                get
                {
                    return _NotNullIntColumn;
                }
                set
                {
                    _NotNullIntColumn = value;
                }
            }
            public Int64 NotNullBigIntColumn
            {
                get
                {
                    return _NotNullBigIntColumn;
                }
                set
                {
                    _NotNullBigIntColumn = value;
                }
            }
            public Byte NotNullTinyIntUnsignedColumn
            {
                get
                {
                    return _NotNullTinyIntUnsignedColumn;
                }
                set
                {
                    _NotNullTinyIntUnsignedColumn = value;
                }
            }
            public UInt16 NotNullSmallIntUnsignedColumn
            {
                get
                {
                    return _NotNullSmallIntUnsignedColumn;
                }
                set
                {
                    _NotNullSmallIntUnsignedColumn = value;
                }
            }
            public UInt32 NotNullMediumIntUnsignedColumn
            {
                get
                {
                    return _NotNullMediumIntUnsignedColumn;
                }
                set
                {
                    _NotNullMediumIntUnsignedColumn = value;
                }
            }
            public UInt32 NotNullIntUnsignedColumn
            {
                get
                {
                    return _NotNullIntUnsignedColumn;
                }
                set
                {
                    _NotNullIntUnsignedColumn = value;
                }
            }
            public UInt64 NotNullBigIntUnsignedColumn
            {
                get
                {
                    return _NotNullBigIntUnsignedColumn;
                }
                set
                {
                    _NotNullBigIntUnsignedColumn = value;
                }
            }
            public Single NotNullFloatColumn
            {
                get
                {
                    return _NotNullFloatColumn;
                }
                set
                {
                    _NotNullFloatColumn = value;
                }
            }
            public Double NotNullDoubleColumn
            {
                get
                {
                    return _NotNullDoubleColumn;
                }
                set
                {
                    _NotNullDoubleColumn = value;
                }
            }
            public Decimal NotNullDecimalColumn
            {
                get
                {
                    return _NotNullDecimalColumn;
                }
                set
                {
                    _NotNullDecimalColumn = value;
                }
            }
            public Decimal NotNullNumericColumn
            {
                get
                {
                    return _NotNullNumericColumn;
                }
                set
                {
                    _NotNullNumericColumn = value;
                }
            }
            public DateTime NotNullDateColumn
            {
                get
                {
                    return _NotNullDateColumn;
                }
                set
                {
                    _NotNullDateColumn = value;
                }
            }
            public DateTime NotNullDateTimeColumn
            {
                get
                {
                    return _NotNullDateTimeColumn;
                }
                set
                {
                    _NotNullDateTimeColumn = value;
                }
            }
            public TimeSpan NotNullTimeColumn
            {
                get
                {
                    return _NotNullTimeColumn;
                }
                set
                {
                    _NotNullTimeColumn = value;
                }
            }
            public Int32 NotNullYearColumn
            {
                get
                {
                    return _NotNullYearColumn;
                }
                set
                {
                    _NotNullYearColumn = value;
                }
            }
            public Byte[] NotNullBinaryColumn
            {
                get
                {
                    return _NotNullBinaryColumn;
                }
                set
                {
                    _NotNullBinaryColumn = value;
                }
            }
            public Byte[] NotNullVarBinaryColumn
            {
                get
                {
                    return _NotNullVarBinaryColumn;
                }
                set
                {
                    _NotNullVarBinaryColumn = value;
                }
            }
            public Byte[] NotNullTinyBlobColumn
            {
                get
                {
                    return _NotNullTinyBlobColumn;
                }
                set
                {
                    _NotNullTinyBlobColumn = value;
                }
            }
            public String NotNullTinyTextColumn
            {
                get
                {
                    return _NotNullTinyTextColumn;
                }
                set
                {
                    _NotNullTinyTextColumn = value ?? "";
                }
            }
            public Byte[] NotNullBlobColumn
            {
                get
                {
                    return _NotNullBlobColumn;
                }
                set
                {
                    _NotNullBlobColumn = value;
                }
            }
            public String NotNullTextColumn
            {
                get
                {
                    return _NotNullTextColumn;
                }
                set
                {
                    _NotNullTextColumn = value ?? "";
                }
            }
            public Byte[] NotNullMediumBlobColumn
            {
                get
                {
                    return _NotNullMediumBlobColumn;
                }
                set
                {
                    _NotNullMediumBlobColumn = value;
                }
            }
            public String NotNullMediumTextColumn
            {
                get
                {
                    return _NotNullMediumTextColumn;
                }
                set
                {
                    _NotNullMediumTextColumn = value ?? "";
                }
            }
            public Byte[] NotNullLongBlobColumn
            {
                get
                {
                    return _NotNullLongBlobColumn;
                }
                set
                {
                    _NotNullLongBlobColumn = value;
                }
            }
            public String NotNullLongTextColumn
            {
                get
                {
                    return _NotNullLongTextColumn;
                }
                set
                {
                    _NotNullLongTextColumn = value ?? "";
                }
            }
            public global::MySql.Data.Types.MySqlGeometry NotNullGeometryColumn
            {
                get
                {
                    return _NotNullGeometryColumn;
                }
                set
                {
                    _NotNullGeometryColumn = value;
                }
            }
            public MyEnum NotNullEnumColumn
            {
                get
                {
                    return _NotNullEnumColumn;
                }
                set
                {
                    _NotNullEnumColumn = value;
                }
            }
            public MySet NotNullSetColumn
            {
                get
                {
                    return _NotNullSetColumn;
                }
                set
                {
                    _NotNullSetColumn = value;
                }
            }

            public Record()
            {
                ConstructorExecuted();
            }
            public Record(IRecord record)
            {
                this.SetProperty(record);
                ConstructorExecuted();
            }

            public override String GetTableName()
            {
                return "alldatatypetable";
            }
            partial void ConstructorExecuted();
            public override void SetProperty(Record record)
            {
                this.SetProperty(record as IRecord);
            }
            public void SetProperty(IRecord record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                this.PrimaryKeyColumn = r.PrimaryKeyColumn;
                this.TimestampColumn = r.TimestampColumn;
                this.CharColumn = r.CharColumn;
                this.VarCharColumn = r.VarCharColumn;
                this.BitColumn = r.BitColumn;
                this.TinyIntColumn = r.TinyIntColumn;
                this.SmallIntColumn = r.SmallIntColumn;
                this.MediumIntColumn = r.MediumIntColumn;
                this.IntColumn = r.IntColumn;
                this.BigIntColumn = r.BigIntColumn;
                this.TinyIntUnsignedColumn = r.TinyIntUnsignedColumn;
                this.SmallIntUnsignedColumn = r.SmallIntUnsignedColumn;
                this.MediumIntUnsignedColumn = r.MediumIntUnsignedColumn;
                this.IntUnsignedColumn = r.IntUnsignedColumn;
                this.BigIntUnsignedColumn = r.BigIntUnsignedColumn;
                this.FloatColumn = r.FloatColumn;
                this.DoubleColumn = r.DoubleColumn;
                this.DecimalColumn = r.DecimalColumn;
                this.NumericColumn = r.NumericColumn;
                this.DateColumn = r.DateColumn;
                this.DateTimeColumn = r.DateTimeColumn;
                this.TimeColumn = r.TimeColumn;
                this.YearColumn = r.YearColumn;
                this.BinaryColumn = r.BinaryColumn;
                this.VarBinaryColumn = r.VarBinaryColumn;
                this.TinyBlobColumn = r.TinyBlobColumn;
                this.MediumBlobColumn = r.MediumBlobColumn;
                this.BlobColumn = r.BlobColumn;
                this.LongBlobColumn = r.LongBlobColumn;
                this.TinyTextColumn = r.TinyTextColumn;
                this.MediumTextColumn = r.MediumTextColumn;
                this.TextColumn = r.TextColumn;
                this.LongTextColumn = r.LongTextColumn;
                this.GeometryColumn = r.GeometryColumn;
                this.EnumColumn = r.EnumColumn;
                this.SetColumn = r.SetColumn;
                this.NotNullCharColumn = r.NotNullCharColumn;
                this.NotNullVarCharColumn = r.NotNullVarCharColumn;
                this.NotNullBitColumn = r.NotNullBitColumn;
                this.NotNullTinyIntColumn = r.NotNullTinyIntColumn;
                this.NotNullSmallIntColumn = r.NotNullSmallIntColumn;
                this.NotNullMediumIntColumn = r.NotNullMediumIntColumn;
                this.NotNullIntColumn = r.NotNullIntColumn;
                this.NotNullBigIntColumn = r.NotNullBigIntColumn;
                this.NotNullTinyIntUnsignedColumn = r.NotNullTinyIntUnsignedColumn;
                this.NotNullSmallIntUnsignedColumn = r.NotNullSmallIntUnsignedColumn;
                this.NotNullMediumIntUnsignedColumn = r.NotNullMediumIntUnsignedColumn;
                this.NotNullIntUnsignedColumn = r.NotNullIntUnsignedColumn;
                this.NotNullBigIntUnsignedColumn = r.NotNullBigIntUnsignedColumn;
                this.NotNullFloatColumn = r.NotNullFloatColumn;
                this.NotNullDoubleColumn = r.NotNullDoubleColumn;
                this.NotNullDecimalColumn = r.NotNullDecimalColumn;
                this.NotNullNumericColumn = r.NotNullNumericColumn;
                this.NotNullDateColumn = r.NotNullDateColumn;
                this.NotNullDateTimeColumn = r.NotNullDateTimeColumn;
                this.NotNullTimeColumn = r.NotNullTimeColumn;
                this.NotNullYearColumn = r.NotNullYearColumn;
                this.NotNullBinaryColumn = r.NotNullBinaryColumn;
                this.NotNullVarBinaryColumn = r.NotNullVarBinaryColumn;
                this.NotNullTinyBlobColumn = r.NotNullTinyBlobColumn;
                this.NotNullTinyTextColumn = r.NotNullTinyTextColumn;
                this.NotNullBlobColumn = r.NotNullBlobColumn;
                this.NotNullTextColumn = r.NotNullTextColumn;
                this.NotNullMediumBlobColumn = r.NotNullMediumBlobColumn;
                this.NotNullMediumTextColumn = r.NotNullMediumTextColumn;
                this.NotNullLongBlobColumn = r.NotNullLongBlobColumn;
                this.NotNullLongTextColumn = r.NotNullLongTextColumn;
                this.NotNullGeometryColumn = r.NotNullGeometryColumn;
                this.NotNullEnumColumn = r.NotNullEnumColumn;
                this.NotNullSetColumn = r.NotNullSetColumn;
            }
            public override Boolean CompareAllColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.PrimaryKeyColumn, r.PrimaryKeyColumn) && 
                Object.Equals(this.TimestampColumn, r.TimestampColumn) && 
                Object.Equals(this.CharColumn, r.CharColumn) && 
                Object.Equals(this.VarCharColumn, r.VarCharColumn) && 
                Object.Equals(this.BitColumn, r.BitColumn) && 
                Object.Equals(this.TinyIntColumn, r.TinyIntColumn) && 
                Object.Equals(this.SmallIntColumn, r.SmallIntColumn) && 
                Object.Equals(this.MediumIntColumn, r.MediumIntColumn) && 
                Object.Equals(this.IntColumn, r.IntColumn) && 
                Object.Equals(this.BigIntColumn, r.BigIntColumn) && 
                Object.Equals(this.TinyIntUnsignedColumn, r.TinyIntUnsignedColumn) && 
                Object.Equals(this.SmallIntUnsignedColumn, r.SmallIntUnsignedColumn) && 
                Object.Equals(this.MediumIntUnsignedColumn, r.MediumIntUnsignedColumn) && 
                Object.Equals(this.IntUnsignedColumn, r.IntUnsignedColumn) && 
                Object.Equals(this.BigIntUnsignedColumn, r.BigIntUnsignedColumn) && 
                Object.Equals(this.FloatColumn, r.FloatColumn) && 
                Object.Equals(this.DoubleColumn, r.DoubleColumn) && 
                Object.Equals(this.DecimalColumn, r.DecimalColumn) && 
                Object.Equals(this.NumericColumn, r.NumericColumn) && 
                Object.Equals(this.DateColumn, r.DateColumn) && 
                Object.Equals(this.DateTimeColumn, r.DateTimeColumn) && 
                Object.Equals(this.TimeColumn, r.TimeColumn) && 
                Object.Equals(this.YearColumn, r.YearColumn) && 
                Object.Equals(this.BinaryColumn, r.BinaryColumn) && 
                Object.Equals(this.VarBinaryColumn, r.VarBinaryColumn) && 
                Object.Equals(this.TinyBlobColumn, r.TinyBlobColumn) && 
                Object.Equals(this.MediumBlobColumn, r.MediumBlobColumn) && 
                Object.Equals(this.BlobColumn, r.BlobColumn) && 
                Object.Equals(this.LongBlobColumn, r.LongBlobColumn) && 
                Object.Equals(this.TinyTextColumn, r.TinyTextColumn) && 
                Object.Equals(this.MediumTextColumn, r.MediumTextColumn) && 
                Object.Equals(this.TextColumn, r.TextColumn) && 
                Object.Equals(this.LongTextColumn, r.LongTextColumn) && 
                Object.Equals(this.GeometryColumn, r.GeometryColumn) && 
                Object.Equals(this.EnumColumn, r.EnumColumn) && 
                Object.Equals(this.SetColumn, r.SetColumn) && 
                Object.Equals(this.NotNullCharColumn, r.NotNullCharColumn) && 
                Object.Equals(this.NotNullVarCharColumn, r.NotNullVarCharColumn) && 
                Object.Equals(this.NotNullBitColumn, r.NotNullBitColumn) && 
                Object.Equals(this.NotNullTinyIntColumn, r.NotNullTinyIntColumn) && 
                Object.Equals(this.NotNullSmallIntColumn, r.NotNullSmallIntColumn) && 
                Object.Equals(this.NotNullMediumIntColumn, r.NotNullMediumIntColumn) && 
                Object.Equals(this.NotNullIntColumn, r.NotNullIntColumn) && 
                Object.Equals(this.NotNullBigIntColumn, r.NotNullBigIntColumn) && 
                Object.Equals(this.NotNullTinyIntUnsignedColumn, r.NotNullTinyIntUnsignedColumn) && 
                Object.Equals(this.NotNullSmallIntUnsignedColumn, r.NotNullSmallIntUnsignedColumn) && 
                Object.Equals(this.NotNullMediumIntUnsignedColumn, r.NotNullMediumIntUnsignedColumn) && 
                Object.Equals(this.NotNullIntUnsignedColumn, r.NotNullIntUnsignedColumn) && 
                Object.Equals(this.NotNullBigIntUnsignedColumn, r.NotNullBigIntUnsignedColumn) && 
                Object.Equals(this.NotNullFloatColumn, r.NotNullFloatColumn) && 
                Object.Equals(this.NotNullDoubleColumn, r.NotNullDoubleColumn) && 
                Object.Equals(this.NotNullDecimalColumn, r.NotNullDecimalColumn) && 
                Object.Equals(this.NotNullNumericColumn, r.NotNullNumericColumn) && 
                Object.Equals(this.NotNullDateColumn, r.NotNullDateColumn) && 
                Object.Equals(this.NotNullDateTimeColumn, r.NotNullDateTimeColumn) && 
                Object.Equals(this.NotNullTimeColumn, r.NotNullTimeColumn) && 
                Object.Equals(this.NotNullYearColumn, r.NotNullYearColumn) && 
                Object.Equals(this.NotNullBinaryColumn, r.NotNullBinaryColumn) && 
                Object.Equals(this.NotNullVarBinaryColumn, r.NotNullVarBinaryColumn) && 
                Object.Equals(this.NotNullTinyBlobColumn, r.NotNullTinyBlobColumn) && 
                Object.Equals(this.NotNullTinyTextColumn, r.NotNullTinyTextColumn) && 
                Object.Equals(this.NotNullBlobColumn, r.NotNullBlobColumn) && 
                Object.Equals(this.NotNullTextColumn, r.NotNullTextColumn) && 
                Object.Equals(this.NotNullMediumBlobColumn, r.NotNullMediumBlobColumn) && 
                Object.Equals(this.NotNullMediumTextColumn, r.NotNullMediumTextColumn) && 
                Object.Equals(this.NotNullLongBlobColumn, r.NotNullLongBlobColumn) && 
                Object.Equals(this.NotNullLongTextColumn, r.NotNullLongTextColumn) && 
                Object.Equals(this.NotNullGeometryColumn, r.NotNullGeometryColumn) && 
                Object.Equals(this.NotNullEnumColumn, r.NotNullEnumColumn) && 
                Object.Equals(this.NotNullSetColumn, r.NotNullSetColumn);
            }
            public override Boolean ComparePrimaryKeyColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.PrimaryKeyColumn, r.PrimaryKeyColumn);
            }
            public override Object GetValue(Int32 index)
            {
                switch (index)
                {
                    case 0: return this.PrimaryKeyColumn;
                    case 1: return this.TimestampColumn;
                    case 2: return this.CharColumn;
                    case 3: return this.VarCharColumn;
                    case 4: return this.BitColumn;
                    case 5: return this.TinyIntColumn;
                    case 6: return this.SmallIntColumn;
                    case 7: return this.MediumIntColumn;
                    case 8: return this.IntColumn;
                    case 9: return this.BigIntColumn;
                    case 10: return this.TinyIntUnsignedColumn;
                    case 11: return this.SmallIntUnsignedColumn;
                    case 12: return this.MediumIntUnsignedColumn;
                    case 13: return this.IntUnsignedColumn;
                    case 14: return this.BigIntUnsignedColumn;
                    case 15: return this.FloatColumn;
                    case 16: return this.DoubleColumn;
                    case 17: return this.DecimalColumn;
                    case 18: return this.NumericColumn;
                    case 19: return this.DateColumn;
                    case 20: return this.DateTimeColumn;
                    case 21: return this.TimeColumn;
                    case 22: return this.YearColumn;
                    case 23: return this.BinaryColumn;
                    case 24: return this.VarBinaryColumn;
                    case 25: return this.TinyBlobColumn;
                    case 26: return this.MediumBlobColumn;
                    case 27: return this.BlobColumn;
                    case 28: return this.LongBlobColumn;
                    case 29: return this.TinyTextColumn;
                    case 30: return this.MediumTextColumn;
                    case 31: return this.TextColumn;
                    case 32: return this.LongTextColumn;
                    case 33: return this.GeometryColumn;
                    case 34: return this.EnumColumn;
                    case 35: return this.SetColumn;
                    case 36: return this.NotNullCharColumn;
                    case 37: return this.NotNullVarCharColumn;
                    case 38: return this.NotNullBitColumn;
                    case 39: return this.NotNullTinyIntColumn;
                    case 40: return this.NotNullSmallIntColumn;
                    case 41: return this.NotNullMediumIntColumn;
                    case 42: return this.NotNullIntColumn;
                    case 43: return this.NotNullBigIntColumn;
                    case 44: return this.NotNullTinyIntUnsignedColumn;
                    case 45: return this.NotNullSmallIntUnsignedColumn;
                    case 46: return this.NotNullMediumIntUnsignedColumn;
                    case 47: return this.NotNullIntUnsignedColumn;
                    case 48: return this.NotNullBigIntUnsignedColumn;
                    case 49: return this.NotNullFloatColumn;
                    case 50: return this.NotNullDoubleColumn;
                    case 51: return this.NotNullDecimalColumn;
                    case 52: return this.NotNullNumericColumn;
                    case 53: return this.NotNullDateColumn;
                    case 54: return this.NotNullDateTimeColumn;
                    case 55: return this.NotNullTimeColumn;
                    case 56: return this.NotNullYearColumn;
                    case 57: return this.NotNullBinaryColumn;
                    case 58: return this.NotNullVarBinaryColumn;
                    case 59: return this.NotNullTinyBlobColumn;
                    case 60: return this.NotNullTinyTextColumn;
                    case 61: return this.NotNullBlobColumn;
                    case 62: return this.NotNullTextColumn;
                    case 63: return this.NotNullMediumBlobColumn;
                    case 64: return this.NotNullMediumTextColumn;
                    case 65: return this.NotNullLongBlobColumn;
                    case 66: return this.NotNullLongTextColumn;
                    case 67: return this.NotNullGeometryColumn;
                    case 68: return this.NotNullEnumColumn;
                    case 69: return this.NotNullSetColumn;
                }
                throw new ArgumentOutOfRangeException();
            }
            public override Boolean SetValue(Int32 index, Object value)
            {
                switch (index)
                {
                    case 0:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt64(value);
                            if (newValue == null) return false;
                            this.PrimaryKeyColumn = newValue.Value;
                            return true;
                        }
                    case 1:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.TimestampColumn = newValue.Value;
                            return true;
                        }
                    case 2:
                        if (value == null)
                        {
                            this.CharColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.CharColumn = newValue;
                            return true;
                        }
                    case 3:
                        if (value == null)
                        {
                            this.VarCharColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.VarCharColumn = newValue;
                            return true;
                        }
                    case 4:
                        if (value == null)
                        {
                            this.BitColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToBoolean(value);
                            if (newValue == null) return false;
                            this.BitColumn = newValue.Value;
                            return true;
                        }
                    case 5:
                        if (value == null)
                        {
                            this.TinyIntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSByte(value);
                            if (newValue == null) return false;
                            this.TinyIntColumn = newValue.Value;
                            return true;
                        }
                    case 6:
                        if (value == null)
                        {
                            this.SmallIntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt16(value);
                            if (newValue == null) return false;
                            this.SmallIntColumn = newValue.Value;
                            return true;
                        }
                    case 7:
                        if (value == null)
                        {
                            this.MediumIntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.MediumIntColumn = newValue.Value;
                            return true;
                        }
                    case 8:
                        if (value == null)
                        {
                            this.IntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.IntColumn = newValue.Value;
                            return true;
                        }
                    case 9:
                        if (value == null)
                        {
                            this.BigIntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt64(value);
                            if (newValue == null) return false;
                            this.BigIntColumn = newValue.Value;
                            return true;
                        }
                    case 10:
                        if (value == null)
                        {
                            this.TinyIntUnsignedColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToByte(value);
                            if (newValue == null) return false;
                            this.TinyIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 11:
                        if (value == null)
                        {
                            this.SmallIntUnsignedColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt16(value);
                            if (newValue == null) return false;
                            this.SmallIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 12:
                        if (value == null)
                        {
                            this.MediumIntUnsignedColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt32(value);
                            if (newValue == null) return false;
                            this.MediumIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 13:
                        if (value == null)
                        {
                            this.IntUnsignedColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt32(value);
                            if (newValue == null) return false;
                            this.IntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 14:
                        if (value == null)
                        {
                            this.BigIntUnsignedColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt64(value);
                            if (newValue == null) return false;
                            this.BigIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 15:
                        if (value == null)
                        {
                            this.FloatColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSingle(value);
                            if (newValue == null) return false;
                            this.FloatColumn = newValue.Value;
                            return true;
                        }
                    case 16:
                        if (value == null)
                        {
                            this.DoubleColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDouble(value);
                            if (newValue == null) return false;
                            this.DoubleColumn = newValue.Value;
                            return true;
                        }
                    case 17:
                        if (value == null)
                        {
                            this.DecimalColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.DecimalColumn = newValue.Value;
                            return true;
                        }
                    case 18:
                        if (value == null)
                        {
                            this.NumericColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.NumericColumn = newValue.Value;
                            return true;
                        }
                    case 19:
                        if (value == null)
                        {
                            this.DateColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.DateColumn = newValue.Value;
                            return true;
                        }
                    case 20:
                        if (value == null)
                        {
                            this.DateTimeColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.DateTimeColumn = newValue.Value;
                            return true;
                        }
                    case 21:
                        if (value == null)
                        {
                            this.TimeColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToTimeSpan(value);
                            if (newValue == null) return false;
                            this.TimeColumn = newValue.Value;
                            return true;
                        }
                    case 22:
                        if (value == null)
                        {
                            this.YearColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.YearColumn = newValue.Value;
                            return true;
                        }
                    case 23:
                        if (value == null)
                        {
                            this.BinaryColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.BinaryColumn = newValue;
                            return true;
                        }
                    case 24:
                        if (value == null)
                        {
                            this.VarBinaryColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.VarBinaryColumn = newValue;
                            return true;
                        }
                    case 25:
                        if (value == null)
                        {
                            this.TinyBlobColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.TinyBlobColumn = newValue;
                            return true;
                        }
                    case 26:
                        if (value == null)
                        {
                            this.MediumBlobColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.MediumBlobColumn = newValue;
                            return true;
                        }
                    case 27:
                        if (value == null)
                        {
                            this.BlobColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.BlobColumn = newValue;
                            return true;
                        }
                    case 28:
                        if (value == null)
                        {
                            this.LongBlobColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.LongBlobColumn = newValue;
                            return true;
                        }
                    case 29:
                        if (value == null)
                        {
                            this.TinyTextColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.TinyTextColumn = newValue;
                            return true;
                        }
                    case 30:
                        if (value == null)
                        {
                            this.MediumTextColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.MediumTextColumn = newValue;
                            return true;
                        }
                    case 31:
                        if (value == null)
                        {
                            this.TextColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.TextColumn = newValue;
                            return true;
                        }
                    case 32:
                        if (value == null)
                        {
                            this.LongTextColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.LongTextColumn = newValue;
                            return true;
                        }
                    case 33:
                        if (value == null)
                        {
                            this.GeometryColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as global::MySql.Data.Types.MySqlGeometry?;
                            if (newValue == null) return false;
                            this.GeometryColumn = newValue.Value;
                            return true;
                        }
                    case 34:
                        if (value == null)
                        {
                            this.EnumColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToEnum<MyEnum>(value);
                            if (newValue == null) return false;
                            this.EnumColumn = newValue.Value;
                            return true;
                        }
                    case 35:
                        if (value == null)
                        {
                            this.SetColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToEnum<MySet>(value);
                            if (newValue == null) return false;
                            this.SetColumn = newValue.Value;
                            return true;
                        }
                    case 36:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullCharColumn = newValue;
                            return true;
                        }
                    case 37:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullVarCharColumn = newValue;
                            return true;
                        }
                    case 38:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToBoolean(value);
                            if (newValue == null) return false;
                            this.NotNullBitColumn = newValue.Value;
                            return true;
                        }
                    case 39:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSByte(value);
                            if (newValue == null) return false;
                            this.NotNullTinyIntColumn = newValue.Value;
                            return true;
                        }
                    case 40:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt16(value);
                            if (newValue == null) return false;
                            this.NotNullSmallIntColumn = newValue.Value;
                            return true;
                        }
                    case 41:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.NotNullMediumIntColumn = newValue.Value;
                            return true;
                        }
                    case 42:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.NotNullIntColumn = newValue.Value;
                            return true;
                        }
                    case 43:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt64(value);
                            if (newValue == null) return false;
                            this.NotNullBigIntColumn = newValue.Value;
                            return true;
                        }
                    case 44:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToByte(value);
                            if (newValue == null) return false;
                            this.NotNullTinyIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 45:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt16(value);
                            if (newValue == null) return false;
                            this.NotNullSmallIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 46:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt32(value);
                            if (newValue == null) return false;
                            this.NotNullMediumIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 47:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt32(value);
                            if (newValue == null) return false;
                            this.NotNullIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 48:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToUInt64(value);
                            if (newValue == null) return false;
                            this.NotNullBigIntUnsignedColumn = newValue.Value;
                            return true;
                        }
                    case 49:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSingle(value);
                            if (newValue == null) return false;
                            this.NotNullFloatColumn = newValue.Value;
                            return true;
                        }
                    case 50:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDouble(value);
                            if (newValue == null) return false;
                            this.NotNullDoubleColumn = newValue.Value;
                            return true;
                        }
                    case 51:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.NotNullDecimalColumn = newValue.Value;
                            return true;
                        }
                    case 52:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.NotNullNumericColumn = newValue.Value;
                            return true;
                        }
                    case 53:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.NotNullDateColumn = newValue.Value;
                            return true;
                        }
                    case 54:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.NotNullDateTimeColumn = newValue.Value;
                            return true;
                        }
                    case 55:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToTimeSpan(value);
                            if (newValue == null) return false;
                            this.NotNullTimeColumn = newValue.Value;
                            return true;
                        }
                    case 56:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.NotNullYearColumn = newValue.Value;
                            return true;
                        }
                    case 57:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullBinaryColumn = newValue;
                            return true;
                        }
                    case 58:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullVarBinaryColumn = newValue;
                            return true;
                        }
                    case 59:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullTinyBlobColumn = newValue;
                            return true;
                        }
                    case 60:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullTinyTextColumn = newValue;
                            return true;
                        }
                    case 61:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullBlobColumn = newValue;
                            return true;
                        }
                    case 62:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullTextColumn = newValue;
                            return true;
                        }
                    case 63:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullMediumBlobColumn = newValue;
                            return true;
                        }
                    case 64:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullMediumTextColumn = newValue;
                            return true;
                        }
                    case 65:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullLongBlobColumn = newValue;
                            return true;
                        }
                    case 66:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullLongTextColumn = newValue;
                            return true;
                        }
                    case 67:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as global::MySql.Data.Types.MySqlGeometry?;
                            if (newValue == null) return false;
                            this.NotNullGeometryColumn = newValue.Value;
                            return true;
                        }
                    case 68:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToEnum<MyEnum>(value);
                            if (newValue == null) return false;
                            this.NotNullEnumColumn = newValue.Value;
                            return true;
                        }
                    case 69:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToEnum<MySet>(value);
                            if (newValue == null) return false;
                            this.NotNullSetColumn = newValue.Value;
                            return true;
                        }
                }
                throw new ArgumentOutOfRangeException("index", index, "index must be 0-69");
            }
            public override Int32 GetColumnCount()
            {
                return 70;
            }
        }
    }
}
