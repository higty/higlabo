//Generated at 2022/01/05 08:55:34 by DbSharpApplication.
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
    public partial class MultiPkTableSelectByPrimaryKey : StoredProcedureWithResultSet<MultiPkTableSelectByPrimaryKey.ResultSet>
    {
        public const String Name = "MultiPkTableSelectByPrimaryKey";
        private Int64 _PK_BigIntColumn;
        private Int32 _PK_IntColumn;
        private Double _PK_FloatColumn;

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
        public Int64 PK_BigIntColumn
        {
            get
            {
                return _PK_BigIntColumn;
            }
            set
            {
                _PK_BigIntColumn = value;
            }
        }
        public Int32 PK_IntColumn
        {
            get
            {
                return _PK_IntColumn;
            }
            set
            {
                _PK_IntColumn = value;
            }
        }
        public Double PK_FloatColumn
        {
            get
            {
                return _PK_FloatColumn;
            }
            set
            {
                _PK_FloatColumn = value;
            }
        }

        public MultiPkTableSelectByPrimaryKey()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return MultiPkTableSelectByPrimaryKey.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@PK_BigIntColumn", SqlDbType.BigInt, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_BigIntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@PK_IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@PK_FloatColumn", SqlDbType.Float, 53, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_FloatColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
        }
        public override MultiPkTableSelectByPrimaryKey.ResultSet CreateResultSet()
        {
            return new ResultSet(this);
        }
        protected override void SetResultSet(MultiPkTableSelectByPrimaryKey.ResultSet resultSet, IDataReader reader)
        {
            var r = resultSet;
            Int32 index = -1;
            try
            {
                index += 1; r.BigIntColumn = reader.GetInt64(index);
                index += 1; r.IntColumn = reader.GetInt32(index);
                index += 1; r.FloatColumn = reader.GetDouble(index);
                index += 1; if (reader[index] != DBNull.Value) r.BinaryColumn = reader[index] as Byte[];
                index += 1; r.TimestampColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.VarBinaryColumn = reader[index] as Byte[];
                index += 1; if (reader[index] != DBNull.Value) r.BitColumn = reader.GetBoolean(index);
                index += 1; if (reader[index] != DBNull.Value) r.NCharColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.NTextColumn = reader[index] as String;
                index += 1; if (reader[index] != DBNull.Value) r.NVarCharColumn = reader[index] as String;
            }
            catch (Exception ex)
            {
                throw new StoredProcedureSchemaMismatchedException(this, index, ex);
            }
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<MultiPkTableSelectByPrimaryKey>");
            sb.AppendFormat("PK_BigIntColumn={0}", this.PK_BigIntColumn); sb.AppendLine();
            sb.AppendFormat("PK_IntColumn={0}", this.PK_IntColumn); sb.AppendLine();
            sb.AppendFormat("PK_FloatColumn={0}", this.PK_FloatColumn); sb.AppendLine();
            return sb.ToString();
        }

        public partial class ResultSet : StoredProcedureResultSet, MultiPkTable.IRecord
        {
            private Int64 _BigIntColumn;
            private Int32 _IntColumn;
            private Double _FloatColumn;
            private Byte[] _BinaryColumn;
            private Byte[] _TimestampColumn;
            private Byte[] _VarBinaryColumn;
            private Boolean? _BitColumn;
            private String _NCharColumn = null;
            private String _NTextColumn = null;
            private String _NVarCharColumn = null;

            public Int64 BigIntColumn
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
            public Int32 IntColumn
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
            public Double FloatColumn
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
            public Byte[] TimestampColumn
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
            public String NTextColumn
            {
                get
                {
                    return _NTextColumn;
                }
                set
                {
                    _NTextColumn = value;
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

            public ResultSet()
            {
            }
            public ResultSet(MultiPkTable.IRecord resultSet)
            {
                var r = resultSet;
                BigIntColumn = r.BigIntColumn;
                IntColumn = r.IntColumn;
                FloatColumn = r.FloatColumn;
                BinaryColumn = r.BinaryColumn;
                TimestampColumn = r.TimestampColumn;
                VarBinaryColumn = r.VarBinaryColumn;
                BitColumn = r.BitColumn;
                NCharColumn = r.NCharColumn;
                NTextColumn = r.NTextColumn;
                NVarCharColumn = r.NVarCharColumn;
            }
            internal ResultSet(MultiPkTableSelectByPrimaryKey storedProcedure)
            {
                this._StoredProcedureResultSet_StoredProcedure = storedProcedure;
            }

            public override String ToString()
            {
                var sb = new StringBuilder(64);
                sb.AppendLine("<MultiPkTableSelectByPrimaryKey.ResultSet>");
                sb.AppendFormat("BigIntColumn={0}", this.BigIntColumn); sb.AppendLine();
                sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
                sb.AppendFormat("FloatColumn={0}", this.FloatColumn); sb.AppendLine();
                sb.AppendFormat("BinaryColumn={0}", this.BinaryColumn); sb.AppendLine();
                sb.AppendFormat("TimestampColumn={0}", this.TimestampColumn); sb.AppendLine();
                sb.AppendFormat("VarBinaryColumn={0}", this.VarBinaryColumn); sb.AppendLine();
                sb.AppendFormat("BitColumn={0}", this.BitColumn); sb.AppendLine();
                sb.AppendFormat("NCharColumn={0}", this.NCharColumn); sb.AppendLine();
                sb.AppendFormat("NTextColumn={0}", this.NTextColumn); sb.AppendLine();
                sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
                return sb.ToString();
            }
        }
    }
}
