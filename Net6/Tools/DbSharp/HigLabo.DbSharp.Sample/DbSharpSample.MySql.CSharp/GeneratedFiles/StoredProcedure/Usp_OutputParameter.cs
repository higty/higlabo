﻿//Generated at 2022/01/01 11:52:05 by DbSharpApplication.
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
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class Usp_OutputParameter : StoredProcedure
    {
        public const String Name = "Usp_OutputParameter";
        private String _CharColumn = null;
        private String _NCharColumn = null;
        private String _VarCharColumn = null;
        private String _NVarCharColumn = null;
        private Boolean? _BitColumn;
        private SByte? _TinyIntColumn;
        private Int16? _SmallIntColumn;
        private Int32? _MediumIntColumn;
        private Int32? _IntColumn;
        private Int64? _BigIntColumn;
        private Byte? _TinyIntUnsignedColumn;
        private UInt16? _SmallIntUnsignedColumn;
        private UInt32? _MediumIntUnsignedColumn;
        private UInt32? _IntUnsignedColumn;
        private UInt64? _BigIntUnsignedColumn;
        private Single? _FloatColumn;
        private Double? _DoubleColumn;
        private Decimal? _DecimalColumn;
        private Decimal? _NumericColumn;
        private DateTime? _DateColumn;
        private DateTime? _DateTimeColumn;
        private TimeSpan? _TimeColumn;
        private Int32? _YearColumn;
        private Byte[] _BinaryColumn;
        private Byte[] _VarBinaryColumn;
        private Byte[] _TinyBlobColumn;
        private Byte[] _MediumBlobColumn;
        private Byte[] _BlobColumn;
        private Byte[] _LongBlobColumn;
        private String _TinyTextColumn = null;
        private String _TextColumn = null;
        private String _MediumTextColumn = null;
        private String _LongTextColumn = null;
        private DateTime? _TimestampColumn;
        private MyEnum? _EnumColumn;
        private MySet? _SetColumn;

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
        public String CharColumn
        {
            get
            {
                return _CharColumn;
            }
            set
            {
                _CharColumn = value;
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
                _NCharColumn = value;
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
                _VarCharColumn = value;
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
                _NVarCharColumn = value;
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
                _BitColumn = value;
            }
        }
        public SByte? TinyIntColumn
        {
            get
            {
                return _TinyIntColumn;
            }
            set
            {
                _TinyIntColumn = value;
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
                _SmallIntColumn = value;
            }
        }
        public Int32? MediumIntColumn
        {
            get
            {
                return _MediumIntColumn;
            }
            set
            {
                _MediumIntColumn = value;
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
                _IntColumn = value;
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
                _BigIntColumn = value;
            }
        }
        public Byte? TinyIntUnsignedColumn
        {
            get
            {
                return _TinyIntUnsignedColumn;
            }
            set
            {
                _TinyIntUnsignedColumn = value;
            }
        }
        public UInt16? SmallIntUnsignedColumn
        {
            get
            {
                return _SmallIntUnsignedColumn;
            }
            set
            {
                _SmallIntUnsignedColumn = value;
            }
        }
        public UInt32? MediumIntUnsignedColumn
        {
            get
            {
                return _MediumIntUnsignedColumn;
            }
            set
            {
                _MediumIntUnsignedColumn = value;
            }
        }
        public UInt32? IntUnsignedColumn
        {
            get
            {
                return _IntUnsignedColumn;
            }
            set
            {
                _IntUnsignedColumn = value;
            }
        }
        public UInt64? BigIntUnsignedColumn
        {
            get
            {
                return _BigIntUnsignedColumn;
            }
            set
            {
                _BigIntUnsignedColumn = value;
            }
        }
        public Single? FloatColumn
        {
            get
            {
                return _FloatColumn;
            }
            set
            {
                _FloatColumn = value;
            }
        }
        public Double? DoubleColumn
        {
            get
            {
                return _DoubleColumn;
            }
            set
            {
                _DoubleColumn = value;
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
                _DecimalColumn = value;
            }
        }
        public Decimal? NumericColumn
        {
            get
            {
                return _NumericColumn;
            }
            set
            {
                _NumericColumn = value;
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
                _DateColumn = value;
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
                _DateTimeColumn = value;
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
                _TimeColumn = value;
            }
        }
        public Int32? YearColumn
        {
            get
            {
                return _YearColumn;
            }
            set
            {
                _YearColumn = value;
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
                _BinaryColumn = value;
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
                _VarBinaryColumn = value;
            }
        }
        public Byte[] TinyBlobColumn
        {
            get
            {
                return _TinyBlobColumn;
            }
            set
            {
                _TinyBlobColumn = value;
            }
        }
        public Byte[] MediumBlobColumn
        {
            get
            {
                return _MediumBlobColumn;
            }
            set
            {
                _MediumBlobColumn = value;
            }
        }
        public Byte[] BlobColumn
        {
            get
            {
                return _BlobColumn;
            }
            set
            {
                _BlobColumn = value;
            }
        }
        public Byte[] LongBlobColumn
        {
            get
            {
                return _LongBlobColumn;
            }
            set
            {
                _LongBlobColumn = value;
            }
        }
        public String TinyTextColumn
        {
            get
            {
                return _TinyTextColumn;
            }
            set
            {
                _TinyTextColumn = value;
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
                _TextColumn = value;
            }
        }
        public String MediumTextColumn
        {
            get
            {
                return _MediumTextColumn;
            }
            set
            {
                _MediumTextColumn = value;
            }
        }
        public String LongTextColumn
        {
            get
            {
                return _LongTextColumn;
            }
            set
            {
                _LongTextColumn = value;
            }
        }
        public DateTime? TimestampColumn
        {
            get
            {
                return _TimestampColumn;
            }
            set
            {
                _TimestampColumn = value;
            }
        }
        public MyEnum? EnumColumn
        {
            get
            {
                return _EnumColumn;
            }
            set
            {
                _EnumColumn = value;
            }
        }
        public MySet? SetColumn
        {
            get
            {
                return _SetColumn;
            }
            set
            {
                _SetColumn = value;
            }
        }

        public Usp_OutputParameter()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_MySql";
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
            
            p = db.CreateParameter("CharColumn", MySqlDbType.String, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.CharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("NCharColumn", MySqlDbType.String, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.NCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("VarCharColumn", MySqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("NVarCharColumn", MySqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.NVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("BitColumn", MySqlDbType.Bit, 1, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BitColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TinyIntColumn", MySqlDbType.Byte, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TinyIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("SmallIntColumn", MySqlDbType.Int16, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("MediumIntColumn", MySqlDbType.Int24, 7, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.MediumIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("IntColumn", MySqlDbType.Int32, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("BigIntColumn", MySqlDbType.Int64, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BigIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TinyIntUnsignedColumn", MySqlDbType.UByte, 3, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TinyIntUnsignedColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("SmallIntUnsignedColumn", MySqlDbType.UInt16, 5, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.SmallIntUnsignedColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("MediumIntUnsignedColumn", MySqlDbType.UInt24, 7, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.MediumIntUnsignedColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("IntUnsignedColumn", MySqlDbType.UInt32, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntUnsignedColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("BigIntUnsignedColumn", MySqlDbType.UInt64, 20, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.BigIntUnsignedColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("FloatColumn", MySqlDbType.Float, 8, 4);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.FloatColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("DoubleColumn", MySqlDbType.Double, 9, 5);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DoubleColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("DecimalColumn", MySqlDbType.Decimal, 10, 5);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DecimalColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("NumericColumn", MySqlDbType.Decimal, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.NumericColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("DateColumn", MySqlDbType.Date, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("DateTimeColumn", MySqlDbType.DateTime, null, 5);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.DateTimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TimeColumn", MySqlDbType.Time, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimeColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("YearColumn", MySqlDbType.Year, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.YearColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("BinaryColumn", MySqlDbType.Binary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.BinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("VarBinaryColumn", MySqlDbType.VarBinary, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 100;
            p.Value = this.VarBinaryColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TinyBlobColumn", MySqlDbType.TinyBlob, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 255;
            p.Value = this.TinyBlobColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("MediumBlobColumn", MySqlDbType.MediumBlob, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 16777215;
            p.Value = this.MediumBlobColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("BlobColumn", MySqlDbType.Blob, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 65535;
            p.Value = this.BlobColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("LongBlobColumn", MySqlDbType.LongBlob, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 2147483647;
            p.Value = this.LongBlobColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TinyTextColumn", MySqlDbType.TinyText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 255;
            p.Value = this.TinyTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TextColumn", MySqlDbType.Text, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 65535;
            p.Value = this.TextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("MediumTextColumn", MySqlDbType.MediumText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 16777215;
            p.Value = this.MediumTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("LongTextColumn", MySqlDbType.LongText, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 2147483647;
            p.Value = this.LongTextColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TimestampColumn", MySqlDbType.Timestamp, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimestampColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("EnumColumn", MySqlDbType.Enum, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 7;
            p.Value = this.EnumColumn.ToStringOrNullFromEnum();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("SetColumn", MySqlDbType.Set, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Size = 20;
            p.Value = this.SetColumn.ToStringOrNullFromEnum();
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
            var cm = command;
            DbParameter p = null;
            p = cm.Parameters[0] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.CharColumn = (String)p.Value;
            p = cm.Parameters[1] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.NCharColumn = (String)p.Value;
            p = cm.Parameters[2] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.VarCharColumn = (String)p.Value;
            p = cm.Parameters[3] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.NVarCharColumn = (String)p.Value;
            p = cm.Parameters[4] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BitColumn = ((UInt64)p.Value != 0);
            p = cm.Parameters[5] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TinyIntColumn = (SByte)p.Value;
            p = cm.Parameters[6] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SmallIntColumn = (Int16)p.Value;
            p = cm.Parameters[7] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.MediumIntColumn = (Int32)p.Value;
            p = cm.Parameters[8] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.IntColumn = (Int32)p.Value;
            p = cm.Parameters[9] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BigIntColumn = (Int64)p.Value;
            p = cm.Parameters[10] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TinyIntUnsignedColumn = (Byte)p.Value;
            p = cm.Parameters[11] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SmallIntUnsignedColumn = (UInt16)p.Value;
            p = cm.Parameters[12] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.MediumIntUnsignedColumn = (UInt32)p.Value;
            p = cm.Parameters[13] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.IntUnsignedColumn = (UInt32)p.Value;
            p = cm.Parameters[14] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BigIntUnsignedColumn = (UInt64)p.Value;
            p = cm.Parameters[15] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.FloatColumn = (Single)p.Value;
            p = cm.Parameters[16] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DoubleColumn = (Double)p.Value;
            p = cm.Parameters[17] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DecimalColumn = (Decimal)p.Value;
            p = cm.Parameters[18] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.NumericColumn = (Decimal)p.Value;
            p = cm.Parameters[19] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateColumn = (DateTime)p.Value;
            p = cm.Parameters[20] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.DateTimeColumn = (DateTime)p.Value;
            p = cm.Parameters[21] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimeColumn = (TimeSpan)p.Value;
            p = cm.Parameters[22] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.YearColumn = (Int32)p.Value;
            p = cm.Parameters[23] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BinaryColumn = (Byte[])p.Value;
            p = cm.Parameters[24] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.VarBinaryColumn = (Byte[])p.Value;
            p = cm.Parameters[25] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TinyBlobColumn = (Byte[])p.Value;
            p = cm.Parameters[26] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.MediumBlobColumn = (Byte[])p.Value;
            p = cm.Parameters[27] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.BlobColumn = (Byte[])p.Value;
            p = cm.Parameters[28] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.LongBlobColumn = (Byte[])p.Value;
            p = cm.Parameters[29] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TinyTextColumn = (String)p.Value;
            p = cm.Parameters[30] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TextColumn = (String)p.Value;
            p = cm.Parameters[31] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.MediumTextColumn = (String)p.Value;
            p = cm.Parameters[32] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.LongTextColumn = (String)p.Value;
            p = cm.Parameters[33] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimestampColumn = (DateTime)p.Value;
            p = cm.Parameters[34] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.EnumColumn = StoredProcedure.ToEnum<MyEnum>(p.Value as String) ?? this.EnumColumn;
            p = cm.Parameters[35] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.SetColumn = StoredProcedure.ToEnum<MySet>(p.Value as String) ?? this.SetColumn;
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<Usp_OutputParameter>");
            sb.AppendFormat("CharColumn={0}", this.CharColumn); sb.AppendLine();
            sb.AppendFormat("NCharColumn={0}", this.NCharColumn); sb.AppendLine();
            sb.AppendFormat("VarCharColumn={0}", this.VarCharColumn); sb.AppendLine();
            sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
            sb.AppendFormat("BitColumn={0}", this.BitColumn); sb.AppendLine();
            sb.AppendFormat("TinyIntColumn={0}", this.TinyIntColumn); sb.AppendLine();
            sb.AppendFormat("SmallIntColumn={0}", this.SmallIntColumn); sb.AppendLine();
            sb.AppendFormat("MediumIntColumn={0}", this.MediumIntColumn); sb.AppendLine();
            sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
            sb.AppendFormat("BigIntColumn={0}", this.BigIntColumn); sb.AppendLine();
            sb.AppendFormat("TinyIntUnsignedColumn={0}", this.TinyIntUnsignedColumn); sb.AppendLine();
            sb.AppendFormat("SmallIntUnsignedColumn={0}", this.SmallIntUnsignedColumn); sb.AppendLine();
            sb.AppendFormat("MediumIntUnsignedColumn={0}", this.MediumIntUnsignedColumn); sb.AppendLine();
            sb.AppendFormat("IntUnsignedColumn={0}", this.IntUnsignedColumn); sb.AppendLine();
            sb.AppendFormat("BigIntUnsignedColumn={0}", this.BigIntUnsignedColumn); sb.AppendLine();
            sb.AppendFormat("FloatColumn={0}", this.FloatColumn); sb.AppendLine();
            sb.AppendFormat("DoubleColumn={0}", this.DoubleColumn); sb.AppendLine();
            sb.AppendFormat("DecimalColumn={0}", this.DecimalColumn); sb.AppendLine();
            sb.AppendFormat("NumericColumn={0}", this.NumericColumn); sb.AppendLine();
            sb.AppendFormat("DateColumn={0}", this.DateColumn); sb.AppendLine();
            sb.AppendFormat("DateTimeColumn={0}", this.DateTimeColumn); sb.AppendLine();
            sb.AppendFormat("TimeColumn={0}", this.TimeColumn); sb.AppendLine();
            sb.AppendFormat("YearColumn={0}", this.YearColumn); sb.AppendLine();
            sb.AppendFormat("BinaryColumn={0}", this.BinaryColumn); sb.AppendLine();
            sb.AppendFormat("VarBinaryColumn={0}", this.VarBinaryColumn); sb.AppendLine();
            sb.AppendFormat("TinyBlobColumn={0}", this.TinyBlobColumn); sb.AppendLine();
            sb.AppendFormat("MediumBlobColumn={0}", this.MediumBlobColumn); sb.AppendLine();
            sb.AppendFormat("BlobColumn={0}", this.BlobColumn); sb.AppendLine();
            sb.AppendFormat("LongBlobColumn={0}", this.LongBlobColumn); sb.AppendLine();
            sb.AppendFormat("TinyTextColumn={0}", this.TinyTextColumn); sb.AppendLine();
            sb.AppendFormat("TextColumn={0}", this.TextColumn); sb.AppendLine();
            sb.AppendFormat("MediumTextColumn={0}", this.MediumTextColumn); sb.AppendLine();
            sb.AppendFormat("LongTextColumn={0}", this.LongTextColumn); sb.AppendLine();
            sb.AppendFormat("TimestampColumn={0}", this.TimestampColumn); sb.AppendLine();
            sb.AppendFormat("EnumColumn={0}", this.EnumColumn); sb.AppendLine();
            sb.AppendFormat("SetColumn={0}", this.SetColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
