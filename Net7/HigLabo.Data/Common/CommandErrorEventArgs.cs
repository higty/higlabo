using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    public class CommandErrorEventArgs : EventArgs
    {
        public MethodName MethodName { get; private set; }
        public string ConnectionString { get; private set; } = "";
        public DbCommand? Command { get; private set; }
        public DbDataAdapter? DataAdapter { get; private set; }
        public Object? ExecutionContext { get; set; }
        public Exception Exception { get; private set; }

        public bool ThrowException { get; set; }

        protected CommandErrorEventArgs(MethodName methodName, String connectionString, Exception exception, Object? executionContext)
        {
            this.MethodName = methodName;
            this.ConnectionString = connectionString;
            this.Exception = exception;
            this.ThrowException = true;
            this.ExecutionContext = executionContext;
        }
        public CommandErrorEventArgs(MethodName methodName, String connectionString, Exception exception, Object? executionContext, DbCommand? command)
            : this(methodName, connectionString, exception, executionContext)
        {
            this.Command = command;
        }
        public CommandErrorEventArgs(MethodName methodName, String connectionString, Exception exception, Object? executionContext, DbDataAdapter? dataAdapter)
            : this(methodName, connectionString, exception, executionContext)
        {
            this.DataAdapter = dataAdapter;
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
            catch { return nameof(CommandErrorEventArgs); }
        }
    }
}
