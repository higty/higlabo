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
    public partial class AllDataTypeTableUpdate : StoredProcedure
    {
        public const String Name = "AllDataTypeTableUpdate";

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
        public Int64 PK_PrimaryKeyColumn { get; set; }
        public Byte[] PK_TimestampColumn { get; set; }

        public AllDataTypeTableUpdate()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return AllDataTypeTableUpdate.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@PrimaryKeyColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PrimaryKeyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TimestampColumn", SqlDbType.Timestamp, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimestampColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BigIntColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.BigIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BinaryColumn", SqlDbType.Binary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.BinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@ImageColumn", SqlDbType.Image, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.ImageColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@VarBinaryColumn", SqlDbType.VarBinary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.VarBinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BitColumn", SqlDbType.Bit, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.BitColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@CharColumn", SqlDbType.Char, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.CharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NCharColumn", SqlDbType.NChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NTextColumn", SqlDbType.NText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 1073741823;
            p.Value = this.NTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NVarCharColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TextColumn", SqlDbType.Text, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.TextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@VarCharColumn", SqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.VarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@XmlColumn", SqlDbType.Xml, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = -1;
            p.Value = this.XmlColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeColumn", SqlDbType.DateTime, null, 3);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.DateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallDateTimeColumn", SqlDbType.SmallDateTime, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.SmallDateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateColumn", SqlDbType.Date, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.DateColumn?.ToDateTime(TimeOnly.MinValue);
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TimeColumn", SqlDbType.Time, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.TimeColumn?.ToTimeSpan();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTime2Column", SqlDbType.DateTime2, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.DateTime2Column;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DecimalColumn", SqlDbType.Decimal, 18, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.DecimalColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@MoneyColumn", SqlDbType.Money, 19, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.MoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallMoneyColumn", SqlDbType.SmallMoney, 10, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.SmallMoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@FloatColumn", SqlDbType.Float, 53, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.FloatColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@RealColumn", SqlDbType.Real, 24, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.RealColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@UniqueIdentifierColumn", SqlDbType.UniqueIdentifier, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.UniqueIdentifierColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallIntColumn", SqlDbType.SmallInt, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.SmallIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TinyIntColumn", SqlDbType.TinyInt, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.TinyIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeOffsetColumn", SqlDbType.DateTimeOffset, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.DateTimeOffsetColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SqlVariantColumn", SqlDbType.Variant, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 0;
            p.Value = this.SqlVariantColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@EnumColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 20;
            p.Value = this.EnumColumn.ToStringOrNullFromEnum();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullBigIntColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullBigIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullBinaryColumn", SqlDbType.Binary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullBinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullImageColumn", SqlDbType.Image, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.NotNullImageColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullVarBinaryColumn", SqlDbType.VarBinary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullVarBinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullBitColumn", SqlDbType.Bit, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullBitColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullCharColumn", SqlDbType.Char, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullNCharColumn", SqlDbType.NChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullNCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullNTextColumn", SqlDbType.NText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 1073741823;
            p.Value = this.NotNullNTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullNVarCharColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullNVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullTextColumn", SqlDbType.Text, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.NotNullTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullVarCharColumn", SqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NotNullVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullXmlColumn", SqlDbType.Xml, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = -1;
            p.Value = this.NotNullXmlColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullDateTimeColumn", SqlDbType.DateTime, null, 3);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullDateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullSmallDateTimeColumn", SqlDbType.SmallDateTime, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullSmallDateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullDateColumn", SqlDbType.Date, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullDateColumn.ToDateTime(TimeOnly.MinValue);
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullTimeColumn", SqlDbType.Time, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullTimeColumn.ToTimeSpan();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullDateTime2Column", SqlDbType.DateTime2, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullDateTime2Column;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullDecimalColumn", SqlDbType.Decimal, 18, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullDecimalColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullMoneyColumn", SqlDbType.Money, 19, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullMoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullSmallMoneyColumn", SqlDbType.SmallMoney, 10, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullSmallMoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullFloatColumn", SqlDbType.Float, 53, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullFloatColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullIntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullRealColumn", SqlDbType.Real, 24, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullRealColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullUniqueIdentifierColumn", SqlDbType.UniqueIdentifier, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullUniqueIdentifierColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullSmallIntColumn", SqlDbType.SmallInt, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullSmallIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullTinyIntColumn", SqlDbType.TinyInt, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullTinyIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullDateTimeOffsetColumn", SqlDbType.DateTimeOffset, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.NotNullDateTimeOffsetColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullSqlVariantColumn", SqlDbType.Variant, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 0;
            p.Value = this.NotNullSqlVariantColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NotNullEnumColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 20;
            p.Value = this.NotNullEnumColumn.ToStringFromEnum();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@PK_PrimaryKeyColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_PrimaryKeyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@PK_TimestampColumn", SqlDbType.Timestamp, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_TimestampColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
            var cm = command;
            DbParameter p = null;
            p = cm.Parameters[1] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimestampColumn = (Byte[])p.Value;
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<AllDataTypeTableUpdate>");
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
            sb.AppendFormat("PK_PrimaryKeyColumn={0}", this.PK_PrimaryKeyColumn); sb.AppendLine();
            sb.AppendFormat("PK_TimestampColumn={0}", this.PK_TimestampColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
