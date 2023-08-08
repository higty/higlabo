using HigLabo.Core;
using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public abstract class DatabaseSchemaReader
    {
        public TypeConverter TypeConverter { get; init; } = new TypeConverter();
        public abstract DatabaseSchemaQueryBuilder QueryBuilder { get; }
        public abstract DatabaseServer DatabaseServer { get; }
        public String ConnectionString { get; protected set; } = "";
        public abstract Boolean SupportUserDefinedTableType { get; }

        public abstract Database CreateDatabase();
        public virtual async ValueTask<List<DatabaseObject>> GetTablesAsync()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetTables());
                while (reader!.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.Table);
                    o.Name = reader.GetString(0);
                    o.CreateTime = reader.GetDateTime(1);
                    o.LastAlteredTime = reader.GetDateTime(2);
                    l.Add(o);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<Table> GetTableAsync(String name)
        {
            var t = new Table(name);
            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetTable(name));
                if (reader == null || await reader.ReadAsync() == false) { throw new InvalidOperationException(String.Format("Table {0} does not exist.", name)); }
                t.Name = reader.GetString(0);
                t.CreateTime = reader.GetDateTime(1);
                t.LastAlteredTime = reader.GetDateTime(2);
                db.Close();
            }
            foreach (var item in await this.GetColumnListAsync(name))
            {
                t.Columns.Add(item);
            }
            foreach (var item in await this.GetPrimaryKeyAsync(name))
            {
                var c = t.Columns.Find(el => el.Name == item.ColumnName);
                if (c == null) { continue; }
                c.IsPrimaryKey = true;
                c.Clustered = item.Clustered;
            }
            foreach (var item in await this.GetIndexAsync(name))
            {
                var columnList = new List<Column>();
                foreach (var indexColumn in item.Columns)
                {
                    var c = t.Columns.First(el => el.Name == indexColumn.Name);
                    columnList.Add(c);
                }
                item.Columns.Clear();
                item.Columns.AddRange(columnList);
                t.IndexList.Add(item);
            }
            foreach (var item in await this.GetForeignKeyColumnAsync(name))
            {
                var c = t.Columns.First(el => el.Name == item.ColumnName);
                c.ForeignKey = item;
            }
            foreach (var item in await this.GetCheckConstraintAsync(name))
            {
                t.CheckConstraintList.Add(item);
            }
            foreach (var item in await this.GetDefaultCostraintAsync(name))
            {
                var c = t.Columns.First(el => el.Name == item.ColumnName);
                c.DefaultCostraint = item;
            }
            return t;
        }
        public virtual async ValueTask<List<PrimaryKeyConstraint>> GetPrimaryKeyAsync(String tableName)
        {
            var l = new List<PrimaryKeyConstraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetPrimaryKey(tableName));
                while (await reader!.ReadAsync())
                {
                    var c = new PrimaryKeyConstraint();
                    c.Name = reader.GetString(0);
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.Clustered = reader.GetString(3);
                    l.Add(c);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<Index>> GetIndexAsync(String tableName)
        {
            var l = new List<Index>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetIndex(tableName));
                while (await reader!.ReadAsync())
                {
                    var indexName = reader.GetString(0);
                    var ix = l.Find(el => el.Name == indexName);
                    if (ix == null)
                    {
                        ix = new Index();
                        ix.Name = indexName;
                        ix.TableName = reader.GetString(1);
                        ix.IndexType = reader.GetString(3);
                        ix.IsUnique = reader.GetBoolean(4);
                        ix.ObjectType = reader.GetString(5);
                    }
                    var columnName = reader.GetString(2); 
                    ix.Columns.Add(new Column() { Name = columnName });
                    l.Add(ix);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<DefaultCostraint>> GetDefaultCostraintAsync(String tableName)
        {
            var l = new List<DefaultCostraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetDefaultConstraints(tableName));
                while (await reader!.ReadAsync())
                {
                    var c = new DefaultCostraint();
                    c.Name = reader.GetString(0) ?? "";
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.Definition = reader.GetString(3);
                    l.Add(c);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<ForeignKeyColumn>> GetForeignKeyColumnAsync(String tableName)
        {
            var l = new List<ForeignKeyColumn>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetForeignKeys(tableName));
                while (await reader!.ReadAsync())
                {
                    var c = new ForeignKeyColumn();
                    c.ForeignKeyName = reader.GetString(0);
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.ParentTableName = reader.GetString(3);
                    c.ParentColumnName = reader.GetString(4);
                    c.OnUpdate = reader.GetString(5);
                    c.OnDelete = reader.GetString(6);
                    l.Add(c);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<CheckConstraint>> GetCheckConstraintAsync(String tableName)
        {
            var l = new List<CheckConstraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetCheckConstraints(tableName));
                while (await reader!.ReadAsync())
                {
                    var c = new CheckConstraint();
                    c.Name = reader.GetString(0);
                    c.TableName = tableName;
                    c.Definition = reader.GetString(2);
                    l.Add(c);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<Column>> GetColumnListAsync(String tableName)
        {
            var l = new List<Column>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetColumns(tableName));

                while (await reader!.ReadAsync())
                {
                    var c = new Column();
                    c.Name = reader.GetString(1);
                    c.Ordinal = l.Count;
                    c.IsPrimaryKey = false;
                    c.DbType = this.CreateDbType(reader[2]);
                    if (reader[3] != DBNull.Value) c.Length = this.TypeConverter.ToInt32(reader[3]);
                    if (reader[4] != DBNull.Value) c.Precision = this.TypeConverter.ToInt32(reader[4]);
                    if (reader[5] != DBNull.Value) c.Scale = this.TypeConverter.ToInt32(reader[5]);
                    c.AllowNull = reader.GetBoolean(6);
                    c.IsIdentity = reader.GetBoolean(7);
                    c.IsRowGuidCol = reader.GetBoolean(8);
                    c.UdtTypeName = reader.GetString(9);//UdtTypeName
                    if (reader[10] != DBNull.Value) c.EnumValues = reader.GetString(10);

                    l.Add(c);
                }
                db.Close();
            }
            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetPrimaryKey(tableName));

                while (await reader!.ReadAsync())
                {
                    var columnName = reader.GetString(2);
                    var c = l.First(el => el.Name == columnName);
                    c.IsPrimaryKey = true;
                    c.Clustered = reader.GetString(3);
                }
                db.Close();
            }
            return l;
        }

        public virtual async ValueTask<List<DatabaseObject>> GetViewsAsync()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetViews());
                while (await reader!.ReadAsync())
                {
                    var o = new DatabaseObject(DatabaseObjectType.View);
                    o.Name = reader.GetString(0);
                    o.CreateTime = reader.GetDateTime(1);
                    o.LastAlteredTime = reader.GetDateTime(2);
                    o.Body = reader.GetString(3);
                    l.Add(o);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<List<DatabaseObject>> GetStoredProceduresAsync()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetStoredProcedures());
                while (await reader!.ReadAsync())
                {
                    var o = new DatabaseObject(DatabaseObjectType.StoredProcedure);
                    o.Name = reader.GetString(0);
                    if (reader[1] != DBNull.Value) { o.Body = reader.GetString(1); }
                    o.CreateTime = reader.GetDateTime(2);
                    o.LastAlteredTime = reader.GetDateTime(3);
                    l.Add(o);
                }
                db.Close();
            }
            return l;
        }
        public virtual async ValueTask<Boolean> ExistStoredProcedure(String name)
        {
            var q = this.QueryBuilder;
            using (var db = this.CreateDatabase())
            {
                var dr = await db.ExecuteReaderAsync(q.GetStoredProcedure(name));
                while (await dr!.ReadAsync())
                {
                    return true;
                }
                db.Close();
            }
            return false;
        }
        public virtual async ValueTask<StoredProcedure> GetStoredProcedureAsync(String name)
        {
            var sp = new StoredProcedure(this.DatabaseServer, name);
            
            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetStoredProcedure(name));
                if (await reader!.ReadAsync() == false) { throw new InvalidOperationException(String.Format("Stored procedure {0} does not exist.", name)); }
                sp.Name = reader.GetString(0);
                if (reader[1] != DBNull.Value)
                {
                    sp.Body = reader.GetString(1).TrimStart();
                }
                sp.CreateTime = reader.GetDateTime(2);
                sp.LastAlteredTime = reader.GetDateTime(3);
            }
            foreach (var parameter in await this.GetParametersAsync(name))
            {
                sp.Parameters.Add(parameter);
            }
            return sp;
        }
        public virtual async ValueTask<List<SqlInputParameter>> GetParametersAsync(String storedProcedureName)
        {
            var l = new List<SqlInputParameter>();
            Int32 name = 1;
            Int32 dbType = 2;
            Int32 parameterLength = 3;
            Int32 parameterPrecision = 4;
            Int32 parameterScale = 5;
            Int32 isOutput = 6;
            Int32 userTableTypeName = 7;
            Int32 udtTypeName = 8;

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetParameters(storedProcedureName));

                while (await reader!.ReadAsync())
                {
                    var p = new SqlInputParameter();
                    p.Name = reader.GetString(name);
                    p.Ordinal = l.Count;
                    p.DbType = this.CreateDbType(reader[dbType]);
                    if (p.DbType.IsStructured() == true)
                    {
                        p.UserTableTypeName = reader.GetString(userTableTypeName);
                    }
                    if (p.DbType.IsUdt() == true)
                    {
                        p.UdtTypeName = reader.GetString(udtTypeName);
                    }
                    p.AllowNull = true;
                    if (reader[parameterLength] != DBNull.Value) p.Length = this.TypeConverter.ToInt32(reader[parameterLength]);
                    if (reader[parameterPrecision] != DBNull.Value) p.Precision = this.TypeConverter.ToInt32(reader[parameterPrecision]);
                    if (reader[parameterScale] != DBNull.Value) p.Scale = this.TypeConverter.ToInt32(reader[parameterScale]);
                    if (reader.GetBoolean(isOutput) == true)
                    {
                        p.ParameterDirection = ParameterDirection.InputOutput;
                    }
                    else
                    {
                        p.ParameterDirection = ParameterDirection.Input;
                    }
                    l.Add(p);
                }

                db.Close();
            }
            return l;
        }
        public abstract Task SetResultSetsListAsync(StoredProcedure sp, Dictionary<String, Object> values);

        public virtual async ValueTask<List<DatabaseObject>> GetStoredFunctionsAsync()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetStoredFunctions());
                while (await reader!.ReadAsync())
                {
                    var o = new DatabaseObject(DatabaseObjectType.StoredFunction);
                    o.Name = reader.GetString(0);
                    o.Body = reader.GetString(1);
                    o.CreateTime = reader.GetDateTime(2);
                    o.LastAlteredTime = reader.GetDateTime(3);
                    l.Add(o);
                }
            }
            return l;
        }

        public virtual async ValueTask<List<DatabaseObject>> GetUserDefinedTableTypesAsync()
        {
            return await ValueTask.FromResult(new List<DatabaseObject>());
        }
        public virtual async ValueTask<UserDefinedTableType> GetUserDefinedTableTypeAsync(string name)
        {
            return await ValueTask.FromResult(new UserDefinedTableType());
        }
        public virtual async ValueTask<List<DataType>> GetUserDefinedTableTypeColumnsAsync(string name)
        {
            return await ValueTask.FromResult(new List<DataType>());
        }
        protected abstract MetaData.DbType CreateDbType(Object value);

        protected T CreateTestSqlCommand<T>(StoredProcedure sp, Dictionary<String, Object> values)
            where T : DbCommand, new()
        {
            T cm = new T();
            cm.CommandText = sp.Name;
            cm.CommandType = CommandType.StoredProcedure;
            foreach (var item in sp.Parameters)
            {
                var p = this.CreateParameter(item.Name, item);
                if (values.ContainsKey(item.Name) == true)
                {
                    p.Value = values[item.Name];
                }
                cm.Parameters.Add(p);
            }
            return cm;
        }
        protected abstract IDbDataParameter CreateParameter(String name, DataType dataType);
        protected abstract Object? GetParameterValue(DataType dataType, Object dbType);

        public abstract String GetDefinitionText(Table table);
    }
}
