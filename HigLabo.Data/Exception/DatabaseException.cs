using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace HigLabo.Data
{
    /// <summary>
    /// データベースで発生した例外を表現します。
    /// </summary>
    [Serializable]
    public class DatabaseException : Exception
    {
        private Dictionary<String, object> _Data = new Dictionary<string, object>();

        /// <summary>
        /// エラーが発生したメソッドを示す値を取得します。
        /// </summary>
        public MethodName MethodName { get; set; }

        /// <summary>
        /// コマンドが実行されるデータベースへの接続文字列を取得します。
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 実行されたコマンドを取得します。
        /// </summary>
        public DbCommand Command { get; set; }

        /// <summary>
        /// 実行されたデータアダプタを取得します。
        /// </summary>
        public DbDataAdapter DataAdapter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override System.Collections.IDictionary Data
        {
            get { return _Data; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlException SqlException
        {
            get { return this.InnerException as SqlException; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public DatabaseException(Exception ex)
            : this(ex, MethodName.Unknown, "")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="methodName"></param>
        /// <param name="connectionString"></param>
        /// <param name="context"></param>
        public DatabaseException(Exception ex, MethodName methodName, String connectionString)
            : base(ex.Message, ex)
        {
            this.MethodName = methodName;
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.SqlException != null)
            {
                sb.Append("SqlException.Number=");
                sb.Append(this.SqlException.Number);
                sb.AppendLine();
            }
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
