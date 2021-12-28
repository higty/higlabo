//Generated at 2021/12/28 12:32:44 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Text;
using System.ComponentModel;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class MultiPkTable
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
            public Int64 BigIntColumn { get; set; }
            public Int32 IntColumn { get; set; }
            public Double FloatColumn { get; set; }
            public Byte[] BinaryColumn { get; set; }
            public Byte[] TimestampColumn { get; set; }
            public Byte[] VarBinaryColumn { get; set; }
            public Boolean? BitColumn { get; set; }
            public String NCharColumn { get; set; } = null;
            public String NTextColumn { get; set; } = null;
            public String NVarCharColumn { get; set; } = null;

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
                return "MultiPkTable";
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
                this.BigIntColumn = r.BigIntColumn;
                this.IntColumn = r.IntColumn;
                this.FloatColumn = r.FloatColumn;
                this.BinaryColumn = r.BinaryColumn;
                this.TimestampColumn = r.TimestampColumn;
                this.VarBinaryColumn = r.VarBinaryColumn;
                this.BitColumn = r.BitColumn;
                this.NCharColumn = r.NCharColumn;
                this.NTextColumn = r.NTextColumn;
                this.NVarCharColumn = r.NVarCharColumn;
            }
            public override Boolean CompareAllColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.BigIntColumn, r.BigIntColumn) && 
                Object.Equals(this.IntColumn, r.IntColumn) && 
                Object.Equals(this.FloatColumn, r.FloatColumn) && 
                Object.Equals(this.BinaryColumn, r.BinaryColumn) && 
                Object.Equals(this.TimestampColumn, r.TimestampColumn) && 
                Object.Equals(this.VarBinaryColumn, r.VarBinaryColumn) && 
                Object.Equals(this.BitColumn, r.BitColumn) && 
                Object.Equals(this.NCharColumn, r.NCharColumn) && 
                Object.Equals(this.NTextColumn, r.NTextColumn) && 
                Object.Equals(this.NVarCharColumn, r.NVarCharColumn);
            }
            public override Boolean ComparePrimaryKeyColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.BigIntColumn, r.BigIntColumn) && 
                Object.Equals(this.IntColumn, r.IntColumn) && 
                Object.Equals(this.FloatColumn, r.FloatColumn);
            }
            public override Object GetValue(Int32 index)
            {
                switch (index)
                {
                    case 0: return this.BigIntColumn;
                    case 1: return this.IntColumn;
                    case 2: return this.FloatColumn;
                    case 3: return this.BinaryColumn;
                    case 4: return this.TimestampColumn;
                    case 5: return this.VarBinaryColumn;
                    case 6: return this.BitColumn;
                    case 7: return this.NCharColumn;
                    case 8: return this.NTextColumn;
                    case 9: return this.NVarCharColumn;
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
                            this.BigIntColumn = newValue.Value;
                            return true;
                        }
                    case 1:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToInt32(value);
                            if (newValue == null) return false;
                            this.IntColumn = newValue.Value;
                            return true;
                        }
                    case 2:
                        if (value == null)
                        {
                            return false;
                        }
                        else
                        {
                            var newValue = TableRecord.TypeConverter.ToDouble(value);
                            if (newValue == null) return false;
                            this.FloatColumn = newValue.Value;
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
                            return false;
                        }
                        else
                        {
                            var newValue = value as Byte[];
                            if (newValue == null) return false;
                            this.TimestampColumn = newValue;
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
                    case 8:
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
                    case 9:
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
                }
                throw new ArgumentOutOfRangeException("index", index, "index must be 0-9");
            }
            public override Int32 GetColumnCount()
            {
                return 10;
            }
        }
    }
}
