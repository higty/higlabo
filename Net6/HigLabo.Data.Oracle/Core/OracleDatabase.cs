using System;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace HigLabo.Data
{
    public partial class OracleDatabase : Database
    {
        public OracleDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public OracleDatabase(String dataSource, String userID, String password)
        {
            this.ConnectionString = OracleDatabaseConnectionString.Create(dataSource, userID, password);
        }
        protected override DbConnection CreateDbConnection()
        {
            return new OracleConnection();
        }
        protected override DbCommand CreateDbCommand()
        {
            return new OracleCommand();
        }
        public override DbDataAdapter CreateDataAdapter()
        {
            return new OracleDataAdapter();
        }
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
        public OracleParameter CreateParameter(string parameterName, OracleDbType dbType, object value)
        {
            return (OracleParameter)base.CreateParameter(parameterName, dbType, value);
        }
    }
}
