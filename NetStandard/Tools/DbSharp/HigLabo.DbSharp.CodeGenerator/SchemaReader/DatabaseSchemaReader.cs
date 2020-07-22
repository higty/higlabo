using HigLabo.Core;
using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
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
            foreach (var column in this.GetColumns(name))
            {
                t.Columns.Add(column);
            }
            return t;
        }
        public virtual List<Column> GetColumns(String tableName)
        {
            var l = new List<Column>();
            Column c = null;
            Int32 name = 1;
            Int32 IsPrimaryKey = 2;
            Int32 dbType = 3;
            Int32 columnLength = 4;
            Int32 columnPrecision = 5;
            Int32 columnScale = 6;
            Int32 allowNull = 7;
            Int32 IsIdentity = 8;
            Int32 IsRowGuidCol = 9;
            Int32 udtTypeName = 10;
            Int32 enumValues = 11;

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetColumns(tableName));

                while (reader.Read())
                {
                    c = new Column();
                    c.Name = reader.GetString(name);
                    c.Ordinal = l.Count;
                    c.IsPrimaryKey = reader.GetBoolean(IsPrimaryKey);
                    c.DbType = this.CreateDbType(reader[dbType]);
                    c.UdtTypeName = reader.GetString(udtTypeName);//UdtTypeName
                    if (reader[columnLength] != DBNull.Value) c.Length = AppEnvironment.Settings.TypeConverter.ToInt32(reader[columnLength]);
                    if (reader[columnPrecision] != DBNull.Value) c.Precision = AppEnvironment.Settings.TypeConverter.ToInt32(reader[columnPrecision]);
                    if (reader[columnScale] != DBNull.Value) c.Scale = AppEnvironment.Settings.TypeConverter.ToInt32(reader[columnScale]);
                    c.AllowNull = reader.GetBoolean(allowNull);
                    c.IsIdentity = reader.GetBoolean(IsIdentity);
                    c.IsRowGuidCol = reader.GetBoolean(IsRowGuidCol);
                    if (reader[enumValues] != DBNull.Value) c.EnumValues = reader.GetString(enumValues);

                    l.Add(c);
                }
            }
            return l;
        }
        public virtual List<DatabaseObject> GetStoredProcedures()
        {
            var l = new List<DatabaseObject>();
            Int32 storedProcedureName = 0;
            Int32 body = 1;
            Int32 createTime = 2;
            Int32 lastAlteredTime = 3;

            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetStoredProcedures());
                while (reader.Read())
                {
                    var o = new DatabaseObject(DatabaseObjectType.StoredProcedure);
                    o.Name = reader.GetString(storedProcedureName);
                    o.Body = reader.GetString(body);
                    o.CreateTime = reader.GetDateTime(createTime);
                    o.LastAlteredTime = reader.GetDateTime(lastAlteredTime);
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
            Int32 storedProcedureName = 0;
            Int32 body = 1;
            Int32 createTime = 2;
            Int32 lastAlteredTime = 3;
            
            using (Database db = this.CreateDatabase())
            {
                var reader = db.ExecuteReader(this.QueryBuilder.GetStoredProcedure(name));
                if (reader.Read() == false) throw new InvalidOperationException(String.Format("Stored procedure {0} does not exist.", name));
                sp.Name = reader.GetString(storedProcedureName);
                sp.Body = reader.GetString(body).TrimStart();
                sp.CreateTime = reader.GetDateTime(createTime);
                sp.LastAlteredTime = reader.GetDateTime(lastAlteredTime);
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
    }
}
