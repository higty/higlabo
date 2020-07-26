using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharpApplication.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using HigLabo.Wpf;
using HigLabo.DbSharp.Service;
using HigLabo.DbSharp.MetaData;
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for ImportObjectGenerateFileWindow.xaml
    /// </summary>
    public partial class ImportObjectGenerateFileWindow : Window
    {
        public ImportObjectGenerateFileWindow()
        {
            InitializeComponent();
            this.ConnectionStringComboBox.ItemsSource = AValue.ConfigData.ConnectionStrings;
            this.ConnectionStringComboBox.SelectedIndex = 0;

            this.OutputDirectoryPathTextBox.Text = AValue.ConfigData.GetOutputDirectoryPath();
            this.NamespaceNameTextBox.Text = AValue.SchemaData.NamespaceName;
            this.DatabaseKeyTextBox.Text = AValue.SchemaData.DatabaseKey;

            AValue.ConfigData.ImportObjectGenerateFileWindow.Initialize(this);
        }
        private String GetSelectedConnectionString()
        {
            var ci = this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
            if (ci == null) { return ""; }
            return ci.ConnectionString;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("ImportObjectGenerateFile Execute");

            var ci = this.ConnectionStringComboBox.SelectedValue as ConnectionStringInfo;
            if (ci == null)
            {
                MessageBox.Show(Properties.Resources.PleaseSelectConnectionString);
                return;
            }
            if (AValue.CanConnectToDatabase(AValue.SchemaData.DatabaseServer, ci.ConnectionString) == false)
            {
                MessageBox.Show(Properties.Resources.ConnectionStringInvalid);
                return;
            }

            var path = this.OutputDirectoryPathTextBox.Text;
            if (path.EndsWith("\\") == false)
            {
                path += "\\";
            }
            AValue.EnsureGenerateSourceCodeFolder(path);
            this.OutputDirectoryPathTextBox.Text = path;

            var sv = new ImportObjectGenerateFileCommandService(AValue.SchemaData);
            sv.ImportAllObject = this.ImportAllObjectCheckBox.IsChecked == true;
            sv.LoadCommand(ci.ConnectionString, path, this.NamespaceNameTextBox.Text, this.DatabaseKeyTextBox.Text);

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
    }
}
