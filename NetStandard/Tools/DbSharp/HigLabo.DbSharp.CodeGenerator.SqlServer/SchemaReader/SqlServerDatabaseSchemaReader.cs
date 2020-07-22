using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using System.Data;
using HigLabo.Core;
using System.Data.SqlClient;
using HigLabo.CodeGenerator;
using System.Reflection;
using System.Data.Common;
using Microsoft.SqlServer.Types;

namespace HigLabo.DbSharp.MetaData
{
    public class SqlServerDatabaseSchemaReader : DatabaseSchemaReader
    {
        public override DatabaseServer DatabaseServer
        {
            get { return DatabaseServer.SqlServer; }
        }
        public override bool SupportUserDefinedTableType
        {
            get { return true; }
        }
        public SqlServerDatabaseSchemaReader(String connectionString)
        {
            this.QueryBuilder = new SqlServerDatabaseSchemaQueryBuilder();
            this.ConnectionString = connectionString;
        }
    
        public override Database CreateDatabase()
        {
            return new SqlServerDatabase(this.ConnectionString);
        }

        public override void SetResultSetsList(StoredProcedure sp, Dictionary<String, Object> values)
        {
            List<StoredProcedureResultSetColumn> resultSetsList = new List<StoredProcedureResultSetColumn>();
            StoredProcedureResultSetColumn resultSets = null;
            List<DataTable> schemaDataTableList = new List<DataTable>();
            DataType c = null;
            var cm = CreateTestSqlCommand<SqlCommand>(sp, values);

            //UserDefinedTableType
            foreach (var item in sp.Parameters.Where(el => el.DbType.SqlServerDbType == SqlServer2012DbType.Structured))
            {
                var dt = cm.Parameters[item.Name].Value as DataTable;
                var udt = this.GetUserDefinedTableType(item.UserTableTypeName);
                foreach (var column in udt.Columns)
                {
                    dt.Columns.Add(new DataColumn(column.Name, column.GetClassNameType().ToType()));
                }
                var oo = new Object[udt.Columns.Count];
                for (int i = 0; i < udt.Columns.Count; i++)
                {
                    c = udt.Columns[i];
                    oo[i] = this.GetParameterValue(c, c.DbType.SqlServerDbType.Value, udt.Name);
                }
                dt.Rows.Add(oo);
            }
            //処理の実行によってデータの変更などの副作用が起きないようにRollBackする。
            using (var db = this.CreateDatabase())
            {
                try
                {
                    db.Open();
                    db.BeginTransaction(IsolationLevel.ReadUncommitted);

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
                        var tp = row["DataType"] as TypeInfo;
                        var typeName = "";
                        if (tp == null)
                        {
                            typeName = row["UdtAssemblyQualifiedName"].ToString().ExtractString(null, ',');
                        }
                        else
                        {
                            typeName = tp.FullName;
                        }
                        switch (typeName)
                        {
                            case "Microsoft.SqlServer.Types.SqlGeometry": c.UdtTypeName = "geometry"; break;
                            case "Microsoft.SqlServer.Types.SqlGeography": c.UdtTypeName = "geography"; break;
                            case "Microsoft.SqlServer.Types.SqlHierarchyId": c.UdtTypeName = "hierarchyid"; break;
                            default: throw new InvalidOperationException();
                        }
                    }

                    if (c.DbType.IsStructured() == true)
                    {
                        throw new NotImplementedException();
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
        public override List<DatabaseObject> GetUserDefinedTableTypes()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetUserDefinedTypes());

                while (reader.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.UserDefinedTableType);
                    o.Name = reader.GetString(0);
                    o.CreateTime = DateTime.Now;
                    o.LastAlteredTime = DateTime.Now;
                    l.Add(o);
                }
            }
            return l;
        }
        public override UserDefinedTableType GetUserDefinedTableType(String name)
        {
            UserDefinedTableType st = new UserDefinedTableType(name);
            foreach (var column in this.GetUserDefinedTableTypeColumns(name))
            {
                st.Columns.Add(column);
            }
            return st;
        }
        public override List<DataType> GetUserDefinedTableTypeColumns(String name)
        {
            List<DataType> l = new List<DataType>();
            DataType c = null;

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetUserDefinedTypeColumns(name));

                while (reader.Read())
                {
                    c = new DataType();
                    c.Name = reader.GetString(0);
                    c.Ordinal = l.Count;
                    c.DbType = this.CreateDbType(reader["ColumnType"]);
                    c.UdtTypeName = reader.GetString(6);//UdtTypeName
                    if (reader[4] != DBNull.Value) c.Length = reader.GetInt16(2);
                    if (reader[5] != DBNull.Value) c.Precision = reader.GetByte(3);
                    if (reader[6] != DBNull.Value) c.Scale = reader.GetByte(4);
                    c.AllowNull = reader.GetBoolean(5);

                    l.Add(c);
                }
            }
            return l;
        }

        protected override MetaData.DbType CreateDbType(Object value)
        {
            var tp = AppEnvironment.Settings.TypeConverter.ToEnum<SqlServer2012DbType>(value);
            if (tp.HasValue == false) throw new InvalidCastException();
            return new MetaData.DbType(tp.Value);
        }
        protected override IDbDataParameter CreateParameter(String name, DataType dataType)
        {
            var sqlDbType = dataType.DbType.SqlServerDbType.ToString().ToEnum<SqlDbType>().Value;
            var p = new System.Data.SqlClient.SqlParameter(name, sqlDbType);
            if (dataType is SqlInputParameter dType)
            {
                p.Direction = dType.ParameterDirection;
            }
            if (p.Direction != ParameterDirection.Output)
            {
                if (dataType.DbType.SqlServerDbType == SqlServer2012DbType.Udt)
                {
                    p.SetUdtTypeName(dataType.UdtTypeName);
                    p.Value = this.GetParameterValue(dataType, dataType.DbType.SqlServerDbType.Value, dataType.UdtTypeName);
                }
                else
                {
                    p.Value = this.GetParameterValue(dataType, dataType.DbType.SqlServerDbType.Value);
                }
            }
            return p;
        }
        protected override Object GetParameterValue(DataType dataType, Object sqlDbType)
        {
            switch ((SqlServer2012DbType)sqlDbType)
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
                    return DateTime.Now;
                case SqlServer2012DbType.Udt:
                    return new Object();

                case SqlServer2012DbType.Structured:
                    return new DataTable();

                case SqlServer2012DbType.DateTimeOffset:
                    return new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.FromHours(9));

                default: throw new ArgumentException();
            }
        }
        private Object GetParameterValue(DataType dataType, Object sqlDbType, String udtTypeName)
        {
            switch (udtTypeName)
            {
                case "geometry": return SqlGeometry.Point(137, 42, 4320);
                case "geography": return SqlGeography.Point(42, 135, 4326);
                case "hierarchyid": return SqlHierarchyId.Parse("/1/2/3/");
                default: break;
            }
            return GetParameterValue(dataType, sqlDbType);
        }

        private class SqlServerDatabaseSchemaQueryBuilder : DatabaseSchemaQueryBuilder
        {
            public override String GetDatabases()
            {
                return
    @"
SELECT name AS DATABASE_NAME
FROM sys.databases
WHERE database_id > 4
ORDER BY name ASC
";
            }
            public override String GetTables()
            {
                return @"
SELECT TABLE_NAME,T2.create_date,modify_date
FROM INFORMATION_SCHEMA.TABLES As T1 
Inner Join sys.tables as T2 
On T1.TABLE_NAME = T2.name 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME ASC
                    ";
            }
            public override String GetTable(String name)
            {
                var q = @"
SELECT TABLE_NAME,T2.create_date,modify_date
FROM INFORMATION_SCHEMA.TABLES As T1 
Inner Join sys.tables as T2 
On T1.TABLE_NAME = T2.name 
WHERE TABLE_TYPE = 'BASE TABLE'
And TABLE_NAME = '{0}'
ORDER BY TABLE_NAME ASC
                    ";
                return String.Format(q, name);
            }
            public override String GetViews()
            {
                return @"
SELECT TABLE_NAME AS VIEW_NAME
FROM INFORMATION_SCHEMA.VIEWS
ORDER BY VIEW_NAME ASC
";
            }
            public override String GetColumns(String tableName)
            {
                var q = @"
SELECT T01.TABLE_NAME AS TableName
,T01.COLUMN_NAME AS ColumnName
,CASE T03.COLUMN_NAME 
    When T01.COLUMN_NAME Then convert(bit, 1) 
    Else convert(bit, 0) 
End As IsPrimaryKey
,CASE T06.is_table_type 
	When 1 Then 'structured' 
	Else
		Case T06.is_assembly_type
		When 1 Then 'udt' 
		Else 
			Case T01.DATA_TYPE 
			When 'sql_variant' Then 'variant'
			Else T01.DATA_TYPE End 
		End 
	End As DbType
,T01.CHARACTER_MAXIMUM_LENGTH AS ColumnLength
,T01.NUMERIC_PRECISION AS ColumnPrecision
,IsNull(T01.NUMERIC_SCALE,T01.DATETIME_PRECISION) AS ColumnScale
,Case T01.IS_NULLABLE When 'YES' Then convert(bit, 1) Else convert(bit, 0) End As AllowNull
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T01.TABLE_SCHEMA) + '.' + QUOTENAME(T01.TABLE_NAME)), T01.COLUMN_NAME, 'IsIdentity')) as IsIdentity
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T01.TABLE_SCHEMA) + '.' + QUOTENAME(T01.TABLE_NAME)), T01.COLUMN_NAME, 'IsRowGuidCol')) as IsRowGuid
,CASE T06.is_table_type 
	When 1 Then T06.name 
	Else
		Case T06.is_assembly_type
		When 1 Then T06.name
		Else '' 
	End
End as UdtTypeName
,'' as EnumValues
FROM INFORMATION_SCHEMA.COLUMNS AS T01
LEFT JOIN (
	SELECT T02.CONSTRAINT_NAME
	, T02.TABLE_NAME
	, T02.COLUMN_NAME
	FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS T02
	LEFT JOIN sys.key_constraints AS S01
	ON T02.CONSTRAINT_NAME = S01.name
	WHERE S01.type = 'PK'
) AS T03
ON T01.TABLE_NAME = T03.TABLE_NAME
AND T01.COLUMN_NAME = T03.COLUMN_NAME
Inner Join sys.tables as T04 
ON T01.TABLE_NAME = T04.name 
Inner Join sys.columns as T05 
ON T04.object_id = T05.object_id AND T01.COLUMN_NAME = T05.name 
Inner Join sys.types as T06 
ON T05.user_type_id = T06.user_type_id
WHERE T01.TABLE_NAME = '{0}'
ORDER BY T01.ORDINAL_POSITION
                    ";
                return String.Format(q, tableName);
            }
            public override String GetStoredProcedures()
            {
                return @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES as T1
join sys.sql_modules as T2 
on OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = 'PROCEDURE'
ORDER BY SPECIFIC_NAME
";
            }
            public override String GetStoredProcedure(String name)
            {
                var q = @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES as T1
join sys.sql_modules as T2 
on OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = 'PROCEDURE'
AND SPECIFIC_NAME = '{0}'
ORDER BY SPECIFIC_NAME
";
                return String.Format(q, name);
            }
            public override String GetParameters(String storedProcedureName)
            {
                var q = @"
SELECT T01.SPECIFIC_NAME as StoredProcedureName
,T01.PARAMETER_NAME as ParameterName 
,CASE T04.is_table_type 
	When 1 Then 'structured' 
	Else 
		Case T04.is_assembly_type
		When 1 Then 'udt' 
		Else
			Case T04.name 
			When 'sql_variant' Then 'variant'
			Else T04.name 
			End
	End
End as DbType
,T01.CHARACTER_MAXIMUM_LENGTH as ParameterLength
,T01.Numeric_Precision as ParameterPrecision
,IsNull(T01.Numeric_Scale,T01.DateTime_Precision) as ParameterScale
,Case T01.Parameter_Mode 
	When 'OUT' Then convert(bit, 1) 
	When 'INOUT' Then convert(bit, 1) 
	Else convert(bit, 0) 
End as IsOutput
,IsNull(USER_DEFINED_TYPE_NAME,'') as UserTableTypeName
,Case T04.is_assembly_type
When 1 Then T04.name
Else '' 
End as UdtTypeName 
FROM INFORMATION_SCHEMA.PARAMETERS As T01 
Inner Join sys.procedures as T02 
ON T01.SPECIFIC_NAME = T02.name 
Inner Join sys.parameters as T03 
ON T02.object_id = T03.object_id 
and T01.PARAMETER_NAME = T03.name
Inner Join sys.types as T04 
ON T03.user_type_id = T04.user_type_id
Where SPECIFIC_NAME = '{0}'
Order by Ordinal_Position
";
                return String.Format(q, storedProcedureName);
            }
            public override String GetUserDefinedTypes()
            {
                var q = @"
Select T02.name As Name 
From sys.columns AS T01
Inner Join sys.table_types AS T02
ON T01.object_id = T02.type_table_object_id
Inner Join sys.types AS T03
ON T01.system_type_id = T03.system_type_id 
and T01.user_type_id = T03.user_type_id 
Inner Join sys.types as T06 
ON T03.user_type_id = T06.user_type_id
Where T03.name != 'sysname'
group by T02.name
";
                return String.Format(q);
            }
            public override String GetUserDefinedTypeColumns(String name)
            {
                var q = @"
Select T01.name AS ColumnName
,CASE T06.is_table_type 
	When 1 Then 'structured' 
	Else
		Case T06.is_assembly_type
		When 1 Then 'udt' 
		Else 
			Case T03.name 
			When 'sql_variant' Then 'variant'
			Else T03.name End 
		End 
	End As ColumnType
, T01.max_length AS ColumnLength
, T01.precision AS ColumnPrecision
, T01.scale AS ColumnScale
, T01.is_nullable AS AllowNull
,CASE T06.is_table_type 
	When 1 Then T06.name 
	Else
		Case T06.is_assembly_type
		When 1 Then T06.name
		Else '' 
	End
End as UdtTypeName

From sys.columns AS T01
Inner Join sys.table_types AS T02
ON T01.object_id = T02.type_table_object_id
Inner Join sys.types AS T03
ON T01.system_type_id = T03.system_type_id 
and T01.user_type_id = T03.user_type_id 
Inner Join sys.types as T06 
ON T03.user_type_id = T06.user_type_id
Where T02.name = '{0}' 
And T03.name != 'sysname'
order by column_id 
";
                return String.Format(q, name);
            }
        }
    }
}
