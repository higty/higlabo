using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace HigLabo.Data;

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
        return new SqliteConnection();
    }
    protected override DbCommand CreateDbCommand()
    {
        return new SqliteCommand();
    }
    public override DbDataAdapter CreateDataAdapter()
    {
        throw new NotSupportedException();
    }
    public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
    {
        if (dbType is DbType)
        {
            return new SqliteParameter(name, (DbType)dbType);
        }
        throw new ArgumentException("dbType must be DbType.");
    }
    public SqliteParameter CreateParameter(string parameterName, SqlDbType dbType, object value)
    {
        return (SqliteParameter)base.CreateParameter(parameterName, dbType, value);
    }
}
