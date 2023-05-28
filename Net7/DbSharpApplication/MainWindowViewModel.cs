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
    public enum MainWindowDisplayMode
    {
        Initialized,
        AddGenerateSetting,
        EditGenerateSetting,
        GenerateSettingSelected,
    }

    [ObservableObject]
    public partial class MainWindowViewModel
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
        public ObservableCollection<DatabaseObject> DatabaseObjectList { get; init; } = new();

        [ObservableProperty]
        public MainWindowDisplayMode displayMode = MainWindowDisplayMode.Initialized;
        [ObservableProperty]
        public Visibility addPanelVisible = Visibility.Hidden;
        [ObservableProperty]
        public Visibility generatePanelVisible = Visibility.Hidden;

        public MainWindowViewModel()
        {
            this.LanguageList.Add(new LanguageSetting("en-US"));
            this.LanguageList.Add(new LanguageSetting("ja-JP"));
        }

        public void SetDisplayMode(MainWindowDisplayMode displayMode)
        {
            this.DisplayMode = displayMode;
            this.AddPanelVisible = this.DisplayMode == MainWindowDisplayMode.AddGenerateSetting ? Visibility.Visible : Visibility.Hidden;
            this.GeneratePanelVisible = this.DisplayMode == MainWindowDisplayMode.GenerateSettingSelected ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
