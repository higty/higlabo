using System;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace HigLabo.Data
{
    /// <summary>
    /// Oracleサーバーへの接続及びデータ操作の機能を提供します。
    /// </summary>
    public partial class OracleDatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public OracleDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        public OracleDatabase(String dataSource, String userID, String password)
        {
            this.ConnectionString = OracleDatabaseConnectionString.Create(dataSource, userID, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DbConnection CreateDbConnection()
        {
            return new OracleConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected override DbCommand CreateDbCommand()
        {
            return new OracleCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new OracleDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is OracleDbType)
            {
                var p = new OracleParameter(name, (OracleDbType)dbType);
                if (precision.HasValue == true) p.Precision = precision.Value;
                if (scale.HasValue == true) p.Scale = scale.Value;
                return p;
            }
            throw new ArgumentException("dbType must be OracleDbType.");
        }
    }
}
