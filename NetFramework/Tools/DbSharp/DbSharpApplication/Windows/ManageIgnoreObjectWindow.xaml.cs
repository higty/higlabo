using HigLabo.DbSharp.MetaData;
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

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// ManageIgnoreObjectWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ManageIgnoreObjectWindow : Window
    {
        private ObservableCollection<CheckedItem<DatabaseObject>> _IgnoreObjects = new ObservableCollection<CheckedItem<DatabaseObject>>();
        
        public ManageIgnoreObjectWindow(IEnumerable<DatabaseObject> ignoreObjects)
        {
            InitializeComponent();

            this.IgnoreObjectListBox.ItemsSource = _IgnoreObjects;

            foreach (var item in ignoreObjects)
            {
                var existItem = AValue.SchemaData.IgnoreObjects.FirstOrDefault(el => el.Name == item.Name);
                if (existItem != null) { continue; }
                AValue.SchemaData.IgnoreObjects.Add(item);
            }
            InitializeIgnoreObjects();
            AValue.ConfigData.ManageIgnoreObjectWindow.Initialize(this);
        }
        private void InitializeIgnoreObjects()
        {
            foreach (var item in AValue.SchemaData.IgnoreObjects.Select(el => CheckedItem.Create(el)))
            {
                _IgnoreObjects.Add(item);
            }
        }

        private void IgnoreObjectSelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _IgnoreObjects)
            {
                item.IsChecked = this.IgnoreObjectSelectAllCheckBox.IsChecked == true;
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var l = _IgnoreObjects.Where(el => el.IsChecked).ToList();
            foreach (var item in l)
            {
                _IgnoreObjects.Remove(item);
                AValue.SchemaData.IgnoreObjects.Remove(item.Item);
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
