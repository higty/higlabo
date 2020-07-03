using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.DbSharp.Service
{
    public class ImportObjectGenerateFileCommandService : CommandService
    {
        private SchemaData _SchemaData = null;
        public Boolean ImportAllObject { get; set; }
        public Boolean DeleteExistedFiles { get; set; }

        public ImportObjectGenerateFileCommandService(SchemaData schemaData)
        {
            _SchemaData = schemaData;
            this.ImportAllObject = false;
            this.DeleteExistedFiles = false;
        }
        public void LoadCommand(String connectionString, String outputDirectoryPath, String namespaceName, String databaseKey)
        {
            this.Commands.Clear();

            var sv = this;
            var sc = _SchemaData;
            sc.NamespaceName = namespaceName;
            sc.DatabaseKey = databaseKey;

            DatabaseSchemaReader db = DatabaseSchemaReader.Create(sc.DatabaseServer, connectionString);

            var tt = db.GetTables();
            var ss = db.GetStoredProcedures();
            var uu = db.GetUserDefinedTableTypes();

            {
                var cm = new ImportTableCommand(sc, connectionString);
                cm.Names.AddRange(tt.Where(el => this.ImportAllObject == true || el.LastAlteredTime > sc.LastExecuteTimeOfImportTable).Select(el => el.Name));
                cm.Names.RemoveAll(name => sc.IgnoreObjects.Exists(el => el.Name == name));
                sv.Commands.Add(cm);
            }
            {
                var cm = new ImportStoredProcedureCommand(sc, connectionString);
                cm.Names.AddRange(ss.Where(el => this.ImportAllObject == true || el.LastAlteredTime > sc.LastExecuteTimeOfImportStoredProcedure).Select(el => el.Name));
                cm.Names.RemoveAll(name => sc.IgnoreObjects.Exists(el => el.Name == name));
                sv.Commands.Add(cm);
            }
            {
                var cm = new ImportUserDefinedTableTypeCommand(sc, connectionString);
                cm.Names.AddRange(uu.Where(el => this.ImportAllObject == true || el.LastAlteredTime > sc.LastExecuteTimeOfImportUserDefinedTableType).Select(el => el.Name));
                cm.Names.RemoveAll(name => sc.IgnoreObjects.Exists(el => el.Name == name));
                sv.Commands.Add(cm);
            }

            {
                var cm = new DeleteObjectCommand(outputDirectoryPath, sc, connectionString);
                cm.Started += (o, ea) =>
                {
                    var tNames = db.GetTables().Select(el => el.Name).ToList();
                    var sNames = db.GetStoredProcedures().Select(el => el.Name).ToList();
                    var uNames = db.GetUserDefinedTableTypes().Select(el => el.Name).ToList();
                    cm.TableNames.AddRange(sc.Tables.Where(el => tNames.Contains(el.Name) == false).Select(el => el.Name));
                    cm.StoredProcedures.AddRange(sc.StoredProcedures.Where(el => sNames.Contains(el.Name) == false).Select(el => el.Name));
                    cm.UserDefinedTableTypes.AddRange(sc.UserDefinedTableTypes.Where(el => uNames.Contains(el.Name) == false).Select(el => el.Name));
                };
                sv.Commands.Add(cm);
            }

            {
                var cm = new GenerateSourceCodeCommand(outputDirectoryPath, sc);
                cm.Started += (o, ea) =>
                {
                    cm.Tables.AddRange(sc.Tables);
                    cm.StoredProcedures.AddRange(sc.StoredProcedures);
                    cm.UserDefinedTableTypes.AddRange(sc.UserDefinedTableTypes);
                };
                sv.Commands.Add(cm);
            }
        }
    }
}
