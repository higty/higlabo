using DbSharpApplication;
using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static DbSharpApplication.ConfigData;

namespace DbSharpApplication;
/// <summary>
/// MainWindow2025.xaml の相互作用ロジック
/// </summary>
public partial class MainWindow2025 : Window
{
    public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();

    public MainWindow2025()
    {
        InitializeComponent();
   
        this.DataContext = this.ViewModel;

        ConfigData.Load();
        ConfigData.Current.EnsureFileExists();

        this.EditPanel.Visibility = Visibility.Hidden;

        this.SetBinding();
        this.SetText();

        ConfigData.Current.MainWindow.Initialize(this);
        switch (ConfigData.Current.MainWindow.SelectedTab)
        {
            case "SettingTab": this.SettingTab.IsSelected = true; break;
            case "ConnectionStringTab": this.ConnectionStringTab.IsSelected = true; break;
            case "PlaygroundTab": this.PlaygroundTab.IsSelected = true; break;
            default: break;
        }
        this.Closing += MainWindow_Closing;
    }
    private void SetBinding()
    {
        this.SchemeFilePath.Content = ConfigData.Current.SchemeFilePath;
        this.SetRecentFilesBinding();

        this.LanguageListComboBox.ItemsSource = this.ViewModel.LanguageList;
        this.LanguageListComboBox.SelectedItem = this.ViewModel.LanguageList.FirstOrDefault(el => el.Name == CultureInfo.CurrentCulture.Name);
        this.LanguageListComboBox.SelectionChanged += LanguageListComboBox_SelectionChanged;

        this.ConnectionStringListView.ItemsSource = null;
        this.ConnectionStringListView.ItemsSource = ConfigData.Current.ConnectionStringList;
        this.ConnectionStringListView.SelectionChanged += ConnectionStringListView_SelectionChanged;
        this.GenerateSettingListView.ItemsSource = SchemeData.Current.GenerateSettingList;

        this.DatabaseServerComboBox.ItemsSource = null;
        this.DatabaseServerComboBox.ItemsSource = this.ViewModel.DatabaseServerList;
        this.DatabaseServerComboBox.SelectedItem = this.ViewModel.DatabaseServerList[0];

        this.GenerateSettingListView.SelectionChanged += GenerateSettingListView_SelectionChanged;
        this.GenerateSettingListView.ItemsSource = SchemeData.Current.GenerateSettingList;

        this.ConnectionStringListComboBox.ItemsSource = null;
        this.ConnectionStringListComboBox.ItemsSource = ConfigData.Current.ConnectionStringList;
        this.ConnectionStringListComboBox.SelectionChanged += ConnectionStringListComboBox_SelectionChanged;

        this.GeneratePanel.Visibility = Visibility.Hidden;

        this.DatabaseObjectListView.ItemsSource = this.ViewModel.DatabaseObjectList;
        this.DatabaseObjectListView.MouseDoubleClick += DatabaseObjectListView_MouseDoubleClick;
        var cView = CollectionViewSource.GetDefaultView(this.ViewModel.DatabaseObjectList);
        cView.Filter = this.FilterDatabaseObject;
        this.FilterObjectTextBox.TextChanged += FilterObjectTextBox_TextChanged;
    }
    private void SetRecentFilesBinding()
    {
        this.m0003.ItemsSource = ConfigData.Current.SchemeFilePathList.Select(x => new FilePathInfo { FilePath = x });
    }
    private void SetText()
    {
        this.m0000.Header = T.Text.Get("Scheme _File", "スキーマファイル(_F)");
        this.m0001.Header = T.Text.Get("_New Scheme File","新規作成(_N)");
        this.m0002.Header = T.Text.Get("_Open Scheme File", "開く(_O)");
        this.m0003.Header = T.Text.Get("_Recent Scheme Files", "最近使用したファイル(_R)");
        this.m0004.Header = T.Text.Get("_Save", "保存(_S)");
        this.m0005.Header = T.Text.Get("Save _As", "名前を付けて保存(_A)");
        this.m0006.Header = T.Text.Get("E_xit", "終了(_X)");

        this.SettingTab.Header = T.Text.Settings;
        this.ConnectionStringTab.Header = T.Text.ConnectionString;

        this.ConfigFilePathLabel.Content = T.Text.Get("Config file path", "設定ファイルのパス");
        this.ConfigFilePath.Content = ConfigData.SettingFilePath;
        this.SchemeFilePathLabel.Content = T.Text.Get("Scheme file path", "スキーマファイルのパス");

        this.ConnectionStringListLabel.Content = T.Text.ConnectionString;
        this.ConnectionStringLabel.Content = T.Text.ConnectionString;
        this.AddConnectionStringButton.Content = T.Text.Add;
        this.DeleteConnectionStringButton.Content = T.Text.Delete;

        this.AddSettingButton.Content = T.Text.Add;
        this.DeleteSettingButton.Content = T.Text.Delete;

        this.GenerateSettingLabel.Content = T.Text.Get("Generate Settings", "生成の設定");
        this.LoadStoredProcedureButton.Content = T.Text.LoadStoredProcedure + "(_S)";
        this.LoadUserDefinedTypeButton.Content = T.Text.LoadUserDefinedType + "(_U)";
        this.GenerateDefinitionButton.Content = T.Text.GenerateDefinition + "(_D)";
        this.OpenOutputFolderButton.Content = T.Text.OpenOutputFolder + "(_F)";
        this.GenerateButton.Content = T.Text.Generate + "(_G)";
    }

    private void m0001_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dlg = new SaveFileDialog();

        dlg.Filter = ConfigData.DialogFilter;
        if (dlg.ShowDialog() == true)
        {
            this.SaveSchemaFile(dlg.FileName);
        }
        this.SetBinding();
    }
    private void m0002_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.DefaultExt = ".xml";
        if (dlg.ShowDialog() == true)
        {
            this.OpenSchemaFile(dlg.FileName);
        }
    }
    private void OpenSchemaFile(String filePath)
    {
        ConfigData.Current.SchemeFilePath = filePath;
        ConfigData.Current.SchemeFilePathList.AddIfNotExist(ConfigData.Current.SchemeFilePath);
        ConfigData.Current.LoadSchemeFile(ConfigData.Current.SchemeFilePath);
        this.SetBinding();
    }
    private void m0003_Click(object sender, RoutedEventArgs e)
    {
        var fi = ((MenuItem)e.OriginalSource).DataContext as FilePathInfo;
        if (fi == null) { return; }
        var path = fi.FilePath;

        if (String.IsNullOrEmpty(path) == true || File.Exists(path) == false)
        {
            MessageBox.Show("File not found. Path=" + path);
            ConfigData.Current.SchemeFilePathList.Remove(path);
            this.SetRecentFilesBinding();
            return;
        }
        this.OpenSchemaFile(path);
    }
    private void m0004_Click(object sender, RoutedEventArgs e)
    {
        ConfigData.Current.Save();
    }
    private void m0005_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dlg = new SaveFileDialog();

        dlg.Filter = ConfigData.DialogFilter;
        if (dlg.ShowDialog() == true)
        {
            this.SaveSchemaFile(dlg.FileName);
        }
    }
    private void SaveSchemaFile(String fileName)
    {
        ConfigData.Current.SchemeFilePath = fileName;
        ConfigData.Current.SchemeFilePathList.Add(fileName);
        ConfigData.Current.Save();
        this.SchemeFilePath.Content = ConfigData.Current.SchemeFilePath;
        this.SetRecentFilesBinding();
    }
    private void m0006_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = e.Uri.AbsoluteUri,
            UseShellExecute = true,
            WorkingDirectory = Environment.CurrentDirectory,
        };
        Process.Start(psi);
    }
    private void LanguageListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var language = this.LanguageListComboBox.SelectedItem as MainWindowViewModel.LanguageSetting;
        if (language == null) { return; }

        CultureInfo.CurrentCulture = new CultureInfo(language.Name);
        this.SetText();
    }

    private void ConnectionStringListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.ConnectionStringListView.SelectedItem == null)
        {
            this.EditPanel.Visibility = Visibility.Hidden;
        }
        else
        {
            this.EditPanel.Visibility = Visibility.Visible;
        }
    }
    private void AddConnectionStringButton_Click(object sender, RoutedEventArgs e)
    {
        var setting = new ConnectionStringSetting();
        setting.Name = "Connection 1";
        ConfigData.Current.ConnectionStringList.Add(setting);

        this.SetBinding();
    }
    private void DeleteConnectionStringButton_Click(object sender, RoutedEventArgs e)
    {
        var c = this.ConnectionStringListView.SelectedItem as ConnectionStringSetting;
        if (c == null) { return; }

        if (MessageBox.Show(T.Text.ConfirmDelete, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            ConfigData.Current.ConnectionStringList.Remove(c);
            this.SetBinding();
        }
    }

    private void AddSettingButton_Click(object sender, RoutedEventArgs e)
    {
        var c = new GenerateSetting();
        c.DatabaseServer = DatabaseServer.SqlServer;
        c.Name = "New Setting";
        SchemeData.Current.GenerateSettingList.Add(c);
    }
    private void DeleteSettingButton_Click(object sender, RoutedEventArgs e)
    {
        var c = this.GenerateSettingListView.SelectedItem as GenerateSetting;
        if (c == null) { return; }

        if (MessageBox.Show(T.Text.ConfirmDelete, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            SchemeData.Current.GenerateSettingList.Remove(c);
        }
    }

    private void ConnectionStringListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.ConnectionStringListComboBox.SelectedItem == null)
        {
            this.GeneratePanel.Visibility = Visibility.Hidden;
        }
        else
        {
            this.GeneratePanel.Visibility = Visibility.Visible;
        }
    }
    private ConfigData.ConnectionStringSetting? GetConnectionStringSetting()
    {
        return this.ConnectionStringListComboBox.SelectedValue as ConfigData.ConnectionStringSetting;
    }
    private DatabaseSchemaReader? GetDatabaseSchemaReader()
    {
        var setting = this.GetSelectedGenerateSetting();
        if (setting == null) { return null; }
        var c = this.GetConnectionStringSetting();
        if (c == null) { return null; }
        return setting.CreateDatabaseSchemaReader(c.ConnectionString);
    }

    private async void LoadStoredProcedureButton_Click(object sender, RoutedEventArgs e)
    {
        var reader = this.GetDatabaseSchemaReader();
        if (reader == null) { return; }
        this.ViewModel.DatabaseObjectList.Clear();

        try
        {
            var l = await reader.GetStoredProceduresAsync();
            foreach (var item in l.OrderByDescending(el => el.LastAlteredTime))
            {
                this.ViewModel.DatabaseObjectList.Add(item);
            }
            this.SaveConnectionStringName();
        }
        catch
        {
            MessageBox.Show(T.Text.ConnectionFailed);
        }
    }
    private void GenerateSettingListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        this.GeneratePanel.Visibility = Visibility.Hidden;
        var setting = this.GetSelectedGenerateSetting();
        if (setting != null)
        {
            this.ConnectionStringListComboBox.SelectedItem = ConfigData.Current.ConnectionStringList.Find(el => el.Name == setting.ConnectionStringName);
            this.GeneratePanel.Visibility = Visibility.Visible;
        }
        this.ViewModel.DatabaseObjectList.Clear();
    }
    private GenerateSetting? GetSelectedGenerateSetting()
    {
        return this.GenerateSettingListView.SelectedItem as GenerateSetting;
    }
    private async void LoadUserDefinedTypeButton_Click(object sender, RoutedEventArgs e)
    {
        var reader = this.GetDatabaseSchemaReader();
        if (reader == null) { return; }

        this.ViewModel.DatabaseObjectList.Clear();
        try
        {
            var l = await reader.GetUserDefinedTableTypesAsync();
            foreach (var item in l.OrderByDescending(el => el.LastAlteredTime))
            {
                this.ViewModel.DatabaseObjectList.Add(item);
            }
            this.SaveConnectionStringName();
        }
        catch
        {
            MessageBox.Show(T.Text.ConnectionFailed);
        }
    }
    private void GenerateDefinitionButton_Click(object sender, RoutedEventArgs e)
    {
        var c = this.GetConnectionStringSetting();
        if (c == null) { return; }
        var w = new DatabaseDefinitionWindow(c.ConnectionString);
        w.ShowDialog();

        this.SaveConnectionStringName();
    }
    private void OpenOutputFolderButton_Click(object sender, RoutedEventArgs e)
    {
        var setting = this.GetSelectedGenerateSetting();
        if (setting == null || setting.OutputFolderPath.IsNullOrEmpty()) { return; }
        try
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", $"/e,/root,\"{setting.OutputFolderPath}\"");
        }
        catch
        {
            MessageBox.Show($"Failed to open folder. Path is {setting.OutputFolderPath}");
        }
    }
    private void SaveConnectionStringName()
    {
        var setting = this.GetSelectedGenerateSetting();
        if (setting != null)
        {
            var c = this.GetConnectionStringSetting();
            setting.ConnectionStringName = c?.Name ?? "";
        }
    }

    private void FilterObjectTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var cView = CollectionViewSource.GetDefaultView(this.ViewModel.DatabaseObjectList);
        cView.Refresh();
    }
    private Boolean FilterDatabaseObject(object obj)
    {
        var o = (DatabaseObject)obj;
        if (this.FilterObjectTextBox.Text.IsNullOrEmpty()) { return true; }
        if (o.Name.Contains(this.FilterObjectTextBox.Text, StringComparison.OrdinalIgnoreCase)) { return true; }
        return false;
    }

    private async void DatabaseObjectListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        await this.OpenGenerateWindow();
    }
    private async void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        await this.OpenGenerateWindow();
    }
    private async Task OpenGenerateWindow()
    {
        var setting = this.GetSelectedGenerateSetting();
        if (setting == null) { return; }

        var o = this.DatabaseObjectListView.SelectedItem as DatabaseObject;
        if (o == null)
        {
            MessageBox.Show(T.Text.PleaseSelect);
            return;
        }

        var reader = this.GetDatabaseSchemaReader();
        if (reader == null) { return; }

        switch (o.ObjectType)
        {
            case DatabaseObjectType.StoredProcedure:
                {
                    var sp = await reader.GetStoredProcedureAsync(o.Name);
                    var w = new StoredProcedureWindow(new StoredProcedureWindowViewModel(reader.ConnectionString, setting, sp));
                    w.ShowDialog();
                    break;
                }
            case DatabaseObjectType.UserDefinedTableType:
                {
                    var u = await reader.GetUserDefinedTableTypeAsync(o.Name);
                    var w = new UserDefinedTableTypeWindow(new UserDefinedTableTypeWindowViewModel(setting, u));
                    w.ShowDialog();
                    break;
                }
            case DatabaseObjectType.Unknown:
            case DatabaseObjectType.Table:
            case DatabaseObjectType.View:
            case DatabaseObjectType.StoredFunction:
                throw new InvalidOperationException();
            default: throw SwitchStatementNotImplementException.Create(o.ObjectType);
        }
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        ConfigData.Current.Save();
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            var tabItem = tabControl.SelectedItem as TabItem;
            if (tabItem != null)
            {
                ConfigData.Current.MainWindow.SelectedTab = tabItem.Name ?? "";
            }
        }
    }
}
