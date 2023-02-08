using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace HigLabo.Data
{
    public partial class SQLiteDatabase : Database
    {
        public SQLiteDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public SQLiteDatabase(String filePath, String password)
        {
            this.ConnectionString = SQLiteDatabaseConnectionString.Create(filePath, password);
        }
        protected override DbConnection CreateDbConnection()
        {
            return new SQLiteConnection();
        }
        protected override DbCommand CreateDbCommand()
        {
            return new SQLiteCommand();
        }
        public override DbDataAdapter CreateDataAdapter()
        {
            return new SQLiteDataAdapter();
        }
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is DbType)
            {
                return new SQLiteParameter(name, (DbType)dbType);
            }
            throw new ArgumentException("dbType must be DbType.");
        }
        public SQLiteParameter CreateParameter(string parameterName, SqlDbType dbType, object value)
        {
            return (SQLiteParameter)base.CreateParameter(parameterName, dbType, value);
        }
    }
}
