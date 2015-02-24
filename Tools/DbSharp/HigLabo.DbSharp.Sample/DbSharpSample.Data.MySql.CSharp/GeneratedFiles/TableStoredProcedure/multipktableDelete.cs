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
    public partial class multipktableDelete : StoredProcedure
    {
        public const String Name = "multipktableDelete";
        private Int64 _PK_BigIntColumn;
        private Int32 _PK_IntColumn;
        private Single _PK_FloatColumn;
        private DateTime _PK_TimestampColumn;

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
        public Int64 PK_BigIntColumn
        {
            get
            {
                return _PK_BigIntColumn;
            }
            set
            {
                this.SetPropertyValue(ref _PK_BigIntColumn, value, this.GetPropertyChangedEventHandler());
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
                this.SetPropertyValue(ref _PK_IntColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public Single PK_FloatColumn
        {
            get
            {
                return _PK_FloatColumn;
            }
            set
            {
                this.SetPropertyValue(ref _PK_FloatColumn, value, this.GetPropertyChangedEventHandler());
            }
        }
        public DateTime PK_TimestampColumn
        {
            get
            {
                return _PK_TimestampColumn;
            }
            set
            {
                this.SetPropertyValue(ref _PK_TimestampColumn, value, this.GetPropertyChangedEventHandler());
            }
        }

        public multipktableDelete()
        {
            ConstructorExecuted();
        }

        public override String GetDatabaseKey()
        {
            return "DbSharpSample_MySql";
        }
        public override String GetStoredProcedureName()
        {
            return multipktableDelete.Name;
        }
        partial void ConstructorExecuted();
        public override DbCommand CreateCommand()
        {
            var db = new MySqlDatabase("");
            var cm = db.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = this.GetStoredProcedureName();
            
            DbParameter p = null;
            
            p = db.CreateParameter("PK_BigIntColumn", MySqlDbType.Int64, 19, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_BigIntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("PK_IntColumn", MySqlDbType.Int32, 10, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_IntColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("PK_FloatColumn", MySqlDbType.Float, 12, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_FloatColumn;
            cm.Parameters.Add(p);
            
            p = db.CreateParameter("PK_TimestampColumn", MySqlDbType.Timestamp, null, 0);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.Value = this.PK_TimestampColumn;
            cm.Parameters.Add(p);
            
            for (int i = 0; i < cm.Parameters.Count; i++)
            {
                if (cm.Parameters[i].Value == null) cm.Parameters[i].Value = DBNull.Value;
            }
            return cm;
        }
        protected override void SetOutputParameterValue(DbCommand command)
        {
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<multipktableDelete>");
            sb.AppendFormat("PK_BigIntColumn={0}", this.PK_BigIntColumn); sb.AppendLine();
            sb.AppendFormat("PK_IntColumn={0}", this.PK_IntColumn); sb.AppendLine();
            sb.AppendFormat("PK_FloatColumn={0}", this.PK_FloatColumn); sb.AppendLine();
            sb.AppendFormat("PK_TimestampColumn={0}", this.PK_TimestampColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
