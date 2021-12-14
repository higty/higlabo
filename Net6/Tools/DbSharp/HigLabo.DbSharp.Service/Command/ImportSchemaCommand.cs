using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public abstract class ImportSchemaCommand : DbSharpCommand
    {
        public DatabaseSchemaReader DatabaseSchemaReader { get; private set; }
        protected SchemaData SchemaData { get; set; }

        public ImportSchemaCommand(SchemaData schemaData, String connectionString)
        {
            this.SchemaData = schemaData;
            this.DatabaseSchemaReader = ImportSchemaCommand.CreateDatabaseSchemaReader(schemaData.DatabaseServer, connectionString);
        }
        protected void AddOrReplace<T>(ICollection<T> source, ICollection<T> newCollection, Func<T, T, Boolean> equalityFunc)
        {
            foreach (var item in newCollection)
            {
                var itemExist = source.FirstOrDefault(el => equalityFunc(item, el));
                if (itemExist != null)
                {
                    source.Remove(itemExist);
                }
                source.Add(item);
            }
        }

        public static DatabaseSchemaReader CreateDatabaseSchemaReader(DatabaseServer databaseServer, String connectionString)
        {
            switch (databaseServer)
            {
                case DatabaseServer.SqlServer: return new SqlServerDatabaseSchemaReader(connectionString);
                case DatabaseServer.Oracle: throw new NotImplementedException();
                case DatabaseServer.MySql: return new MySqlDatabaseSchemaReader(connectionString);
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        public static TableStoredProcedureFactory CreateTableStoredProcedureFactory(DatabaseSchemaReader reader)
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
        public static TableStoredProcedureFactory CreateTableStoredProcedureFactory(DatabaseServer server, String connectionString)
        {
            var r = CreateDatabaseSchemaReader(server, connectionString);
            return CreateTableStoredProcedureFactory(r);
        }
    }
}
