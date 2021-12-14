using System;
using System.Data;
using Npgsql;
using System.Data.Common;
using NpgsqlTypes;

namespace HigLabo.Data
{
    /// <summary>
    /// Postgreサーバーへの接続及びデータ操作の機能を提供します。
    /// </summary>
    public partial class PostgreSqlDatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public PostgreSqlDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        public PostgreSqlDatabase(String serverName, String databaseName, String userID, String password)
        {
            this.ConnectionString = PostgreSqlDatabaseConnectionString.Create(serverName, databaseName, userID, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DbConnection CreateDbConnection()
        {
            return new NpgsqlConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected override DbCommand CreateDbCommand()
        {
            return new NpgsqlCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new NpgsqlDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is NpgsqlDbType)
            {
                var p = new NpgsqlParameter(name, (NpgsqlDbType)dbType);
                if (precision.HasValue == true) p.Precision = precision.Value;
                if (scale.HasValue == true) p.Scale = scale.Value;
                return p;
            }
            throw new ArgumentException("dbType must be NpgsqlDbType.");
        }
    }
}
