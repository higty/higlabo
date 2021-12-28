//Generated at 2021/12/28 12:32:44 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient.Server;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class MyTableType1 : UserDefinedTableType<MyTableType1.Record>
    {
        public override SqlDataRecord CreateSqlDataRecord()
        {
            SqlMetaData[] metaData = new SqlMetaData[4];
            metaData[0] = new SqlMetaData("BigIntColumn", SqlDbType.BigInt);
            metaData[1] = new SqlMetaData("BinaryColumn", SqlDbType.Binary, 100);
            metaData[2] = new SqlMetaData("ImageColumn", SqlDbType.Image);
            metaData[3] = new SqlMetaData("VarBinaryColumn", SqlDbType.VarBinary, 100);
            return new SqlDataRecord(metaData);
        }

        public partial class Record : UserDefinedTableTypeRecord
        {
            public Int64 BigIntColumn { get; set; }
            public Byte[] BinaryColumn { get; set; }
            public Byte[] ImageColumn { get; set; }
            public Byte[] VarBinaryColumn { get; set; }

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
