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
