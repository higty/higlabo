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
        private Int64? _BigIntColumn;
        private Byte[] _BinaryColumn;
        private Byte[] _ImageColumn;
        private Byte[] _VarBinaryColumn;
        private Boolean? _BitColumn;
        private String _CharColumn = "";
        private String _NCharColumn = "";
        private String _NTextColumn = "";
        private String _NVarCharColumn = "";
        private String _TextColumn = "";
        private String _VarCharColumn = "";
        private String _XmlColumn = "";
        private DateTime? _DateTimeColumn;
        private DateTime? _SmallDateTimeColumn;
        private DateTime? _DateColumn;
        private TimeSpan? _TimeColumn;
        private DateTime? _DateTime2Column;
        private Decimal? _DecimalColumn;
        private Decimal? _MoneyColumn;
        private Decimal? _SmallMoneyColumn;
        private Double? _FloatColumn;
        private Int32? _IntColumn;
        private Single? _RealColumn;
        private Guid? _UniqueIdentifierColumn;
        private Int16? _SmallIntColumn;
        private Byte? _TinyIntColumn;
        private DateTimeOffset? _DateTimeOffsetColumn;
        private global::Microsoft.SqlServer.Types.SqlGeometry _GeometryColumn;
        private global::Microsoft.SqlServer.Types.SqlGeography _GeographyColumn;
        private global::Microsoft.SqlServer.Types.SqlHierarchyId? _HierarchyIDColumn;
        private String _EnumColumn = "";

        public String TransactionKey
        {
            get
            {
                return ((IDatabaseContext)this).TransactionKey;
            }
            set
            {
                ((IDatabaseContext)this).TransactionKey = value;
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
        public Boolean? BitColumn
        {
            get
            {
                return _BitColumn;
            }
            set
            {
                this.SetPropertyValue(ref _BitColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _CharColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public String NCharColumn
        {
            get
            {
                return _NCharColumn;
            }
            set
            {
                this.SetPropertyValue(ref _NCharColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public String NTextColumn
        {
            get
            {
                return _NTextColumn;
            }
            set
            {
                this.SetPropertyValue(ref _NTextColumn, value, this.GetPropertyChangedEventHandler());
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
        public String TextColumn
        {
            get
            {
                return _TextColumn;
            }
            set
            {
                this.SetPropertyValue(ref _TextColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _VarCharColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public String XmlColumn
        {
            get
            {
                return _XmlColumn;
            }
            set
            {
                this.SetPropertyValue(ref _XmlColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _DateTimeColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public DateTime? SmallDateTimeColumn
        {
            get
            {
                return _SmallDateTimeColumn;
            }
            set
            {
                this.SetPropertyValue(ref _SmallDateTimeColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _DateColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _TimeColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public DateTime? DateTime2Column
        {
            get
            {
                return _DateTime2Column;
            }
            set
            {
                this.SetPropertyValue(ref _DateTime2Column, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _DecimalColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Decimal? MoneyColumn
        {
            get
            {
                return _MoneyColumn;
            }
            set
            {
                this.SetPropertyValue(ref _MoneyColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Decimal? SmallMoneyColumn
        {
            get
            {
                return _SmallMoneyColumn;
            }
            set
            {
                this.SetPropertyValue(ref _SmallMoneyColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Double? FloatColumn
        {
            get
            {
                return _FloatColumn;
            }
            set
            {
                this.SetPropertyValue(ref _FloatColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _IntColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Single? RealColumn
        {
            get
            {
                return _RealColumn;
            }
            set
            {
                this.SetPropertyValue(ref _RealColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Guid? UniqueIdentifierColumn
        {
            get
            {
                return _UniqueIdentifierColumn;
            }
            set
            {
                this.SetPropertyValue(ref _UniqueIdentifierColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _SmallIntColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Byte? TinyIntColumn
        {
            get
            {
                return _TinyIntColumn;
            }
            set
            {
                this.SetPropertyValue(ref _TinyIntColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public DateTimeOffset? DateTimeOffsetColumn
        {
            get
            {
                return _DateTimeOffsetColumn;
            }
            set
            {
                this.SetPropertyValue(ref _DateTimeOffsetColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public global::Microsoft.SqlServer.Types.SqlGeometry GeometryColumn
        {
            get
            {
                return _GeometryColumn;
            }
            set
            {
                this.SetPropertyValue(ref _GeometryColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public global::Microsoft.SqlServer.Types.SqlGeography GeographyColumn
        {
            get
            {
                return _GeographyColumn;
            }
            set
            {
                this.SetPropertyValue(ref _GeographyColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public global::Microsoft.SqlServer.Types.SqlHierarchyId? HierarchyIDColumn
        {
            get
            {
                return _HierarchyIDColumn;
            }
            set
            {
                this.SetPropertyValue(ref _HierarchyIDColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public String EnumColumn
        {
            get
            {
                return _EnumColumn;
            }
            set
            {
                this.SetPropertyValue(ref _EnumColumn, value, this.GetPropertyChangedEventHandler());
            }
        }

        public Usp_OutputParameter()
        {
            ConstructorExecuted();
        }

        public override String GetDatabaseKey()
        {
            return "DbSharpSample_SqlServer";
        }
        public override String GetStoredProcedureName()
        {
            return Usp_OutputParameter.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand()
        {
            var db = new SqlServerDatabase("");
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@BigIntColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BigIntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BinaryColumn", SqlDbType.Binary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.BinaryColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@ImageColumn", SqlDbType.Image, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.ImageColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@VarBinaryColumn", SqlDbType.VarBinary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarBinaryColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@BitColumn", SqlDbType.Bit, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BitColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@CharColumn", SqlDbType.Char, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.CharColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NCharColumn", SqlDbType.NChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.NCharColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NTextColumn", SqlDbType.NText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 1073741823;
            p.Value = this.NTextColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NVarCharColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.NVarCharColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TextColumn", SqlDbType.Text, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 2147483647;
            p.Value = this.TextColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@VarCharColumn", SqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarCharColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@XmlColumn", SqlDbType.Xml, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = -1;
            p.Value = this.XmlColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeColumn", SqlDbType.DateTime, null, 3);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTimeColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallDateTimeColumn", SqlDbType.SmallDateTime, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallDateTimeColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateColumn", SqlDbType.Date, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TimeColumn", SqlDbType.Time, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimeColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTime2Column", SqlDbType.DateTime2, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTime2Column;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DecimalColumn", SqlDbType.Decimal, 18, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DecimalColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@MoneyColumn", SqlDbType.Money, 19, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.MoneyColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallMoneyColumn", SqlDbType.SmallMoney, 10, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallMoneyColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@FloatColumn", SqlDbType.Float, 53, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.FloatColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@RealColumn", SqlDbType.Real, 24, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.RealColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@UniqueIdentifierColumn", SqlDbType.UniqueIdentifier, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.UniqueIdentifierColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@SmallIntColumn", SqlDbType.SmallInt, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallIntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@TinyIntColumn", SqlDbType.TinyInt, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TinyIntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@DateTimeOffsetColumn", SqlDbType.DateTimeOffset, null, 7);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTimeOffsetColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@GeometryColumn", SqlDbType.Udt, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = -1;
            p.SetUdtTypeName("geometry");
            p.Value = this.GeometryColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@GeographyColumn", SqlDbType.Udt, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = -1;
            p.SetUdtTypeName("geography");
            p.Value = this.GeographyColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@HierarchyIDColumn", SqlDbType.Udt, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 892;
            p.SetUdtTypeName("hierarchyid");
            p.Value = this.HierarchyIDColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@EnumColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 20;
            p.Value = this.EnumColumn;
            cm.Parameters.Add(p);
            
            for (int i = 0; i < cm.Parameters.Count; i++)
            {
                if (cm.Parameters[i].Value == null) cm.Parameters[i].Value = DBNull.Value;
            }
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
            if (p.Value != DBNull.Value && p.Value != null) this.DateColumn = (DateTime)p.Value;
            p = cm.Parameters[15] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimeColumn = (TimeSpan)p.Value;
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
            if (p.Value != DBNull.Value && p.Value != null) this.GeometryColumn = (global::Microsoft.SqlServer.Types.SqlGeometry)p.Value;
            p = cm.Parameters[28] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.GeographyColumn = (global::Microsoft.SqlServer.Types.SqlGeography)p.Value;
            p = cm.Parameters[30] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.EnumColumn = (String)p.Value;
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
            sb.AppendFormat("GeometryColumn={0}", this.GeometryColumn); sb.AppendLine();
            sb.AppendFormat("GeographyColumn={0}", this.GeographyColumn); sb.AppendLine();
            sb.AppendFormat("HierarchyIDColumn={0}", this.HierarchyIDColumn); sb.AppendLine();
            sb.AppendFormat("EnumColumn={0}", this.EnumColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
