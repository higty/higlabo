using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HigLabo.Data
{
    public class CommandExecutingEventArgs : EventArgs
    {
        public MethodName MethodName { get; private set; }
        public string ConnectionString { get; private set; }
        public DbCommand Command { get; private set; }
        public DbDataAdapter DataAdapter { get; private set; }
        public Object ExecutionContext { get; set; }
        public bool Cancel { get; set; }

        public CommandExecutingEventArgs(MethodName methodName, String connectionString)
        {
            MethodName = methodName;
            ConnectionString = connectionString;
        }
        public CommandExecutingEventArgs(MethodName methodName, String connectionString, DbCommand command)
            : this(methodName, connectionString)
        {
            Cancel = false;
            Command = command;
        }
        public CommandExecutingEventArgs(MethodName methodName, String connectionString, DbDataAdapter dataAdapter)
            : this(methodName, connectionString)
        {
            Cancel = false;
            DataAdapter = dataAdapter;
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
