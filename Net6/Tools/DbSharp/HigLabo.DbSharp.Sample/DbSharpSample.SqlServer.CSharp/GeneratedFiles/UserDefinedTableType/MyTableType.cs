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
    public partial class MyTableType : UserDefinedTableType<MyTableType.Record>
    {
        public override SqlDataRecord CreateSqlDataRecord()
        {
            SqlMetaData[] metaData = new SqlMetaData[28];
            metaData[0] = new SqlMetaData("BigIntColumn", SqlDbType.BigInt);
            metaData[1] = new SqlMetaData("BinaryColumn", SqlDbType.Binary, 100);
            metaData[2] = new SqlMetaData("ImageColumn", SqlDbType.Image);
            metaData[3] = new SqlMetaData("VarBinaryColumn", SqlDbType.VarBinary, 100);
            metaData[4] = new SqlMetaData("BitColumn", SqlDbType.Bit);
            metaData[5] = new SqlMetaData("CharColumn", SqlDbType.Char, 100);
            metaData[6] = new SqlMetaData("NCharColumn", SqlDbType.NChar, 100);
            metaData[7] = new SqlMetaData("NTextColumn", SqlDbType.NText);
            metaData[8] = new SqlMetaData("NVarCharColumn", SqlDbType.NVarChar, 100);
            metaData[9] = new SqlMetaData("TextColumn", SqlDbType.Text);
            metaData[10] = new SqlMetaData("VarCharColumn", SqlDbType.VarChar, 100);
            metaData[11] = new SqlMetaData("XmlColumn", SqlDbType.Xml);
            metaData[12] = new SqlMetaData("DateTimeColumn", SqlDbType.DateTime);
            metaData[13] = new SqlMetaData("SmallDateTimeColumn", SqlDbType.SmallDateTime);
            metaData[14] = new SqlMetaData("DateColumn", SqlDbType.Date);
            metaData[15] = new SqlMetaData("TimeColumn", SqlDbType.Time);
            metaData[16] = new SqlMetaData("DateTime2Column", SqlDbType.DateTime2, 0, 7);
            metaData[17] = new SqlMetaData("DecimalColumn", SqlDbType.Decimal, 18, 0);
            metaData[18] = new SqlMetaData("MoneyColumn", SqlDbType.Money);
            metaData[19] = new SqlMetaData("SmallMoneyColumn", SqlDbType.SmallMoney);
            metaData[20] = new SqlMetaData("FloatColumn", SqlDbType.Float);
            metaData[21] = new SqlMetaData("IntColumn", SqlDbType.Int);
            metaData[22] = new SqlMetaData("RealColumn", SqlDbType.Real);
            metaData[23] = new SqlMetaData("UniqueIdentifierColumn", SqlDbType.UniqueIdentifier);
            metaData[24] = new SqlMetaData("SmallIntColumn", SqlDbType.SmallInt);
            metaData[25] = new SqlMetaData("TinyIntColumn", SqlDbType.TinyInt);
            metaData[26] = new SqlMetaData("DateTimeOffsetColumn", SqlDbType.DateTimeOffset, 0, 7);
            metaData[27] = new SqlMetaData("EnumColumn", SqlDbType.NVarChar, 20);
            return new SqlDataRecord(metaData);
        }

        public partial class Record : UserDefinedTableTypeRecord
        {
            public Int64 BigIntColumn { get; set; }
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
            public MyEnum? EnumColumn { get; set; }

            public Record()
            {
            }

            public override Object[] GetValues()
            {
                Object[] oo = new Object[28];
                oo[0] = this.BigIntColumn;
                oo[1] = this.BinaryColumn;
                oo[2] = this.ImageColumn;
                oo[3] = this.VarBinaryColumn;
                oo[4] = this.BitColumn;
                oo[5] = this.CharColumn;
                oo[6] = this.NCharColumn;
                oo[7] = this.NTextColumn;
                oo[8] = this.NVarCharColumn;
                oo[9] = this.TextColumn;
                oo[10] = this.VarCharColumn;
                oo[11] = this.XmlColumn;
                oo[12] = this.DateTimeColumn;
                oo[13] = this.SmallDateTimeColumn;
                oo[14] = this.DateColumn?.ToDateTime(TimeOnly.MinValue);
                oo[15] = this.TimeColumn?.ToTimeSpan();
                oo[16] = this.DateTime2Column;
                oo[17] = this.DecimalColumn;
                oo[18] = this.MoneyColumn;
                oo[19] = this.SmallMoneyColumn;
                oo[20] = this.FloatColumn;
                oo[21] = this.IntColumn;
                oo[22] = this.RealColumn;
                oo[23] = this.UniqueIdentifierColumn;
                oo[24] = this.SmallIntColumn;
                oo[25] = this.TinyIntColumn;
                oo[26] = this.DateTimeOffsetColumn;
                if (this.EnumColumn != null) oo[27] = this.EnumColumn.ToString();
                return oo;
            }
        }
    }
}
