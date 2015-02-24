using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class MyTableType1 : UserDefinedTableType<MyTableType1.Record>
    {
        public override DataTable CreateDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("BigIntColumn", typeof(Int64));
            dt.Columns.Add("BinaryColumn", typeof(Byte[]));
            dt.Columns.Add("ImageColumn", typeof(Byte[]));
            dt.Columns.Add("VarBinaryColumn", typeof(Byte[]));
            return dt;
        }

        public partial class Record : UserDefinedTableTypeRecord
        {
            private Int64 _BigIntColumn;
            private Byte[] _BinaryColumn;
            private Byte[] _ImageColumn;
            private Byte[] _VarBinaryColumn;

            public Int64 BigIntColumn
            {
                get
                {
                    return _BigIntColumn;
                }
                set
                {
                    this.SetPropertyValue(ref _BigIntColumn, value, this.GetPropertyChangedEventHandler());
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
                    this.SetPropertyValue(ref _BinaryColumn, value, this.GetPropertyChangedEventHandler());
                }
            }
            public Byte[] ImageColumn
            {
                get
                {
                    return _ImageColumn;
                }
                set
                {
                    this.SetPropertyValue(ref _ImageColumn, value, this.GetPropertyChangedEventHandler());
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
                    this.SetPropertyValue(ref _VarBinaryColumn, value, this.GetPropertyChangedEventHandler());
                }
            }

            public Record()
            {
            }

            public override Object[] GetValues()
            {
                Object[] oo = new Object[4];
                oo[0] = this.BigIntColumn;
                oo[1] = this.BinaryColumn;
                oo[2] = this.ImageColumn;
                oo[3] = this.VarBinaryColumn;
                return oo;
            }
        }
    }
}
