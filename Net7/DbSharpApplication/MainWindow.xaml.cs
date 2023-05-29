using Google.Protobuf.WellKnownTypes;
using HigLabo.Core;
using HigLabo.Data;
using HigLabo.DbSharp.MetaData;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbSharpApplication
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.SetText();

            ConfigData.Current = ConfigData.Load();
            ConfigData.Current.EnsureFileExists();

            this.ViewModel = new MainWindowViewModel();
            this.DataContext = this.ViewModel;
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Initialized);

            this.LanguageListComboBox.ItemsSource = this.ViewModel.LanguageList;
            this.LanguageListComboBox.SelectedItem = this.ViewModel.LanguageList.FirstOrDefault(el => el.Name == CultureInfo.CurrentCulture.Name);
            this.LanguageListComboBox.SelectionChanged += LanguageListComboBox_SelectionChanged;

            this.DatabaseServerComboBox.ItemsSource = this.ViewModel.DatabaseServerList;
            this.DatabaseServerComboBox.SelectedItem = this.ViewModel.DatabaseServerList[0];

            this.GenerateSettingListView.SelectionChanged += GenerateSettingListView_SelectionChanged;
            this.GenerateSettingListView.ItemsSource = ConfigData.Current.GenerateSettingList;
     
            this.DatabaseObjectListView.ItemsSource = this.ViewModel.DatabaseObjectList;
            this.DatabaseObjectListView.MouseDoubleClick += DatabaseObjectListView_MouseDoubleClick;
            var cView = CollectionViewSource.GetDefaultView(this.ViewModel.DatabaseObjectList);
            cView.Filter = this.FilterDatabaseObject;
            this.FilterObjectTextBox.TextChanged += FilterObjectTextBox_TextChanged;

            this.Closing += MainWindow_Closing;
        }

        private void LanguageListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var language = this.LanguageListComboBox.SelectedItem as MainWindowViewModel.LanguageSetting;
            CultureInfo.CurrentCulture = new CultureInfo(language.Name);

            this.SetText();
        }

        private void SetText()
        {
            this.ConnectionListLabel.Content = T.Text.ConnectionList;
            this.AddConnectionButton.Content = T.Text.Add;

            this.AddPanelConnectionStringLabel.Content = T.Text.Name;
            this.AddPanelConnectionStringLabel.Content = T.Text.ConnectionString;
            
            this.SaveButton.Content = T.Text.Save;
            this.CancelButton.Content = T.Text.Cancel;

            this.OpenOutputFolderButton.Content = T.Text.OpenOutputFolder;
            this.LoadStoredProcedureButton.Content = T.Text.LoadStoredProcedure;
            this.LoadUserDefinedTypeButton.Content = T.Text.LoadUserDefinedType;
            this.GenerateButton.Content = T.Text.Generate;
        }
        private void GenerateSettingListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.GetSelectedGenerateSetting() == null)
            {
                this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Initialized);
            }
            else
            {
                this.ViewModel.SetDisplayMode(MainWindowDisplayMode.GenerateSettingSelected);
            }
            this.ViewModel.DatabaseObjectList.Clear();
        }
        private GenerateSetting? GetSelectedGenerateSetting()
        {
            return this.GenerateSettingListView.SelectedItem as GenerateSetting;
        }

        private void AddConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            this.GenerateSettingListView.SelectedItem = null;
            this.AddPanel.DataContext = new GenerateSetting();
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.AddGenerateSetting);
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var c = this.AddPanel.DataContext as GenerateSetting;
            if (c == null) { return; }

            c.DatabaseServer = (DatabaseServer)this.DatabaseServerComboBox.SelectedItem;
            ConfigData.Current.GenerateSettingList.Add(c);

            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Initialized);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddPanel.DataContext = null;
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Initialized);
        }

        private DatabaseSchemaReader? GetDatabaseSchemaReader()
        {
            var setting = this.GetSelectedGenerateSetting();
            if (setting == null) { return null; }
            return setting.CreateDatabaseSchemaReader();
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
            }
            catch
            {
                MessageBox.Show(T.Text.ConnectionFailed);
            }
        }
        private async void LoadUserDefinedTypeButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = this.GetSelectedGenerateSetting();
            if (setting == null) { return; }

            this.ViewModel.DatabaseObjectList.Clear();
            try
            {
                var reader = setting.CreateDatabaseSchemaReader();
                var l = await reader.GetUserDefinedTableTypesAsync();
                foreach (var item in l.OrderByDescending(el => el.LastAlteredTime))
                {
                    this.ViewModel.DatabaseObjectList.Add(item);
                }
            }
            catch
            {
                MessageBox.Show(T.Text.ConnectionFailed);
            }
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
                MessageBox.Show("Please select object.");
                return;
            }

            var reader = setting.CreateDatabaseSchemaReader();
            switch (o.ObjectType)
            {
                case DatabaseObjectType.StoredProcedure:
                    {
                        var sp = await reader.GetStoredProcedureAsync(o.Name);
                        var w = new StoredProcedureWindow(new StoredProcedureWindowViewModel(setting, sp));
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
    }
}
