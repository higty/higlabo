using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlServerCommandExecutingEventArgs : CommandExecutingEventArgs
    {
        public SqlBulkCopyContext SqlBulkCopyContext { get; private set; }
        public SqlServerCommandExecutingEventArgs(MethodName methodName, String connectionString, SqlBulkCopyContext sqlBulkCopyContext)
            : base(methodName, connectionString)
        {
            Cancel = false;
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
                return sb.ToString();
            }
            catch { return base.ToString(); }
        }
    }
}
