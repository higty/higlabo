using System;
using System.Data;
using System.Text;
using System.ComponentModel;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class RowGuidColTable
    {
        public partial class Record : TableRecord<Record>, IRecord
        {
            private Guid _RowGuidColumn;
            private String _NVarCharColumn = "";

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
            public Guid RowGuidColumn
            {
                get
                {
                    return _RowGuidColumn;
                }
                set
                {
                    this.SetPropertyValue(ref _RowGuidColumn, value, this.GetPropertyChangedEventHandler());
                }
            }
            public String NVarCharColumn
            {
                get
                {
                    return _NVarCharColumn;
                }
                set
                {
                    this.SetPropertyValue(ref _NVarCharColumn, value, this.GetPropertyChangedEventHandler());
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
                return "RowGuidColTable";
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
                this.RowGuidColumn = r.RowGuidColumn;
                this.NVarCharColumn = r.NVarCharColumn;
            }
            public override Boolean CompareAllColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.RowGuidColumn, r.RowGuidColumn) && 
                Object.Equals(this.NVarCharColumn, r.NVarCharColumn);
            }
            public override Boolean ComparePrimaryKeyColumn(Record record)
            {
                if (record == null) throw new ArgumentNullException("record");
                var r = record;
                return Object.Equals(this.RowGuidColumn, r.RowGuidColumn);
            }
            public override Object GetValue(Int32 index)
            {
                switch (index)
                {
                    case 0: return this.RowGuidColumn;
                    case 1: return this.NVarCharColumn;
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
                            var newValue = TableRecord.TypeConverter.ToGuid(value);
                            if (newValue == null) return false;
                            this.RowGuidColumn = newValue.Value;
                            return true;
                        }
                    case 1:
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
                throw new ArgumentOutOfRangeException("index", index, "index must be 0-1");
            }
            public override Int32 GetColumnCount()
            {
                return 2;
            }
        }
    }
}
