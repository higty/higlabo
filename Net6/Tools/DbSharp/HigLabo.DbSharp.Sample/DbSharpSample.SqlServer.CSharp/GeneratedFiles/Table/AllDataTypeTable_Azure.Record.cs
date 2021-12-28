//Generated at 2021/12/28 12:32:44 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Text;
using System.ComponentModel;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class AllDataTypeTable_Azure
    {
        public partial class Record : TableRecord<Record>, IRecord
        {
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
            public Int64 PrimaryKeyColumn { get; set; }
            public Byte[] TimestampColumn { get; set; }
            public Int64? BigIntColumn { get; set; }
            public Byte[] BinaryColumn { get; set; }
            public Byte[] ImageColumn { get; set; }
            public Byte[] VarBinaryColumn { get; set; }
            public Boolean? BitColumn { get; set; }
            public String CharColumn { get; set; } = null;
            public String NCharColumn { get; set; } = null;
            public String NTextColumn { get; set; } = null;
            public String NVarCharColumn { get; set; } = null;
            public String TextColumn { get; set; } = null;
            public String VarCharColumn { get; set; } = null;
            public String XmlColumn { get; set; } = null;
            public DateTime? DateTimeColumn { get; set; }
            public DateTime? SmallDateTimeColumn { get; set; }
            public DateOnly? DateColumn { get; set; }
            public TimeOnly? TimeColumn { get; set; }
            public DateTime? DateTime2Column { get; set; }
            public Decimal? DecimalColumn { get; set; }
            public Decimal? MoneyColumn { get; set; }
            public Decimal? SmallMoneyColumn { get; set; }
            public Double? FloatColumn { get; set; }
            public Int32? IntColumn { get; set; }
            public Single? RealColumn { get; set; }
            public Guid? UniqueIdentifierColumn { get; set; }
            public Int16? SmallIntColumn { get; set; }
            public Byte? TinyIntColumn { get; set; }
            public DateTimeOffset? DateTimeOffsetColumn { get; set; }
            public Object SqlVariantColumn { get; set; }
            public MyEnum? EnumColumn { get; set; }
            public Int64 NotNullBigIntColumn { get; set; }
            public Byte[] NotNullBinaryColumn { get; set; }
            public Byte[] NotNullImageColumn { get; set; }
            public Byte[] NotNullVarBinaryColumn { get; set; }
            public Boolean NotNullBitColumn { get; set; }
            public String NotNullCharColumn { get; set; } = "";
            public String NotNullNCharColumn { get; set; } = "";
            public String NotNullNTextColumn { get; set; } = "";
            public String NotNullNVarCharColumn { get; set; } = "";
            public String NotNullTextColumn { get; set; } = "";
            public String NotNullVarCharColumn { get; set; } = "";
            public String NotNullXmlColumn { get; set; } = "";
            public DateTime NotNullDateTimeColumn { get; set; }
            public DateTime NotNullSmallDateTimeColumn { get; set; }
            public DateOnly NotNullDateColumn { get; set; }
            public TimeOnly NotNullTimeColumn { get; set; }
            public DateTime NotNullDateTime2Column { get; set; }
            public Decimal NotNullDecimalColumn { get; set; }
            public Decimal NotNullMoneyColumn { get; set; }
            public Decimal NotNullSmallMoneyColumn { get; set; }
            public Double NotNullFloatColumn { get; set; }
            public Int32 NotNullIntColumn { get; set; }
            public Single NotNullRealColumn { get; set; }
            public Guid NotNullUniqueIdentifierColumn { get; set; }
            public Int16 NotNullSmallIntColumn { get; set; }
            public Byte NotNullTinyIntColumn { get; set; }
            public DateTimeOffset NotNullDateTimeOffsetColumn { get; set; }
            public Object NotNullSqlVariantColumn { get; set; }
            public MyEnum NotNullEnumColumn { get; set; }

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
                return "AllDataTypeTable_Azure";
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
                this.BigIntColumn = r.BigIntColumn;
                this.BinaryColumn = r.BinaryColumn;
                this.ImageColumn = r.ImageColumn;
                this.VarBinaryColumn = r.VarBinaryColumn;
                this.BitColumn = r.BitColumn;
                this.CharColumn = r.CharColumn;
                this.NCharColumn = r.NCharColumn;
                this.NTextColumn = r.NTextColumn;
                this.NVarCharColumn = r.NVarCharColumn;
                this.TextColumn = r.TextColumn;
                this.VarCharColumn = r.VarCharColumn;
                this.XmlColumn = r.XmlColumn;
                this.DateTimeColumn = r.DateTimeColumn;
                this.SmallDateTimeColumn = r.SmallDateTimeColumn;
                this.DateColumn = r.DateColumn;
                this.TimeColumn = r.TimeColumn;
                this.DateTime2Column = r.DateTime2Column;
                this.DecimalColumn = r.DecimalColumn;
                this.MoneyColumn = r.MoneyColumn;
                this.SmallMoneyColumn = r.SmallMoneyColumn;
                this.FloatColumn = r.FloatColumn;
                this.IntColumn = r.IntColumn;
                this.RealColumn = r.RealColumn;
                this.UniqueIdentifierColumn = r.UniqueIdentifierColumn;
                this.SmallIntColumn = r.SmallIntColumn;
                this.TinyIntColumn = r.TinyIntColumn;
                this.DateTimeOffsetColumn = r.DateTimeOffsetColumn;
                this.SqlVariantColumn = r.SqlVariantColumn;
                this.EnumColumn = r.EnumColumn;
                this.NotNullBigIntColumn = r.NotNullBigIntColumn;
                this.NotNullBinaryColumn = r.NotNullBinaryColumn;
                this.NotNullImageColumn = r.NotNullImageColumn;
                this.NotNullVarBinaryColumn = r.NotNullVarBinaryColumn;
                this.NotNullBitColumn = r.NotNullBitColumn;
                this.NotNullCharColumn = r.NotNullCharColumn;
                this.NotNullNCharColumn = r.NotNullNCharColumn;
                this.NotNullNTextColumn = r.NotNullNTextColumn;
                this.NotNullNVarCharColumn = r.NotNullNVarCharColumn;
                this.NotNullTextColumn = r.NotNullTextColumn;
                this.NotNullVarCharColumn = r.NotNullVarCharColumn;
                this.NotNullXmlColumn = r.NotNullXmlColumn;
                this.NotNullDateTimeColumn = r.NotNullDateTimeColumn;
                this.NotNullSmallDateTimeColumn = r.NotNullSmallDateTimeColumn;
                this.NotNullDateColumn = r.NotNullDateColumn;
                this.NotNullTimeColumn = r.NotNullTimeColumn;
                this.NotNullDateTime2Column = r.NotNullDateTime2Column;
                this.NotNullDecimalColumn = r.NotNullDecimalColumn;
                this.NotNullMoneyColumn = r.NotNullMoneyColumn;
                this.NotNullSmallMoneyColumn = r.NotNullSmallMoneyColumn;
                this.NotNullFloatColumn = r.NotNullFloatColumn;
                this.NotNullIntColumn = r.NotNullIntColumn;
                this.NotNullRealColumn = r.NotNullRealColumn;
                this.NotNullUniqueIdentifierColumn = r.NotNullUniqueIdentifierColumn;
                this.NotNullSmallIntColumn = r.NotNullSmallIntColumn;
                this.NotNullTinyIntColumn = r.NotNullTinyIntColumn;
                this.NotNullDateTimeOffsetColumn = r.NotNullDateTimeOffsetColumn;
                this.NotNullSqlVariantColumn = r.NotNullSqlVariantColumn;
                this.NotNullEnumColumn = r.NotNullEnumColumn;
            }
            public override Boolean CompareAllColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.PrimaryKeyColumn, r.PrimaryKeyColumn) && 
                Object.Equals(this.TimestampColumn, r.TimestampColumn) && 
                Object.Equals(this.BigIntColumn, r.BigIntColumn) && 
                Object.Equals(this.BinaryColumn, r.BinaryColumn) && 
                Object.Equals(this.ImageColumn, r.ImageColumn) && 
                Object.Equals(this.VarBinaryColumn, r.VarBinaryColumn) && 
                Object.Equals(this.BitColumn, r.BitColumn) && 
                Object.Equals(this.CharColumn, r.CharColumn) && 
                Object.Equals(this.NCharColumn, r.NCharColumn) && 
                Object.Equals(this.NTextColumn, r.NTextColumn) && 
                Object.Equals(this.NVarCharColumn, r.NVarCharColumn) && 
                Object.Equals(this.TextColumn, r.TextColumn) && 
                Object.Equals(this.VarCharColumn, r.VarCharColumn) && 
                Object.Equals(this.XmlColumn, r.XmlColumn) && 
                Object.Equals(this.DateTimeColumn, r.DateTimeColumn) && 
                Object.Equals(this.SmallDateTimeColumn, r.SmallDateTimeColumn) && 
                Object.Equals(this.DateColumn, r.DateColumn) && 
                Object.Equals(this.TimeColumn, r.TimeColumn) && 
                Object.Equals(this.DateTime2Column, r.DateTime2Column) && 
                Object.Equals(this.DecimalColumn, r.DecimalColumn) && 
                Object.Equals(this.MoneyColumn, r.MoneyColumn) && 
                Object.Equals(this.SmallMoneyColumn, r.SmallMoneyColumn) && 
                Object.Equals(this.FloatColumn, r.FloatColumn) && 
                Object.Equals(this.IntColumn, r.IntColumn) && 
                Object.Equals(this.RealColumn, r.RealColumn) && 
                Object.Equals(this.UniqueIdentifierColumn, r.UniqueIdentifierColumn) && 
                Object.Equals(this.SmallIntColumn, r.SmallIntColumn) && 
                Object.Equals(this.TinyIntColumn, r.TinyIntColumn) && 
                Object.Equals(this.DateTimeOffsetColumn, r.DateTimeOffsetColumn) && 
                Object.Equals(this.SqlVariantColumn, r.SqlVariantColumn) && 
                Object.Equals(this.EnumColumn, r.EnumColumn) && 
                Object.Equals(this.NotNullBigIntColumn, r.NotNullBigIntColumn) && 
                Object.Equals(this.NotNullBinaryColumn, r.NotNullBinaryColumn) && 
                Object.Equals(this.NotNullImageColumn, r.NotNullImageColumn) && 
                Object.Equals(this.NotNullVarBinaryColumn, r.NotNullVarBinaryColumn) && 
                Object.Equals(this.NotNullBitColumn, r.NotNullBitColumn) && 
                Object.Equals(this.NotNullCharColumn, r.NotNullCharColumn) && 
                Object.Equals(this.NotNullNCharColumn, r.NotNullNCharColumn) && 
                Object.Equals(this.NotNullNTextColumn, r.NotNullNTextColumn) && 
                Object.Equals(this.NotNullNVarCharColumn, r.NotNullNVarCharColumn) && 
                Object.Equals(this.NotNullTextColumn, r.NotNullTextColumn) && 
                Object.Equals(this.NotNullVarCharColumn, r.NotNullVarCharColumn) && 
                Object.Equals(this.NotNullXmlColumn, r.NotNullXmlColumn) && 
                Object.Equals(this.NotNullDateTimeColumn, r.NotNullDateTimeColumn) && 
                Object.Equals(this.NotNullSmallDateTimeColumn, r.NotNullSmallDateTimeColumn) && 
                Object.Equals(this.NotNullDateColumn, r.NotNullDateColumn) && 
                Object.Equals(this.NotNullTimeColumn, r.NotNullTimeColumn) && 
                Object.Equals(this.NotNullDateTime2Column, r.NotNullDateTime2Column) && 
                Object.Equals(this.NotNullDecimalColumn, r.NotNullDecimalColumn) && 
                Object.Equals(this.NotNullMoneyColumn, r.NotNullMoneyColumn) && 
                Object.Equals(this.NotNullSmallMoneyColumn, r.NotNullSmallMoneyColumn) && 
                Object.Equals(this.NotNullFloatColumn, r.NotNullFloatColumn) && 
                Object.Equals(this.NotNullIntColumn, r.NotNullIntColumn) && 
                Object.Equals(this.NotNullRealColumn, r.NotNullRealColumn) && 
                Object.Equals(this.NotNullUniqueIdentifierColumn, r.NotNullUniqueIdentifierColumn) && 
                Object.Equals(this.NotNullSmallIntColumn, r.NotNullSmallIntColumn) && 
                Object.Equals(this.NotNullTinyIntColumn, r.NotNullTinyIntColumn) && 
                Object.Equals(this.NotNullDateTimeOffsetColumn, r.NotNullDateTimeOffsetColumn) && 
                Object.Equals(this.NotNullSqlVariantColumn, r.NotNullSqlVariantColumn) && 
                Object.Equals(this.NotNullEnumColumn, r.NotNullEnumColumn);
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
                    case 2: return this.BigIntColumn;
                    case 3: return this.BinaryColumn;
                    case 4: return this.ImageColumn;
                    case 5: return this.VarBinaryColumn;
                    case 6: return this.BitColumn;
                    case 7: return this.CharColumn;
                    case 8: return this.NCharColumn;
                    case 9: return this.NTextColumn;
                    case 10: return this.NVarCharColumn;
                    case 11: return this.TextColumn;
                    case 12: return this.VarCharColumn;
                    case 13: return this.XmlColumn;
                    case 14: return this.DateTimeColumn;
                    case 15: return this.SmallDateTimeColumn;
                    case 16: return this.DateColumn;
                    case 17: return this.TimeColumn;
                    case 18: return this.DateTime2Column;
                    case 19: return this.DecimalColumn;
                    case 20: return this.MoneyColumn;
                    case 21: return this.SmallMoneyColumn;
                    case 22: return this.FloatColumn;
                    case 23: return this.IntColumn;
                    case 24: return this.RealColumn;
                    case 25: return this.UniqueIdentifierColumn;
                    case 26: return this.SmallIntColumn;
                    case 27: return this.TinyIntColumn;
                    case 28: return this.DateTimeOffsetColumn;
                    case 29: return this.SqlVariantColumn;
                    case 30: return this.EnumColumn;
                    case 31: return this.NotNullBigIntColumn;
                    case 32: return this.NotNullBinaryColumn;
                    case 33: return this.NotNullImageColumn;
                    case 34: return this.NotNullVarBinaryColumn;
                    case 35: return this.NotNullBitColumn;
                    case 36: return this.NotNullCharColumn;
                    case 37: return this.NotNullNCharColumn;
                    case 38: return this.NotNullNTextColumn;
                    case 39: return this.NotNullNVarCharColumn;
                    case 40: return this.NotNullTextColumn;
                    case 41: return this.NotNullVarCharColumn;
                    case 42: return this.NotNullXmlColumn;
                    case 43: return this.NotNullDateTimeColumn;
                    case 44: return this.NotNullSmallDateTimeColumn;
                    case 45: return this.NotNullDateColumn;
                    case 46: return this.NotNullTimeColumn;
                    case 47: return this.NotNullDateTime2Column;
                    case 48: return this.NotNullDecimalColumn;
                    case 49: return this.NotNullMoneyColumn;
                    case 50: return this.NotNullSmallMoneyColumn;
                    case 51: return this.NotNullFloatColumn;
                    case 52: return this.NotNullIntColumn;
                    case 53: return this.NotNullRealColumn;
                    case 54: return this.NotNullUniqueIdentifierColumn;
                    case 55: return this.NotNullSmallIntColumn;
                    case 56: return this.NotNullTinyIntColumn;
                    case 57: return this.NotNullDateTimeOffsetColumn;
                    case 58: return this.NotNullSqlVariantColumn;
                    case 59: return this.NotNullEnumColumn;
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
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.TimestampColumn = newValue;
                            return true;
                        }
                    case 2:
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
                    case 3:
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
                    case 4:
                        if (value == null)
                        {
                            this.ImageColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.ImageColumn = newValue;
                            return true;
                        }
                    case 5:
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
                    case 6:
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
                    case 7:
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
                    case 8:
                        if (value == null)
                        {
                            this.NCharColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NCharColumn = newValue;
                            return true;
                        }
                    case 9:
                        if (value == null)
                        {
                            this.NTextColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NTextColumn = newValue;
                            return true;
                        }
                    case 10:
                        if (value == null)
                        {
                            this.NVarCharColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NVarCharColumn = newValue;
                            return true;
                        }
                    case 11:
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
                    case 12:
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
                    case 13:
                        if (value == null)
                        {
                            this.XmlColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.XmlColumn = newValue;
                            return true;
                        }
                    case 14:
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
                    case 15:
                        if (value == null)
                        {
                            this.SmallDateTimeColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.SmallDateTimeColumn = newValue.Value;
                            return true;
                        }
                    case 16:
                        if (value == null)
                        {
                            this.DateColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateOnly(value);
                            if (newValue == null) return false;
                            this.DateColumn = newValue.Value;
                            return true;
                        }
                    case 17:
                        if (value == null)
                        {
                            this.TimeColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToTimeOnly(value);
                            if (newValue == null) return false;
                            this.TimeColumn = newValue.Value;
                            return true;
                        }
                    case 18:
                        if (value == null)
                        {
                            this.DateTime2Column = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.DateTime2Column = newValue.Value;
                            return true;
                        }
                    case 19:
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
                    case 20:
                        if (value == null)
                        {
                            this.MoneyColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.MoneyColumn = newValue.Value;
                            return true;
                        }
                    case 21:
                        if (value == null)
                        {
                            this.SmallMoneyColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.SmallMoneyColumn = newValue.Value;
                            return true;
                        }
                    case 22:
                        if (value == null)
                        {
                            this.FloatColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDouble(value);
                            if (newValue == null) return false;
                            this.FloatColumn = newValue.Value;
                            return true;
                        }
                    case 23:
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
                    case 24:
                        if (value == null)
                        {
                            this.RealColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSingle(value);
                            if (newValue == null) return false;
                            this.RealColumn = newValue.Value;
                            return true;
                        }
                    case 25:
                        if (value == null)
                        {
                            this.UniqueIdentifierColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToGuid(value);
                            if (newValue == null) return false;
                            this.UniqueIdentifierColumn = newValue.Value;
                            return true;
                        }
                    case 26:
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
                    case 27:
                        if (value == null)
                        {
                            this.TinyIntColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToByte(value);
                            if (newValue == null) return false;
                            this.TinyIntColumn = newValue.Value;
                            return true;
                        }
                    case 28:
                        if (value == null)
                        {
                            this.DateTimeOffsetColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTimeOffset(value);
                            if (newValue == null) return false;
                            this.DateTimeOffsetColumn = newValue.Value;
                            return true;
                        }
                    case 29:
                        if (value == null)
                        {
                            this.SqlVariantColumn = null;
                            return true;
                        }
                        else
                        {
                            var newValue = value as Object;
                            if (newValue == null) return false;
                            this.SqlVariantColumn = newValue;
                            return true;
                        }
                    case 30:
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
                    case 31:
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
                    case 32:
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
                    case 33:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.NotNullImageColumn = newValue;
                            return true;
                        }
                    case 34:
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
                    case 35:
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
                            this.NotNullNCharColumn = newValue;
                            return true;
                        }
                    case 38:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullNTextColumn = newValue;
                            return true;
                        }
                    case 39:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullNVarCharColumn = newValue;
                            return true;
                        }
                    case 40:
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
                    case 41:
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
                    case 42:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as String;
                            if (newValue == null) return false;
                            this.NotNullXmlColumn = newValue;
                            return true;
                        }
                    case 43:
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
                    case 44:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.NotNullSmallDateTimeColumn = newValue.Value;
                            return true;
                        }
                    case 45:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateOnly(value);
                            if (newValue == null) return false;
                            this.NotNullDateColumn = newValue.Value;
                            return true;
                        }
                    case 46:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToTimeOnly(value);
                            if (newValue == null) return false;
                            this.NotNullTimeColumn = newValue.Value;
                            return true;
                        }
                    case 47:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTime(value);
                            if (newValue == null) return false;
                            this.NotNullDateTime2Column = newValue.Value;
                            return true;
                        }
                    case 48:
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
                    case 49:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.NotNullMoneyColumn = newValue.Value;
                            return true;
                        }
                    case 50:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDecimal(value);
                            if (newValue == null) return false;
                            this.NotNullSmallMoneyColumn = newValue.Value;
                            return true;
                        }
                    case 51:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDouble(value);
                            if (newValue == null) return false;
                            this.NotNullFloatColumn = newValue.Value;
                            return true;
                        }
                    case 52:
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
                    case 53:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToSingle(value);
                            if (newValue == null) return false;
                            this.NotNullRealColumn = newValue.Value;
                            return true;
                        }
                    case 54:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToGuid(value);
                            if (newValue == null) return false;
                            this.NotNullUniqueIdentifierColumn = newValue.Value;
                            return true;
                        }
                    case 55:
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
                    case 56:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToByte(value);
                            if (newValue == null) return false;
                            this.NotNullTinyIntColumn = newValue.Value;
                            return true;
                        }
                    case 57:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDateTimeOffset(value);
                            if (newValue == null) return false;
                            this.NotNullDateTimeOffsetColumn = newValue.Value;
                            return true;
                        }
                    case 58:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = value as Object;
                            if (newValue == null) return false;
                            this.NotNullSqlVariantColumn = newValue;
                            return true;
                        }
                    case 59:
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
                }
                throw new ArgumentOutOfRangeException("index", index, "index must be 0-59");
            }
            public override Int32 GetColumnCount()
            {
                return 60;
            }
        }
    }
}
