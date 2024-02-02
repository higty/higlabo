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
using static DbSharpApplication.ConfigData;

namespace DbSharpApplication
{
    /// <summary>
    /// ConnectionStringWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConnectionStringWindow : Window
    {
        public ConnectionStringWindow()
        {
            InitializeComponent();

            this.ConnectionStringListView.ItemsSource = ConfigData.Current.ConnectionStringList;
            this.ConnectionStringListView.SelectionChanged += ConnectionStringListView_SelectionChanged;
            this.EditPanel.Visibility = Visibility.Hidden;

            this.SetText();
        }

        private void ConnectionStringListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ConnectionStringListView.SelectedItem == null)
            {
                this.EditPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                this.EditPanel.Visibility = Visibility.Visible;
            }
        }

        private void SetText()
        {
            this.ConnectionStringListLabel.Content = T.Text.ConnectionString;
            this.ConnectionStringLabel.Content = T.Text.ConnectionString;
            this.AddButton.Content = T.Text.Add;
            this.DeleteButton.Content = T.Text.Delete;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = new ConnectionStringSetting();
            setting.Name = "Connection 1";
            ConfigData.Current.ConnectionStringList.Add(setting);
       
            this.ConnectionStringListView.ItemsSource = null;
            this.ConnectionStringListView.ItemsSource = ConfigData.Current.ConnectionStringList;
            this.ConnectionStringListView.SelectedItem = setting;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ConnectionStringListView.SelectedItem == null) { return; }
            ConfigData.Current.ConnectionStringList.Remove((ConnectionStringSetting)this.ConnectionStringListView.SelectedItem);

            this.ConnectionStringListView.ItemsSource = null;
            this.ConnectionStringListView.ItemsSource = ConfigData.Current.ConnectionStringList;
        }
    }
}
