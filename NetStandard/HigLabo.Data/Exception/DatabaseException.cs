using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
    [Serializable]
    public class DatabaseException : Exception
    {
        private Dictionary<String, object> _Data = new Dictionary<string, object>();

        public MethodName MethodName { get; set; }
        public string ConnectionString { get; set; }
        public DbCommand Command { get; set; }
        public DbDataAdapter DataAdapter { get; set; }

        public override System.Collections.IDictionary Data
        {
            get { return _Data; }
        }

        public DatabaseException(Exception ex)
            : this(ex, MethodName.Unknown, "")
        {
        }
        public DatabaseException(Exception ex, MethodName methodName, String connectionString)
            : base(ex.Message, ex)
        {
            this.MethodName = methodName;
            this.ConnectionString = connectionString;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Command != null)
            {
                sb.Append("SqlCommand.CommandText=");
                sb.Append(Command.CommandText);
                sb.AppendLine();
                foreach (var parameter in Command.Parameters)
                {
                    IDbDataParameter p = parameter as IDbDataParameter;
                    if (p == null) { continue; }
                    sb.AppendFormat("{0}={1}", p.ParameterName, p.Value);
                    sb.AppendLine();
                }
            }
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
