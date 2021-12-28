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
    public partial class RowGuidColTableSelectByPrimaryKey : StoredProcedureWithResultSet<RowGuidColTableSelectByPrimaryKey.ResultSet>
    {
        public const String Name = "RowGuidColTableSelectByPrimaryKey";

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
        public Guid PK_RowGuidColumn { get; set; }

        public RowGuidColTableSelectByPrimaryKey()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return RowGuidColTableSelectByPrimaryKey.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@PK_RowGuidColumn", SqlDbType.UniqueIdentifier, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_RowGuidColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
        }
        public override RowGuidColTableSelectByPrimaryKey.ResultSet CreateResultSet()
        {
            return new ResultSet(this);
        }
        protected override void SetResultSet(RowGuidColTableSelectByPrimaryKey.ResultSet resultSet, IDataReader reader)
        {
            var r = resultSet;
            Int32 index = -1;
            try
            {
                index += 1; r.RowGuidColumn = reader.GetGuid(index);
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
            sb.AppendLine("<RowGuidColTableSelectByPrimaryKey>");
            sb.AppendFormat("PK_RowGuidColumn={0}", this.PK_RowGuidColumn); sb.AppendLine();
            return sb.ToString();
        }

        public partial class ResultSet : StoredProcedureResultSet, RowGuidColTable.IRecord
        {
            public Guid RowGuidColumn { get; set; }
            public String NVarCharColumn { get; set; } = null;

            public ResultSet()
            {
            }
            public ResultSet(RowGuidColTable.IRecord resultSet)
            {
                var r = resultSet;
                RowGuidColumn = r.RowGuidColumn;
                NVarCharColumn = r.NVarCharColumn;
            }
            internal ResultSet(RowGuidColTableSelectByPrimaryKey storedProcedure)
            {
                this._StoredProcedureResultSet_StoredProcedure = storedProcedure;
            }

            public override String ToString()
            {
                var sb = new StringBuilder(64);
                sb.AppendLine("<RowGuidColTableSelectByPrimaryKey.ResultSet>");
                sb.AppendFormat("RowGuidColumn={0}", this.RowGuidColumn); sb.AppendLine();
                sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
                return sb.ToString();
            }
        }
    }
}
