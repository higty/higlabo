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
    public partial class IdentityTableSelectAll : StoredProcedureWithResultSet<IdentityTableSelectAll.ResultSet>
    {
        public const String Name = "IdentityTableSelectAll";

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

        public IdentityTableSelectAll()
        {
            ConstructorExecuted();
        }

        public override String GetDatabaseKey()
        {
            return "DbSharpSample_SqlServer";
        }
        public override String GetStoredProcedureName()
        {
            return IdentityTableSelectAll.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand()
        {
            var db = new SqlServerDatabase("");
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
        }
        public override IdentityTableSelectAll.ResultSet CreateResultSet()
        {
            return new ResultSet(this);
        }
        public new IdentityTableSelectAll.ResultSet GetFirstResultSet()
        {
            return base.GetFirstResultSet() as IdentityTableSelectAll.ResultSet;
        }
        public new IdentityTableSelectAll.ResultSet GetFirstResultSet(Database database)
        {
            return base.GetFirstResultSet(database) as IdentityTableSelectAll.ResultSet;
        }
        protected override void SetResultSet(IdentityTableSelectAll.ResultSet resultSet, IDataReader reader)
        {
            var r = resultSet;
            Int32 index = -1;
            try
            {
                index += 1; r.IntColumn = reader.GetInt32(index);
                index += 1; if (reader[index] != DBNull.Value) r.NVarCharColumn = reader[index] as String;
            }
            catch (InvalidCastException ex)
            {
                throw new StoredProcedureSchemaMismatchedException(this, index, ex);
            }
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<IdentityTableSelectAll>");
            return sb.ToString();
        }

        public partial class ResultSet : StoredProcedureResultSet, IdentityTable.IRecord
        {
            private Int32 _IntColumn;
            private String _NVarCharColumn = "";

            public Int32 IntColumn
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

            public ResultSet()
            {
            }
            public ResultSet(IdentityTable.IRecord resultSet)
            {
                var r = resultSet;
                IntColumn = r.IntColumn;
                NVarCharColumn = r.NVarCharColumn;
            }
            internal ResultSet(IdentityTableSelectAll storedProcedure)
            {
                this._StoredProcedureResultSet_StoredProcedure = storedProcedure;
            }

            public override String ToString()
            {
                var sb = new StringBuilder(64);
                sb.AppendLine("<IdentityTableSelectAll.ResultSet>");
                sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
                sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
                return sb.ToString();
            }
        }
    }
}
