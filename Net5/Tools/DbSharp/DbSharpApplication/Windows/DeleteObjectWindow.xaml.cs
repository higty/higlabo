using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharpApplication.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HigLabo.Wpf;
using HigLabo.DbSharp.MetaData;
using HigLabo.DbSharp.Service;
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for DeleteObjectWindow.xaml
    /// </summary>
    public partial class DeleteObjectWindow : Window
    {
        private ObservableCollection<CheckedItem<Table>> _Tables = new ObservableCollection<CheckedItem<Table>>();
        private ObservableCollection<CheckedItem<StoredProcedure>> _StoredProcedures = new ObservableCollection<CheckedItem<StoredProcedure>>();
        private ObservableCollection<CheckedItem<UserDefinedTableType>> _UserDefinedTableTypes = new ObservableCollection<CheckedItem<UserDefinedTableType>>();
        public DeleteObjectWindow()
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
            AValue.ConfigData.DeleteObjectWindow.Initialize(this);
        }
        private String GetSelectedConnectionString()
        {
            var ci = this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
            return ci.ConnectionString;
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
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
            
            this.ImportTable();
            this.ImportStoredProcedure();
            this.ImportUserDefinedTableType();

            if (this.TableListBox.Items.Count == 0 &&
                this.StoredProcedureListBox.Items.Count == 0 &&
                this.UserDefinedTableTypeListBox.Items.Count == 0)
            {
                MessageBox.Show(Properties.Resources.ThereIsNoObjectDeletedAfterLastProcess);
            }

            AValue.ConfigData.MoveConnectionStringToFirst(ci);
            this.ConnectionStringComboBox.SelectedItem = AValue.ConfigData.ConnectionStrings[0];
        }
        private void ImportTable()
        {
            DatabaseSchemaReader db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, this.GetSelectedConnectionString());
            var l = db.GetTables().ToList();

            _Tables.Clear();
            foreach (var item in AValue.SchemaData.Tables.Where(el => l.Exists(t => t.Name == el.Name) == false).Select(el => CheckedItem.Create(el)))
            {
                _Tables.Add(item);
            }
            this.TableSelectAllCheckBox.IsChecked = true;
        }
        private void ImportStoredProcedure()
        {
            DatabaseSchemaReader db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, this.GetSelectedConnectionString());
            var l = db.GetStoredProcedures().ToList();

            _StoredProcedures.Clear();
            foreach (var item in AValue.SchemaData.StoredProcedures.Where(el => l.Exists(sp => sp.Name == el.Name) == false).Select(el => CheckedItem.Create(el)))
            {
                _StoredProcedures.Add(item);
            }
            this.StoredProcedureSelectAllCheckBox.IsChecked = true;
        }
        private void ImportUserDefinedTableType()
        {
            var db = ImportSchemaCommand.CreateDatabaseSchemaReader(AValue.SchemaData.DatabaseServer, this.GetSelectedConnectionString());
            var l = db.GetUserDefinedTableTypes().ToList();

            _UserDefinedTableTypes.Clear();
            foreach (var item in AValue.SchemaData.UserDefinedTableTypes.Where(el => l.Exists(sp => sp.Name == el.Name) == false).Select(el => CheckedItem.Create(el)))
            {
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
            Analytics.TrackEvent("DeleteObject Execute");

            var tNames = _Tables.Where(el => el.IsChecked).Select(el => el.Item.Name).ToList();
            var sNames = _StoredProcedures.Where(el => el.IsChecked).Select(el => el.Item.Name).ToList();
            var uNames = _UserDefinedTableTypes.Where(el => el.IsChecked).Select(el => el.Item.Name).ToList();
            var ci = this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
            var sv = new DeleteObjectCommandService(AValue.ConfigData.GetOutputDirectoryPath(), AValue.SchemaData, ci.ConnectionString
                , tNames, sNames, uNames);

            AValue.ConfigData.MoveConnectionStringToFirst(ci);

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

    }
}
