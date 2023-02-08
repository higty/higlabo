using System;
using System.Data;
using Npgsql;
using System.Data.Common;
using NpgsqlTypes;

namespace HigLabo.Data
{
    public partial class PostgreSqlDatabase : Database
    {
        public PostgreSqlDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public PostgreSqlDatabase(String serverName, String databaseName, String userID, String password)
        {
            this.ConnectionString = PostgreSqlDatabaseConnectionString.Create(serverName, databaseName, userID, password);
        }
        protected override DbConnection CreateDbConnection()
        {
            return new NpgsqlConnection();
        }
        protected override DbCommand CreateDbCommand()
        {
            return new NpgsqlCommand();
        }
        public override DbDataAdapter CreateDataAdapter()
        {
            return new NpgsqlDataAdapter();
        }
        public override DbParameter CreateParameter(string parameterName, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is NpgsqlDbType)
            {
                var p = new NpgsqlParameter(parameterName, (NpgsqlDbType)dbType);
                if (precision.HasValue == true) p.Precision = precision.Value;
                if (scale.HasValue == true) p.Scale = scale.Value;
                return p;
            }
            throw new ArgumentException("dbType must be NpgsqlDbType.");
        }
        public NpgsqlParameter CreateParameter(string parameterName, NpgsqlDbType dbType, object value)
        {
            return (NpgsqlParameter)base.CreateParameter(parameterName, dbType, value);
        }
    }
}
