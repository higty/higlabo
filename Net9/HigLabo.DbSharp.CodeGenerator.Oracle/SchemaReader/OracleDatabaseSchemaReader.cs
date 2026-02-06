using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using Oracle.ManagedDataAccess;
using System.Data.Common;
using System.Data;
using System.Reflection;
using HigLabo.Core;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;

namespace HigLabo.DbSharp.MetaData;

public class OracleDatabaseSchemaReader : DatabaseSchemaReader
{
    public override DatabaseSchemaQueryBuilder QueryBuilder => new OracleDatabaseSchemaQueryBuilder();
    public override DatabaseServer DatabaseServer
    {
        get { return DatabaseServer.Oracle; }
    }
    public override bool SupportUserDefinedTableType
    {
        get { return false; }
    }

    public OracleDatabaseSchemaReader(String connectionString)
    {
        this.ConnectionString = connectionString;
    }
    public override Database CreateDatabase()
    {
        return new HigLabo.Data.OracleDatabase(this.ConnectionString);
    }

    public override async Task SetResultSetsListAsync(StoredProcedure sp, Dictionary<String, Object> values)
    {
        List<StoredProcedureResultSetColumn> resultSetsList = new List<StoredProcedureResultSetColumn>();
        List<DataTable> schemaDataTableList = new List<DataTable>();
        var cm = CreateTestSqlCommand<OracleCommand>(sp, values);

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
        var cm = new OracleCommand(storedProcedureName) { CommandType = CommandType.StoredProcedure };
        foreach (var p in parameters)
        {
            cm.Parameters.Add(this.CreateParameter(p.Name, p));
        }
        return cm;
    }

    protected override MetaData.DbType CreateDbType(Object value)
    {
        var tp = this.TypeConverter.ToEnum<OracleDbType>(value);
        if (tp.HasValue == false) throw new InvalidCastException();
        return new MetaData.DbType(tp.Value);
    }
    protected override IDbDataParameter CreateParameter(String name, DataType dataType)
    {
        var p = new Oracle.ManagedDataAccess.Client.OracleParameter(name, dataType.DbType!.OracleServerDbType!.Value);
        if (dataType is SqlInputParameter dType)
        {
            p.Direction = dType.ParameterDirection;
        }
        if (p.Direction != ParameterDirection.Output)
        {
            p.Value = this.GetParameterValue(dataType, dataType.DbType.OracleServerDbType.Value);
        }
        return p;
    }
    protected override Object? GetParameterValue(DataType dataType, Object sqlDbType)
    {
        switch ((OracleDbType)sqlDbType)
        {
            case OracleDbType.BFile:
            case OracleDbType.Blob:
                return new Byte[0];
            case OracleDbType.Byte:
                return 1;
            case OracleDbType.Char:
                return "a";
            case OracleDbType.Clob:
                return 1;
            case OracleDbType.Date:
                return new DateTime(2000, 1, 1);
            case OracleDbType.Decimal:
                return 1.0m;
            case OracleDbType.Double:
                return 1;
            case OracleDbType.Long:
                return 1;
            case OracleDbType.LongRaw:
                return new Byte[0];
            case OracleDbType.Int16:
            case OracleDbType.Int32:
            case OracleDbType.Int64:
                return 1;
            case OracleDbType.IntervalDS:
                return TimeSpan.FromHours(1);
            case OracleDbType.IntervalYM:
                return 1;
            case OracleDbType.NClob:
                return 1;
            case OracleDbType.NChar:
            case OracleDbType.NVarchar2:
                return "a";
            case OracleDbType.Raw:
                return new Byte[0];
            case OracleDbType.RefCursor:
                throw new NotSupportedException();
            case OracleDbType.Single:
                return 1;
            case OracleDbType.TimeStamp:
            case OracleDbType.TimeStampLTZ:
            case OracleDbType.TimeStampTZ:
                return new DateTime(2000, 1, 1);
            case OracleDbType.Varchar2:
                return "a";
            case OracleDbType.XmlType:
                return "<xml></xml>";
            case OracleDbType.BinaryDouble:
            case OracleDbType.BinaryFloat:
                return 1;
            case OracleDbType.Boolean:
                return true;
            default: throw new InvalidOperationException();
        }
    }

    public override string GetDefinitionText(Table table)
    {
        var t = table;
        var sb = new StringBuilder();

        sb.AppendFormat("CREATE TABLE \"{0}\"", t.Name).AppendLine();
        sb.AppendLine("(");

        for (int i = 0; i < t.Columns.Count; i++)
        {
            var c = t.Columns[i];
            if (i > 0)
            {
                sb.AppendLine(",");
            }
            sb.Append("  ");
            sb.Append(GetOracleColumnDefinition(c));
        }
        sb.AppendLine();

        // Primary Key
        var pkColumns = t.GetPrimaryKeyColumns().ToList();
        if (pkColumns.Count > 0)
        {
            sb.Append(", CONSTRAINT \"");
            sb.Append(t.Name);
            sb.Append("_PK\" PRIMARY KEY (");
            sb.Append(String.Join(", ", pkColumns.Select(el => "\"" + el.Name + "\"")));
            sb.AppendLine(")");
        }

        // Foreign Keys
        foreach (var c in t.Columns.FindAll(el => el.ForeignKey != null))
        {
            sb.AppendFormat(", CONSTRAINT \"{0}_FK_{1}\" FOREIGN KEY (\"{1}\") REFERENCES \"{2}\"(\"{3}\")"
                , t.Name, c.Name, c.ForeignKey!.ParentTableName, c.ForeignKey.ParentColumnName);
            if (c.ForeignKey.OnDelete != "NO_ACTION")
            {
                sb.AppendFormat(" ON DELETE {0}", c.ForeignKey.OnDelete.Replace("_", " "));
            }
            sb.AppendLine();
        }

        sb.AppendLine(");");
        sb.AppendLine();

        // Indexes (non-primary key, non-unique)
        foreach (var ix in t.IndexList.Where(el => !el.IsUnique))
        {
            sb.AppendFormat("CREATE INDEX \"{0}\" ON \"{1}\" ({2});"
                , ix.Name
                , t.Name
                , String.Join(", ", ix.Columns.Select(el => "\"" + el.Name + "\"")));
            sb.AppendLine();
        }

        // Check Constraints
        foreach (var cc in t.CheckConstraintList)
        {
            sb.AppendFormat("ALTER TABLE \"{0}\" ADD CONSTRAINT \"{1}\" CHECK ({2});",
                t.Name, cc.Name, cc.Definition);
            sb.AppendLine();
        }

        return sb.ToString();
    }
    private string GetOracleColumnDefinition(Column c)
    {
        var sb = new StringBuilder();
        sb.AppendFormat("\"{0}\" ", c.Name);
        sb.Append(GetOracleTypeName(c));

        if (c.AllowNull == false)
        {
            sb.Append(" NOT NULL");
        }

        if (c.DefaultCostraint != null)
        {
            sb.AppendFormat(" DEFAULT {0}", c.DefaultCostraint.Definition);
        }

        return sb.ToString();
    }
    private string GetOracleTypeName(Column c)
    {
        var dbType = c.DbType!.OracleServerDbType!.Value;
        switch (dbType)
        {
            case OracleDbType.Varchar2:
                return c.Length.HasValue ? $"VARCHAR2({c.Length})" : "VARCHAR2(4000)";
            case OracleDbType.NVarchar2:
                return c.Length.HasValue ? $"NVARCHAR2({c.Length})" : "NVARCHAR2(2000)";
            case OracleDbType.Char:
                return c.Length.HasValue ? $"CHAR({c.Length})" : "CHAR(1)";
            case OracleDbType.NChar:
                return c.Length.HasValue ? $"NCHAR({c.Length})" : "NCHAR(1)";
            case OracleDbType.Int16:
            case OracleDbType.Int32:
            case OracleDbType.Int64:
            case OracleDbType.Decimal:
                if (c.Precision.HasValue && c.Scale.HasValue)
                    return $"NUMBER({c.Precision},{c.Scale})";
                else if (c.Precision.HasValue)
                    return $"NUMBER({c.Precision})";
                return "NUMBER";
            case OracleDbType.Double:
                return "FLOAT";
            case OracleDbType.BinaryFloat:
                return "BINARY_FLOAT";
            case OracleDbType.BinaryDouble:
                return "BINARY_DOUBLE";
            case OracleDbType.Date:
                return "DATE";
            case OracleDbType.TimeStamp:
                return c.Scale.HasValue ? $"TIMESTAMP({c.Scale})" : "TIMESTAMP";
            case OracleDbType.TimeStampTZ:
                return c.Scale.HasValue ? $"TIMESTAMP({c.Scale}) WITH TIME ZONE" : "TIMESTAMP WITH TIME ZONE";
            case OracleDbType.TimeStampLTZ:
                return c.Scale.HasValue ? $"TIMESTAMP({c.Scale}) WITH LOCAL TIME ZONE" : "TIMESTAMP WITH LOCAL TIME ZONE";
            case OracleDbType.IntervalDS:
                return "INTERVAL DAY TO SECOND";
            case OracleDbType.IntervalYM:
                return "INTERVAL YEAR TO MONTH";
            case OracleDbType.Raw:
                return c.Length.HasValue ? $"RAW({c.Length})" : "RAW(2000)";
            case OracleDbType.Long:
                return "LONG";
            case OracleDbType.LongRaw:
                return "LONG RAW";
            case OracleDbType.Blob:
                return "BLOB";
            case OracleDbType.Clob:
                return "CLOB";
            case OracleDbType.NClob:
                return "NCLOB";
            case OracleDbType.BFile:
                return "BFILE";
            case OracleDbType.XmlType:
                return "XMLTYPE";
            case OracleDbType.Byte:
                return "NUMBER(3)";
            case OracleDbType.Single:
                return "BINARY_FLOAT";
            case OracleDbType.Boolean:
                return "NUMBER(1)";
            default:
                return "VARCHAR2(4000)";
        }
    }

    private class OracleDatabaseSchemaQueryBuilder : DatabaseSchemaQueryBuilder
    {
        public override String GetDatabases()
        {
            return @"
SELECT USERNAME AS SCHEMA_NAME
FROM ALL_USERS
WHERE ORACLE_MAINTAINED = 'N'
ORDER BY USERNAME ASC
";
        }
        public override String GetTables()
        {
            return @"
SELECT T1.TABLE_NAME
, T2.CREATED AS CREATE_TIME
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS MODIFY_TIME
FROM ALL_TABLES T1
JOIN ALL_OBJECTS T2 ON T1.TABLE_NAME = T2.OBJECT_NAME
    AND T1.OWNER = T2.OWNER AND T2.OBJECT_TYPE = 'TABLE'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
ORDER BY T1.TABLE_NAME ASC
";
        }
        public override String GetTable(String name)
        {
            var q = @"
SELECT T1.TABLE_NAME
, T2.CREATED AS CREATE_TIME
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS MODIFY_TIME
FROM ALL_TABLES T1
JOIN ALL_OBJECTS T2 ON T1.TABLE_NAME = T2.OBJECT_NAME
    AND T1.OWNER = T2.OWNER AND T2.OBJECT_TYPE = 'TABLE'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
";
            return String.Format(q, name);
        }
        public override String GetColumns(String tableName)
        {
            var q = @"
SELECT T1.TABLE_NAME AS TableName
, T1.COLUMN_NAME AS ColumnName
, CASE T1.DATA_TYPE
    WHEN 'VARCHAR2' THEN 'Varchar2'
    WHEN 'NVARCHAR2' THEN 'NVarchar2'
    WHEN 'CHAR' THEN 'Char'
    WHEN 'NCHAR' THEN 'NChar'
    WHEN 'NUMBER' THEN
        CASE
            WHEN T1.DATA_PRECISION IS NULL AND T1.DATA_SCALE IS NULL THEN 'Decimal'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 5 THEN 'Int16'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 10 THEN 'Int32'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 19 THEN 'Int64'
            ELSE 'Decimal'
        END
    WHEN 'FLOAT' THEN 'Double'
    WHEN 'BINARY_FLOAT' THEN 'BinaryFloat'
    WHEN 'BINARY_DOUBLE' THEN 'BinaryDouble'
    WHEN 'DATE' THEN 'Date'
    WHEN 'RAW' THEN 'Raw'
    WHEN 'LONG RAW' THEN 'LongRaw'
    WHEN 'LONG' THEN 'Long'
    WHEN 'BLOB' THEN 'Blob'
    WHEN 'CLOB' THEN 'Clob'
    WHEN 'NCLOB' THEN 'NClob'
    WHEN 'BFILE' THEN 'BFile'
    WHEN 'XMLTYPE' THEN 'XmlType'
    ELSE
        CASE
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%WITH LOCAL TIME ZONE' THEN 'TimeStampLTZ'
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%WITH TIME ZONE' THEN 'TimeStampTZ'
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%' THEN 'TimeStamp'
            WHEN T1.DATA_TYPE LIKE 'INTERVAL DAY%' THEN 'IntervalDS'
            WHEN T1.DATA_TYPE LIKE 'INTERVAL YEAR%' THEN 'IntervalYM'
            ELSE 'Varchar2'
        END
  END AS DbType
, T1.DATA_LENGTH AS ColumnLength
, T1.DATA_PRECISION AS ColumnPrecision
, T1.DATA_SCALE AS ColumnScale
, CASE T1.NULLABLE WHEN 'Y' THEN 1 ELSE 0 END AS AllowNull
, CASE WHEN T1.IDENTITY_COLUMN = 'YES' THEN 1 ELSE 0 END AS IsIdentity
, 0 AS IsRowGuidCol
, '' AS UdtTypeName
, '' AS EnumValues
FROM ALL_TAB_COLUMNS T1
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
ORDER BY T1.COLUMN_ID
";
            return String.Format(q, tableName);
        }
        public override String GetPrimaryKey(String tableName)
        {
            var q = @"
SELECT T1.CONSTRAINT_NAME AS Name
, T1.TABLE_NAME AS TableName
, T2.COLUMN_NAME AS ColumnName
, 'NONCLUSTERED' AS type_desc
FROM ALL_CONSTRAINTS T1
JOIN ALL_CONS_COLUMNS T2 ON T1.CONSTRAINT_NAME = T2.CONSTRAINT_NAME
    AND T1.OWNER = T2.OWNER
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
AND T1.CONSTRAINT_TYPE = 'P'
ORDER BY T2.POSITION
";
            return String.Format(q, tableName);
        }
        public override String GetIndex(String tableName)
        {
            var q = @"
SELECT T1.INDEX_NAME AS IndexName
, T1.TABLE_NAME AS TableName
, T2.COLUMN_NAME AS ColumnName
, CASE T1.INDEX_TYPE
    WHEN 'NORMAL' THEN CASE T1.UNIQUENESS WHEN 'UNIQUE' THEN 'UNIQUE' ELSE 'NONCLUSTERED' END
    WHEN 'BITMAP' THEN 'BITMAP'
    WHEN 'FUNCTION-BASED NORMAL' THEN 'FUNCTION-BASED'
    ELSE T1.INDEX_TYPE
  END AS IndexType
, CASE T1.UNIQUENESS WHEN 'UNIQUE' THEN 1 ELSE 0 END AS IsUnique
, 'Table' AS ObjectType
FROM ALL_INDEXES T1
JOIN ALL_IND_COLUMNS T2 ON T1.INDEX_NAME = T2.INDEX_NAME
    AND T1.OWNER = T2.INDEX_OWNER
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
ORDER BY T1.INDEX_NAME, T2.COLUMN_POSITION
";
            return String.Format(q, tableName);
        }
        public override String GetForeignKeys(String tableName)
        {
            var q = @"
SELECT T1.CONSTRAINT_NAME AS Name
, T1.TABLE_NAME AS TableName
, T2.COLUMN_NAME AS ColumnName
, T3.TABLE_NAME AS ParentTableName
, T4.COLUMN_NAME AS ParentColumnName
, 'NO_ACTION' AS update_referential_action_desc
, CASE T1.DELETE_RULE
    WHEN 'CASCADE' THEN 'CASCADE'
    WHEN 'SET NULL' THEN 'SET_NULL'
    ELSE 'NO_ACTION'
  END AS delete_referential_action_desc
FROM ALL_CONSTRAINTS T1
JOIN ALL_CONS_COLUMNS T2 ON T1.CONSTRAINT_NAME = T2.CONSTRAINT_NAME
    AND T1.OWNER = T2.OWNER
JOIN ALL_CONSTRAINTS T3 ON T1.R_CONSTRAINT_NAME = T3.CONSTRAINT_NAME
    AND T1.R_OWNER = T3.OWNER
JOIN ALL_CONS_COLUMNS T4 ON T3.CONSTRAINT_NAME = T4.CONSTRAINT_NAME
    AND T3.OWNER = T4.OWNER AND T2.POSITION = T4.POSITION
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
AND T1.CONSTRAINT_TYPE = 'R'
ORDER BY T1.CONSTRAINT_NAME, T2.POSITION
";
            return String.Format(q, tableName);
        }
        public override String GetDefaultConstraints(String tableName)
        {
            var q = @"
SELECT '' AS Name
, T1.TABLE_NAME AS TableName
, T1.COLUMN_NAME AS ColumnName
, T1.DATA_DEFAULT AS Definition
FROM ALL_TAB_COLUMNS T1
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
AND T1.DATA_DEFAULT IS NOT NULL
ORDER BY T1.COLUMN_ID
";
            return String.Format(q, tableName);
        }
        public override String GetCheckConstraints(String tableName)
        {
            var q = @"
SELECT T1.CONSTRAINT_NAME AS Name
, T1.TABLE_NAME AS TableName
, TO_CHAR(T1.SEARCH_CONDITION) AS Definition
FROM ALL_CONSTRAINTS T1
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.TABLE_NAME = '{0}'
AND T1.CONSTRAINT_TYPE = 'C'
AND T1.GENERATED = 'USER NAME'
ORDER BY T1.CONSTRAINT_NAME
";
            return String.Format(q, tableName);
        }
        public override String GetViews()
        {
            return @"
SELECT T1.VIEW_NAME AS VIEW_NAME
, T2.CREATED AS CREATE_TIME
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS MODIFY_TIME
, TO_CHAR(T1.TEXT) AS DEFINITION
FROM ALL_VIEWS T1
JOIN ALL_OBJECTS T2 ON T1.VIEW_NAME = T2.OBJECT_NAME
    AND T1.OWNER = T2.OWNER AND T2.OBJECT_TYPE = 'VIEW'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
ORDER BY T1.VIEW_NAME ASC
";
        }
        public override String GetUserDefinedTypes()
        {
            throw new NotSupportedException();
        }
        public override String GetUserDefinedTypeColumns(String name)
        {
            throw new NotSupportedException();
        }
        public override String GetStoredProcedures()
        {
            return @"
SELECT T1.OBJECT_NAME AS SPECIFIC_NAME
, '' AS ROUTINE_DEFINITION
, T2.CREATED AS CREATED
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS LAST_ALTERED
FROM ALL_PROCEDURES T1
JOIN ALL_OBJECTS T2 ON T1.OWNER = T2.OWNER
    AND T1.OBJECT_NAME = T2.OBJECT_NAME AND T2.OBJECT_TYPE = 'PROCEDURE'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.OBJECT_TYPE = 'PROCEDURE'
AND T1.PROCEDURE_NAME IS NULL
ORDER BY T1.OBJECT_NAME
";
        }
        public override String GetStoredProcedure(String name)
        {
            var q = @"
SELECT T1.OBJECT_NAME AS SPECIFIC_NAME
, '' AS ROUTINE_DEFINITION
, T2.CREATED AS CREATED
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS LAST_ALTERED
FROM ALL_PROCEDURES T1
JOIN ALL_OBJECTS T2 ON T1.OWNER = T2.OWNER
    AND T1.OBJECT_NAME = T2.OBJECT_NAME AND T2.OBJECT_TYPE = 'PROCEDURE'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.OBJECT_TYPE = 'PROCEDURE'
AND T1.OBJECT_NAME = '{0}'
AND T1.PROCEDURE_NAME IS NULL
";
            return String.Format(q, name);
        }
        public override String GetParameters(String storedProcedureName)
        {
            var q = @"
SELECT T1.OBJECT_NAME AS StoredProcedureName
, T1.ARGUMENT_NAME AS ParameterName
, CASE T1.DATA_TYPE
    WHEN 'VARCHAR2' THEN 'Varchar2'
    WHEN 'NVARCHAR2' THEN 'NVarchar2'
    WHEN 'CHAR' THEN 'Char'
    WHEN 'NCHAR' THEN 'NChar'
    WHEN 'NUMBER' THEN
        CASE
            WHEN T1.DATA_PRECISION IS NULL AND T1.DATA_SCALE IS NULL THEN 'Decimal'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 5 THEN 'Int16'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 10 THEN 'Int32'
            WHEN T1.DATA_SCALE = 0 AND T1.DATA_PRECISION <= 19 THEN 'Int64'
            ELSE 'Decimal'
        END
    WHEN 'FLOAT' THEN 'Double'
    WHEN 'BINARY_FLOAT' THEN 'BinaryFloat'
    WHEN 'BINARY_DOUBLE' THEN 'BinaryDouble'
    WHEN 'DATE' THEN 'Date'
    WHEN 'RAW' THEN 'Raw'
    WHEN 'LONG RAW' THEN 'LongRaw'
    WHEN 'LONG' THEN 'Long'
    WHEN 'BLOB' THEN 'Blob'
    WHEN 'CLOB' THEN 'Clob'
    WHEN 'NCLOB' THEN 'NClob'
    WHEN 'BFILE' THEN 'BFile'
    WHEN 'XMLTYPE' THEN 'XmlType'
    WHEN 'REF CURSOR' THEN 'RefCursor'
    ELSE
        CASE
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%WITH LOCAL TIME ZONE' THEN 'TimeStampLTZ'
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%WITH TIME ZONE' THEN 'TimeStampTZ'
            WHEN T1.DATA_TYPE LIKE 'TIMESTAMP%' THEN 'TimeStamp'
            WHEN T1.DATA_TYPE LIKE 'INTERVAL DAY%' THEN 'IntervalDS'
            WHEN T1.DATA_TYPE LIKE 'INTERVAL YEAR%' THEN 'IntervalYM'
            ELSE 'Varchar2'
        END
  END AS DbType
, T1.DATA_LENGTH AS ParameterLength
, T1.DATA_PRECISION AS ParameterPrecision
, T1.DATA_SCALE AS ParameterScale
, CASE T1.IN_OUT
    WHEN 'OUT' THEN 1
    WHEN 'IN/OUT' THEN 1
    ELSE 0
  END AS IsOutput
, '' AS UserTableTypeName
, '' AS UdtTypeName
FROM ALL_ARGUMENTS T1
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.OBJECT_NAME = '{0}'
AND T1.ARGUMENT_NAME IS NOT NULL
ORDER BY T1.POSITION
";
            return String.Format(q, storedProcedureName);
        }
        public override String GetStoredFunctions()
        {
            return @"
SELECT T1.OBJECT_NAME AS SPECIFIC_NAME
, '' AS ROUTINE_DEFINITION
, T2.CREATED AS CREATED
, NVL(T2.LAST_DDL_TIME, T2.CREATED) AS LAST_ALTERED
FROM ALL_PROCEDURES T1
JOIN ALL_OBJECTS T2 ON T1.OWNER = T2.OWNER
    AND T1.OBJECT_NAME = T2.OBJECT_NAME AND T2.OBJECT_TYPE = 'FUNCTION'
WHERE T1.OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA')
AND T1.OBJECT_TYPE = 'FUNCTION'
AND T1.PROCEDURE_NAME IS NULL
ORDER BY T1.OBJECT_NAME
";
        }
    }
}
