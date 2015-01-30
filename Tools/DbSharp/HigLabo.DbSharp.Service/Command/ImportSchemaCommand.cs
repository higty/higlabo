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
            this.DatabaseSchemaReader = DatabaseSchemaReader.Create(schemaData.DatabaseServer, connectionString);
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
    }
}
