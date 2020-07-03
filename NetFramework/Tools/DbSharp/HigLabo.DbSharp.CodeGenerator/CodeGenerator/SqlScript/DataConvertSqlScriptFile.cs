using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class DataConvertSqlScriptFile : SqlScriptFile
    {
        public DatabaseServer DatabaseServer { get; private set; }
        public DataConvertSqlScriptFile(DatabaseServer databaseServer)
        {
            this.DatabaseServer = databaseServer;
        }
        public override String CreateBodyText()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.CreateBodyTextSqlServer();
                case DatabaseServer.Oracle: throw new NotImplementedException();
                case DatabaseServer.MySql: throw new NotImplementedException();
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        private String CreateBodyTextSqlServer()
        {
            StringBuilder sb = new StringBuilder(512);

            sb.AppendLine("/*");
            sb.AppendLine("exec sp_configure 'show advanced options', 1;");
            sb.AppendLine("RECONFIGURE;");
            sb.AppendLine("exec sp_configure 'Ad Hoc Distributed Queries', 1;");
            sb.AppendLine("RECONFIGURE;");
            sb.AppendLine("GO");
            sb.AppendLine("*/");
            sb.AppendLine();

            sb.AppendLine("--Sql server authentication");
            sb.AppendLine("--Set @DBInfo = ' OpenDataSource(''SQLOLEDB'','''");
            sb.AppendLine("--Set @DBInfo = @DBInfo + 'Data Source = MyServerName;'");
            sb.AppendLine("--Set @DBInfo = @DBInfo + 'User ID = MyUserID;'");
            sb.AppendLine("--Set @DBInfo = @DBInfo + 'Password = MyPassword'').'");
            sb.AppendLine();
            sb.AppendLine("--Windows authentication");
            sb.AppendLine("--Set @DBInfo = ' OpenDataSource(''SQLOLEDB'','''");
            sb.AppendLine("--Set @DBInfo = @DBInfo + 'Data Source = MyServerName;'");
            sb.AppendLine("--Set @DBInfo = @DBInfo + 'Integrated Security = SSPI'').'");
            sb.AppendLine();
            sb.AppendLine("--Set @Source = @Source + 'MyDBName.dbo.'");
            sb.AppendLine();
            sb.AppendLine("Declare @Source varchar (500)");
            sb.AppendLine("Declare @Target varchar (500)");
            sb.AppendLine();
            sb.AppendLine("--Azure LinkedServerName.DatabaseName.dbo.");
            sb.AppendLine("Set @Source = 'ServerName.MyDBName.dbo.'");
            sb.AppendLine("Set @Target = 'ServerName.MyDBName.dbo.'");
            sb.AppendLine();
            sb.AppendLine();

            foreach (var table in this.Tables)
            {
                sb.AppendFormat("print '{0}';EXEC ('INSERT INTO ' + @Target + '{0} (", table.Name);
                var firstColumn = true;
                foreach (var column in table.Columns)
                {
                    if (column.DbType.SqlServerDbType == SqlServer2012DbType.Timestamp) { continue; }
                    if (firstColumn == false)
                    {
                        sb.Append(",");
                    }
                    firstColumn = false;
                    sb.AppendFormat("[{0}]", column.Name);
                }
                sb.Append(") SELECT ");
                firstColumn = true;
                foreach (var column in table.Columns)
                {
                    if (column.DbType.SqlServerDbType == SqlServer2012DbType.Timestamp) { continue; }
                    if (firstColumn == false)
                    {
                        sb.Append(",");
                    }
                    firstColumn = false;
                    sb.AppendFormat("[{0}]", column.Name);
                }
                sb.AppendFormat(" FROM ' + @Source + '{0}');", table.Name);

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
