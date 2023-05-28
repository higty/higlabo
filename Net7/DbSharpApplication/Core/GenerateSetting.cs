using CommunityToolkit.Mvvm.ComponentModel;
using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public Visibility OpenOutputFolderButtonVisible
        {
            get { return this.outputFolderPath.IsNullOrEmpty() ? Visibility.Hidden : Visibility.Visible; }
        }

        public ObservableCollection<StoredProcedure> StoredProcedureList { get; init; } = new();
        public ObservableCollection<UserDefinedTableType> UserDefinedTableType { get; init; } = new();

        public DatabaseSchemaReader CreateDatabaseSchemaReader()
        {
            switch (this.databaseServer)
            {
                case DatabaseServer.SqlServer: return new SqlServerDatabaseSchemaReader(this.connectionString);
                case DatabaseServer.Oracle: throw new NotImplementedException();
                case DatabaseServer.MySql: return new MySqlDatabaseSchemaReader(this.connectionString);
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
    }
}
