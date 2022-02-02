using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using HigLabo.DbSharpApplication.Core;
using HigLabo.Wpf;
using Microsoft.AppCenter.Analytics;
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
    public partial class CopyResultSetWindow : Window
    {
        private ObservableCollection<StoredProcedure> _StoredProcedures = new ObservableCollection<StoredProcedure>();

        public CopyResultSetWindow(StoredProcedure storedProcedure)
        {
            InitializeComponent();
            AValue.ConfigData.CopyResultSetWindow.Initialize(this);

            this.TargetStoredProcedureComboBox.ItemsSource = _StoredProcedures;
            this.SourceStoredProcedureComboBox.ItemsSource = _StoredProcedures;

            _StoredProcedures.AddRange(AValue.SchemaData.StoredProcedures.Where(el => el.ResultSets.Count > 0).OrderBy(el => el.Name));
            this.SourceStoredProcedureResultSetComboBox.SelectedItem = storedProcedure;
            this.TargetStoredProcedureComboBox.SelectedItem = storedProcedure;
        }
        private void SourceStoredProcedureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sp = this.SourceStoredProcedureComboBox.SelectedItem as StoredProcedure;
            if (sp == null || sp.ResultSets.Count == 0) { return; }
            this.SourceStoredProcedureResultSetComboBox.SelectedItem = sp.ResultSets[0];
        }
        private void TargetStoredProcedureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sp = this.TargetStoredProcedureComboBox.SelectedItem as StoredProcedure;
            if (sp == null || sp.ResultSets.Count == 0) { return; }
            this.TargetStoredProcedureResultSetComboBox.SelectedItem = sp.ResultSets[0];
    
            this.SetComboBoxIndex(sp);
        }
        private void SetComboBoxIndex(StoredProcedure storedProcedure)
        {
            var count = 1;
            var previousList = new List<StoredProcedure>();

            while (storedProcedure.Name.Length > count)
            {
                var s = storedProcedure.Name.Substring(0, count);
                var spList = _StoredProcedures.Where(el => el.Name != storedProcedure.Name && el.Name.StartsWith(s, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(el => el.Name).ToList();
                if (spList.Count == 0)
                {
                    this.SourceStoredProcedureComboBox.SelectedItem = previousList[previousList.Count - 1];
                    return;
                }
                else if (spList.Count == 1)
                {
                    this.SourceStoredProcedureComboBox.SelectedItem = spList[0];
                    return;
                }
                else if (spList.Count > 1)
                {
                    previousList = spList;
                }
                count++;
                if (count > 1000) { break; }
            }
            this.SourceStoredProcedureComboBox.SelectedItem = _StoredProcedures.FirstOrDefault();
        }
        private void TargetStoredProcedureResultSetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rs = this.TargetStoredProcedureResultSetComboBox.SelectedItem as StoredProcedureResultSetColumn;

            this.SetResultSetIndex(rs);
        }
        private void SetResultSetIndex(StoredProcedureResultSetColumn resultSet)
        {
            var sp = this.SourceStoredProcedureComboBox.SelectedItem as StoredProcedure;
            if (sp == null) { return; }
            var rs = resultSet;
            if (resultSet == null) { return; }

            foreach (var item in sp.ResultSets)
            {
                if (item.Name == rs.Name)
                {
                    this.SourceStoredProcedureResultSetComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("CopyResultSet Execute");

            if (this.SourceStoredProcedureResultSetComboBox.SelectedItem == null ||
                this.TargetStoredProcedureResultSetComboBox.SelectedItem == null)
            {
                MessageBox.Show(Properties.Resources.PleaseSelectItem);
                return;
            }
            var sSP = this.SourceStoredProcedureComboBox.SelectedItem as StoredProcedure;
            var tSP = this.TargetStoredProcedureComboBox.SelectedItem as StoredProcedure;
            var sResultSet = (this.SourceStoredProcedureResultSetComboBox.SelectedItem as StoredProcedureResultSetColumn);
            var tResultSet = (this.TargetStoredProcedureResultSetComboBox.SelectedItem as StoredProcedureResultSetColumn);

            tResultSet.Name = sResultSet.Name;
            foreach (var c in tResultSet.Columns)
            {
                var sColumn = sResultSet.Columns.Find(el => el.Name == c.Name);
                if (sColumn == null) { continue; }
                c.AllowNull = sColumn.AllowNull;
                c.EnumName = sColumn.EnumName;
            }
            this.StatusMessage.Content = String.Format("{0} Copy executed! [{1}.{2} --> {3}.{4}]"
                , DateTime.Now.ToString("HH:mm:ss")
                , sSP.Name, sResultSet.Name
                , tSP.Name, tResultSet.Name);
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
