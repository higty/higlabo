﻿//Generated by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net7
using System.Data;
using System.Data.Common;
using System.Text;
using HigLabo.Core;
using HigLabo.Data;
using HigLabo.DbSharp;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class identitytableInsert : StoredProcedure
    {
        public const String Name = "identitytableInsert";
        private Int32? _IntColumn;
        private DateTime? _TimestampColumn;
        private String? _NVarCharColumn = null;

        public String DatabaseKey
        {
            get
            {
                return ((IDatabaseKey)this).DatabaseKey;
            }
            set
            {
                ((IDatabaseKey)this).DatabaseKey = value;
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
        public String? NVarCharColumn
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

        public identitytableInsert()
        {
            ((IDatabaseKey)this).DatabaseKey = "DbSharpSample";
            ConstructorExecuted();
        }

        public override String GetStoredProcedureName()
        {
            return identitytableInsert.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand(Database database)
        {
            var db = database;
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter? p = null;
            
            p = db.CreateParameter("IntColumn", MySqlDbType.Int32, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.IntColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("TimestampColumn", MySqlDbType.Timestamp, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.InputOutput;
            p.Value = this.TimestampColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("NVarCharColumn", MySqlDbType.VarChar, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Size = 100;
            p.Value = this.NVarCharColumn;
            p.Value = p.Value ?? DBNull.Value;
            cm.Parameters.Add(p);
            
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
            var cm = command;
            DbParameter? p = null;
            p = cm.Parameters[0] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.IntColumn = (Int32)p.Value;
            p = cm.Parameters[1] as DbParameter;
            if (p.Value != DBNull.Value && p.Value != null) this.TimestampColumn = (DateTime)p.Value;
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<identitytableInsert>");
            sb.AppendFormat("IntColumn={0}", this.IntColumn); sb.AppendLine();
            sb.AppendFormat("TimestampColumn={0}", this.TimestampColumn); sb.AppendLine();
            sb.AppendFormat("NVarCharColumn={0}", this.NVarCharColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
