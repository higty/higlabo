using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using System.Data;
using HigLabo.Core;
using HigLabo.CodeGenerator;
using System.Reflection;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace HigLabo.DbSharp.MetaData
{
    public class SqlServerDatabaseSchemaReader : DatabaseSchemaReader
    {
        public override DatabaseSchemaQueryBuilder QueryBuilder => new SqlServerDatabaseSchemaQueryBuilder();
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
            this.ConnectionString = connectionString;
        }
    
        public override Database CreateDatabase()
        {
            return new SqlServerDatabase(this.ConnectionString);
        }

        public override async Task SetResultSetsListAsync(StoredProcedure sp, Dictionary<String, Object> values)
        {
            List<StoredProcedureResultSetColumn> resultSetsList = new List<StoredProcedureResultSetColumn>();
            List<DataTable> schemaDataTableList = new List<DataTable>();
            var cm = CreateTestSqlCommand<SqlCommand>(sp, values);

            //UserDefinedTableType
            foreach (var item in sp.Parameters.Where(el => el.DbType!.SqlServerDbType == SqlServer2022DbType.Structured))
            {
                var dt = (DataTable)cm.Parameters[item.Name].Value;
                var udt = await this.GetUserDefinedTableTypeAsync(item.UserTableTypeName);
                foreach (var column in udt.Columns)
                {
                    dt.Columns.Add(new DataColumn(column.Name, column.GetClassNameType().ToType()));
                }
                var oo = new Object?[udt.Columns.Count];
                for (int i = 0; i < udt.Columns.Count; i++)
                {
                    var c = udt.Columns[i];
                    oo[i] = this.GetParameterValue(c, c.DbType!.SqlServerDbType!.Value);
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

                    using (IDataReader r = db.ExecuteReader(cm)!)
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
                                schemaDataTableList.Add(r.GetSchemaTable()!);
                            }
                        }
                    }
                    if (db.OnTransaction == true)
                    {
                        db.RollBackTransaction();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    System.Diagnostics.Debugger.Break();
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
                var resultSets = index switch
                {
                    0 => new StoredProcedureResultSetColumn("ResultSet"),
                    _ => new StoredProcedureResultSetColumn("ResultSet" + index),
                };
                for (var i = 0; i < schemaDataTable.Rows.Count; i++)
                {
                    var row = schemaDataTable.Rows[i];

                    var c = new DataType();
                    c.Name = row["ColumnName"].ToString()!;
                    c.Ordinal = resultSets.Columns.Count;
                    c.DbType = this.CreateDbType(row["ProviderType"]);
                    if (c.DbType.IsUdt() == true)
                    {
                        var tp = row["DataType"] as TypeInfo;
                        var typeName = "";
                        if (tp == null)
                        {
                            typeName = row["UdtAssemblyQualifiedName"].ToString()!.ExtractString(null, ',');
                        }
                        else
                        {
                            typeName = tp.FullName;
                        }
                    }

                    if (c.DbType.IsStructured() == true)
                    {
                        throw new NotImplementedException();
                    }
                    c.Length = this.TypeConverter.ToInt32(row["ColumnSize"]) ?? c.Length;
                    c.Precision = this.TypeConverter.ToInt32(row["NumericPrecision"]) ?? c.Precision;
                    if (c.DbType.CanDeclarePrecisionScale() == true ||
                        c.DbType.CanDeclareScale() == true)
                    {
                        c.Scale = this.TypeConverter.ToInt32(row["NumericScale"]) ?? c.Scale;
                        if (c.Scale.HasValue == false)
                        {
                            c.Scale = this.TypeConverter.ToInt32(row["DateTimeScale"]) ?? c.Scale;
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
        public override async ValueTask<List<DatabaseObject>> GetUserDefinedTableTypesAsync()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetUserDefinedTypes());

                while (await reader!.ReadAsync())
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
        public override async ValueTask<UserDefinedTableType> GetUserDefinedTableTypeAsync(String name)
        {
            UserDefinedTableType st = new UserDefinedTableType(name);
            foreach (var column in await this.GetUserDefinedTableTypeColumnsAsync(name))
            {
                st.Columns.Add(column);
            }
            return st;
        }
        public override async ValueTask<List<DataType>> GetUserDefinedTableTypeColumnsAsync(String name)
        {
            List<DataType> l = new List<DataType>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetUserDefinedTypeColumns(name));
                while (await reader!.ReadAsync())
                {
                    var c = new DataType();
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
            var tp = this.TypeConverter.ToEnum<SqlServer2022DbType>(value);
            if (tp.HasValue == false) throw new InvalidCastException();
            return new MetaData.DbType(tp.Value);
        }
        protected override IDbDataParameter CreateParameter(String name, DataType dataType)
        {
            var sqlDbType = dataType.DbType!.SqlServerDbType.ToString()!.ToEnum<SqlDbType>()!.Value;
            var p = new Microsoft.Data.SqlClient.SqlParameter(name, sqlDbType);
            if (dataType is SqlInputParameter dType)
            {
                p.Direction = dType.ParameterDirection;
            }
            if (p.Direction != ParameterDirection.Output)
            {
                if (dataType.DbType.SqlServerDbType == SqlServer2022DbType.Udt)
                {
                    p.SetUdtTypeName(dataType.UdtTypeName);
                    p.Value = this.GetParameterValue(dataType, dataType.DbType.SqlServerDbType.Value);
                }
                else
                {
                    p.Value = this.GetParameterValue(dataType, dataType.DbType.SqlServerDbType!.Value);
                }
            }
            return p;
        }
        protected override Object? GetParameterValue(DataType dataType, Object sqlDbType)
        {
            switch ((SqlServer2022DbType)sqlDbType)
            {
                case SqlServer2022DbType.BigInt:
                    return 1;

                case SqlServer2022DbType.Binary:
                case SqlServer2022DbType.Image:
                case SqlServer2022DbType.Timestamp:
                case SqlServer2022DbType.VarBinary:
                    return new Byte[0];

                case SqlServer2022DbType.Bit:
                    return true;

                case SqlServer2022DbType.Char:
                case SqlServer2022DbType.NChar:
                case SqlServer2022DbType.NText:
                case SqlServer2022DbType.NVarChar:
                case SqlServer2022DbType.Text:
                case SqlServer2022DbType.VarChar:
                    return "a";
                case SqlServer2022DbType.Xml:
                    return "<xml></xml>";

                case SqlServer2022DbType.DateTime:
                case SqlServer2022DbType.SmallDateTime:
                case SqlServer2022DbType.Date:
                case SqlServer2022DbType.DateTime2:
                    return new DateTime(2000, 1, 1);
                case SqlServer2022DbType.Time:
                    return new TimeSpan(2, 0, 0);

                case SqlServer2022DbType.Decimal:
                case SqlServer2022DbType.Money:
                case SqlServer2022DbType.SmallMoney:
                    return 1;

                case SqlServer2022DbType.Float:
                    return 1;

                case SqlServer2022DbType.Int:
                    return 1;

                case SqlServer2022DbType.Real:
                    return 1;

                case SqlServer2022DbType.UniqueIdentifier:
                    return Guid.NewGuid();

                case SqlServer2022DbType.SmallInt:
                    return 1;

                case SqlServer2022DbType.TinyInt:
                    return 1;

                case SqlServer2022DbType.Variant:
                    return DateTime.Now;
                case SqlServer2022DbType.Udt:
                    return new Object();

                case SqlServer2022DbType.Structured:
                    return new DataTable();

                case SqlServer2022DbType.DateTimeOffset:
                    return new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.FromHours(9));

                default: throw new ArgumentException();
            }
        }

        public override string GetDefinitionText(Table table)
        {
            var t = table;
            var sb = new StringBuilder();

            sb.AppendFormat("create table {0}", t.Name).AppendLine();
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
                    sb.Append(" not null");
                }
                if (c.DefaultCostraint != null)
                {
                    sb.AppendFormat(" constraint {0} default {1}"
                        , c.DefaultCostraint.Name, c.DefaultCostraint.Definition);
                }
                sb.AppendLine();
            }
            sb.AppendLine();

            {
                var cc = t.GetPrimaryKeyColumns().ToList();
                if (cc.Count > 0)
                {
                    sb.AppendFormat(",constraint {0}_PrimaryKey primary key {1}(", t.Name, cc[0].Clustered);
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
            foreach (var c in t.Columns.FindAll(el => el.ForeignKey != null))
            {
                sb.AppendFormat(",constraint {0}_Fk_{1} foreign key({1}) references {2}({3}) on update {4} on delete {5}"
                    , t.Name, c.Name, c.ForeignKey!.ParentTableName, c.ForeignKey.ParentColumnName
                    , c.ForeignKey.OnUpdate.Replace("_", " ")
                    , c.ForeignKey.OnDelete.Replace("_", " "));
                sb.AppendLine();
            }
            foreach (var cc in t.CheckConstraintList)
            {
                sb.AppendFormat(",constraint {0} check({1})", cc.Name, cc.Definition);
                sb.AppendLine();
            }
            foreach (var ix in t.IndexList)
            {
                //Pass PrimaryKey
                if (ix.IsUnique == true) { continue; }
                //Index only
                if (String.Equals(ix.IndexType, "clustered", StringComparison.OrdinalIgnoreCase) == false &&
                    String.Equals(ix.IndexType, "nonClustered", StringComparison.OrdinalIgnoreCase) == false) { continue; }

                sb.AppendFormat(",index {0} {1} ({2})"
                    , ix.Name
                    , ix.IndexType
                    , String.Join(',', ix.Columns.Select(el => el.Name)));
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
FROM sys.databases with(nolock) 
WHERE database_id > 4
ORDER BY name ASC
";
            }
            public override String GetTables()
            {
                return @"
SELECT name,create_date,modify_date FROM sys.tables with(nolock) 
where name != N'sysdiagrams'
and name != N'sp_renamediagram'
and name != N'sp_upgraddiagrams'
ORDER BY name
";
            }
            public override String GetTable(String name)
            {
                var q = @"
SELECT name,create_date,modify_date FROM sys.tables with(nolock) WHERE name = N'{0}'
";
                return String.Format(q, name);
            }
            public override String GetColumns(String tableName)
            {
                var q = @"
SELECT T1.TABLE_NAME AS TableName
,T1.COLUMN_NAME AS ColumnName
,CASE T6.is_table_type 
	When 1 Then N'structured' 
	Else
		Case T6.is_assembly_type
		When 1 Then N'udt' 
		Else 
			Case T1.DATA_TYPE 
			When N'sql_variant' Then N'variant'
			Else T1.DATA_TYPE End 
		End 
	End As DbType
,T1.CHARACTER_MAXIMUM_LENGTH AS ColumnLength
,T1.NUMERIC_PRECISION AS ColumnPrecision
,IsNull(T1.NUMERIC_SCALE,T1.DATETIME_PRECISION) AS ColumnScale
,Case T1.IS_NULLABLE When N'YES' Then convert(bit, 1) Else convert(bit, 0) End As AllowNull
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T1.TABLE_SCHEMA) + N'.' + QUOTENAME(T1.TABLE_NAME)), T1.COLUMN_NAME, N'IsIdentity')) as IsIdentity
,convert(bit, COLUMNPROPERTY(OBJECT_ID(QUOTENAME(T1.TABLE_SCHEMA) + N'.' + QUOTENAME(T1.TABLE_NAME)), T1.COLUMN_NAME, N'IsRowGuidCol')) as IsRowGuid
,CASE T6.is_table_type 
	When 1 Then T6.name 
	Else
		Case T6.is_assembly_type
		When 1 Then T6.name
		Else N'' 
	End
End as UdtTypeName
,N'' as EnumValues
FROM INFORMATION_SCHEMA.COLUMNS AS T1 with(nolock) 
Inner Join sys.tables as T4  with(nolock) ON T1.TABLE_NAME = T4.name 
Inner Join sys.columns as T5  with(nolock) ON T4.object_id = T5.object_id AND T1.COLUMN_NAME = T5.name 
Inner Join sys.types as T6 with(nolock) ON T5.user_type_id = T6.user_type_id
WHERE T1.TABLE_NAME = N'{0}'
ORDER BY T1.ORDINAL_POSITION
";
                return String.Format(q, tableName);
            }
            public override String GetPrimaryKey(String tableName)
            {
                var q = @"
select T6.name as Name, T1.name as TableName, T2.name as ColumnName,T4.type_desc
from sys.tables as T1 with(nolock)
inner join sys.columns as T2 with(nolock) on T1.object_id = T2.object_id 
inner join sys.index_columns as T3 with(nolock) on T1.object_id = T3.object_id and T2.column_id = T3.column_id 
inner join sys.indexes as T4 with(nolock) on T1.object_id = T4.object_id and  T3.index_id = T4.index_id 
inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as T5 with(nolock) on T1.name = T5.table_name and T2.name = T5.column_name
inner join sys.key_constraints as T6 with(nolock) on T5.constraint_name = T6.name and T6.type = N'PK'
where T1.name = N'{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetIndex(String tableName)
            {
                var q = @"
select T2.[name] as IndexName
,T1.[name] as TableName
,T4.[name] as ColumnName
,case 
when T2.[type] = 1 then N'Clustered'
when T2.[type] = 2 then N'NonClustered'
when T2.[type] = 3 then N'XML'
when T2.[type] = 4 then N'Spatial'
when T2.[type] = 5 then N'Clustered ColumnStore'
when T2.[type] = 6 then N'NonClustered ColumnStore'
when T2.[type] = 7 then N'NonClustered hash'
end as IndexType
,T2.is_unique as IsUnique
,case when T1.[type] = N'U' then N'Table'
when T1.[type] = N'V' then N'View'
end as [object_type]
from sys.objects as T1 with(nolock)
inner join sys.indexes as T2 with(nolock) on T1.object_id = T2.object_id
inner join sys.index_columns as T3 with(nolock) on T2.object_id = T3.object_id and T2.index_id = T3.index_id
inner join sys.columns as T4 with(nolock) on T3.object_id = T4.object_id and T3.column_id = T4.column_id
where T1.is_ms_shipped <> 1
and T2.index_id > 0
and T1.[name] = N'{0}'
order by T2.[name]
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
FROM sys.default_constraints as T1 with(nolock)
inner join sys.tables as T2 with(nolock) on T1.parent_object_id = T2.object_id
inner join sys.columns as T3 with(nolock) on T2.object_id = T3.object_id and T1.parent_column_id = T3.column_id
where T2.name = N'{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetForeignKeys(String tableName)
            {
                var q = @"
select T0.name,T2.name as TableName,T3.name as ColumnName,T4.name as ParentTableName,T5.name as ParentColumnName
, update_referential_action_desc,delete_referential_action_desc
from sys.foreign_keys as T0 with(nolock)
inner join sys.foreign_key_columns as T1 with(nolock) on T0.object_id = T1.constraint_object_id
inner join sys.tables as T2 with(nolock) on T1.parent_object_id = T2.object_id 
inner join sys.columns as T3 with(nolock) on T1.parent_object_id = T3.object_id and T1.parent_column_id = T3.column_id
inner join sys.tables as T4 with(nolock) on T1.referenced_object_id = T4.object_id 
inner join sys.columns as T5 with(nolock) on T1.referenced_object_id = T5.object_id and T1.referenced_column_id = T5.column_id
where T2.name = N'{0}'
";
                return String.Format(q, tableName);
            }
            public override String GetCheckConstraints(String tableName)
            {
                var q = @"
SELECT constraint_name as Name
,table_name as TableName
,object_definition(OBJECT_ID(CONSTRAINT_NAME)) as Definition
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS with(nolock)
where table_name = N'{0}'
and CONSTRAINT_TYPE = N'CHECK' 
";
                return String.Format(q, tableName);
            }
            public override String GetViews()
            {
                return @"
select name,create_date,modify_date,definition
from sys.objects as T1 with(nolock)
join sys.sql_modules T2 with(nolock) on T1.object_id = T2.object_id
where T1.type = N'V' and is_ms_shipped = 0
order by T1.name
";
            }
            public override String GetUserDefinedTypes()
            {
                var q = @"
Select T02.name As Name 
From sys.columns AS T01 with(nolock)
Inner Join sys.table_types AS T02 with(nolock) ON T01.object_id = T02.type_table_object_id
Inner Join sys.types AS T03 with(nolock) ON T01.system_type_id = T03.system_type_id and T01.user_type_id = T03.user_type_id 
Inner Join sys.types AS T06 with(nolock) ON T03.user_type_id = T06.user_type_id
Where T03.name != N'sysname'
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
	When 1 Then N'structured' 
	Else
		Case T06.is_assembly_type
		When 1 Then N'udt' 
		Else 
			Case T03.name 
			When N'sql_variant' Then N'variant'
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
		Else N'' 
	End
End as UdtTypeName
From sys.columns AS T01 with(nolock)
Inner Join sys.table_types AS T02 with(nolock) ON T01.object_id = T02.type_table_object_id
Inner Join sys.types AS T03 with(nolock) ON T01.system_type_id = T03.system_type_id and T01.user_type_id = T03.user_type_id 
Inner Join sys.types AS T06 with(nolock) ON T03.user_type_id = T06.user_type_id
Where T02.name = N'{0}' 
And T03.name != N'sysname'
order by column_id 
";
                return String.Format(q, name);
            }
            public override String GetStoredProcedures()
            {
                return @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES as T1 with(nolock)
join sys.sql_modules AS T2 ON OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = N'PROCEDURE'
ORDER BY SPECIFIC_NAME
";
            }
            public override String GetStoredProcedure(String name)
            {
                var q = @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES as T1 with(nolock)
JOIN sys.sql_modules AS T2 with(nolock) ON OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = N'PROCEDURE'
AND SPECIFIC_NAME = N'{0}'
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
	When 1 Then N'structured' 
	Else 
		Case T04.is_assembly_type
		When 1 Then N'udt' 
		Else
			Case T04.name 
			When N'sql_variant' Then N'variant'
			Else T04.name 
			End
	End
End as DbType
,T01.CHARACTER_MAXIMUM_LENGTH as ParameterLength
,T01.Numeric_Precision as ParameterPrecision
,IsNull(T01.Numeric_Scale,T01.DateTime_Precision) as ParameterScale
,Case T01.Parameter_Mode 
	When N'OUT' Then convert(bit, 1) 
	When N'INOUT' Then convert(bit, 1) 
	Else convert(bit, 0) 
End as IsOutput
,IsNull(USER_DEFINED_TYPE_NAME,N'') as UserTableTypeName
,Case T04.is_assembly_type
When 1 Then T04.name
Else N'' 
End as UdtTypeName 
FROM INFORMATION_SCHEMA.PARAMETERS As T01 with(nolock) 
Inner Join sys.procedures as T02 with(nolock) ON T01.SPECIFIC_NAME = T02.name 
Inner Join sys.parameters as T03 with(nolock) ON T02.object_id = T03.object_id and T01.PARAMETER_NAME = T03.name
Inner Join sys.types as T04 with(nolock) ON T03.user_type_id = T04.user_type_id
Where SPECIFIC_NAME = N'{0}'
Order by Ordinal_Position
";
                return String.Format(q, storedProcedureName);
            }
            public override String GetStoredFunctions()
            {
                return @"
SELECT SPECIFIC_NAME,T2.definition,CREATED,LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES AS T1 with(nolock)
inner join sys.sql_modules as T2 with(nolock) ON OBJECT_ID(T1.SPECIFIC_NAME) = T2.object_id
WHERE ROUTINE_TYPE = N'FUNCTION'
and SPECIFIC_NAME != N'fn_diagramobjects'
ORDER BY SPECIFIC_NAME
";
            }
        }
    }
}
