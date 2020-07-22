using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    public class SqlServerCommandErrorEventArgs : CommandErrorEventArgs 
    {
        public SqlBulkCopyContext SqlBulkCopyContext { get; private set; }
        public SqlServerCommandErrorEventArgs(MethodName methodName, String connectionString, Exception exception, Object executionContext, SqlBulkCopyContext sqlBulkCopyContext)
            : base(methodName, connectionString, exception, executionContext)
        {
            this.SqlBulkCopyContext = sqlBulkCopyContext;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(128);
            try
            {
                if (String.IsNullOrEmpty(this.ConnectionString) == false)
                {
                    sb.Append(this.ConnectionString);
                    sb.Append(" ");
                }
                if (this.Command != null)
                {
                    sb.Append(this.Command.CommandText);
                    sb.Append(" ");
                }
                if (this.Exception != null)
                {
                    sb.Append(this.Exception.ToString());
                }
                return sb.ToString();
            }
            catch { return base.ToString(); }
        }
    }
}
