using HigLabo.Core;
using HigLabo.LanguageTextApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace BlobToEnumApplication
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ConfigData.Current = ConfigData.Load();

            this.ViewModel = new MainWindowViewModel();
            this.DataContext = this.ViewModel;
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.List);

            this.BlobContainerListView.ItemsSource = ConfigData.Current.ContainerList;
            this.BlobContainerListView.MouseDoubleClick += BlobContainerListView_MouseDoubleClick;

            this.GenerateLogListView.ItemsSource = this.ViewModel.GenerateLogList;

            this.Closing += MainWindow_Closing;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = new BlobContainerSetting();
            ConfigData.Current.ContainerList.Add(setting);
            this.BlobContainerListView.SelectedItem = setting;
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Edit);
        }
        private void BlobContainerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var setting = this.BlobContainerListView.SelectedItem as BlobContainerSetting;
            if (setting == null)
            {
                return;
            }
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Edit);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(T.Text.ConfirmDelete, "", MessageBoxButton.YesNo) != MessageBoxResult.Yes) { return; }

            ConfigData.Current.ContainerList.Remove((BlobContainerSetting)this.BlobContainerListView.SelectedItem);
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.List);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.List);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = this.BlobContainerListView.SelectedItem as BlobContainerSetting;
            if (setting == null)
            {
                MessageBox.Show(T.Text.PleaseSelect);
                return;
            }

            this.ViewModel.ProgressPercentage = 0;
            this.ViewModel.ProgressPercentageText = "0%";
            this.ViewModel.GenerateLogList.Clear();
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.Generating);

            var cm = new ClassGenerateCommand(setting);
            cm.PercentageProgressed += ClassGenerateCommand_PercentageProgressed;
            cm.Executed += ClassGenerateCommand_Executed;
            App.BackgroundService.AddCommand(cm);
        }

        private void ClassGenerateCommand_PercentageProgressed(object? sender, ClassGenerateCommand.PercentageProgressEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.ViewModel.ProgressPercentage = e.Percentage * 100;
                this.ViewModel.ProgressPercentageText = (e.Percentage * 100).ToString("##0") + "%";
            }));
        }

        private void ClassGenerateCommand_Executed(object? sender, ClassGenerateCommand.ExecutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.ViewModel.GenerateLogList.Add(e);
                this.GenerateLogListView.ScrollIntoView(e);
            }));
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            ConfigData.Current.Save();
        }

        private void GenerateCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SetDisplayMode(MainWindowDisplayMode.List);
        }
    }
}
