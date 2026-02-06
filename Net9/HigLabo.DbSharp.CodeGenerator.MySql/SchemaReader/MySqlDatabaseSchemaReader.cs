using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using System.Reflection;
using HigLabo.Core;
using MySql.Data.Types;

namespace HigLabo.DbSharp.MetaData;

public class MySqlDatabaseSchemaReader : DatabaseSchemaReader
{
    public override DatabaseSchemaQueryBuilder QueryBuilder => new MySqlDatabaseSchemaQueryBuilder();
    public override DatabaseServer DatabaseServer
    {
        get { return DatabaseServer.MySql; }
    }
    public override bool SupportUserDefinedTableType
    {
        get { return false; }
    }
    public MySqlDatabaseSchemaReader(String connectionString)
    {
        this.ConnectionString = connectionString;
    }
    public override Database CreateDatabase()
    {
        return new MySqlDatabase(this.ConnectionString);
    }

    public override async Task SetResultSetsListAsync(StoredProcedure sp, Dictionary<String, Object> values)
    {
        List<StoredProcedureResultSetColumn> resultSetsList = new List<StoredProcedureResultSetColumn>();
        List<DataTable> schemaDataTableList = new List<DataTable>();
        var cm = CreateTestSqlCommand<MySqlCommand>(sp, values);

        //処理の実行によってデータの変更などの副作用が起きないようにRollBackする。
        using (var db = this.CreateDatabase())
        {
            try
            {
                db.Open();
                db.BeginTransaction(IsolationLevel.ReadCommitted);

                using (var r = await db.ExecuteReaderAsync(cm))
                {
                    var schemaDataTable = r!.GetSchemaTable();
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
                    throw new InvalidOperationException();
                }

                if (c.DbType.IsStructured() == true)
                {
                    throw new InvalidOperationException();
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
    private DbCommand GetTestExecutingSqlCommand(String storedProcedureName, IEnumerable<SqlInputParameter> parameters)
    {
        var cm = new MySqlCommand(storedProcedureName) { CommandType = CommandType.StoredProcedure };
        foreach (var p in parameters)
        {
            cm.Parameters.Add(this.CreateParameter(p.Name, p));
        }
        return cm;
    }

    protected override MetaData.DbType CreateDbType(Object value)
    {
        var tp = this.TypeConverter.ToEnum<MySqlDbType>(value);
        if (tp.HasValue == false) throw new InvalidCastException();
        return new MetaData.DbType(tp.Value);
    }
    protected override IDbDataParameter CreateParameter(String name, DataType dataType)
    {
        var p = new MySql.Data.MySqlClient.MySqlParameter(name, dataType.DbType!.MySqlServerDbType!.Value.GetMySqlDbType());
        if (dataType is SqlInputParameter dType)
        {
            p.Direction = dType.ParameterDirection;
        }
        if (p.Direction != ParameterDirection.Output)
        {
            p.Value = this.GetParameterValue(dataType, dataType.DbType.MySqlServerDbType.Value);
        }
        return p;
    }
    protected override Object? GetParameterValue(DataType dataType, Object sqlDbType)
    {
        switch ((MySqlDbType)sqlDbType)
        {
            case MySqlDbType.Binary:
            case MySqlDbType.Blob:
            case MySqlDbType.TinyBlob:
            case MySqlDbType.MediumBlob:
            case MySqlDbType.LongBlob:
            case MySqlDbType.VarBinary:
                return new Byte[0];
            case MySqlDbType.Date:
            case MySqlDbType.Newdate:
            case MySqlDbType.DateTime:
                return new DateTime(2000, 1, 1);
            case MySqlDbType.Enum:
                return "a";
            case MySqlDbType.Geometry:
                return new MySqlGeometry(40.735031, -73.768387);
            case MySqlDbType.Guid:
                return Guid.NewGuid();
            case MySqlDbType.Bit:
            case MySqlDbType.Double:
            case MySqlDbType.Float:
            case MySqlDbType.Byte:
            case MySqlDbType.Int16:
            case MySqlDbType.Int24:
            case MySqlDbType.Int32:
            case MySqlDbType.Int64:
            case MySqlDbType.UByte:
            case MySqlDbType.UInt16:
            case MySqlDbType.UInt24:
            case MySqlDbType.UInt32:
            case MySqlDbType.UInt64:
            case MySqlDbType.Decimal:
            case MySqlDbType.NewDecimal:
                return 1;
            case MySqlDbType.JSON:
                return "{ \"Name\" : \"Name1\" }";
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

    public override string GetDefinitionText(Table table)
    {
        var t = table;
        var sb = new StringBuilder();

        sb.AppendFormat("CREATE TABLE `{0}`", t.Name).AppendLine();
        sb.AppendLine("(");

        for (int i = 0; i < t.Columns.Count; i++)
        {
            var c = t.Columns[i];
            if (i > 0)
            {
                sb.AppendLine(",");
            }
            sb.Append("  ");
            sb.Append(GetMySqlColumnDefinition(c));
        }
        sb.AppendLine();

        // Primary Key
        var pkColumns = t.GetPrimaryKeyColumns().ToList();
        if (pkColumns.Count > 0)
        {
            sb.Append(", PRIMARY KEY (");
            sb.Append(String.Join(", ", pkColumns.Select(el => "`" + el.Name + "`")));
            sb.AppendLine(")");
        }

        // Foreign Keys
        foreach (var c in t.Columns.FindAll(el => el.ForeignKey != null))
        {
            sb.AppendFormat(", CONSTRAINT `{0}_FK_{1}` FOREIGN KEY (`{1}`) REFERENCES `{2}`(`{3}`)"
                , t.Name, c.Name, c.ForeignKey!.ParentTableName, c.ForeignKey.ParentColumnName);
            if (c.ForeignKey.OnUpdate != "NO_ACTION" && c.ForeignKey.OnUpdate != "RESTRICT")
            {
                sb.AppendFormat(" ON UPDATE {0}", c.ForeignKey.OnUpdate.Replace("_", " "));
            }
            if (c.ForeignKey.OnDelete != "NO_ACTION" && c.ForeignKey.OnDelete != "RESTRICT")
            {
                sb.AppendFormat(" ON DELETE {0}", c.ForeignKey.OnDelete.Replace("_", " "));
            }
            sb.AppendLine();
        }

        // Indexes (non-primary key, non-unique)
        foreach (var ix in t.IndexList.Where(el => !el.IsUnique))
        {
            sb.AppendFormat(", INDEX `{0}` ({1})"
                , ix.Name
                , String.Join(", ", ix.Columns.Select(el => "`" + el.Name + "`")));
            sb.AppendLine();
        }

        sb.AppendLine(") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");
        sb.AppendLine();

        // Check Constraints (MySQL 8.0.16+)
        foreach (var cc in t.CheckConstraintList)
        {
            sb.AppendFormat("ALTER TABLE `{0}` ADD CONSTRAINT `{1}` CHECK ({2});",
                t.Name, cc.Name, cc.Definition);
            sb.AppendLine();
        }

        return sb.ToString();
    }
    private string GetMySqlColumnDefinition(Column c)
    {
        var sb = new StringBuilder();
        sb.AppendFormat("`{0}` ", c.Name);
        sb.Append(GetMySqlTypeName(c));

        if (c.AllowNull == false)
        {
            sb.Append(" NOT NULL");
        }

        if (c.IsIdentity == true)
        {
            sb.Append(" AUTO_INCREMENT");
        }

        if (c.DefaultCostraint != null)
        {
            sb.AppendFormat(" DEFAULT {0}", c.DefaultCostraint.Definition);
        }

        return sb.ToString();
    }
    private string GetMySqlTypeName(Column c)
    {
        var dbType = c.DbType!.MySqlServerDbType!.Value;
        switch (dbType)
        {
            case MySqlDbType.String:
                return c.Length.HasValue ? $"CHAR({c.Length})" : "CHAR(255)";
            case MySqlDbType.VarChar:
            case MySqlDbType.VarString:
                return c.Length.HasValue ? $"VARCHAR({c.Length})" : "VARCHAR(255)";
            case MySqlDbType.Text:
                return "TEXT";
            case MySqlDbType.TinyText:
                return "TINYTEXT";
            case MySqlDbType.MediumText:
                return "MEDIUMTEXT";
            case MySqlDbType.LongText:
                return "LONGTEXT";
            case MySqlDbType.Byte:
                return "TINYINT";
            case MySqlDbType.UByte:
                return "TINYINT UNSIGNED";
            case MySqlDbType.Int16:
                return "SMALLINT";
            case MySqlDbType.UInt16:
                return "SMALLINT UNSIGNED";
            case MySqlDbType.Int24:
                return "MEDIUMINT";
            case MySqlDbType.UInt24:
                return "MEDIUMINT UNSIGNED";
            case MySqlDbType.Int32:
                return "INT";
            case MySqlDbType.UInt32:
                return "INT UNSIGNED";
            case MySqlDbType.Int64:
                return "BIGINT";
            case MySqlDbType.UInt64:
                return "BIGINT UNSIGNED";
            case MySqlDbType.Float:
                return "FLOAT";
            case MySqlDbType.Double:
                return "DOUBLE";
            case MySqlDbType.Decimal:
            case MySqlDbType.NewDecimal:
                if (c.Precision.HasValue && c.Scale.HasValue)
                    return $"DECIMAL({c.Precision},{c.Scale})";
                else if (c.Precision.HasValue)
                    return $"DECIMAL({c.Precision})";
                return "DECIMAL";
            case MySqlDbType.Date:
            case MySqlDbType.Newdate:
                return "DATE";
            case MySqlDbType.DateTime:
                return c.Scale.HasValue && c.Scale > 0 ? $"DATETIME({c.Scale})" : "DATETIME";
            case MySqlDbType.Timestamp:
                return c.Scale.HasValue && c.Scale > 0 ? $"TIMESTAMP({c.Scale})" : "TIMESTAMP";
            case MySqlDbType.Time:
                return c.Scale.HasValue && c.Scale > 0 ? $"TIME({c.Scale})" : "TIME";
            case MySqlDbType.Year:
                return "YEAR";
            case MySqlDbType.Bit:
                return c.Length.HasValue ? $"BIT({c.Length})" : "BIT(1)";
            case MySqlDbType.Binary:
                return c.Length.HasValue ? $"BINARY({c.Length})" : "BINARY(255)";
            case MySqlDbType.VarBinary:
                return c.Length.HasValue ? $"VARBINARY({c.Length})" : "VARBINARY(255)";
            case MySqlDbType.Blob:
                return "BLOB";
            case MySqlDbType.TinyBlob:
                return "TINYBLOB";
            case MySqlDbType.MediumBlob:
                return "MEDIUMBLOB";
            case MySqlDbType.LongBlob:
                return "LONGBLOB";
            case MySqlDbType.Enum:
                return !String.IsNullOrEmpty(c.EnumValues) ? c.EnumValues : "ENUM('value1')";
            case MySqlDbType.Set:
                return !String.IsNullOrEmpty(c.EnumValues) ? c.EnumValues : "SET('value1')";
            case MySqlDbType.JSON:
                return "JSON";
            case MySqlDbType.Geometry:
                return "GEOMETRY";
            case MySqlDbType.Guid:
                return "CHAR(36)";
            default:
                return "VARCHAR(255)";
        }
    }

    private class MySqlDatabaseSchemaQueryBuilder : DatabaseSchemaQueryBuilder
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
        public override String GetColumns(String tableName)
        {
            var q = @"
SELECT T01.TABLE_NAME AS TableName
,T01.COLUMN_NAME AS ColumnName
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
order by ORDINAL_POSITION
";
            return String.Format(q, tableName);
        }
        public override String GetPrimaryKey(String tableName)
        {
            var q = @"
SELECT '' as Name
, T01.TABLE_NAME AS TableName
, T01.COLUMN_NAME AS ColumnName
, '' as type_desc
from information_schema.columns as T01
where Table_Schema = (SELECT DATABASE() FROM DUAL) 
and TABLE_NAME = '{0}'
and T01.COLUMN_KEY = 'PRI'
";
            return String.Format(q, tableName);
        }
        public override String GetIndex(String tableName)
        {
            var q = @"
select index_name
,table_name
,column_name
,INDEX_TYPE AS IndexType
,CASE NON_UNIQUE when 1 then 0 else 1 end as IsUnique
,'Table' as ObjectType 
from information_schema.statistics where table_name = '{0}';
";
            return String.Format(q, tableName);
        }
        public override String GetDefaultConstraints(String tableName)
        {
            var q = @"
SELECT '' as Name
,cols.TABLE_NAME
,cols.COLUMN_NAME
,cols.COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.`COLUMNS` as cols
WHERE cols.TABLE_SCHEMA=DATABASE()
AND cols.TABLE_NAME='{0}'
AND cols.COLUMN_DEFAULT IS NOT NULL"
;
            return String.Format(q, tableName);
        }
        public override String GetForeignKeys(String tableName)
        {
            var q = @"
SELECT T1.constraint_name as Name
, T1.table_name as TableName
, T1.column_name as ColumnName
, T1.referenced_table_name as ParentTableName
, T1.referenced_column_name as ParentColumnName
, T2.update_rule
, T2.delete_rule 
FROM INFORMATION_SCHEMA.key_column_usage T1
JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS as T2 on T1.constraint_name = T2.constraint_name
WHERE T1.referenced_table_schema = '{0}' 
AND T1.referenced_table_name IS NOT NULL 
ORDER BY T1.table_name, T1.column_name
";
            return String.Format(q, tableName);
        }
        public override String GetCheckConstraints(String tableName)
        {
            var q = @"
SELECT constraint_name as Name
,table_name as TableName
,'' as Definition
FROM information_schema.table_constraints 
where table_name = N'{0}'
and CONSTRAINT_TYPE = N'CHECK';";
            return String.Format(q, tableName);
        }
        public override String GetViews()
        {
            return @"
SELECT T1.TABLE_NAME AS VIEW_NAME
, T1.CREATE_TIME AS CREATE_TIME
, IFNULL(T1.UPDATE_TIME, T1.CREATE_TIME) AS MODIFY_TIME
, T2.VIEW_DEFINITION AS DEFINITION
FROM INFORMATION_SCHEMA.TABLES T1
JOIN INFORMATION_SCHEMA.VIEWS T2 ON T1.TABLE_NAME = T2.TABLE_NAME
    AND T1.TABLE_SCHEMA = T2.TABLE_SCHEMA
WHERE T1.TABLE_SCHEMA = (SELECT DATABASE() FROM DUAL)
AND T1.TABLE_TYPE = 'VIEW'
ORDER BY T1.TABLE_NAME ASC
";
        }
        public override String GetUserDefinedTypes()
        {
            throw new NotImplementedException();
        }
        public override String GetUserDefinedTypeColumns(String name)
        {
            throw new NotImplementedException();
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
        public override string GetStoredFunctions()
        {
            return @"
SELECT SPECIFIC_NAME, ROUTINE_DEFINITION, CREATED, LAST_ALTERED
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_SCHEMA = (SELECT DATABASE() FROM DUAL)
AND ROUTINE_TYPE = 'FUNCTION'
ORDER BY SPECIFIC_NAME
";
        }
    }
}
