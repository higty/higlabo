using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ImportStoredProcedureCommand : ImportSchemaCommand
    {
        public List<String> Names { get; private set; }

        public ImportStoredProcedureCommand(SchemaData schemaData, String connectionString)
            : base(schemaData, connectionString)
        {
            this.Names = new List<string>();
        }
        protected override void Execute()
        {
            var r = this.DatabaseSchemaReader;
            var names = this.Names;
            var totalCount = names.Count;
            var ss = new List<StoredProcedure>();

            for (int i = 0; i < totalCount; i++)
            {
                var name = names[i];
                var spExisted = this.SchemaData.StoredProcedures.FirstOrDefault(el => el.Name == name);
                var sp = r.GetStoredProcedure(name);

                if (spExisted == null)
                {
                    ss.Add(sp);
                }
                else if (spExisted.StoredProcedureType == StoredProcedureType.Custom)
                {
                    sp.TableName = spExisted.TableName;
                    sp.StoredProcedureType = spExisted.StoredProcedureType;
                    foreach (var parameter in sp.Parameters)
                    {
                        var p = spExisted.Parameters.Find(el => el.Name == parameter.Name);
                        if (p == null) { continue; }
                        parameter.AllowNull = p.AllowNull;
                        parameter.EnumName = p.EnumName;
                        parameter.EnumValues = p.EnumValues;
                    }
                    Int32 index = -1;
                    foreach (var resultSets in sp.ResultSets)
                    {
                        index += 1;
                        if (index == sp.ResultSets.Count) { continue; }
                        if (index >= spExisted.ResultSets.Count) { continue; }
                        var resultSetsExisted = spExisted.ResultSets[index];
                        resultSets.Name = resultSetsExisted.Name;
                        resultSets.TableName = resultSetsExisted.TableName;
                        foreach (var column in resultSets.Columns)
                        {
                            var c = resultSetsExisted.Columns.Find(el => el.Name == column.Name);
                            if (c == null) { continue; }
                            column.AllowNull = c.AllowNull;
                            column.EnumName = c.EnumName;
                            column.EnumValues = c.EnumValues;
                        }
                    }
                    ss.Add(sp);
                }
                else if (spExisted.LastAlteredTime < sp.LastAlteredTime)
                {
                    ss.Add(sp);
                }
                this.OnProcessProgress(new ProcessProgressEventArgs(name, i / totalCount));
            }
            //スキーマファイルに追加
            this.AddOrReplace(this.SchemaData.StoredProcedures, ss, (item, element) => item.Name == element.Name);
            this.SchemaData.LastExecuteTimeOfImportStoredProcedure = DateTime.Now;
        }
    }
}
