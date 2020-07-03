using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class DeleteObjectCommand : ImportSchemaCommand
    {
        public String OutputDirectoryPath { get; set; }
        public Boolean DeleteExistedFiles { get; set; }
        public List<String> TableNames { get; private set; }
        public List<String> StoredProcedures { get; private set; }
        public List<String> UserDefinedTableTypes { get; private set; }

        public DeleteObjectCommand(String outputDirectoryPath, SchemaData schemaData, String connectionString)
            : base(schemaData, connectionString)
        {
            this.OutputDirectoryPath = outputDirectoryPath;
            this.DeleteExistedFiles = false;
            this.TableNames = new List<string>();
            this.StoredProcedures = new List<string>();
            this.UserDefinedTableTypes = new List<string>();
        }

        protected override void Execute()
        {
            var totalCount = this.TableNames.Count + this.StoredProcedures.Count + this.UserDefinedTableTypes.Count;
            Int32 removed = 0;

            var db = this.DatabaseSchemaReader;
            {
                foreach (var name in this.TableNames)
                {
                    var t = this.SchemaData.Tables.FirstOrDefault(el => el.Name == name);
                    if (t == null) { continue; }
                    this.SchemaData.Tables.Remove(t);

                    this.DeleteFile("Table", name);
                    this.DeleteFile("Table", name + ".Record");
                    this.DeleteFile("Table", name + ".IRecord");
                    this.OnProcessProgress(new ProcessProgressEventArgs(name + " removed", removed / totalCount));
                    removed++;
                }
            }
            {
                foreach (var name in this.StoredProcedures)
                {
                    var sp = this.SchemaData.StoredProcedures.FirstOrDefault(el => el.Name == name);
                    if (sp == null) { continue; }
                    this.SchemaData.StoredProcedures.Remove(sp);

                    this.DeleteFile("StoredProcedure", name);
                    this.DeleteFile("TableStoredProcedure", name);
                    this.OnProcessProgress(new ProcessProgressEventArgs(name + " removed", removed / totalCount)); 
                    removed++;
                }
            }
            {
                foreach (var name in this.UserDefinedTableTypes)
                {
                    var ut = this.SchemaData.UserDefinedTableTypes.FirstOrDefault(el => el.Name == name);
                    if (ut == null) { continue; }
                    this.SchemaData.UserDefinedTableTypes.Remove(ut);

                    this.DeleteFile("UserDefinedTableType", name);
                    this.OnProcessProgress(new ProcessProgressEventArgs(name + " removed", removed / totalCount));
                    removed++;
                }
            }
        }
        private void DeleteFile(String objectTypeName, String fileName)
        {
            String path = String.Format("{0}{1}\\{2}.cs", this.OutputDirectoryPath, objectTypeName, fileName);
            if (File.Exists(path) == true)
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }
        }
    }
}
