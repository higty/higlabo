using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class DeleteObjectCommandService : CommandService
    {
        private SchemaData _SchemaData = null;

        public DeleteObjectCommandService(String outputDirectoryPath
            , SchemaData schemaData
            , String connectionString
            , IEnumerable<String> tableNames
            , IEnumerable<String> storedProcedureNames
            , IEnumerable<String> userDefinedTableTypeNames)

        {
            this._SchemaData = schemaData;
            var sc = this._SchemaData;

            var cm = new DeleteObjectCommand(outputDirectoryPath, sc, connectionString);
            cm.TableNames.AddRange(tableNames);
            cm.StoredProcedures.AddRange(storedProcedureNames);
            cm.UserDefinedTableTypes.AddRange(userDefinedTableTypeNames);

            this.Commands.Add(cm);
        }
    }
}
