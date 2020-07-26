using HigLabo.DbSharp.MetaData;
using HigLabo.DbSharp.Service;
using HigLabo.DbSharpApplication.Core;
using HigLabo.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using HigLabo.Core;
using System.Threading;
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for ImportObjectWindow.xaml
    /// </summary>
    public partial class ImportObjectWindow : Window
    {
        private ObservableCollection<CheckedItem<DatabaseObject>> _Tables = new ObservableCollection<CheckedItem<DatabaseObject>>();
        private ObservableCollection<CheckedItem<DatabaseObject>> _StoredProcedures = new ObservableCollection<CheckedItem<DatabaseObject>>();
        private ObservableCollection<CheckedItem<DatabaseObject>> _UserDefinedTableTypes = new ObservableCollection<CheckedItem<DatabaseObject>>();

        public ImportObjectWindow()
        {
            InitializeComponent();

            this.ConnectionStringComboBox.ItemsSource = AValue.ConfigData.ConnectionStrings;

            this.TableListBox.ItemsSource = _Tables;
            this.StoredProcedureListBox.ItemsSource = _StoredProcedures;
            this.UserDefinedTableTypeListBox.ItemsSource = _UserDefinedTableTypes;
       
            if (AValue.ConfigData.ConnectionStrings.Count > 0)
            {
                this.ConnectionStringComboBox.SelectedItem = AValue.ConfigData.ConnectionStrings[0];
            }

            if (AValue.ConfigData.UseTableFeature)
            {
                this.TableSelectAllCheckBox.Visibility = Visibility.Visible;
                this.TableListBox.Visibility = Visibility.Visible;
                this.UseTableFeatureUnableText.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.TableSelectAllCheckBox.Visibility = Visibility.Collapsed;
                this.TableListBox.Visibility = Visibility.Collapsed;
                this.UseTableFeatureUnableText.Visibility = Visibility.Visible;
            }
            if (AValue.SchemaData.DatabaseServer == DatabaseServer.SqlServer)
            {
                this.ForeignKeyCheckBox.IsChecked = true;
            }
            AValue.ConfigData.ImportObjectWindow.Initialize(this);
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ConnectionStringComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(Properties.Resources.PleaseSelectConnectionString);
                return;
            }
            var ci = this.GetSelectedConnectionStringInfo();
            var offsetHour = ci.TimeZone;
            if (AValue.ConfigData.UseTableFeature)
            {
                this.ImportTable(ci.ConnectionString, offsetHour);
            }
            this.ImportStoredProcedure(ci.ConnectionString, offsetHour);
            this.ImportUserDefinedTableType(ci.ConnectionString, offsetHour);

            if (this.TableListBox.Items.Count == 0 &&
                this.StoredProcedureListBox.Items.Count == 0 &&
                this.UserDefinedTableTypeListBox.Items.Count == 0)
            {
                MessageBox.Show(Properties.Resources.ThereIsNoObjectAlteredAfterLastProcess);
            }

            AValue.ConfigData.MoveConnectionStringToFirst(ci);
            this.ConnectionStringComboBox.SelectedItem = AValue.ConfigData.ConnectionStrings[0];
        }
        private ConnectionStringInfo GetSelectedConnectionStringInfo()
        {
            return this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
        }
        private void ImportTable(String connectionString, Int32 offsetHour)
        {
            var l = new List<DatabaseObject>();
            var db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, connectionString);

            foreach (var item in db.GetTables())
            {
                if (this.ImportAllCheckBox.IsChecked == false &&
                    item.LastAlteredTime + TimeSpan.FromHours(offsetHour) < AValue.SchemaData.LastExecuteTimeOfImportTable)
                { continue; }
                if (AValue.SchemaData.IgnoreObjects.Exists(el => el.Name == item.Name) == true)
                { continue; }

                l.Add(item);
            }

            _Tables.Clear();
            foreach (var item in l.Select(el => CheckedItem.Create(el)))
            {
                item.IsChecked = true;
                _Tables.Add(item);
            }
            this.TableSelectAllCheckBox.IsChecked = true;
        }
        private void ImportStoredProcedure(String connectionString, Int32 offsetHour)
        {
            var l = new List<DatabaseObject>();
            var db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, connectionString);
            
            foreach (var item in db.GetStoredProcedures())
            {
                if (this.ImportAllCheckBox.IsChecked == false &&
                    item.LastAlteredTime + TimeSpan.FromHours(offsetHour) < AValue.SchemaData.LastExecuteTimeOfImportStoredProcedure)
                { continue; }
                if (AValue.SchemaData.IgnoreObjects.Exists(el => el.Name == item.Name) == true)
                { continue; }
                
                l.Add(item);
            }

            _StoredProcedures.Clear();
            foreach (var item in l.Select(el => CheckedItem.Create(el)))
            {
                item.IsChecked = true;
                _StoredProcedures.Add(item);
            }
            this.StoredProcedureSelectAllCheckBox.IsChecked = true;
        }
        private void ImportUserDefinedTableType(String connectionString, Int32 offsetHour)
        {
            var l = new List<DatabaseObject>();
            var db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, connectionString);

            if (db.SupportUserDefinedTableType == false) { return; }

            foreach (var item in db.GetUserDefinedTableTypes())
            {
                if (this.ImportAllCheckBox.IsChecked == false &&
                    item.LastAlteredTime + TimeSpan.FromHours(offsetHour) < AValue.SchemaData.LastExecuteTimeOfImportUserDefinedTableType)
                { continue; }
                if (AValue.SchemaData.IgnoreObjects.Exists(el => el.Name == item.Name) == true)
                { continue; }

                l.Add(item);
            }

            _UserDefinedTableTypes.Clear();
            foreach (var item in l.Select(el => CheckedItem.Create(el)))
            {
                item.IsChecked = true;
                _UserDefinedTableTypes.Add(item);
            }
            this.UserDefinedTableTypeSelectAllCheckBox.IsChecked = true;
        }
        private void TableSelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _Tables)
            {
                item.IsChecked = this.TableSelectAllCheckBox.IsChecked == true;
            }
        }
        private void StoredProcedureSelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _StoredProcedures)
            {
                item.IsChecked = this.StoredProcedureSelectAllCheckBox.IsChecked == true;
            }
        }
        private void UserDefinedTableTypeSelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _UserDefinedTableTypes)
            {
                item.IsChecked = this.UserDefinedTableTypeSelectAllCheckBox.IsChecked == true;
            }
        }

        private void AddToIgnoreListButton_Click(object sender, RoutedEventArgs e)
        {
            var l = new List<DatabaseObject>();
            l.AddRange(_Tables.Where(el => el.IsChecked).Select(el => el.Item));
            l.AddRange(_StoredProcedures.Where(el => el.IsChecked).Select(el => el.Item));
            l.AddRange(_UserDefinedTableTypes.Where(el => el.IsChecked).Select(el => el.Item));
            var w = new ManageIgnoreObjectWindow(l);
            w.ShowDialog();
        }
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("ImportObject Execute");

            if (this.ConnectionStringComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(Properties.Resources.PleaseSelectConnectionString);
                return;
            }
            var ci = this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
            if (AValue.CanConnectToDatabase(AValue.SchemaData.DatabaseServer, ci.ConnectionString) == false)
            {
                MessageBox.Show(Properties.Resources.ConnectionStringInvalid);
                return;
            }
            var sv = new ImportObjectCommandService(AValue.SchemaData, ci.ConnectionString
                , this.ForeignKeyCheckBox.IsChecked == true
                , _Tables.Where(el => el.IsChecked).Select(el => el.Item.Name)
                , _StoredProcedures.Where(el => el.IsChecked).Select(el => el.Item.Name)
                , _UserDefinedTableTypes.Where(el => el.IsChecked).Select(el => el.Item.Name)
                );

            AValue.ConfigData.MoveConnectionStringToFirst(ci);
            this.ConnectionStringComboBox.SelectedItem = AValue.ConfigData.ConnectionStrings[0];

            this.Hide();

            var w = new ProgressWindow(sv);
            w.ShowDialog();
            sv.ThrowException();

            this.Close();
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ToggleListBoxItemChecked(object sender, KeyEventArgs e)
        {
            var lx = sender as System.Windows.Controls.ListBox;
            if (e.Key == Key.Return &&
                lx.SelectedItems.Count > 0)
            {
                var isChecked = ((CheckedItem<DatabaseObject>)lx.SelectedItems[0]).IsChecked;
                foreach (CheckedItem<DatabaseObject> item in lx.SelectedItems)
                {
                    item.IsChecked = !isChecked;
                }
            }
        }
    }
}
