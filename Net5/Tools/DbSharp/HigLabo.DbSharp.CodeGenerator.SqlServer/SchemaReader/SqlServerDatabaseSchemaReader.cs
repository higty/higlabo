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
using Microsoft.Data.SqlClient;

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
                    o.CreateTime = DateTime.MinValue;
                    o.LastAlteredTime = DateTime.MinValue;
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
                    if (reader[2] != DBNull.Value) c.Length = reader.GetInt32(2);
                    if (reader[3] != DBNull.Value) c.Precision = reader.GetByte(3);
                    if (reader[4] != DBNull.Value) c.Scale = reader.GetByte(4);
                    c.AllowNull = reader.GetBoolean(5);
                    c.UdtTypeName = reader.GetString(6);//UdtTypeName

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
            var p = new Microsoft.Data.SqlClient.SqlParameter(name, sqlDbType);
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

        public override string GetDefinitionText(Table table)
        {
            var t = table;
            var sb = new StringBuilder();

            sb.AppendFormat("Create Table {0}", t.Name).AppendLine();
            for (int i = 0; i < t.Columns.Count; i++)
            {
                var c = t.Columns[i];
                if (i == 0)
                {
                    sb.Append("(");
                    sb.Append(c.GetDeclareParameterText());
                }
                else
                {
                    sb.Append(",");
                    sb.Append(c.GetDeclareParameterText());
                }
                if (c.AllowNull == false)
                {
                    sb.Append(" Not Null");
                }
                if (c.DefaultCostraint != null)
                {
                    sb.AppendFormat(" Constraint {0} Default {1}"
                        , c.DefaultCostraint.Name, c.DefaultCostraint.Definition);
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            {
                var cc = t.GetPrimaryKeyColumns().ToList();
                if (cc.Count > 0)
                {
                    sb.AppendFormat(",Constraint {0}_PrimaryKey Primary Key {1}(", t.Name, cc[0].Clustered);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(cc[i].Name);
                    }
                    sb.AppendLine(")");
                }
            }
            foreach (var cc in t.CheckConstraintList)
            {
                sb.AppendFormat(",Constraint {0} Check({1})"
                    , cc.Name, cc.Definition);
                sb.AppendLine();
            }
            foreach (var c in t.Columns.FindAll(el => el.ForeignKey != null))
            {
                sb.AppendFormat(",Constraint {0}_Fk_{1} Foreign Key({1}) References {2}({3}) On Update {4} On Delete {5}"
                    , t.Name, c.Name, c.ForeignKey.ParentTableName, c.ForeignKey.ParentColumnName
                    , c.ForeignKey.OnUpdate.Replace("_", " ")
                    , c.ForeignKey.OnDelete.Replace("_", " "));
                sb.AppendLine();
            }
            sb.AppendLine(")");

            return sb.ToString();
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
SELECT name,create_date,modify_date FROM sys.tables 
where name != 'sysdiagrams'
and name != 'sp_renamediagram'
and name != 'sp_upgraddiagrams'
ORDER BY name
";
            }
            public override String GetTable(String name)
            {
                var q = @"
SELECT name,create_date,modify_date FROM sys.tables WHERE name = '{0}'
";
                return String.Format(q, name);
            }
            public override String GetColumns(String tableName)
            {
                var q = @"
SELECT T1.TABLE_NAME AS TableName
,T1.COLUMN_NAME AS ColumnName
,CASE T3.COLUMN_NAME 
    When T1.COLUMN_NAME Then convert(bit, 1) 
    Else convert(bit, 0) 
End As IsPrimaryKey
,CASE T6.is_table_type 
	When 1 Then 'structured' 
	Else
		Case T6.is_assembly_type
		When 1 Then 'udt' 
		Else 
			Case T1.DATA_TYPE 
			When 'sql_variant' Then 'variant'
			Else T1.DATA_TYPE End 
		End 
	End As DbType
,T1.CHARACTER_MAXIMUM_LENGTH AS ColumnLength
,T1.NUMERIC_PRECISION AS ColumnPrecision
,IsNull(T1.NUMERIC_SCALE,T1.DATETIME_PRECISION) AS ColumnScale
,Case T1.IS_NULLABLE When 'YES' Then convert(bit, 1) Else convert(bit, 0) End As AllowNull
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T1.TABLE_SCHEMA) + '.' + QUOTENAME(T1.TABLE_NAME)), T1.COLUMN_NAME, 'IsIdentity')) as IsIdentity
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T1.TABLE_SCHEMA) + '.' + QUOTENAME(T1.TABLE_NAME)), T1.COLUMN_NAME, 'IsRowGuidCol')) as IsRowGuid
,CASE T6.is_table_type 
	When 1 Then T6.name 
	Else
		Case T6.is_assembly_type
		When 1 Then T6.name
		Else '' 
	End
End as UdtTypeName
,'' as EnumValues
FROM INFORMATION_SCHEMA.COLUMNS AS T1
LEFT JOIN (
	SELECT T2.CONSTRAINT_NAME
	, T2.TABLE_NAME
	, T2.COLUMN_NAME
	FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS T2
	LEFT JOIN sys.key_constraints AS S01
	ON T2.CONSTRAINT_NAME = S01.name
	WHERE S01.type = 'PK'
) AS T3 ON T1.TABLE_NAME = T3.TABLE_NAME AND T1.COLUMN_NAME = T3.COLUMN_NAME
Inner Join sys.tables as T4 ON T1.TABLE_NAME = T4.name 
Inner Join sys.columns as T5 ON T4.object_id = T5.object_id AND T1.COLUMN_NAME = T5.name 
Inner Join sys.types as T6 ON T5.user_type_id = T6.user_type_id
WHERE T1.TABLE_NAME = '{0}'
ORDER BY T1.ORDINAL_POSITION
";
                return String.Format(q, tableName);
            }
            public override String GetPrimaryKey(String tableName)
            {
                var q = @"
select T6.name as Name, T1.name as TableName, T2.name as ColumnName,T4.type_desc
from sys.tables as T1
inner join sys.columns as T2 on T1.object_id = T2.object_id 
inner join sys.index_columns as T3 on T1.object_id = T3.object_id and T2.column_id = T3.column_id 
inner join sys.indexes as T4 on T1.object_id = T4.object_id and  T3.index_id = T4.index_id 
inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as T5 on T1.name = T5.table_name and T2.name = T5.column_name
inner join sys.key_constraints as T6 on T5.constraint_name = T6.name and T6.type = 'PK'
where T1.name = '{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetDefaultConstraints(String tableName)
            {
                var q = @"
SELECT T1.name
,T2.name as TableName
,T3.name as ColumnName
,object_definition(OBJECT_ID(T1.name)) as Definition
FROM sys.default_constraints as T1
inner join sys.tables as T2 on T1.parent_object_id = T2.object_id
inner join sys.columns as T3 on T2.object_id = T3.object_id and T1.parent_column_id = T3.column_id
where T2.name = '{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetForeignKeys(String tableName)
            {
                var q = @"
select T0.name,T2.name as TableName,T3.name as ColumnName,T4.name as ParentTableName,T5.name as ParentColumnName
, update_referential_action_desc,delete_referential_action_desc
from sys.foreign_keys as T0
inner join sys.foreign_key_columns as T1 on T0.object_id = T1.constraint_object_id
inner join sys.tables as T2 on T1.parent_object_id = T2.object_id 
inner join sys.columns as T3 on T1.parent_object_id = T3.object_id and T1.parent_column_id = T3.column_id
inner join sys.tables as T4 on T1.referenced_object_id = T4.object_id 
inner join sys.columns as T5 on T1.referenced_object_id = T5.object_id and T1.referenced_column_id = T5.column_id
where T2.name = '{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetCheckConstraints(String tableName)
            {
                var q = @"
SELECT constraint_name as Name
,table_name as TableName
,object_definition(OBJECT_ID(CONSTRAINT_NAME)) as Definition
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
where table_name = '{0}'
and CONSTRAINT_TYPE = 'CHECK' 
";
                return String.Format(q, tableName);
            }
            public override String GetViews()
            {
                return @"
select name,create_date,modify_date,definition
from sys.objects as T1
join sys.sql_modules T2 on T1.object_id = T2.object_id
where T1.type = 'V' and is_ms_shipped = 0
order by T1.name
";
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
order by T02.name
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
, CAST(
	CASE WHEN T03.name IN (N'nchar', N'nvarchar') AND T01.max_length <> -1 THEN T01.max_length/2 
	ELSE T01.max_length 
	END AS int
) AS ColumnLength
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
Inner Join sys.table_types AS T02 ON T01.object_id = T02.type_table_object_id
Inner Join sys.types AS T03 ON T01.system_type_id = T03.system_type_id and T01.user_type_id = T03.user_type_id 
Inner Join sys.types as T06 ON T03.user_type_id = T06.user_type_id
Where T02.name = '{0}' 
And T03.name != 'sysname'
order by column_id 
";
                return String.Format(q, name);
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
            public override String GetStoredFunctions()
            {
                return @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES as T1
inner join sys.sql_modules as T2 on OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = 'FUNCTION'
and SPECIFIC_NAME != 'fn_diagramobjects'
ORDER BY SPECIFIC_NAME
";
            }
        }
    }
}
