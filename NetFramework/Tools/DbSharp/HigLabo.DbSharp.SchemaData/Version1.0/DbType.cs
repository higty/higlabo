using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class DbType
    {
        public DatabaseServer DatabaseServer { get; set; }
        public SqlServer2012DbType? SqlServerDbType { get; set; }
        public OracleDbType? OracleServerDbType { get; set; }
        public NpgsqlDbType? PostgreSqlServerDbType { get; set; }
        public MySqlDbType? MySqlServerDbType { get; set; }
        public DbType()
        {
            this.DatabaseServer = DatabaseServer.SqlServer;
        }
        public DbType(SqlServer2012DbType type)
        {
            this.DatabaseServer = DatabaseServer.SqlServer;
            this.SqlServerDbType = type;
        }
        public DbType(OracleDbType type)
        {
            this.DatabaseServer = DatabaseServer.Oracle;
            this.OracleServerDbType = type;
        }
        public DbType(NpgsqlDbType type)
        {
            this.DatabaseServer = DatabaseServer.PostgreSql;
            this.PostgreSqlServerDbType = type;
        }
        public DbType(MySqlDbType type)
        {
            this.DatabaseServer = DatabaseServer.MySql;
            this.MySqlServerDbType = type;
        }
        public String GetDbTypeCodeBlock()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return "SqlDbType." + this.SqlServerDbType.ToString();
                case DatabaseServer.Oracle: return "OracleDbType." + this.OracleServerDbType.ToString();
                case DatabaseServer.MySql: return "MySqlDbType." + this.MySqlServerDbType.ToString();
                case DatabaseServer.PostgreSql: return "NpgsqlDbType." + this.PostgreSqlServerDbType.ToString();
                default: throw new InvalidOperationException();
            }
        }
        public Boolean IsTimestamp()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.SqlServerDbType.Value == SqlServer2012DbType.Timestamp;
                case DatabaseServer.Oracle:
                    {
                        return this.OracleServerDbType.Value == OracleDbType.TimeStamp ||
                        this.OracleServerDbType.Value == OracleDbType.TimeStampLTZ ||
                        this.OracleServerDbType.Value == OracleDbType.TimeStampTZ;
                    }
                case DatabaseServer.MySql: return this.MySqlServerDbType.Value == MySqlDbType.Timestamp;
                case DatabaseServer.PostgreSql:
                    {
                        return this.PostgreSqlServerDbType.Value == NpgsqlDbType.Timestamp ||
                         this.PostgreSqlServerDbType.Value == NpgsqlDbType.TimestampTZ;
                    }
                default: throw new InvalidOperationException();
            }
        }
        public Boolean CanDeclareLength()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var type = this.SqlServerDbType.Value;
                        return type == SqlServer2012DbType.Char ||
                            type == SqlServer2012DbType.NChar ||
                            type == SqlServer2012DbType.VarChar ||
                            type == SqlServer2012DbType.NVarChar ||
                            type == SqlServer2012DbType.Binary ||
                            type == SqlServer2012DbType.VarBinary ||
                            type == SqlServer2012DbType.Variant;
                    }
                case DatabaseServer.MySql:
                    {
                        var type = this.MySqlServerDbType.Value;
                        return type == MySqlDbType.String ||
                            type == MySqlDbType.Text ||
                            type == MySqlDbType.Blob ||
                            type == MySqlDbType.VarChar ||
                            type == MySqlDbType.VarString ||
                            type == MySqlDbType.Binary ||
                            type == MySqlDbType.VarBinary;
                    }
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        public Boolean CanDeclareScale()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var type = this.SqlServerDbType.Value;
                        return type == SqlServer2012DbType.Time ||
                            type == SqlServer2012DbType.DateTime2 ||
                            type == SqlServer2012DbType.DateTimeOffset;
                    }
                case DatabaseServer.MySql:
                    {
                        var type = this.MySqlServerDbType.Value;
                        return type == MySqlDbType.Date ||
                            type == MySqlDbType.Newdate ||
                            type == MySqlDbType.DateTime ||
                            type == MySqlDbType.Time ||
                            type == MySqlDbType.Year;
                    }
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        public Boolean CanDeclarePrecisionScale()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var type = this.SqlServerDbType.Value;
                        return type == SqlServer2012DbType.Decimal ||
                            type == SqlServer2012DbType.Float;
                    }
                case DatabaseServer.MySql:
                    {
                        var type = this.MySqlServerDbType;
                        return type == MySqlDbType.Decimal ||
                            type == MySqlDbType.NewDecimal ||
                            type == MySqlDbType.Double ||
                            type == MySqlDbType.Float;
                    }
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        public Boolean CanDeclareUnsigned()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return false;
                case DatabaseServer.MySql:
                    {
                        var type = this.MySqlServerDbType;
                        return type == MySqlDbType.UByte ||
                            type == MySqlDbType.UInt16 ||
                            type == MySqlDbType.UInt24 ||
                            type == MySqlDbType.UInt32 ||
                            type == MySqlDbType.UInt64;
                    }
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        public Boolean IsStructured()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.SqlServerDbType.Value == SqlServer2012DbType.Structured;
                case DatabaseServer.Oracle: return false;
                case DatabaseServer.MySql: return false;
                case DatabaseServer.PostgreSql: return false;
                default: throw new InvalidOperationException();
            }
        }
        public Boolean IsUdt()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.SqlServerDbType.Value == SqlServer2012DbType.Udt;
                case DatabaseServer.Oracle: return false;
                case DatabaseServer.MySql: return false;
                case DatabaseServer.PostgreSql: return false;
                default: throw new InvalidOperationException();
            }
        }
        public Boolean IsUserDefinedTableType()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.SqlServerDbType.Value == SqlServer2012DbType.Structured;
                case DatabaseServer.Oracle: return false;
                case DatabaseServer.MySql: return false;
                case DatabaseServer.PostgreSql: return false;
                default: throw new InvalidOperationException();
            }
        }
        
        public override string ToString()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.SqlServerDbType.ToString();
                case DatabaseServer.Oracle: return this.OracleServerDbType.ToString();
                case DatabaseServer.MySql: return this.MySqlServerDbType.ToString();
                case DatabaseServer.PostgreSql: return this.PostgreSqlServerDbType.ToString();
                default: throw new InvalidOperationException();
            }
        }
    }
}
