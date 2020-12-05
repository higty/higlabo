using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    public class SqlServerCommandExecutedEventArgs : CommandExecutedEventArgs 
    {
        /// <summary>
        /// 実行されたバルクコピーのコンテキストを取得します。
        /// </summary>
        public SqlBulkCopyContext Context { get; private set; }
        public SqlServerCommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, Object executionContext, SqlBulkCopyContext sqlBulkCopyContext)
            : base(methodName, connectionString, startTime, endTime, executionContext)
        {
            this.Context = sqlBulkCopyContext;
        }
        public override string ToString()
        {
            var sb = new StringBuilder(128);
            try
            {
                if (String.IsNullOrEmpty(ConnectionString) == false)
                {
                    sb.Append(ConnectionString);
                    sb.Append(" ");
                }
                if (Command != null)
                {
                    sb.Append(Command.CommandText);
                    sb.Append(" ");
                }
                return sb.ToString();
            }
            catch { return base.ToString(); }
        }
    }
}
