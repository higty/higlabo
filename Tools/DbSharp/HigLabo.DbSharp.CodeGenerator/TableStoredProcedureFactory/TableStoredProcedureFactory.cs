using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using HigLabo.DbSharp.MetaData;
using System.Data;

namespace HigLabo.DbSharp.CodeGenerator
{
    public abstract class TableStoredProcedureFactory
    {
        public abstract DatabaseServer DatabaseServer { get; }
        public DatabaseSchemaReader DatabaseSchemaReader { get; private set; }

        public TableStoredProcedureFactory(DatabaseSchemaReader reader)
        {
            this.DatabaseSchemaReader = reader;
        }
        public List<StoredProcedure> CreateTableStoredProcedures(Table table)
        {
            var l = new List<StoredProcedure>();
            var r = this.DatabaseSchemaReader;

            using (var db = r.CreateDatabase())
            {
                l.Add(this.CreateStoredProcedure(db, table, StoredProcedureType.SelectAll, this.CreateQueryOfTableNameSelectAll(table)));
                l.Add(this.CreateStoredProcedure(db, table, StoredProcedureType.Insert, this.CreateQueryOfTableNameInsert(table)));
                if (table.HasPrimaryKeyColumn() == true)
                {
                    l.Add(this.CreateStoredProcedure(db, table, StoredProcedureType.SelectByPrimaryKey, this.CreateQueryOfTableNameSelectByPrimaryKey(table)));
                    l.Add(this.CreateStoredProcedure(db, table, StoredProcedureType.Update, this.CreateQueryOfTableNameUpdate(table)));
                    l.Add(this.CreateStoredProcedure(db, table, StoredProcedureType.Delete, this.CreateQueryOfTableNameDelete(table)));
                }
            }
            return l;
        }
        private StoredProcedure CreateStoredProcedure(Database database, Table table, StoredProcedureType storedProcedureType, String query)
        {
            var r = this.DatabaseSchemaReader;
            var db = database;
            var storedProcedureName = table.Name + storedProcedureType.ToString();

            if (r.ExistStoredProcedure(storedProcedureName) == true)
            {
                db.ExecuteCommand("drop procedure " + storedProcedureName);
            }
            this.ExecuteCommand(db, query);
            return this.CreateStoredProcedure(storedProcedureName, storedProcedureType, query, table);
        }
        protected virtual void ExecuteCommand(Database database, String query)
        {
            database.ExecuteCommand(query);
        }
        private StoredProcedure CreateStoredProcedure(String name, StoredProcedureType storedProcedureType, String query, Table table)
        {
            var sp = new StoredProcedure();

            sp.DatabaseServer = this.DatabaseSchemaReader.DatabaseServer;
            sp.Name = name;
            sp.CreateTime = DateTime.Now;
            sp.LastAlteredTime = sp.CreateTime;
            sp.Body = query;

            sp.TableName = table.Name;
            sp.StoredProcedureType = storedProcedureType;
            if (storedProcedureType == StoredProcedureType.Insert ||
                storedProcedureType == StoredProcedureType.Update)
            {
                foreach (var c in table.GetColumns(null, true))
                {
                    var p = new SqlInputParameter("@" + c.Name, c);
                    if (c.IsServerAutomaticallyInsertValueColumn() == true)
                    {
                        p.ParameterDirection = ParameterDirection.InputOutput;
                    }
                    sp.Parameters.Add(p);
                }
            }
            if (storedProcedureType == StoredProcedureType.SelectByPrimaryKey)
            {
                foreach (var c in table.GetPrimaryKeyColumns())
                {
                    sp.Parameters.Add(new SqlInputParameter("@PK_" + c.Name, c));
                }
            }
            else if (storedProcedureType == StoredProcedureType.Update ||
                storedProcedureType == StoredProcedureType.Delete)
            {
                foreach (var c in table.GetPrimaryKeyOrTimestampColumns())
                {
                    sp.Parameters.Add(new SqlInputParameter("@PK_" + c.Name, c));
                }
            }
            if (storedProcedureType == StoredProcedureType.SelectAll ||
                storedProcedureType == StoredProcedureType.SelectByPrimaryKey)
            {
                sp.ResultSets.Add(new StoredProcedureResultSetColumn());
                var resultSets = sp.ResultSets[0];
                resultSets.TableName = table.Name;
                foreach (var c in table.GetColumns(null, true))
                {
                    resultSets.Columns.Add(new DataType(c.Name, c));
                }
            }
            return sp;
        }
        public abstract String CreateQueryOfTableNameSelectAll(Table table);
        public abstract String CreateQueryOfTableNameSelectByPrimaryKey(Table table);
        public abstract String CreateQueryOfTableNameInsert(Table table);
        public abstract String CreateQueryOfTableNameUpdate(Table table);
        public abstract String CreateQueryOfTableNameDelete(Table table);
        protected String CreateText<T>(IEnumerable<T> values, Func<T, String> selector, String separator, Boolean newLine)
        {
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;
            foreach (var item in values)
            {
                if (isFirst == false)
                {
                    sb.Append(separator);
                }
                sb.Append(selector(item));
                if (newLine == true)
                {
                    sb.AppendLine();
                }
                isFirst = false;
            }
            return sb.ToString();
        }

        public static TableStoredProcedureFactory Create(DatabaseSchemaReader reader)
        {
            var r = reader;
            switch (reader.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return new SqlServerTableStoredProcedureFactory(r);
                case DatabaseServer.MySql: return new MySqlTableStoredProcedureFactory(r);
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotSupportedException();
                default: throw new InvalidOperationException();
            }
        }
        public static TableStoredProcedureFactory Create(DatabaseServer server, String connectionString)
        {
            var r = DatabaseSchemaReader.Create(server, connectionString);
            return Create(r);
        }
    }
}
