using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using HigLabo.CodeGenerator;
using HigLabo.DbSharpApplication.Core;
using System.IO;
using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharp.MetaData;
using HigLabo.Wpf;
using HigLabo.Core;
using HigLabo.DbSharp.Service;
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    public partial class GenerateSourceCodeWindow : Window
    {
        private ObservableCollection<SourceCodeFileGeneratedEventArgs> _SourceCodeFileGeneratedEventArgsList = new ObservableCollection<SourceCodeFileGeneratedEventArgs>();
        private ObservableCollection<CheckedItem<Table>> _Tables = new ObservableCollection<CheckedItem<Table>>();
        private ObservableCollection<CheckedItem<StoredProcedure>> _StoredProcedures = new ObservableCollection<CheckedItem<StoredProcedure>>();
        private ObservableCollection<CheckedItem<UserDefinedTableType>> _UserDefinedTableTypes = new ObservableCollection<CheckedItem<UserDefinedTableType>>();

        public GenerateSourceCodeWindow()
        {
            InitializeComponent();

            this.SettingGrid.DataContext = AValue.SchemaData;
            this.OutputDirectoryPathTextBox.DataContext = AValue.ConfigData.GetCurrentRecentSchemaFile();

            this.TableListBox.ItemsSource = _Tables;
            this.StoredProcedureListBox.ItemsSource = _StoredProcedures;
            this.UserDefinedTableTypeListBox.ItemsSource = _UserDefinedTableTypes;

            if (AValue.ConfigData.UseTableFeature)
            {
                _Tables.AddRange(AValue.SchemaData.Tables.Select(el => CheckedItem.Create(el, true)).OrderBy(el => el.Item.Name));
            }
            _StoredProcedures.AddRange(AValue.SchemaData.StoredProcedures.Select(el => CheckedItem.Create(el, true)).OrderBy(el => el.Item.Name));
            _UserDefinedTableTypes.AddRange(AValue.SchemaData.UserDefinedTableTypes.Select(el => CheckedItem.Create(el, true)).OrderBy(el => el.Item.Name));

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

            AValue.ConfigData.GenerateSourceCodeWindow.Initialize(this);
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

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("GenerateSourceCode Execute");

            var path = this.OutputDirectoryPathTextBox.Text;
            if (path.EndsWith("\\") == false)
            {
                path += "\\";
            }
            AValue.EnsureGenerateSourceCodeFolder(path);
            this.OutputDirectoryPathTextBox.Text = path;
            AValue.ConfigData.SetOutputDirectoryPath(path);
            AValue.SchemaData.NamespaceName = this.NamespaceNameTextBox.Text;
            AValue.SchemaData.DatabaseKey = this.DatabaseKeyTextBox.Text;
            AValue.EnsureGenerateSourceCodeFolder(path);

            var sv = new CommandService();
            var cm = new GenerateSourceCodeCommand(AValue.ConfigData.GetOutputDirectoryPath(), AValue.SchemaData);
            if (AValue.ConfigData.UseTableFeature)
            {
                cm.Tables.AddRange(_Tables.Where(el => el.IsChecked).Select(el => el.Item));
            }
            cm.StoredProcedures.AddRange(_StoredProcedures.Where(el => el.IsChecked).Select(el => el.Item));
            cm.UserDefinedTableTypes.AddRange(_UserDefinedTableTypes.Where(el => el.IsChecked).Select(el => el.Item));
            sv.Commands.Add(cm);

            if (cm.Tables.Count == 0 &&
                cm.StoredProcedures.Count == 0 &&
                cm.UserDefinedTableTypes.Count == 0)
            {
                MessageBox.Show(Properties.Resources.PleaseSelectItem);
                return;
            }

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
