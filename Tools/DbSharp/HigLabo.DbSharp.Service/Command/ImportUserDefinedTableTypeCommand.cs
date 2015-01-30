using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ImportUserDefinedTableTypeCommand : ImportSchemaCommand
    {
        public List<String> Names { get; private set; }

        public ImportUserDefinedTableTypeCommand(SchemaData schemaData, String connectionString)
            : base(schemaData, connectionString)
        {
            this.Names = new List<string>();
        }
        protected override void Execute()
        {
            var r = this.DatabaseSchemaReader;
            var names = this.Names;
            var totalCount = names.Count;
            var uu = new List<UserDefinedTableType>();

            for (int i = 0; i < totalCount; i++)
            {
                var name = names[i];
                var st = r.GetUserDefinedTableType(name);

                var stExisted = this.SchemaData.UserDefinedTableTypes.FirstOrDefault(el => el.Name == st.Name);
                if (stExisted == null)
                {
                    uu.Add(st);
                }
                else
                {
                    foreach (var column in st.Columns)
                    {
                        var p = stExisted.Columns.Find(el => el.Name == column.Name);
                        if (p == null) { continue; }
                        column.AllowNull = p.AllowNull;
                        column.EnumName = p.EnumName;
                    }
                    uu.Add(st);
                }
                this.OnProcessProgress(new ProcessProgressEventArgs(st.Name, i / totalCount));
            }
            //スキーマファイルに追加
            this.AddOrReplace(this.SchemaData.UserDefinedTableTypes, uu, (item, element) => item.Name == element.Name);
            this.SchemaData.LastExecuteTimeOfImportUserDefinedTableType = DateTime.Now;
        }
    }
}
