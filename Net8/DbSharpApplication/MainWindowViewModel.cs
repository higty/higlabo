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


public partial class MainWindowViewModel : ObservableObject
{
    public class LanguageSetting
    {
        public String Name { get; set; } 
        public LanguageSetting(String name)
        {
            Name = name;
        }
    }
    public ObservableCollection<LanguageSetting> LanguageList { get; init; } = new();
    public ObservableCollection<DatabaseServer> DatabaseServerList { get; init; } = new();
    public ObservableCollection<DatabaseObject> DatabaseObjectList { get; init; } = new();

    [ObservableProperty]
    public Visibility generatePanelVisible = Visibility.Hidden;

    public MainWindowViewModel()
    {
        this.LanguageList.Add(new LanguageSetting("en-US"));
        this.LanguageList.Add(new LanguageSetting("ja-JP"));

        this.DatabaseServerList.Add(DatabaseServer.SqlServer);
        this.DatabaseServerList.Add(DatabaseServer.MySql);
    }
}
