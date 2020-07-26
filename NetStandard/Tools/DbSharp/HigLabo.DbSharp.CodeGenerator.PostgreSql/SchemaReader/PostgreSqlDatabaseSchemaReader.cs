using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using Npgsql;
using System.Data.Common;
using System.Data;
using System.Reflection;
using HigLabo.Core;
using NpgsqlTypes;
using System.Net.NetworkInformation;

namespace HigLabo.DbSharp.MetaData
{
    public class PostgreSqlDatabaseSchemaReader : DatabaseSchemaReader
    {
        public override DatabaseServer DatabaseServer
        {
            get { return DatabaseServer.PostgreSql; }
        }
        public override bool SupportUserDefinedTableType
        {
            get { return false; }
        }
        public PostgreSqlDatabaseSchemaReader(String connectionString)
        {
            this.QueryBuilder = new PostgreSqlDatabaseSchemaQueryBuilder();
            this.ConnectionString = connectionString;
        }
        public override Database CreateDatabase()
        {
            return new PostgreSqlDatabase(this.ConnectionString);
        }

        public override void SetResultSetsList(StoredProcedure sp, Dictionary<String, Object> values)
        {
            List<StoredProcedureResultSetColumn> resultSetsList = new List<StoredProcedureResultSetColumn>();
            StoredProcedureResultSetColumn resultSets = null;
            List<DataTable> schemaDataTableList = new List<DataTable>();
            DataType c = null;
            var cm = CreateTestSqlCommand<NpgsqlCommand>(sp, values);

            //処理の実行によってデータの変更などの副作用が起きないようにRollBackする。
            using (var db = this.CreateDatabase())
            {
                try
                {
                    db.Open();
                    db.BeginTransaction(IsolationLevel.ReadCommitted);

                    using (IDataReader r = db.ExecuteReader(cm))
                    {
                        var schemaDataTable = r.GetSchemaTable();
                        if (schemaDataTable == null) return;
                        schemaDataTableList.Add(schemaDataTable);
                        //TableNameSelectAllストアドの場合はスキップ
                        if (String.IsNullOrEmpty(sp.TableName) == true ||
                            sp.Name.EndsWith("SelectAll") == false)
                        {
                            while (r.NextResult())
                            {
                                schemaDataTableList.Add(r.GetSchemaTable());
                            }
                        }
                    }
                    if (db.OnTransaction == true)
                    {
                        db.RollBackTransaction();
                    }
                }
                catch
                {
                    if (db.OnTransaction == true)
                    {
                        db.RollBackTransaction();
                    }
                    throw;
                }
            }

            if (schemaDataTableList.Count == 0) return;

            Int32 index = 0;
            foreach (var schemaDataTable in schemaDataTableList)
            {
                if (index == 0)
                {
                    resultSets = new StoredProcedureResultSetColumn("ResultSet");
                }
                else
                {
                    resultSets = new StoredProcedureResultSetColumn("ResultSet" + index);
                }
                for (var i = 0; i < schemaDataTable.Rows.Count; i++)
                {
                    var row = schemaDataTable.Rows[i];

                    c = new DataType();
                    c.Name = row["ColumnName"].ToString();
                    c.Ordinal = resultSets.Columns.Count;
                    c.DbType = this.CreateDbType(row["ProviderType"]);
                    if (c.DbType.IsUdt() == true)
                    {
                        throw new InvalidOperationException();
                    }

                    if (c.DbType.IsStructured() == true)
                    {
                        throw new InvalidOperationException();
                    }
                    c.Length = AppEnvironment.Settings.TypeConverter.ToInt32(row["ColumnSize"]) ?? c.Length;
                    c.Precision = AppEnvironment.Settings.TypeConverter.ToInt32(row["NumericPrecision"]) ?? c.Precision;
                    if (c.DbType.CanDeclarePrecisionScale() == true ||
                        c.DbType.CanDeclareScale() == true)
                    {
                        c.Scale = AppEnvironment.Settings.TypeConverter.ToInt32(row["NumericScale"]) ?? c.Scale;
                        if (c.Scale.HasValue == false)
                        {
                            c.Scale = AppEnvironment.Settings.TypeConverter.ToInt32(row["DateTimeScale"]) ?? c.Scale;
                        }
                    }
                    resultSets.Columns.Add(c);
                }
                resultSetsList.Add(resultSets);
                index += 1;
            }
            foreach (var item in resultSetsList)
            {
                sp.ResultSets.Add(item);
            }
        }
        private DbCommand GetTestExecutingSqlCommand(String storedProcedureName, IEnumerable<SqlInputParameter> parameters)
        {
            var cm = new NpgsqlCommand(storedProcedureName) { CommandType = CommandType.StoredProcedure };
            foreach (var p in parameters)
            {
                cm.Parameters.Add(this.CreateParameter(p.Name, p));
            }
            return cm;
        }

        protected override MetaData.DbType CreateDbType(Object value)
        {
            var tp = AppEnvironment.Settings.TypeConverter.ToEnum<NpgsqlDbType>(value);
            if (tp.HasValue == false) throw new InvalidCastException();
            return new MetaData.DbType(tp.Value);
        }
        protected override IDbDataParameter CreateParameter(String name, DataType dataType)
        {
            var p = new NpgsqlParameter(name, dataType.DbType.PostgreSqlServerDbType.Value);
            if (dataType is SqlInputParameter dType)
            {
                p.Direction = dType.ParameterDirection;
            }
            if (p.Direction != ParameterDirection.Output)
            {
                p.Value = this.GetParameterValue(dataType, dataType.DbType.PostgreSqlServerDbType.Value);
            }
            return p;
        }
        protected override Object GetParameterValue(DataType dataType, Object sqlDbType)
        {
            switch ((NpgsqlDbType)sqlDbType)
            {
                case NpgsqlDbType.Array: return new Byte[0];
                case NpgsqlDbType.Bigint:
                    return 1;
                case NpgsqlDbType.Boolean:
                    return true;
                case NpgsqlDbType.Box:
                    return new NpgsqlTypes.NpgsqlBox();
                case NpgsqlDbType.Bytea:
                    return new Byte[0];
                case NpgsqlDbType.Circle:
                    return new NpgsqlTypes.NpgsqlCircle();
                case NpgsqlDbType.Char:
                    return "a";
                case NpgsqlDbType.Date:
                    return new DateTime(2000, 1, 1);
                case NpgsqlDbType.Double:
                case NpgsqlDbType.Integer:
                    return 1;
                case NpgsqlDbType.Line:
                    return new NpgsqlTypes.NpgsqlLine();
                case NpgsqlDbType.LSeg:
                    return new NpgsqlTypes.NpgsqlLSeg();
                case NpgsqlDbType.Money:
                case NpgsqlDbType.Numeric:
                    return 1.0m;
                case NpgsqlDbType.Path:
                    return new NpgsqlTypes.NpgsqlPath();
                case NpgsqlDbType.Point:
                    return new NpgsqlTypes.NpgsqlPoint();
                case NpgsqlDbType.Polygon:
                    return new NpgsqlTypes.NpgsqlPolygon();
                case NpgsqlDbType.Real:
                    return 1;
                case NpgsqlDbType.Smallint:
                    return 1;
                case NpgsqlDbType.Text:
                    return "a";
                case NpgsqlDbType.Time:
                case NpgsqlDbType.Timestamp:
                    return new DateTime(2000, 1, 1);
                case NpgsqlDbType.Varchar:
                    return "a";
                case NpgsqlDbType.Refcursor:
                    throw new NotSupportedException();
                case NpgsqlDbType.Inet:
                    return ValueTuple.Create(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }, 0));
                case NpgsqlDbType.Bit:
                    return 1;
                case NpgsqlDbType.TimestampTZ:
                    return new DateTime(2000, 1, 1);
                case NpgsqlDbType.Uuid:
                    return new Guid();
                case NpgsqlDbType.Xml:
                    return "<xml></xml>";
                case NpgsqlDbType.Oidvector:
                    return new uint[0];
                case NpgsqlDbType.Interval:
                    return "1";
                case NpgsqlDbType.TimeTZ:
                    return new DateTimeOffset(new DateTime(2000, 1, 1), TimeSpan.FromHours(0));
                case NpgsqlDbType.Name:
                    return "a";
                case NpgsqlDbType.Abstime:
                    throw new NotSupportedException();
                case NpgsqlDbType.MacAddr:
                    return new System.Net.NetworkInformation.PhysicalAddress(new Byte[] { 127, 0, 0, 1 });
                case NpgsqlDbType.Json:
                case NpgsqlDbType.Jsonb:
                    return "{ \"Name\" : \"MyName\" }";
                case NpgsqlDbType.Hstore:
                    return new Dictionary<String, String>();
                case NpgsqlDbType.InternalChar:
                    return 'a';
                case NpgsqlDbType.Varbit:
                    return true;
                case NpgsqlDbType.Unknown:
                    throw new NotSupportedException();
                case NpgsqlDbType.Oid:
                    return 1;
                case NpgsqlDbType.Xid:
                    return 1;
                case NpgsqlDbType.Cid:
                    return 1;
                case NpgsqlDbType.Cidr:
                    return ValueTuple.Create(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }, 0));
                case NpgsqlDbType.TsVector:
                    return NpgsqlTypes.NpgsqlTsVector.Parse("a");
                case NpgsqlDbType.TsQuery:
                    return NpgsqlTypes.NpgsqlTsQuery.Parse("a");
                case NpgsqlDbType.Regtype:
                    return new NotSupportedException();
                case NpgsqlDbType.Geometry:
                    throw new NotSupportedException();
                case NpgsqlDbType.Citext:
                    return "a";
                case NpgsqlDbType.Int2Vector:
                case NpgsqlDbType.Tid:
                    throw new NotSupportedException();
                case NpgsqlDbType.MacAddr8:
                    return new PhysicalAddress(new byte[] { 127, 0, 0, 1 });
                case NpgsqlDbType.Geography:
                case NpgsqlDbType.Regconfig:
                case NpgsqlDbType.Range:
                    throw new NotSupportedException();
                default: throw new InvalidOperationException();
            }
        }

        private class PostgreSqlDatabaseSchemaQueryBuilder : DatabaseSchemaQueryBuilder
        {
            public override String GetDatabases()
            {
                return
    @"
SELECT Schema_Name
FROM INFORMATION_SCHEMA.SCHEMATA
";
            }
            public override String GetTables()
            {
                return @"
select Table_Name,Create_Time,IfNull(Update_Time,Create_Time) 
from information_schema.tables as T01
where table_schema = (SELECT DATABASE() FROM DUAL)
";
            }
            public override String GetTable(String name)
            {
                var q = @"
select Table_Name,Create_Time,IfNull(Update_Time,Create_Time)  
from information_schema.tables as T01
where table_schema = (SELECT DATABASE() FROM DUAL)
And Table_Name = '{0}'
ORDER BY TABLE_NAME ASC
                    ";
                return String.Format(q, name);
            }
            public override String GetViews()
            {
                return @"
SELECT TABLE_NAME AS VIEW_NAME
FROM INFORMATION_SCHEMA.VIEWS
where table_schema = (SELECT DATABASE() FROM DUAL)
ORDER BY VIEW_NAME ASC
";
            }
            public override String GetColumns(String tableName)
            {
                var q = @"
SELECT T01.TABLE_NAME AS TableName
, T01.COLUMN_NAME AS ColumnName
, Case T01.COLUMN_KEY 
	When 'PRI' Then 1 
	Else 0
End As IsPrimaryKey 
,Case T01.DATA_TYPE 
	When 'char' Then 'String' 
	When 'tinyint' Then Case InStr(T01.COLUMN_TYPE, 'unsigned') When 0 Then 'Byte' Else 'UByte' End
	When 'smallint' Then Case InStr(T01.COLUMN_TYPE, 'unsigned') When 0 Then 'Int16' Else 'UInt16' End 
	When 'mediumint' Then Case InStr(T01.COLUMN_TYPE, 'unsigned') When 0 Then 'Int24' Else 'UInt24' End 
	When 'int' Then Case InStr(T01.COLUMN_TYPE, 'unsigned') When 0 Then 'Int32' Else 'UInt32' End 
	When 'bigint' Then Case InStr(T01.COLUMN_TYPE, 'unsigned') When 0 Then 'Int64' Else 'UInt64' End 
	Else T01.DATA_TYPE 
	End As DbType
,T01.CHARACTER_MAXIMUM_LENGTH AS ColumnLength
,T01.NUMERIC_PRECISION AS ColumnPrecision
,IfNull(T01.NUMERIC_SCALE,T01.DateTime_Precision) AS ColumnScale
,Case T01.IS_NULLABLE When 'YES' Then True Else False End As AllowNull
,Case Extra 
	When 'auto_increment' Then True
	Else False
End as IsIdentity
,False as IsRowGuidCol
,'' as UdtTypeName 
,COLUMN_TYPE as EnumValues
from information_schema.columns as T01
where Table_Schema = (SELECT DATABASE() FROM DUAL) 
And TABLE_NAME = '{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetStoredProcedures()
            {
                return @"
SELECT SPECIFIC_NAME,ROUTINE_DEFINITION,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES
WHERE Routine_Schema = (SELECT DATABASE() FROM DUAL) 
And ROUTINE_TYPE = 'PROCEDURE'
ORDER BY SPECIFIC_NAME
";
            }
            public override String GetStoredProcedure(String name)
            {
                var q = @"
SELECT SPECIFIC_NAME,ROUTINE_DEFINITION,Created,Last_Altered
FROM INFORMATION_SCHEMA.ROUTINES
WHERE Routine_Schema = (SELECT DATABASE() FROM DUAL)
And Routine_Type = 'PROCEDURE' 
AND Specific_Name = '{0}'
ORDER BY Specific_Name
";
                return String.Format(q, name);
            }
            public override String GetParameters(String storedProcedureName)
            {
                var q = @"
SELECT T01.SPECIFIC_NAME as StoredProcedureName
,T01.PARAMETER_NAME as ParameterName 
,Case T01.DATA_TYPE 
	When 'char' Then 'String' 
	When 'tinyint' Then Case InStr(T01.DTD_IDENTIFIER, 'unsigned') When 0 Then 'Byte' Else 'UByte' End
	When 'smallint' Then Case InStr(T01.DTD_IDENTIFIER, 'unsigned') When 0 Then 'Int16' Else 'UInt16' End 
	When 'mediumint' Then Case InStr(T01.DTD_IDENTIFIER, 'unsigned') When 0 Then 'Int24' Else 'UInt24' End 
	When 'int' Then Case InStr(T01.DTD_IDENTIFIER, 'unsigned') When 0 Then 'Int32' Else 'UInt32' End 
	When 'bigint' Then Case InStr(T01.DTD_IDENTIFIER, 'unsigned') When 0 Then 'Int64' Else 'UInt64' End 
	Else T01.DATA_TYPE 
	End As DbType
,T01.CHARACTER_MAXIMUM_LENGTH as ParameterLength
,T01.Numeric_Precision as ParameterPrecision
,IfNull(T01.Numeric_Scale,T01.DateTime_Precision) as ParameterScale
,Case T01.Parameter_Mode 
	When 'OUT' Then 1 
	When 'INOUT' Then 1 
	Else 0 
End as IsOutput
, '' as UserTableTypeName
, '' as UdtTypeName
FROM INFORMATION_SCHEMA.PARAMETERS As T01 
Where Specific_Schema = (SELECT DATABASE() FROM DUAL) 
And SPECIFIC_NAME = '{0}'
Order by Ordinal_Position
";
                return String.Format(q, storedProcedureName);
            }
            public override String GetUserDefinedTypes()
            {
                throw new NotSupportedException();
            }
            public override String GetUserDefinedTypeColumns(String name)
            {
                throw new NotSupportedException();
            }
        }
    }
}
