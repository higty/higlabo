using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HigLabo.Core;
using HigLabo.DbSharpApplication.Core;
using HigLabo.DbSharp.CodeGenerator;
using System.ComponentModel;
using HigLabo.DbSharp.MetaData;
using System.Globalization;
using System.Threading;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Object _TableListViewLock = new object();
        private Object _StoredProcedureListViewLock = new object();
        private Object _UserDefinedTableTypeListViewLock = new object();
        private CollectionViewSource _TableListViewSource = new CollectionViewSource();
        private CollectionViewSource _StoredProcedureListViewSource = new CollectionViewSource();
        private CollectionViewSource _UserDefinedTableTypeListViewSource = new CollectionViewSource();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            AValue.ConfigData.MainWindow.Initialize(this);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.m0100.IsEnabled = false;
            this.SetDatabaseTypeList();
            this.m0003.ItemsSource = AValue.ConfigData.RecentSchemaFiles;

            if (String.IsNullOrWhiteSpace(AValue.ConfigData.SchemaFilePath) == true)
            {
                this.SetControlEnable(MainWindowState.New);
            }
            else
            {
                this.SetSchemaData();
            }
        }

        private void SetDatabaseTypeList()
        {
            this.DatabaseTypeList.ItemsSource = Enum<DatabaseServer>.GetValues();
        }
        private void SetItemsSource()
        {
            CollectionViewSource src = null;

            src = _TableListViewSource;
            src.Source = AValue.SchemaData.Tables;
            src.Filter += TableListBox_Filter;
            src.SortDescriptions.Clear();
            src.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            this.TableListBox.ItemsSource = src.View;
            this.StoredProcedureTableListBox.ItemsSource = src.View;

            src = _StoredProcedureListViewSource;
            src.Source = AValue.SchemaData.StoredProcedures;
            src.Filter += StoredProcedureListBox_Filter;
            src.SortDescriptions.Clear();
            src.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            this.StoredProcedureListBox.ItemsSource = src.View;

            this.FilterStoredProcedureTypeListBox.ItemsSource = Enum<StoredProcedureFilter>.GetValues();
            this.FilterStoredProcedureTypeListBox.SelectedIndex = 0;

            src = _UserDefinedTableTypeListViewSource;
            src.Source = AValue.SchemaData.UserDefinedTableTypes;
            src.Filter += UserDefinedTableType_Filter;
            src.SortDescriptions.Clear();
            src.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            this.UserDefinedTableTypeListBox.ItemsSource = src.View;

            BindingOperations.EnableCollectionSynchronization(AValue.SchemaData.Tables, _TableListViewLock);
            BindingOperations.EnableCollectionSynchronization(AValue.SchemaData.StoredProcedures, _StoredProcedureListViewLock);
            BindingOperations.EnableCollectionSynchronization(AValue.SchemaData.UserDefinedTableTypes, _UserDefinedTableTypeListViewLock);
        }

        private void m0001_Click(object sender, RoutedEventArgs e)
        {
            AValue.ConfigData.SchemaFilePath = "";
            AValue.LoadSchemaData("");
            this.SetItemsSource();
            this.SetControlEnable(MainWindowState.New);
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
            String xml = File.ReadAllText(filePath);
            AValue.LoadSchemaData(xml);
            AValue.ConfigData.SchemaFilePath = filePath;
            this.SetSchemaData();
        }
        private void SetSchemaData()
        {
            try
            {
                this.DatabaseTypeList.SelectedValue = AValue.SchemaData.DatabaseServer;
                this.SetItemsSource();
                this.SetControlEnable(MainWindowState.SchemaLoaded);
                this.Title = AValue.ConfigData.SchemaFilePath;
                AValue.ConfigData.ChangeCultureInfo();
                var f = AValue.ConfigData.GetCurrentRecentSchemaFile();
                if (f != null)
                {
                    var cn = AValue.ConfigData.ConnectionStrings.FirstOrDefault(el => el != null && el.Name == f.ConnectionStringName);
                    if (cn != null)
                    {
                        AValue.ConfigData.ConnectionStrings.Remove(cn);
                        AValue.ConfigData.ConnectionStrings.Insert(0, cn);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                AValue.ConfigData.SchemaFilePath = "";
                MessageBox.Show(Properties.Resources.FileNotFound);
            }
            AValue.ConfigData.Save();
        }
        private void m0003_Click(object sender, RoutedEventArgs e)
        {
            var fi = ((MenuItem)e.OriginalSource).DataContext as SchemaFileInfo;
            var path = fi.FilePath;

            if (String.IsNullOrEmpty(path) == true ||
                File.Exists(path) == false)
            {
                MessageBox.Show(Properties.Resources.FileNotFound);
                if (fi != null)
                {
                    AValue.ConfigData.RecentSchemaFiles.Remove(fi);
                }
                return;
            }

            this.OpenSchemaFile(path);
        }
        private void m0004_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (String.IsNullOrEmpty(AValue.ConfigData.SchemaFilePath) == false)
            {
                File.WriteAllText(AValue.ConfigData.SchemaFilePath, AppEnvironment.Settings.XmlSerializer.Serialize(AValue.SchemaData));
                return;
            }

            dlg.Filter = AValue.DialogFilter;
            if (dlg.ShowDialog() == true)
            {
                this.SaveSchemaFile(dlg.FileName);
            }
        }
        private void m0005_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = AValue.DialogFilter;
            if (dlg.ShowDialog() == true)
            {
                this.SaveSchemaFile(dlg.FileName);
            }
        }
        private void SaveSchemaFile(String fileName)
        {
            AValue.ConfigData.SchemaFilePath = fileName;
            File.WriteAllText(AValue.ConfigData.SchemaFilePath, AppEnvironment.Settings.XmlSerializer.Serialize(AValue.SchemaData));
            AValue.ConfigData.Save();
        }
        private void m0006_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void m0101_Click(object sender, RoutedEventArgs e)
        {
            var w = new ManageConnectionStringWindow();
            this.ShowDialog(w);
        }
        private void m0102_Click(object sender, RoutedEventArgs e)
        {
            var w = new ImportObjectWindow();
            this.ShowDialog(w);
            this.MainTabTable.IsSelected = true;
        }
        private void m0191_Click(object sender, RoutedEventArgs e)
        {
            DatabaseObject o = null;

            switch (this.MainTab.SelectedIndex)
            {
                case 0:
                    var t = this.TableListBox.SelectedItem as Table;
                    if (t == null) { return; }
                    o = t;
                    AValue.SchemaData.Tables.Remove(t);
                    break;
                case 1:
                    var sp = this.StoredProcedureListBox.SelectedItem as StoredProcedure;
                    if (sp == null) { return; }
                    o = sp;
                    AValue.SchemaData.StoredProcedures.Remove(sp);
                    break;
                case 2:
                    var ud = this.UserDefinedTableTypeListBox.SelectedItem as UserDefinedTableType;
                    if (ud == null) { return; }
                    o = ud;
                    AValue.SchemaData.UserDefinedTableTypes.Remove(ud);
                    break;
                default: break;
            }
            if (o != null)
            {
                if (AValue.SchemaData.IgnoreObjects.Exists(el => el.Name == o.Name) == false)
                {
                    AValue.SchemaData.IgnoreObjects.Add(o);
                }
            }
        }
        private void m0104_Click(object sender, RoutedEventArgs e)
        {
            var w = new DeleteObjectWindow();
            this.ShowDialog(w);
        }
        private void m0105_Click(object sender, RoutedEventArgs e)
        {
            var w = new GenerateSourceCodeWindow();
            this.ShowDialog(w);
        }
        private void m0106_Click(object sender, RoutedEventArgs e)
        {
            var w = new GenerateSqlScriptWindow();
            this.ShowDialog(w);
        }
        private void m0107_Click(object sender, RoutedEventArgs e)
        {
            var w = new ManageIgnoreObjectWindow(new DatabaseObject[0]);
            this.ShowDialog(w);
        }
        private void m0110_Click(object sender, RoutedEventArgs e)
        {
            var w = new ImportObjectGenerateFileWindow();
            this.ShowDialog(w);
        }

        private void m0201_Click(object sender, RoutedEventArgs e)
        {
            this.MainTabTable.IsSelected = true;
            if (this.TableListBox.SelectedIndex == -1)
            {
                this.TableListBox.SelectedIndex = 0;
            }
        }
        private void m0202_Click(object sender, RoutedEventArgs e)
        {
            this.MainTabStoredProcedure.IsSelected = true;
            if (this.StoredProcedureListBox.SelectedIndex == -1)
            {
                this.StoredProcedureListBox.SelectedIndex = 0;
            }
        }
        private void m0203_Click(object sender, RoutedEventArgs e)
        {
            this.MainTabUserDefinedTableType.IsSelected = true;
            if (this.UserDefinedTableTypeListBox.SelectedIndex == -1)
            {
                this.UserDefinedTableTypeListBox.SelectedIndex = 0;
            }
        }

        private void m0301_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            var w = new EditSettingsWindow();
            this.ShowDialog(w);

            this.Close();
        }

        private void SelectDatabaseTypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DatabaseTypeList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select database type.");
            }
            var databaseServer = (DatabaseServer)this.DatabaseTypeList.SelectedValue;
            if (databaseServer != DatabaseServer.SqlServer &&
                databaseServer != DatabaseServer.MySql)
            {
                MessageBox.Show("SqlServer,MySql are supported.");
                return;
            }

            AValue.SchemaData.DatabaseServer = databaseServer;
            this.SetItemsSource();
            this.SetControlEnable(MainWindowState.SchemaLoaded);

            if (AValue.ConfigData.ConnectionStrings.Count == 0)
            {
                var w = new ManageConnectionStringWindow();
                w.ShowDialog();
                return;
            }
        }
        private void ShowDialog(Window window)
        {
            try
            {
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                AValue.AddErrorLog(ex);
                var w = new MessageWindow(ex.ToString());
                w.ShowDialog();
            }
            finally
            {
                window.Close();
            }
        }

        void TableListBox_Filter(object sender, FilterEventArgs e)
        {
            var t = e.Item as Table;

            if (String.IsNullOrWhiteSpace(this.SearchTableTextBox.Text) == false &&
                t.Name.Contains(this.SearchTableTextBox.Text) == false)
            {
                e.Accepted = false;
            }
        }
        private void SearchTableTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _TableListViewSource.View.Refresh();
            }
        }

        void StoredProcedureListBox_Filter(object sender, FilterEventArgs e)
        {
            if (this.FilterStoredProcedureTypeListBox.SelectedValue == null) return;

            var mode = (StoredProcedureFilter)this.FilterStoredProcedureTypeListBox.SelectedValue;
            var sp = e.Item as StoredProcedure;

            if (String.IsNullOrWhiteSpace(this.SearchStoredProcedureTextBox.Text) == false &&
                sp.Name.Contains(this.SearchStoredProcedureTextBox.Text) == false)
            {
                e.Accepted = false;
                return;
            }
            switch (mode)
            {
                case StoredProcedureFilter.Recent: break;
                case StoredProcedureFilter.Custom: e.Accepted = sp.StoredProcedureType == StoredProcedureType.Custom; break;
                case StoredProcedureFilter.Table: e.Accepted = sp.StoredProcedureType != StoredProcedureType.Custom; break;
                case StoredProcedureFilter.All: break;
                default: throw new InvalidOperationException();
            }
        }
        private void SearchStoredProcedureTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _StoredProcedureListViewSource.View.Refresh();
            }
        }

        private void FilterStoredProcedureTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var src = _StoredProcedureListViewSource;
            src.SortDescriptions.Clear();
            var mode = (StoredProcedureFilter)this.FilterStoredProcedureTypeListBox.SelectedValue;
            if (mode == StoredProcedureFilter.Recent)
            {
                src.SortDescriptions.Add(new SortDescription("LastAlteredTime", ListSortDirection.Descending));
            }
            else
            {
                src.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            src.View.Refresh();
        }
        private void StoredProcedureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ResultSetListBox.SelectedIndex = 0;
        }
        private void ResultSetsTableNameApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var t = this.StoredProcedureTableListBox.SelectedItem as Table;
            var rs = this.ResultSetListBox.SelectedItem as StoredProcedureResultSetColumn;

            if (rs == null) return;

            rs.TableName = t.Name;
            DataType c = null;
            foreach (var column in t.Columns)
            {
                c = rs.Columns.Find(el => el.Name == column.Name);
                if (c == null) { continue; }
                c.AllowNull = column.AllowNull;
                c.EnumName = column.EnumName;
                c.EnumValues = column.EnumValues;
            }
        }

        void UserDefinedTableType_Filter(object sender, FilterEventArgs e)
        {
            var t = e.Item as UserDefinedTableType;

            if (String.IsNullOrWhiteSpace(this.SearchUserDefinedTableTypeTextBox.Text) == false &&
                t.Name.Contains(this.SearchUserDefinedTableTypeTextBox.Text) == false)
            {
                e.Accepted = false;
            }
        }
        private void SearchUserDefinedTableTypeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _UserDefinedTableTypeListViewSource.View.Refresh();
            }
        }
        private void SetControlEnable(MainWindowState state)
        {
            switch (state)
            {
                case MainWindowState.New:
                    {
                        this.DatabaseTypeList.IsEnabled = true;
                        this.SelectDatabaseTypeButton.Visibility = Visibility.Visible;
                        this.MainTab.Visibility = Visibility.Hidden;
                        this.MainTabTable.Visibility = Visibility.Hidden;
                        this.MainTabStoredProcedure.Visibility = Visibility.Hidden;
                        this.MainTabUserDefinedTableType.Visibility = Visibility.Hidden;
                        this.m0100.IsEnabled = false;
                        this.m0200.IsEnabled = false;
                        this.m0300.IsEnabled = false;
                    }
                    break;
                case MainWindowState.SchemaLoaded:
                    {
                        this.DatabaseTypeList.IsEnabled = false;
                        this.SelectDatabaseTypeButton.Visibility = Visibility.Hidden;
                        this.MainTab.Visibility = Visibility.Visible;
                        this.MainTabTable.Visibility = Visibility.Visible;
                        this.MainTabStoredProcedure.Visibility = Visibility.Visible;
                        this.MainTabUserDefinedTableType.Visibility = Visibility.Visible;
                        this.m0100.IsEnabled = true;
                        this.m0200.IsEnabled = true;
                        this.m0300.IsEnabled = true;
                    }
                    break;
                default: throw new InvalidOperationException();
            }

        }

        private void ColumnListBox_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header as String == "EnumName")
            {
                var tx = e.EditingElement as TextBox;
                this.SetEnumNameToStoredProcedure(tx.Text);
            }
        }
        private void SetEnumNameToStoredProcedure(String enumName)
        {
            var c = this.ColumnListBox.SelectedValue as Column;
            c.EnumName = enumName;
            var t = this.TableListBox.SelectedValue as Table;

            foreach (var sp in AValue.SchemaData.StoredProcedures.Where(el => el.TableName == t.Name))
            {
                var parameters = sp.Parameters.FindAll(p => p.GetNameWithoutAtmark() == c.Name ||
                    p.GetNameWithoutAtmark() == "PK_" + c.Name);
                foreach (var parameter in parameters)
                {
                    parameter.EnumName = c.EnumName;
                    parameter.EnumValues = c.EnumValues;
                }
                foreach (var rs in sp.ResultSets)
                {
                    var resultSetColumn = rs.Columns.Find(p => p.GetNameWithoutAtmark() == c.Name);
                    if (resultSetColumn != null)
                    {
                        resultSetColumn.EnumName = c.EnumName;
                        resultSetColumn.EnumValues = c.EnumValues;
                    }
                }
            }
            foreach (var rs in AValue.SchemaData.StoredProcedures.SelectMany(sp => sp.ResultSets).Where(el => el.TableName == t.Name))
            {
                var column = rs.Columns.Find(p => p.GetNameWithoutAtmark() == c.Name);
                if (column != null)
                {
                    column.EnumName = c.EnumName;
                    column.EnumValues = c.EnumValues;
                }
            }
        }

    }
}
