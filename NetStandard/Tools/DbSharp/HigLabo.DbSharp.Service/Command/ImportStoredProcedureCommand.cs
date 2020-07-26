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
        public Boolean DisableForeignKey { get; set; } = false;

        public ImportStoredProcedureCommand(SchemaData schemaData, String connectionString)
            : base(schemaData, connectionString)
        {
            this.Names = new List<string>();
        }
        protected override void Execute()
        {
            var db = this.DatabaseSchemaReader.CreateDatabase();
            try
            {
                if (this.DisableForeignKey)
                {
                    this.OnProcessProgress(new ProcessProgressEventArgs("Disable ForeignKey...", 0));
                    db.ExecuteCommand("EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");
                }
                this.Import();
            }
            finally
            {
                if (this.DisableForeignKey)
                {
                    this.OnProcessProgress(new ProcessProgressEventArgs("Enable ForeignKey...", 100));
                    db.ExecuteCommand("EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
                    this.OnProcessProgress(new ProcessProgressEventArgs("Enable ForeignKey completed", 100));
                }
            }

        }
        private void Import()
        {
            var r = this.DatabaseSchemaReader;
            var names = this.Names;
            var totalCount = names.Count;
            var ss = new List<MetaData.StoredProcedure>();

            for (int i = 0; i < totalCount; i++)
            {
                var name = names[i];
                var spExisted = this.SchemaData.StoredProcedures.FirstOrDefault(el => el.Name == name);
                var sp = r.GetStoredProcedure(name);
                var d = new Dictionary<String, Object>();

                if (spExisted == null)
                {
                    r.SetResultSetsList(sp, d);
                    ss.Add(sp);
                }
                else
                {
                    if (spExisted.StoredProcedureType == StoredProcedureType.Custom ||
                        spExisted.StoredProcedureType == StoredProcedureType.SelectAll ||
                        spExisted.StoredProcedureType == StoredProcedureType.SelectByPrimaryKey)
                    {
                        r.SetResultSetsList(sp, d);
                    }
                    sp.TableName = spExisted.TableName;
                    sp.StoredProcedureType = spExisted.StoredProcedureType;

                    if (spExisted.StoredProcedureType == StoredProcedureType.Custom)
                    {
                        d = spExisted.Parameters.Where(el => String.IsNullOrEmpty(el.ValueForTest) == false)
                            .ToDictionary(el => el.Name, el => el.ValueForTest as Object);
                        foreach (var parameter in sp.Parameters)
                        {
                            var p = spExisted.Parameters.Find(el => el.Name == parameter.Name);
                            if (p == null) { continue; }
                            parameter.AllowNull = p.AllowNull;
                            parameter.EnumName = p.EnumName;
                            parameter.EnumValues = p.EnumValues;
                            parameter.ValueForTest = p.ValueForTest;
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
                    else
                    {
                        var t = SchemaData.Tables.FirstOrDefault(el => el.Name == sp.TableName);
                        if (t != null)
                        {
                            foreach (var parameter in sp.Parameters)
                            {
                                var pName = parameter.GetNameWithoutAtmark().Replace("PK_", "");
                                var p = t.Columns.Find(el => el.Name == pName);
                                if (p == null) { continue; }
                                parameter.AllowNull = p.AllowNull;
                                parameter.EnumName = p.EnumName;
                                parameter.EnumValues = p.EnumValues;
                            }
                            foreach (var resultSets in sp.ResultSets)
                            {

                                resultSets.TableName = t.Name;
                                foreach (var column in resultSets.Columns)
                                {
                                    var c = t.Columns.Find(el => el.Name == column.Name);
                                    if (c == null) { continue; }
                                    column.AllowNull = c.AllowNull;
                                    column.EnumName = c.EnumName;
                                    column.EnumValues = c.EnumValues;
                                }
                            }
                        }

                        if (spExisted.LastAlteredTime < sp.LastAlteredTime)
                        {
                            ss.Add(sp);
                        }
                    }
                }
                this.OnProcessProgress(new ProcessProgressEventArgs(name, i / totalCount));
            }
            //スキーマファイルに追加
            this.AddOrReplace(this.SchemaData.StoredProcedures, ss, (item, element) => item.Name == element.Name);
            this.SchemaData.LastExecuteTimeOfImportStoredProcedure = DateTime.Now;

        }
    }
}
