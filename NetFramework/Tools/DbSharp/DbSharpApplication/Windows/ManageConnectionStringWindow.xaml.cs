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
using HigLabo.DbSharpApplication.Core;
using System.Collections.ObjectModel;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for ManageConnectionStringWindow.xaml
    /// </summary>
    public partial class ManageConnectionStringWindow : Window
    {
        public ManageConnectionStringWindow()
        {
            InitializeComponent();

            this.ConnectionStringListBox.ItemsSource = AValue.ConfigData.ConnectionStrings;
            AValue.ConfigData.ManageConnectionStringWindow.Initialize(this);
        }
        private void AddConnectionStringButton_Click(object sender, RoutedEventArgs e)
        {
            this.ConnectionStringListBox.SelectedIndex = -1;
            var w = new EditConnectionStringWindow();
            w.Saved += EditConnectionStringWindow_Saved;
            w.ShowDialog();
        }
        private void ConnectionStringListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.EditConnectionString();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.EditConnectionString();
        }
        private void EditConnectionString()
        {
            var ci = this.ConnectionStringListBox.SelectedValue as ConnectionStringInfo;
            var w = new EditConnectionStringWindow(ci);
            w.Saved += EditConnectionStringWindow_Saved;
            w.ShowDialog();
        }
        void EditConnectionStringWindow_Saved(object sender, EditConnectionStringWindowSavedEventArgs e)
        {
            var index = this.ConnectionStringListBox.SelectedIndex;
            if (index > -1)
            {
                AValue.ConfigData.ConnectionStrings[index] = e.ConnectionStringInfo;
            }
            else
            {
                AValue.ConfigData.ConnectionStrings.Add(e.ConnectionStringInfo);
            }
            AValue.ConfigData.Save();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.ConfirmDelete, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ci = this.ConnectionStringListBox.SelectedItem as ConnectionStringInfo;
                AValue.ConfigData.ConnectionStrings.Remove(ci);
            }
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
