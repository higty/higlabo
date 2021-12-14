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
        public DatabaseSchemaQueryBuilder QueryBuilder { get; protected set; }
        public abstract DatabaseServer DatabaseServer { get; }
        public String ConnectionString { get; protected set; }
        public abstract Boolean SupportUserDefinedTableType { get; }

        public abstract Database CreateDatabase();
        public virtual List<DatabaseObject> GetTables()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetTables());
                while (reader.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.Table);
                    o.Name = reader.GetString(0);
                    o.CreateTime = reader.GetDateTime(1);
                    o.LastAlteredTime = reader.GetDateTime(2);
                    l.Add(o);
                }
            }
            return l;
        }
        public virtual Table GetTable(String name)
        {
            var t = new Table(name);
            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetTable(name));
                if (reader.Read() == false) throw new InvalidOperationException(String.Format("Table {0} does not exist.", name));
                t.Name = reader.GetString(0);
                t.CreateTime = reader.GetDateTime(1);
                t.LastAlteredTime = reader.GetDateTime(2);
            }
            var px = new ParalellExecutionContext();
            px.TaskList.Add(this.GetColumnListAsync(name));
            px.TaskList.Add(this.GetPrimaryKeyAsync(name));
            px.TaskList.Add(this.GetDefaultCostraintAsync(name));
            px.TaskList.Add(this.GetForeignKeyColumnAsync(name));
            px.TaskList.Add(this.GetCheckConstraintAsync(name));
            var ex = px.Execute();
            if (ex != null) { ExceptionDispatchInfo.Capture(ex).Throw(); }

            foreach (var item in px.GetResults<List<Column>>().SelectMany(el => el))
            {
                t.Columns.Add(item);
            }
            foreach (var item in px.GetResults<List<PrimaryKeyConstraint>>().SelectMany(el => el))
            {
                var c = t.Columns.Find(el => el.Name == item.ColumnName);
                c.IsPrimaryKey = true;
                c.Clustered = item.Clustered;
            }
            foreach (var item in px.GetResults<List<DefaultCostraint>>().SelectMany(el => el))
            {
                var c = t.Columns.Find(el => el.Name == item.ColumnName);
                c.DefaultCostraint = item;
            }
            foreach (var item in px.GetResults<List<ForeignKeyColumn>>().SelectMany(el => el))
            {
                var c = t.Columns.Find(el => el.Name == item.ColumnName);
                c.ForeignKey = item;
            }
            foreach (var item in px.GetResults<List<CheckConstraint>>().SelectMany(el => el))
            {
                t.CheckConstraintList.Add(item);
            }
            return t;
        }
        public virtual async Task<List<PrimaryKeyConstraint>> GetPrimaryKeyAsync(String tableName)
        {
            var l = new List<PrimaryKeyConstraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetPrimaryKey(tableName));
                while (await reader.ReadAsync())
                {
                    var c = new PrimaryKeyConstraint();
                    c.Name = reader.GetString(0);
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.Clustered = reader.GetString(3);
                    l.Add(c);
                }
            }
            return l;
        }
        public virtual async Task<List<DefaultCostraint>> GetDefaultCostraintAsync(String tableName)
        {
            var l = new List<DefaultCostraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetDefaultConstraints(tableName));
                while (await reader.ReadAsync())
                {
                    var c = new DefaultCostraint();
                    c.Name = reader.GetString(0);
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.Definition = reader.GetString(3);
                    l.Add(c);
                }
            }
            return l;
        }
        public virtual async Task<List<ForeignKeyColumn>> GetForeignKeyColumnAsync(String tableName)
        {
            var l = new List<ForeignKeyColumn>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetForeignKeys(tableName));
                while (await reader.ReadAsync())
                {
                    var c = new ForeignKeyColumn();
                    c.TableName = reader.GetString(1);
                    c.ColumnName = reader.GetString(2);
                    c.ParentTableName = reader.GetString(3);
                    c.ParentColumnName = reader.GetString(4);
                    c.OnUpdate = reader.GetString(5);
                    c.OnDelete = reader.GetString(6);
                    l.Add(c);
                }
            }
            return l;
        }
        public virtual async Task<List<CheckConstraint>> GetCheckConstraintAsync(String tableName)
        {
            var l = new List<CheckConstraint>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetCheckConstraints(tableName));
                while (await reader.ReadAsync())
                {
                    var c = new CheckConstraint();
                    c.Name = reader.GetString(0);
                    c.TableName = tableName;
                    c.Definition = reader.GetString(2);
                    l.Add(c);
                }
            }
            return l;
        }
        public virtual async Task<List<Column>> GetColumnListAsync(String tableName)
        {
            var l = new List<Column>();

            using (Database db = this.CreateDatabase())
            {
                var reader = await db.ExecuteReaderAsync(this.QueryBuilder.GetColumns(tableName));

                while (await reader.ReadAsync())
                {
                    var c = new Column();
                    c.Name = reader.GetString(1);
                    c.Ordinal = l.Count;
                    c.IsPrimaryKey = reader.GetBoolean(2);
                    c.DbType = this.CreateDbType(reader[3]);
                    if (reader[4] != DBNull.Value) c.Length = AppEnvironment.Settings.TypeConverter.ToInt32(reader[4]);
                    if (reader[5] != DBNull.Value) c.Precision = AppEnvironment.Settings.TypeConverter.ToInt32(reader[5]);
                    if (reader[6] != DBNull.Value) c.Scale = AppEnvironment.Settings.TypeConverter.ToInt32(reader[6]);
                    c.AllowNull = reader.GetBoolean(7);
                    c.IsIdentity = reader.GetBoolean(8);
                    c.IsRowGuidCol = reader.GetBoolean(9);
                    c.UdtTypeName = reader.GetString(10);//UdtTypeName
                    if (reader[11] != DBNull.Value) c.EnumValues = reader.GetString(11);

                    l.Add(c);
                }
            }
            return l;
        }

        public virtual List<DatabaseObject> GetViews()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetViews());
                while (reader.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.View);
                    o.Name = reader.GetString(0);
                    o.CreateTime = reader.GetDateTime(1);
                    o.LastAlteredTime = reader.GetDateTime(2);
                    o.Body = reader.GetString(3);
                    l.Add(o);
                }
            }
            return l;
        }
        public virtual List<DatabaseObject> GetStoredProcedures()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetStoredProcedures());
                while (reader.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.StoredProcedure);
                    o.Name = reader.GetString(0);
                    if (reader[1] != DBNull.Value) o.Body = reader.GetString(1);
                    o.CreateTime = reader.GetDateTime(2);
                    o.LastAlteredTime = reader.GetDateTime(3);
                    l.Add(o);
                }
            }
            return l;
        }
        public virtual Boolean ExistStoredProcedure(String name)
        {
            var q = this.QueryBuilder;
            using (var db = this.CreateDatabase())
            {
                var dr = db.ExecuteReader(q.GetStoredProcedure(name));
                while (dr.Read())
                {
                    return true;
                }
            }
            return false;
        }
        public virtual StoredProcedure GetStoredProcedure(String name)
        {
            var sp = new StoredProcedure(this.DatabaseServer, name);
            
            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetStoredProcedure(name));
                if (reader.Read() == false) throw new InvalidOperationException(String.Format("Stored procedure {0} does not exist.", name));
                sp.Name = reader.GetString(0);
                if (reader[1] == DBNull.Value) sp.Body = reader.GetString(1).TrimStart();
                sp.CreateTime = reader.GetDateTime(2);
                sp.LastAlteredTime = reader.GetDateTime(3);
            }
            foreach (var parameter in this.GetParameters(name))
            {
                sp.Parameters.Add(parameter);
            }
            return sp;
        }
        public virtual List<SqlInputParameter> GetParameters(String storedProcedureName)
        {
            var l = new List<SqlInputParameter>();
            SqlInputParameter p = null;
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
                var reader = db.ExecuteReader(this.QueryBuilder.GetParameters(storedProcedureName));

                while (reader.Read())
                {
                    p = new SqlInputParameter();
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
                    if (reader[parameterLength] != DBNull.Value) p.Length = AppEnvironment.Settings.TypeConverter.ToInt32(reader[parameterLength]);
                    if (reader[parameterPrecision] != DBNull.Value) p.Precision = AppEnvironment.Settings.TypeConverter.ToInt32(reader[parameterPrecision]);
                    if (reader[parameterScale] != DBNull.Value) p.Scale = AppEnvironment.Settings.TypeConverter.ToInt32(reader[parameterScale]);
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
            }
            return l;
        }
        public abstract void SetResultSetsList(StoredProcedure sp, Dictionary<String, Object> values);

        public virtual List<DatabaseObject> GetStoredFunctions()
        {
            var l = new List<DatabaseObject>();

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetStoredFunctions());
                while (reader.Read())
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

        public virtual List<DatabaseObject> GetUserDefinedTableTypes()
        {
            throw new NotSupportedException();
        }
        public virtual UserDefinedTableType GetUserDefinedTableType(string name)
        {
            throw new NotSupportedException();
        }
        public virtual List<DataType> GetUserDefinedTableTypeColumns(string name)
        {
            throw new NotSupportedException();
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
        protected abstract Object GetParameterValue(DataType dataType, Object dbType);

        public abstract String GetDefinitionText(Table table);
    }
}
