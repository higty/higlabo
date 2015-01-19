using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace HigLabo.Data
{
    /// <summary>
    /// MYSQLサーバーへの接続及びデータ操作の機能を提供します。
    /// </summary>
    public partial class SQLiteDatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public SQLiteDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="password"></param>
        public SQLiteDatabase(String filePath, String password)
        {
            this.ConnectionString = SQLiteDatabaseConnectionString.Create(filePath, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new SQLiteConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return new SQLiteCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new SQLiteDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is DbType)
            {
                return new SQLiteParameter(name, (DbType)dbType);
            }
            throw new ArgumentException("dbType must be DbType.");
        }
    }
}
