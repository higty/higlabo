using HigLabo.DbSharpApplication.Core;
using System;
using System.Collections.Generic;
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
using HigLabo.DbSharp.CodeGenerator;
using System.IO;
using System.Windows.Threading;
using HigLabo.Wpf;
using Microsoft.AppCenter.Analytics;
using HigLabo.DbSharp.Service;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for GenerateSqlScriptWindow.xaml
    /// </summary>
    public partial class GenerateSqlScriptWindow : Window
    {
        public GenerateSqlScriptWindow()
        {
            InitializeComponent();
            this.OutputDirectoryPathTextBox.Text = AValue.ConfigData.GetSqlScriptOutputDirectoryPath();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("GenerateSqlScript Execute");

            AValue.ConfigData.SetSqlScriptOutputDirectoryPath(this.OutputDirectoryPathTextBox.Text);
            String path = this.OutputDirectoryPathTextBox.Text;
          
            var gen = new SqlScriptFileGenerator(ImportSchemaCommand.CreateTableStoredProcedureFactory(AValue.SchemaData.DatabaseServer, ""));
            gen.Tables.AddRange(AValue.SchemaData.Tables);
            gen.FolderPath = path;
            gen.FileGenerated += this.Dispatcher.CreateEventHander<SqlScriptFileGeneratedEventArgs>(SqlScriptFile_FileGenerated);
            gen.Completed += this.Dispatcher.CreateEventHander(SqlScriptFile_Completed);

            this.ResultLabel.Text = "";
            gen.Start();
        }
        void SqlScriptFile_FileGenerated(object sender, SqlScriptFileGeneratedEventArgs e)
        {
            this.ResultLabel.Text += "Created at " + e.FilePath + Environment.NewLine;
        }
        void SqlScriptFile_Completed(object sender, EventArgs e)
        {
            this.ResultLabel.Text += "Completed";
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
