using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ImportTableCommand : ImportSchemaCommand
    {
        public List<String> Names { get; private set; }

        public ImportTableCommand(SchemaData schemaData, String connectionString)
            :base(schemaData, connectionString)
        {
            this.Names = new List<string>();
        }
        protected override void Execute()
        {
            DatabaseSchemaReader r = this.DatabaseSchemaReader;
            var names = this.Names;
            var totalCount = names.Count;
            var tt = new List<Table>();
            var ss = new List<StoredProcedure>();

            for (int i = 0; i < totalCount; i++)
            {
                var name = names[i];
                var t = r.GetTable(name);

                var tExisted = this.SchemaData.Tables.FirstOrDefault(el => el.Name == t.Name);
                if (tExisted == null)
                {
                    tt.Add(t);
                }
                else
                {
                    foreach (var parameter in t.Columns)
                    {
                        var p = tExisted.Columns.Find(el => el.Name == parameter.Name);
                        if (p == null) { continue; }
                        parameter.EnumName = p.EnumName;
                        parameter.EnumValues = p.EnumValues;
                    }
                    tt.Add(t);
                }
                //CRUD用のストアドをDBに追加
                ss.AddRange(this.AddStoredProcedure(t));
                this.OnProcessProgress(new ProcessProgressEventArgs(t.Name, i / totalCount));
            }
            //スキーマファイルに追加
            this.AddOrReplace(this.SchemaData.Tables, tt, (item, element) => item.Name == element.Name);
            this.AddOrReplace(this.SchemaData.StoredProcedures, ss, (item, element) => item.Name == element.Name);
            this.SchemaData.LastExecuteTimeOfImportTable = DateTime.Now;
        }
        public List<StoredProcedure> AddStoredProcedure(Table table)
        {
            var f = TableStoredProcedureFactory.Create(this.DatabaseSchemaReader);
            return f.CreateTableStoredProcedures(table);
        }
    }
}
