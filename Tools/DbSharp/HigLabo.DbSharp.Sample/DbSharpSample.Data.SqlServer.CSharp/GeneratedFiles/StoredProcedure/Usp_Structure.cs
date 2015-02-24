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
    public partial class Usp_Structure : StoredProcedure
    {
        public const String Name = "Usp_Structure";
        private Int64? _BigIntColumn;
        private MyTableType _StructuredColumn = new MyTableType();

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
        public MyTableType StructuredColumn
        {
            get
            {
                return _StructuredColumn;
            }
            set
            {
                this.SetPropertyValue(ref _StructuredColumn, value, this.GetPropertyChangedEventHandler());
            }
        }

        public Usp_Structure()
        {
            ConstructorExecuted();
        }

        public override String GetDatabaseKey()
        {
            return "DbSharpSample_SqlServer";
        }
        public override String GetStoredProcedureName()
        {
            return Usp_Structure.Name;
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
            
            p = db.CreateParameter("@StructuredColumn", SqlDbType.Structured, null, null);
            p.SourceColumn = p.ParameterName;
            p.Direction = ParameterDirection.Input;
            p.SetTypeName("MyTableType");
            var dt = this.StructuredColumn.CreateDataTable();
            foreach (var item in this.StructuredColumn.Records)
            {
                dt.Rows.Add(item.GetValues());
            }
            p.Value = dt;
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
        }
        public override String ToString()
        {
            var sb = new StringBuilder(32);
            sb.AppendLine("<Usp_Structure>");
            sb.AppendFormat("BigIntColumn={0}", this.BigIntColumn); sb.AppendLine();
            sb.AppendFormat("StructuredColumn={0}", this.StructuredColumn); sb.AppendLine();
            return sb.ToString();
        }
    }
}
