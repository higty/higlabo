using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ImportObjectCommandService : CommandService
    {
        public String ConnectionString { get; private set; }

        private SchemaData _SchemaData = null;
        private List<String> _TableNames = new List<String>();
        private List<String> _StoredProcedureNames = new List<String>();
        private List<String> _UserDefinedTableTypeNames = new List<String>();

        public ImportObjectCommandService(SchemaData schemaData
            , String connectionString
            , IEnumerable<String> tableNames
            , IEnumerable<String> storedProcedureNames
            , IEnumerable<String> userDefinedTableTypeNames)
        {
            this._SchemaData = schemaData;
            this.ConnectionString = connectionString;
            this._TableNames.AddRange(tableNames);
            this._StoredProcedureNames.AddRange(storedProcedureNames);
            this._UserDefinedTableTypeNames.AddRange(userDefinedTableTypeNames);

            this.InitializeProperty();
        }
        private void InitializeProperty()
        {
            var sv = this;
            {
                var cm = new ImportTableCommand(this._SchemaData, this.ConnectionString);
                cm.Names.AddRange(_TableNames);
                sv.Commands.Add(cm);
            }
            {
                var cm = new ImportStoredProcedureCommand(this._SchemaData, this.ConnectionString);
                cm.Names.AddRange(_StoredProcedureNames);
                sv.Commands.Add(cm);
            }
            {
                var cm = new ImportUserDefinedTableTypeCommand(this._SchemaData, this.ConnectionString);
                cm.Names.AddRange(_UserDefinedTableTypeNames);
                sv.Commands.Add(cm);
            }
        }
    }
}
