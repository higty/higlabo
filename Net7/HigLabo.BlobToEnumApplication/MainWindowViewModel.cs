using CommunityToolkit.Mvvm.ComponentModel;
using HigLabo.Core;
using HigLabo.LanguageTextApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlobToEnumApplication
{
    public enum MainWindowDisplayMode
    {
        List,
        Edit,
        Generating,
    }
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        [ObservableProperty]
        public MainWindowDisplayMode displayMode = MainWindowDisplayMode.List;
        [ObservableProperty]
        public Visibility blobContainerListViewVisible = Visibility.Visible;
        [ObservableProperty]
        public Visibility editPanelVisible = Visibility.Hidden;
        [ObservableProperty]
        public Visibility generatingLogVisible = Visibility.Hidden;

        public ObservableCollection<ClassGenerateCommand.ExecutedEventArgs> GenerateLogList { get; init; } = new();
        [ObservableProperty]
        public double progressPercentage = 0;
        [ObservableProperty]
        public string progressPercentageText = "";

        public void SetDisplayMode(MainWindowDisplayMode displayMode)
        {
            this.DisplayMode = displayMode;
            this.BlobContainerListViewVisible = this.DisplayMode == MainWindowDisplayMode.List ? Visibility.Visible : Visibility.Hidden;
            this.EditPanelVisible = this.DisplayMode == MainWindowDisplayMode.Edit ? Visibility.Visible : Visibility.Hidden;
            this.GeneratingLogVisible = this.DisplayMode == MainWindowDisplayMode.Generating ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
