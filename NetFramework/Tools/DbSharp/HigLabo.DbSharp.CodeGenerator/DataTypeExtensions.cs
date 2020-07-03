using HigLabo.DbSharp.MetaData;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class DataTypeExtensions
    {
        public static IDbDataParameter CreateParameter(this DataType dataType)
        {
            var name = dataType.Name;

            switch (dataType.DbType.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var p = new System.Data.SqlClient.SqlParameter(name, dataType.DbType.SqlServerDbType.Value);
                        p.Direction = ParameterDirection.Input;
                        p.Value = GetParameterValue(dataType, dataType.DbType.SqlServerDbType.Value);
                        return p;
                    }
                case DatabaseServer.Oracle:
                    {
                        var p = new Oracle.DataAccess.Client.OracleParameter(name, dataType.DbType.OracleServerDbType.Value);
                        p.Direction = ParameterDirection.Input;
                        //p.Value = GetParameterValue(this.OracleServerDbType.Value);
                        return p;
                    }
                case DatabaseServer.MySql:
                    {
                        var p = new MySql.Data.MySqlClient.MySqlParameter(name, dataType.DbType.MySqlServerDbType.Value);
                        p.Direction = ParameterDirection.Input;
                        p.Value = GetParameterValue(dataType, dataType.DbType.MySqlServerDbType.Value);
                        return p;
                    }
                case DatabaseServer.PostgreSql:
                    {
                        var p = new Npgsql.NpgsqlParameter(name, dataType.DbType.PostgreSqlServerDbType.Value);
                        p.Direction = ParameterDirection.Input;
                        //p.Value = GetParameterValue(this.MySqlDbType.Value);
                        return p;
                    }
                default: throw new InvalidOperationException();
            }
        }
        private static Object GetParameterValue(this DataType dataType, SqlServer2012DbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlServer2012DbType.BigInt:
                    return 1;

                case SqlServer2012DbType.Binary:
                case SqlServer2012DbType.Image:
                case SqlServer2012DbType.Timestamp:
                case SqlServer2012DbType.VarBinary:
                    return new Byte[0];

                case SqlServer2012DbType.Bit:
                    return true;

                case SqlServer2012DbType.Char:
                case SqlServer2012DbType.NChar:
                case SqlServer2012DbType.NText:
                case SqlServer2012DbType.NVarChar:
                case SqlServer2012DbType.Text:
                case SqlServer2012DbType.VarChar:
                    return "a";
                case SqlServer2012DbType.Xml:
                    return "<xml></xml>";

                case SqlServer2012DbType.DateTime:
                case SqlServer2012DbType.SmallDateTime:
                case SqlServer2012DbType.Date:
                case SqlServer2012DbType.DateTime2:
                    return new DateTime(2000, 1, 1);

                case SqlServer2012DbType.Time:
                    return new TimeSpan(2, 0, 0);

                case SqlServer2012DbType.Decimal:
                case SqlServer2012DbType.Money:
                case SqlServer2012DbType.SmallMoney:
                    return 1;

                case SqlServer2012DbType.Float:
                    return 1;

                case SqlServer2012DbType.Int:
                    return 1;

                case SqlServer2012DbType.Real:
                    return 1;

                case SqlServer2012DbType.UniqueIdentifier:
                    return Guid.NewGuid();

                case SqlServer2012DbType.SmallInt:
                    return 1;

                case SqlServer2012DbType.TinyInt:
                    return 1;

                case SqlServer2012DbType.Variant:
                case SqlServer2012DbType.Udt:
                    return new Object();

                case SqlServer2012DbType.Structured:
                    return new DataTable();

                case SqlServer2012DbType.DateTimeOffset:
                    return new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.FromHours(9));

                default: throw new ArgumentException();
            }
        }
        private static Object GetParameterValue(this DataType dataType, MySqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case MySqlDbType.Binary:
                case MySqlDbType.Blob:
                case MySqlDbType.TinyBlob:
                case MySqlDbType.MediumBlob:
                case MySqlDbType.LongBlob:
                case MySqlDbType.Byte:
                case MySqlDbType.VarBinary:
                    return new Byte[0];
                case MySqlDbType.Bit:
                    return true;
                case MySqlDbType.Date:
                case MySqlDbType.Newdate:
                case MySqlDbType.DateTime:
                    return new DateTime(2000, 1, 1);
                case MySqlDbType.Decimal:
                case MySqlDbType.Enum:
                    return "a";
                case MySqlDbType.Geometry:
                    return new MySqlGeometry(40.735031, -73.768387);
                case MySqlDbType.Guid:
                    return Guid.NewGuid();
                case MySqlDbType.Double:
                case MySqlDbType.Float:
                case MySqlDbType.Int16:
                case MySqlDbType.Int24:
                case MySqlDbType.Int32:
                case MySqlDbType.Int64:
                case MySqlDbType.UByte:
                case MySqlDbType.UInt16:
                case MySqlDbType.UInt24:
                case MySqlDbType.UInt32:
                case MySqlDbType.UInt64:
                case MySqlDbType.NewDecimal:
                    return 1;
                case MySqlDbType.Set:
                    return "a";
                case MySqlDbType.Time:
                    return new TimeSpan(2, 0, 0);
                case MySqlDbType.Timestamp:
                    return null;
                case MySqlDbType.LongText:
                case MySqlDbType.MediumText:
                case MySqlDbType.String:
                case MySqlDbType.Text:
                case MySqlDbType.TinyText:
                case MySqlDbType.VarChar:
                case MySqlDbType.VarString:
                    return "a";
                case MySqlDbType.Year:
                    return 2000;
                default: throw new InvalidOperationException();
            }
        }
    }
}
