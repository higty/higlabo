using HigLabo.LanguageTextApplication;
using LanguageTextApplication.Core;
using System;
using System.IO;
using System.Windows;
using T = HigLabo.Core.LanguageText<HigLabo.Core.HigLaboText>;

namespace LanguageTextApplication;

public partial class MainWindow : Window
{
    public HigLabo.Core.ObservableCollection<ClassGenerateCommand.ExecutedEventArgs> LogList { get; init; } = new();

    public MainWindow()
    {
        InitializeComponent();

        ConfigData.Current = ConfigData.Load();
        this.FolderListView.ItemsSource = ConfigData.Current.FolderList;
        this.LogListView.ItemsSource = this.LogList;

        this.Closing += MainWindow_Closing;

        this.AddButton.Content = T.Text.Add;
        this.DeleteButton.Content = T.Text.Delete;
        this.ExecuteButton.Content = T.Text.Execute + "(_E)";
        this.ShowSettingPanelButton.Content = T.Text.Close + "(_C)";
    }

    private void UpdateFolderListView()
    {
        this.FolderListView.ItemsSource = null;
        this.FolderListView.ItemsSource = ConfigData.Current.FolderList;
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var setting = new FolderSetting();
        setting.SourceFolderPath = Environment.CurrentDirectory;
        ConfigData.Current.FolderList.Add(setting);
        this.FolderListView.SelectedItem = setting;
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var c = this.FolderListView.SelectedItem as FolderSetting;
        if (c == null)
        {
            MessageBox.Show(T.Text.PleaseSelect);
            return;
        }
        if (MessageBox.Show(T.Text.ConfirmDelete, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            ConfigData.Current.FolderList.Remove(c);
            this.UpdateFolderListView();
        }
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
        var c = this.FolderListView.SelectedItem as FolderSetting;
        if (c == null)
        {
            MessageBox.Show(T.Text.PleaseSelect);
            return;
        }

        if (c.CSharpFileName.Contains("\\") ||
            c.CSharpFileName.Contains("/"))
        {
            MessageBox.Show("C# file name must not contain \\ and /.");
            return;
        }

        this.SettingPanel.Visibility = Visibility.Hidden;
        this.LogPanel.Visibility = Visibility.Visible;

        this.LogList.Clear();
        var cm = new ClassGenerateCommand(c);
        cm.Executed += ClassGenerateCommand_Executed;
        App.BackgroundService.AddCommand(cm);
    }
    private void ShowSettingPanelButton_Click(object sender, RoutedEventArgs e)
    {
        this.SettingPanel.Visibility = Visibility.Visible;
        this.LogPanel.Visibility = Visibility.Hidden;
    }

    private void ClassGenerateCommand_Executed(object? sender, ClassGenerateCommand.ExecutedEventArgs e)
    {
        this.Dispatcher.BeginInvoke(() =>
        {
            this.LogList.Add(e);
            if(this.LogList.Count > 10000)
            {
                this.LogList.RemoveAt(0);
            }
            this.LogListView.ScrollIntoView(e);
        });
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        ConfigData.Current.Save();
    }
}
