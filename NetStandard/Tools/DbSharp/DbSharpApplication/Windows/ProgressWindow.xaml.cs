using HigLabo.DbSharp.Service;
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        private ObservableCollection<ProcessProgressEventArgs> _ProcessProgressExecutedEventArgsList = new ObservableCollection<ProcessProgressEventArgs>();
        private Object _ProcessProgressExecutedEventArgsListLock = new object();
        private CommandService _CommandService = null;
        private Boolean _IsExecuting = true;

        public ProgressWindow(CommandService commandService)
        {
            InitializeComponent();
            this.Closing += ProgressWindow_Closing;
            this.ProgressListBox.ItemsSource = _ProcessProgressExecutedEventArgsList;
            BindingOperations.EnableCollectionSynchronization(_ProcessProgressExecutedEventArgsList, _ProcessProgressExecutedEventArgsListLock);

            _CommandService = commandService;
            var sv = commandService;
            sv.ProcessProgress += CommandService_ProcessProgress;
            sv.Completed += CommandService_Completed;

            AValue.ConfigData.ImportObjectWindow.Initialize(this);

            this.Loaded += ProgressWindow_Loaded;
        }

        void ProgressWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _CommandService.Start();
        }

        void ProgressWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_IsExecuting == true)
            {
                e.Cancel = true;
                MessageBox.Show(Properties.Resources.CommandServiceExecuting);
                return;
            }
        }
        void CommandService_ProcessProgress(object sender, ProcessProgressEventArgs e)
        {
            this.Dispatcher.Invoke(() => this.CommandService_ProcessProgress_Dispatcher(sender, e));
        }
        void CommandService_ProcessProgress_Dispatcher(object sender, ProcessProgressEventArgs e)
        {
            _ProcessProgressExecutedEventArgsList.Add(e);
            this.ProgressListBox.ScrollIntoView(e);
        }
        void CommandService_Completed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() => this.CommandService_Completed_Dispatcher(sender, e));
        }
        void CommandService_Completed_Dispatcher(object sender, EventArgs e)
        {
            var ea = new ProcessProgressEventArgs(Properties.Resources.Completed, 1);
            _ProcessProgressExecutedEventArgsList.Add(ea);
            this.ProgressListBox.ScrollIntoView(ea);

            _IsExecuting = false;
            this.QuitButton.IsEnabled = true;
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
