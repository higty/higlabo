using Google.Protobuf.WellKnownTypes;
using HigLabo.Core;
using HigLabo.Data;
using HigLabo.DbSharp.MetaData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

            ConfigData.Current = ConfigData.Load();
            ConfigData.Current.EnsureFileExists();

            this.ViewModel = new MainWindowViewModel();
            this.DataContext = this.ViewModel;
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Initialized);

            this.GenerateSettingListView.SelectionChanged += GenerateSettingListView_SelectionChanged;
            this.GenerateSettingListView.ItemsSource = ConfigData.Current.GenerateSettingList;
     
            this.DatabaseObjectListView.ItemsSource = this.ViewModel.DatabaseObjectList;
            var cView = CollectionViewSource.GetDefaultView(this.ViewModel.DatabaseObjectList);
            cView.Filter = this.FilterDatabaseObject;
            this.FilterObjectTextBox.TextChanged += FilterObjectTextBox_TextChanged;

            this.Closing += MainWindow_Closing;
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
        }
        private GenerateSetting? GetSelectedGenerateSetting()
        {
            return this.GenerateSettingListView.SelectedItem as GenerateSetting;
        }

        private void AddConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            this.GenerateSettingListView.SelectedItem = null;
            this.AddPanel.DataContext = new GenerateSetting();
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.AddPanel);
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var c = this.AddPanel.DataContext as GenerateSetting;
            if (c == null) { return; }
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

            var l = await reader.GetStoredProceduresAsync();
            foreach (var item in l.OrderByDescending(el => el.LastAlteredTime))
            {
                this.ViewModel.DatabaseObjectList.Add(item);
            }
        }
        private async void LoadUserDefinedTypeButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = this.GetSelectedGenerateSetting();
            if (setting == null) { return; }

            var db = setting.CreateDatabaseSchemaReader();

            this.ViewModel.DatabaseObjectList.Clear();
            var l = await db.GetUserDefinedTableTypesAsync();
            foreach (var item in l.OrderByDescending(el => el.LastAlteredTime))
            {
                this.ViewModel.DatabaseObjectList.Add(item);
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
        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = this.GetSelectedGenerateSetting();
            if (setting == null) { return; }

            var o = this.DatabaseObjectListView.SelectedItem as DatabaseObject;
            if (o == null)
            {
                MessageBox.Show("Please select object.");
                return;
            }

            switch (o.ObjectType)
            {
                case DatabaseObjectType.StoredProcedure:
                    var reader = setting.CreateDatabaseSchemaReader();
                    var sp = await reader.GetStoredProcedureAsync(o.Name);
                    var w = new StoredProcedureWindow(new StoredProcedureWindowViewModel(setting, sp));
                    w.ShowDialog();
                    break;
                case DatabaseObjectType.UserDefinedTableType:
                    break;
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
