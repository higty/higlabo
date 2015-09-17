using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandExecutingEventArgs : EventArgs
    {
        /// <summary>
        /// エラーが発生したメソッドを示す値を取得します。
        /// </summary>
        public MethodName MethodName { get; private set; }

        /// <summary>
        /// コマンドが実行されるデータベースへの接続文字列を取得します。
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// 実行されたコマンドを取得します。
        /// </summary>
        public DbCommand Command { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DbDataAdapter DataAdapter { get; private set; }

        /// <summary>
        /// 実行されたバルクコピーのコンテキストを取得します。
        /// </summary>
        public SqlBulkCopyContext SqlBulkCopyContext { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Object ExecutionContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        public CommandExecutingEventArgs(MethodName methodName, String connectionString)
        {
            MethodName = methodName;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        public CommandExecutingEventArgs(MethodName methodName, String connectionString, DbCommand command)
            : this(methodName, connectionString)
        {
            Cancel = false;
            Command = command;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="dataAdapter"></param>
        public CommandExecutingEventArgs(MethodName methodName, String connectionString, DbDataAdapter dataAdapter)
            : this(methodName, connectionString)
        {
            Cancel = false;
            DataAdapter = dataAdapter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="context"></param>
        public CommandExecutingEventArgs(MethodName methodName, String connectionString, SqlBulkCopyContext sqlBulkCopyContext)
            : this(methodName, connectionString)
        {
            Cancel = false;
            this.SqlBulkCopyContext = sqlBulkCopyContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
