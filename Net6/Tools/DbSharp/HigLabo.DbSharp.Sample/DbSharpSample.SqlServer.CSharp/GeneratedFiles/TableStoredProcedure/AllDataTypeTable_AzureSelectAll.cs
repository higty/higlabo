//Generated at 2021/12/28 12:32:44 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using HigLabo.Core;
using HigLabo.Data;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class AllDataTypeTable_AzureSelectAll : StoredProcedureWithResultSet<AllDataTypeTable_AzureSelectAll.ResultSet>
    {
        public const String Name = "AllDataTypeTable_AzureSelectAll";

        public String DatabaseKey
        {
            get
            {
                return ((IDatabaseContext)this).DatabaseKey;
            }
            set
            {
                ((IDatabaseContext)this).DatabaseKey = value;
            }
        }

        public AllDataTypeTable_AzureSelectAll()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return AllDataTypeTable_AzureSelectAll.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
        }
        public override AllDataTypeTable_AzureSelectAll.ResultSet CreateResultSet()
        {
            return new ResultSet(this);
        }
        protected override void SetResultSet(AllDataTypeTable_AzureSelectAll.ResultSet resultSet, IDataReader reader)
        {
            var r = resultSet;
            Int32 index = -1;
            try
            {
                index += 1; r.PrimaryKeyColumn = reader.GetInt64(index);
                index += 1; r.TimestampColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.BigIntColumn = reader.GetInt64(index);
                index += 1; if (reader[index] != DBNull.Value) r.BinaryColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.ImageColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.VarBinaryColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.BitColumn = reader.GetBoolean(index);
                index += 1; if (reader[index] != DBNull.Value) r.CharColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.NCharColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.NTextColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.NVarCharColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.TextColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.VarCharColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.XmlColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.DateTimeColumn = reader.GetDateTime(index);
                index += 1; if (reader[index] != DBNull.Value) r.SmallDateTimeColumn = reader.GetDateTime(index);
                index += 1; if (reader[index] != DBNull.Value) r.DateColumn = DateOnly.FromDateTime((DateTime)reader[index]);
                index += 1; if (reader[index] != DBNull.Value) r.TimeColumn = TimeOnly.FromTimeSpan((TimeSpan)reader[index]);
                index += 1; if (reader[index] != DBNull.Value) r.DateTime2Column = reader.GetDateTime(index);
                index += 1; if (reader[index] != DBNull.Value) r.DecimalColumn = reader.GetDecimal(index);
                index += 1; if (reader[index] != DBNull.Value) r.MoneyColumn = reader.GetDecimal(index);
                index += 1; if (reader[index] != DBNull.Value) r.SmallMoneyColumn = reader.GetDecimal(index);
                index += 1; if (reader[index] != DBNull.Value) r.FloatColumn = reader.GetDouble(index);
                index += 1; if (reader[index] != DBNull.Value) r.IntColumn = reader.GetInt32(index);
                index += 1; if (reader[index] != DBNull.Value) r.RealColumn = reader.GetFloat(index);
                index += 1; if (reader[index] != DBNull.Value) r.UniqueIdentifierColumn = reader.GetGuid(index);
                index += 1; if (reader[index] != DBNull.Value) r.SmallIntColumn = reader.GetInt16(index);
                index += 1; if (reader[index] != DBNull.Value) r.TinyIntColumn = reader.GetByte(index);
                index += 1; if (reader[index] != DBNull.Value) r.DateTimeOffsetColumn = (DateTimeOffset)reader[index];
                index += 1; if (reader[index] != DBNull.Value) r.SqlVariantColumn = reader[index] as Object;
                index += 1; if (reader[index] != DBNull.Value) r.EnumColumn = StoredProcedure.ToEnum<MyEnum>(reader[index] as String) ?? r.EnumColumn;
                index += 1; r.NotNullBigIntColumn = reader.GetInt64(index);
                index += 1; r.NotNullBinaryColumn = reader[index] as Byte[];
                index += 1; r.NotNullImageColumn = reader[index] as Byte[];
                index += 1; r.NotNullVarBinaryColumn = reader[index] as Byte[];
                index += 1; r.NotNullBitColumn = reader.GetBoolean(index);
                index += 1; r.NotNullCharColumn = reader[index] as String;
                index += 1; r.NotNullNCharColumn = reader[index] as String;
                index += 1; r.NotNullNTextColumn = reader[index] as String;
                index += 1; r.NotNullNVarCharColumn = reader[index] as String;
                index += 1; r.NotNullTextColumn = reader[index] as String;
                index += 1; r.NotNullVarCharColumn = reader[index] as String;
                index += 1; r.NotNullXmlColumn = reader[index] as String;
                index += 1; r.NotNullDateTimeColumn = reader.GetDateTime(index);
                index += 1; r.NotNullSmallDateTimeColumn = reader.GetDateTime(index);
                index += 1; r.NotNullDateColumn = DateOnly.FromDateTime((DateTime)reader[index]);
                index += 1; r.NotNullTimeColumn = TimeOnly.FromTimeSpan((TimeSpan)reader[index]);
                index += 1; r.NotNullDateTime2Column = reader.GetDateTime(index);
                index += 1; r.NotNullDecimalColumn = reader.GetDecimal(index);
                index += 1; r.NotNullMoneyColumn = reader.GetDecimal(index);
                index += 1; r.NotNullSmallMoneyColumn = reader.GetDecimal(index);
                index += 1; r.NotNullFloatColumn = reader.GetDouble(index);
                index += 1; r.NotNullIntColumn = reader.GetInt32(index);
                index += 1; r.NotNullRealColumn = reader.GetFloat(index);
                index += 1; r.NotNullUniqueIdentifierColumn = reader.GetGuid(index);
                index += 1; r.NotNullSmallIntColumn = reader.GetInt16(index);
                index += 1; r.NotNullTinyIntColumn = reader.GetByte(index);
                index += 1; r.NotNullDateTimeOffsetColumn = (DateTimeOffset)reader[index];
                index += 1; r.NotNullSqlVariantColumn = reader[index] as Object;
                index += 1; r.NotNullEnumColumn = StoredProcedure.ToEnum<MyEnum>(reader[index] as String) ?? r.NotNullEnumColumn;
            }
            catch (Exception ex)
            {
                throw new StoredProcedureSchemaMismatchedException(this, index, ex);
            }
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<AllDataTypeTable_AzureSelectAll>");
            return sb.ToString();
        }

        public partial class ResultSet : StoredProcedureResultSet, AllDataTypeTable_Azure.IRecord
        {
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

            public ResultSet()
            {
            }
            public ResultSet(AllDataTypeTable_Azure.IRecord resultSet)
            {
                var r = resultSet;
                PrimaryKeyColumn = r.PrimaryKeyColumn;
                TimestampColumn = r.TimestampColumn;
                BigIntColumn = r.BigIntColumn;
                BinaryColumn = r.BinaryColumn;
                ImageColumn = r.ImageColumn;
                VarBinaryColumn = r.VarBinaryColumn;
                BitColumn = r.BitColumn;
                CharColumn = r.CharColumn;
                NCharColumn = r.NCharColumn;
                NTextColumn = r.NTextColumn;
                NVarCharColumn = r.NVarCharColumn;
                TextColumn = r.TextColumn;
                VarCharColumn = r.VarCharColumn;
                XmlColumn = r.XmlColumn;
                DateTimeColumn = r.DateTimeColumn;
                SmallDateTimeColumn = r.SmallDateTimeColumn;
                DateColumn = r.DateColumn;
                TimeColumn = r.TimeColumn;
                DateTime2Column = r.DateTime2Column;
                DecimalColumn = r.DecimalColumn;
                MoneyColumn = r.MoneyColumn;
                SmallMoneyColumn = r.SmallMoneyColumn;
                FloatColumn = r.FloatColumn;
                IntColumn = r.IntColumn;
                RealColumn = r.RealColumn;
                UniqueIdentifierColumn = r.UniqueIdentifierColumn;
                SmallIntColumn = r.SmallIntColumn;
                TinyIntColumn = r.TinyIntColumn;
                DateTimeOffsetColumn = r.DateTimeOffsetColumn;
                SqlVariantColumn = r.SqlVariantColumn;
                EnumColumn = r.EnumColumn;
                NotNullBigIntColumn = r.NotNullBigIntColumn;
                NotNullBinaryColumn = r.NotNullBinaryColumn;
                NotNullImageColumn = r.NotNullImageColumn;
                NotNullVarBinaryColumn = r.NotNullVarBinaryColumn;
                NotNullBitColumn = r.NotNullBitColumn;
                NotNullCharColumn = r.NotNullCharColumn;
                NotNullNCharColumn = r.NotNullNCharColumn;
                NotNullNTextColumn = r.NotNullNTextColumn;
                NotNullNVarCharColumn = r.NotNullNVarCharColumn;
                NotNullTextColumn = r.NotNullTextColumn;
                NotNullVarCharColumn = r.NotNullVarCharColumn;
                NotNullXmlColumn = r.NotNullXmlColumn;
                NotNullDateTimeColumn = r.NotNullDateTimeColumn;
                NotNullSmallDateTimeColumn = r.NotNullSmallDateTimeColumn;
                NotNullDateColumn = r.NotNullDateColumn;
                NotNullTimeColumn = r.NotNullTimeColumn;
                NotNullDateTime2Column = r.NotNullDateTime2Column;
                NotNullDecimalColumn = r.NotNullDecimalColumn;
                NotNullMoneyColumn = r.NotNullMoneyColumn;
                NotNullSmallMoneyColumn = r.NotNullSmallMoneyColumn;
                NotNullFloatColumn = r.NotNullFloatColumn;
                NotNullIntColumn = r.NotNullIntColumn;
                NotNullRealColumn = r.NotNullRealColumn;
                NotNullUniqueIdentifierColumn = r.NotNullUniqueIdentifierColumn;
                NotNullSmallIntColumn = r.NotNullSmallIntColumn;
                NotNullTinyIntColumn = r.NotNullTinyIntColumn;
                NotNullDateTimeOffsetColumn = r.NotNullDateTimeOffsetColumn;
                NotNullSqlVariantColumn = r.NotNullSqlVariantColumn;
                NotNullEnumColumn = r.NotNullEnumColumn;
            }
            internal ResultSet(AllDataTypeTable_AzureSelectAll storedProcedure)
            {
                this._StoredProcedureResultSet_StoredProcedure = storedProcedure;
            }

            public override String ToString()
            {
                var sb = new StringBuilder(64);
                sb.AppendLine("<AllDataTypeTable_AzureSelectAll.ResultSet>");
                sb.AppendFormat("PrimaryKeyColumn={0}", this.PrimaryKeyColumn); sb.AppendLine();
                sb.AppendFormat("TimestampColumn={0}", this.TimestampColumn); sb.AppendLine();
                sb.AppendFormat("BigIntColumn={0}", this.BigIntColumn); sb.AppendLine();
                sb.AppendFormat("BinaryColumn={0}", this.BinaryColumn); sb.AppendLine();
                sb.AppendFormat("ImageColumn={0}", this.ImageColumn); sb.AppendLine();
                sb.AppendFormat("VarBinaryColumn={0}", this.VarBinaryColumn); sb.AppendLine();
                sb.AppendFormat("BitColumn={0}", this.BitColumn); sb.AppendLine();
                sb.AppendFormat("CharColumn={0}", this.CharColumn); sb.AppendLine();
                sb.AppendFormat("NCharColumn={0}", this.NCharColumn); sb.AppendLine();
                sb.AppendFormat("NTextColumn={0}", this.NTextColumn); sb.AppendLine();
                sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
                sb.AppendFormat("TextColumn={0}", this.TextColumn); sb.AppendLine();
                sb.AppendFormat("VarCharColumn={0}", this.VarCharColumn); sb.AppendLine();
                sb.AppendFormat("XmlColumn={0}", this.XmlColumn); sb.AppendLine();
                sb.AppendFormat("DateTimeColumn={0}", this.DateTimeColumn); sb.AppendLine();
                sb.AppendFormat("SmallDateTimeColumn={0}", this.SmallDateTimeColumn); sb.AppendLine();
                sb.AppendFormat("DateColumn={0}", this.DateColumn); sb.AppendLine();
                sb.AppendFormat("TimeColumn={0}", this.TimeColumn); sb.AppendLine();
                sb.AppendFormat("DateTime2Column={0}", this.DateTime2Column); sb.AppendLine();
                sb.AppendFormat("DecimalColumn={0}", this.DecimalColumn); sb.AppendLine();
                sb.AppendFormat("MoneyColumn={0}", this.MoneyColumn); sb.AppendLine();
                sb.AppendFormat("SmallMoneyColumn={0}", this.SmallMoneyColumn); sb.AppendLine();
                sb.AppendFormat("FloatColumn={0}", this.FloatColumn); sb.AppendLine();
                sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
                sb.AppendFormat("RealColumn={0}", this.RealColumn); sb.AppendLine();
                sb.AppendFormat("UniqueIdentifierColumn={0}", this.UniqueIdentifierColumn); sb.AppendLine();
                sb.AppendFormat("SmallIntColumn={0}", this.SmallIntColumn); sb.AppendLine();
                sb.AppendFormat("TinyIntColumn={0}", this.TinyIntColumn); sb.AppendLine();
                sb.AppendFormat("DateTimeOffsetColumn={0}", this.DateTimeOffsetColumn); sb.AppendLine();
                sb.AppendFormat("SqlVariantColumn={0}", this.SqlVariantColumn); sb.AppendLine();
                sb.AppendFormat("EnumColumn={0}", this.EnumColumn); sb.AppendLine();
                sb.AppendFormat("NotNullBigIntColumn={0}", this.NotNullBigIntColumn); sb.AppendLine();
                sb.AppendFormat("NotNullBinaryColumn={0}", this.NotNullBinaryColumn); sb.AppendLine();
                sb.AppendFormat("NotNullImageColumn={0}", this.NotNullImageColumn); sb.AppendLine();
                sb.AppendFormat("NotNullVarBinaryColumn={0}", this.NotNullVarBinaryColumn); sb.AppendLine();
                sb.AppendFormat("NotNullBitColumn={0}", this.NotNullBitColumn); sb.AppendLine();
                sb.AppendFormat("NotNullCharColumn={0}", this.NotNullCharColumn); sb.AppendLine();
                sb.AppendFormat("NotNullNCharColumn={0}", this.NotNullNCharColumn); sb.AppendLine();
                sb.AppendFormat("NotNullNTextColumn={0}", this.NotNullNTextColumn); sb.AppendLine();
                sb.AppendFormat("NotNullNVarCharColumn={0}", this.NotNullNVarCharColumn); sb.AppendLine();
                sb.AppendFormat("NotNullTextColumn={0}", this.NotNullTextColumn); sb.AppendLine();
                sb.AppendFormat("NotNullVarCharColumn={0}", this.NotNullVarCharColumn); sb.AppendLine();
                sb.AppendFormat("NotNullXmlColumn={0}", this.NotNullXmlColumn); sb.AppendLine();
                sb.AppendFormat("NotNullDateTimeColumn={0}", this.NotNullDateTimeColumn); sb.AppendLine();
                sb.AppendFormat("NotNullSmallDateTimeColumn={0}", this.NotNullSmallDateTimeColumn); sb.AppendLine();
                sb.AppendFormat("NotNullDateColumn={0}", this.NotNullDateColumn); sb.AppendLine();
                sb.AppendFormat("NotNullTimeColumn={0}", this.NotNullTimeColumn); sb.AppendLine();
                sb.AppendFormat("NotNullDateTime2Column={0}", this.NotNullDateTime2Column); sb.AppendLine();
                sb.AppendFormat("NotNullDecimalColumn={0}", this.NotNullDecimalColumn); sb.AppendLine();
                sb.AppendFormat("NotNullMoneyColumn={0}", this.NotNullMoneyColumn); sb.AppendLine();
                sb.AppendFormat("NotNullSmallMoneyColumn={0}", this.NotNullSmallMoneyColumn); sb.AppendLine();
                sb.AppendFormat("NotNullFloatColumn={0}", this.NotNullFloatColumn); sb.AppendLine();
                sb.AppendFormat("NotNullIntColumn={0}", this.NotNullIntColumn); sb.AppendLine();
                sb.AppendFormat("NotNullRealColumn={0}", this.NotNullRealColumn); sb.AppendLine();
                sb.AppendFormat("NotNullUniqueIdentifierColumn={0}", this.NotNullUniqueIdentifierColumn); sb.AppendLine();
                sb.AppendFormat("NotNullSmallIntColumn={0}", this.NotNullSmallIntColumn); sb.AppendLine();
                sb.AppendFormat("NotNullTinyIntColumn={0}", this.NotNullTinyIntColumn); sb.AppendLine();
                sb.AppendFormat("NotNullDateTimeOffsetColumn={0}", this.NotNullDateTimeOffsetColumn); sb.AppendLine();
                sb.AppendFormat("NotNullSqlVariantColumn={0}", this.NotNullSqlVariantColumn); sb.AppendLine();
                sb.AppendFormat("NotNullEnumColumn={0}", this.NotNullEnumColumn); sb.AppendLine();
                return sb.ToString();
            }
        }
    }
}
