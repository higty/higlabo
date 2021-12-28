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
    public partial class Usp_OutputParameter : StoredProcedure
    {
        public const String Name = "Usp_OutputParameter";

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
        public MyEnum? EnumColumn { get; set; }

        public Usp_OutputParameter()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return Usp_OutputParameter.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@BigIntColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BigIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BinaryColumn", SqlDbType.Binary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
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
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarBinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BitColumn", SqlDbType.Bit, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BitColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@CharColumn", SqlDbType.Char, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.CharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NCharColumn", SqlDbType.NChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
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
            p.Direction = ParameterDirection.InputOutput;
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
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@XmlColumn", SqlDbType.Xml, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = -1;
            p.Value = this.XmlColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeColumn", SqlDbType.DateTime, null, 3);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallDateTimeColumn", SqlDbType.SmallDateTime, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallDateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateColumn", SqlDbType.Date, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateColumn?.ToDateTime(TimeOnly.MinValue);
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TimeColumn", SqlDbType.Time, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimeColumn?.ToTimeSpan();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTime2Column", SqlDbType.DateTime2, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTime2Column;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DecimalColumn", SqlDbType.Decimal, 18, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DecimalColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@MoneyColumn", SqlDbType.Money, 19, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.MoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallMoneyColumn", SqlDbType.SmallMoney, 10, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallMoneyColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@FloatColumn", SqlDbType.Float, 53, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.FloatColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@RealColumn", SqlDbType.Real, 24, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.RealColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@UniqueIdentifierColumn", SqlDbType.UniqueIdentifier, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.UniqueIdentifierColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallIntColumn", SqlDbType.SmallInt, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TinyIntColumn", SqlDbType.TinyInt, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TinyIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeOffsetColumn", SqlDbType.DateTimeOffset, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTimeOffsetColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@EnumColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 20;
            p.Value = this.EnumColumn.ToStringOrNullFromEnum();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
            var cm = command;
            DbParameter p = null;
            p = cm.Parameters[0] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BigIntColumn = (Int64)p.Value;
            p = cm.Parameters[1] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BinaryColumn = (Byte[])p.Value;
            p = cm.Parameters[3] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.VarBinaryColumn = (Byte[])p.Value;
            p = cm.Parameters[4] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BitColumn = (Boolean)p.Value;
            p = cm.Parameters[5] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.CharColumn = (String)p.Value;
            p = cm.Parameters[6] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.NCharColumn = (String)p.Value;
            p = cm.Parameters[8] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.NVarCharColumn = (String)p.Value;
            p = cm.Parameters[10] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.VarCharColumn = (String)p.Value;
            p = cm.Parameters[11] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.XmlColumn = (String)p.Value;
            p = cm.Parameters[12] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateTimeColumn = (DateTime)p.Value;
            p = cm.Parameters[13] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SmallDateTimeColumn = (DateTime)p.Value;
            p = cm.Parameters[14] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateColumn = DateOnly.FromDateTime((DateTime)p.Value);
            p = cm.Parameters[15] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimeColumn = TimeOnly.FromTimeSpan((TimeSpan)p.Value);
            p = cm.Parameters[16] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateTime2Column = (DateTime)p.Value;
            p = cm.Parameters[17] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DecimalColumn = (Decimal)p.Value;
            p = cm.Parameters[18] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.MoneyColumn = (Decimal)p.Value;
            p = cm.Parameters[19] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SmallMoneyColumn = (Decimal)p.Value;
            p = cm.Parameters[20] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.FloatColumn = (Double)p.Value;
            p = cm.Parameters[21] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.IntColumn = (Int32)p.Value;
            p = cm.Parameters[22] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.RealColumn = (Single)p.Value;
            p = cm.Parameters[23] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.UniqueIdentifierColumn = (Guid)p.Value;
            p = cm.Parameters[24] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SmallIntColumn = (Int16)p.Value;
            p = cm.Parameters[25] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TinyIntColumn = (Byte)p.Value;
            p = cm.Parameters[26] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateTimeOffsetColumn = (DateTimeOffset)p.Value;
            p = cm.Parameters[27] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.EnumColumn = StoredProcedure.ToEnum<MyEnum>(p.Value as String) ?? this.EnumColumn;
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<Usp_OutputParameter>");
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
            sb.AppendFormat("EnumColumn={0}", this.EnumColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
