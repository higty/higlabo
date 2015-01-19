using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandExecutedEventArgs : EventArgs
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
        /// 実行されたデータアダプタを取得します。
        /// </summary>
        public DbDataAdapter DataAdapter { get; private set; }

        /// <summary>
        /// 実行されたバルクコピーのコンテキストを取得します。
        /// </summary>
        public SqlBulkCopyContext Context { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset StartTime { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset EndTime { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Duration
        {
            get { return this.EndTime - this.StartTime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            this.MethodName = methodName;
            this.ConnectionString = connectionString;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, DbCommand command)
            : this(methodName, connectionString, startTime, endTime)
        {
            this.Command = command;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="dataAdapter"></param>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, DbDataAdapter dataAdapter)
            : this(methodName, connectionString, startTime, endTime)
        {
            this.DataAdapter = dataAdapter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="context"></param>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, SqlBulkCopyContext context)
            : this(methodName, connectionString, startTime, endTime)
        {
            this.Context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
