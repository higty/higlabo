using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DbSharpApplication
{
    /// <summary>
    /// DatabaseDefinitionWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DatabaseDefinitionWindow : Window
    {
        private WorkerThreadService _WorkerThreadService = new WorkerThreadService();

        public string ConnectionString { get; set; } = "";

        public DatabaseDefinitionWindow(string connectionString)
        {
            InitializeComponent();

            this.SetText();
            _WorkerThreadService.Completed += WorkerThreadService_Completed;

            this.ConnectionString = connectionString;
        }
        private void SetText()
        {
            this.ExecuteButton.Content = T.Text.Execute + "(_E)";
            this.CloseButton.Content = T.Text.Close + "(_C)";
        }


        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_WorkerThreadService.IsExecuting)
            {
                MessageBox.Show("Now executing...");
                return;
            }
            var g = new DatabaseDefinitionFileGenerator(this.ConnectionString);
            g.Loaded += DatabaseDefinitionFileGenerator_Loaded;
            _WorkerThreadService.Generator = g;
            _WorkerThreadService.StartThread();

            this.StatusBarLabel.Content = "";
            this.TableTextBox.Text = "";
            this.StoredProcedureTextBox.Text = "";
        }
        private void WorkerThreadService_Completed(object? sender, WorkerThreadServiceCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.StatusBarLabel.Content = "Completed";
                this.TableTextBox.Text = e.TableFileText;
                this.StoredProcedureTextBox.Text = e.StoredProcedureFileText;
                this.TableSchemeTextBox.Text = e.TableSchemeJsonText;
            });
        }

        private void DatabaseDefinitionFileGenerator_Loaded(object? sender, DatabaseObjectDefinitionLoadedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.StatusBarLabel.Content = DateTimeOffset.Now.ToString("HH:mm:ss.fff") + " " + e.Name + " Loaded";
            });
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_WorkerThreadService.Generator != null)
            {
                _WorkerThreadService.Generator.Loaded -= DatabaseDefinitionFileGenerator_Loaded;
            }
            _WorkerThreadService.Completed -= WorkerThreadService_Completed;
            this.Close();
        }
    }

    public class WorkerThreadServiceCompletedEventArgs : EventArgs
    {
        public String TableFileText { get; set; } = "";
        public String StoredProcedureFileText { get; set; } = "";
        public String TableSchemeJsonText { get; set; } = "";
    }
    public class WorkerThreadService 
    {
        private Thread? _Thread = null;

        public event EventHandler<WorkerThreadServiceCompletedEventArgs>? Completed;
        public Boolean IsExecuting
        {
            get { return _Thread != null; }
        }
        public DatabaseDefinitionFileGenerator? Generator { get; set; }

        public void StartThread()
        {
            _Thread = new Thread(async () => await this.ExecuteAsync());
            _Thread.IsBackground = true;
            _Thread.Priority = ThreadPriority.BelowNormal;
            _Thread.Start();
        }
        private async Task ExecuteAsync()
        {
            try
            {
                var e = new WorkerThreadServiceCompletedEventArgs();
                if (this.Generator != null)
                {
                    e.TableFileText = await this.Generator.CreateTableFile();
                    e.StoredProcedureFileText = await this.Generator.CreateStoredProcedureFile();
                    e.TableSchemeJsonText = await this.Generator.CreateTableSchemeJsonText();
                }
                this.Completed?.Invoke(this, e);
            }
            catch(Exception ex)
            {
                var msg = ex.ToString();
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                _Thread = null;
            }
        }
    }
}
