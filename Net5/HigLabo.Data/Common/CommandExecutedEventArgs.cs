using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    public class CommandExecutedEventArgs : EventArgs
    {
        public MethodName MethodName { get; private set; }
        public string ConnectionString { get; private set; }
        public DbCommand Command { get; private set; }
        public DbDataAdapter DataAdapter { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset EndTime { get; private set; }
        public TimeSpan Duration
        {
            get { return this.EndTime - this.StartTime; }
        }
        public Object ExecutionContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, Object executionContext)
        {
            this.MethodName = methodName;
            this.ConnectionString = connectionString;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.ExecutionContext = executionContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, Object executionContext, DbCommand command)
            : this(methodName, connectionString, startTime, endTime, executionContext)
        {
            this.Command = command;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="dataAdapter"></param>
        public CommandExecutedEventArgs(MethodName methodName, String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, Object executionContext, DbDataAdapter dataAdapter)
            : this(methodName, connectionString, startTime, endTime, executionContext)
        {
            this.DataAdapter = dataAdapter;
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
