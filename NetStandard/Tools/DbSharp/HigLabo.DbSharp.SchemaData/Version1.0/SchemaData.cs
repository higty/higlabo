using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class SchemaData
    {
        public String VersionNumber { get; set; }
        public DatabaseServer DatabaseServer { get; set; }
        public String NamespaceName { get; set; }
        public String DatabaseKey { get; set; }
        
        public ObservableCollection<Table> Tables { get; private set; }
        public ObservableCollection<StoredProcedure> StoredProcedures { get; private set; }
        public ObservableCollection<UserDefinedTableType> UserDefinedTableTypes { get; private set; }
        public ObservableCollection<DatabaseObject> IgnoreObjects { get; private set; }

        public DateTime LastExecuteTimeOfImportTable { get; set; }
        public DateTime LastExecuteTimeOfImportStoredProcedure { get; set; }
        public DateTime LastExecuteTimeOfImportUserDefinedTableType { get; set; }

        public SchemaData()
        {
            this.VersionNumber = "1.1";
            this.Tables = new ObservableCollection<Table>();
            this.StoredProcedures = new ObservableCollection<StoredProcedure>();
            this.UserDefinedTableTypes = new ObservableCollection<UserDefinedTableType>();
            this.IgnoreObjects = new ObservableCollection<DatabaseObject>();
        }
    }
}
