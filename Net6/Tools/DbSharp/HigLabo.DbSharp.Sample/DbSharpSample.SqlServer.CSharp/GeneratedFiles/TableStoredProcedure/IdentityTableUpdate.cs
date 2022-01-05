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
    public partial class IdentityTableUpdate : StoredProcedure
    {
        public const String Name = "IdentityTableUpdate";
        private Int32 _IntColumn;
        private String _NVarCharColumn = null;
        private Int32 _PK_IntColumn;

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

        public IdentityTableUpdate()
        {
            ((IDatabaseContext)this).DatabaseKey = "DbSharpSample_SqlServer";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return IdentityTableUpdate.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("@IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@NVarCharColumn", SqlDbType.NVarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("@PK_IntColumn", SqlDbType.Int, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
            var cm = command;
            DbParameter p = null;
            p = cm.Parameters[0] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.IntColumn = (Int32)p.Value;
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<IdentityTableUpdate>");
            sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
            sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
            sb.AppendFormat("PK_IntColumn={0}", this.PK_IntColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
