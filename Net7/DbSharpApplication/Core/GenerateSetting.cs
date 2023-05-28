using CommunityToolkit.Mvvm.ComponentModel;
using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSharpApplication
{
    [ObservableObject]
    public partial class GenerateSetting
    {
        [ObservableProperty]
        public String name = "";
        [ObservableProperty]
        public String connectionString = "";
        [ObservableProperty]
        public String outputFolderPath = "";

        [ObservableProperty]
        public DatabaseServer databaseServer = DatabaseServer.SqlServer;
        [ObservableProperty]
        public String namespaceName = "";
        [ObservableProperty]
        public String databaseKey = "";

        public ObservableCollection<StoredProcedure> StoredProcedureList { get; init; } = new();
        public ObservableCollection<UserDefinedTableType> UserDefinedTableType { get; init; } = new();

        public DatabaseSchemaReader CreateDatabaseSchemaReader()
        {
            switch (this.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return new SqlServerDatabaseSchemaReader(this.ConnectionString);
                case DatabaseServer.Oracle: throw new NotImplementedException();
                case DatabaseServer.MySql: return new MySqlDatabaseSchemaReader(this.ConnectionString);
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
    }
}
