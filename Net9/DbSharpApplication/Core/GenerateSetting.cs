using CommunityToolkit.Mvvm.ComponentModel;
using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DbSharpApplication;

public partial class GenerateSetting : ObservableObject
{
    [ObservableProperty]
    public String name = "";
    [ObservableProperty]
    public String outputFolderPath = "";

    [ObservableProperty]
    public String connectionStringName = "";
    [ObservableProperty]
    public DatabaseServer databaseServer = DatabaseServer.SqlServer;
    [ObservableProperty]
    public String namespaceName = "";
    [ObservableProperty]
    public String databaseKey = "";

    public Visibility OpenOutputFolderButtonVisible
    {
        get { return this.OutputFolderPath.IsNullOrEmpty() ? Visibility.Hidden : Visibility.Visible; }
    }

    public ObservableCollection<StoredProcedure> StoredProcedureList { get; init; } = new();
    public ObservableCollection<UserDefinedTableType> UserDefinedTableType { get; init; } = new();

    public DatabaseSchemaReader CreateDatabaseSchemaReader(string connectionString)
    {
        switch (this.DatabaseServer)
        {
            case DatabaseServer.SqlServer: return new SqlServerDatabaseSchemaReader(connectionString);
            case DatabaseServer.Oracle: throw new NotImplementedException();
            case DatabaseServer.MySql: return new MySqlDatabaseSchemaReader(connectionString);
            case DatabaseServer.PostgreSql: throw new NotImplementedException();
            default: throw new InvalidOperationException();
        }
    }
}
