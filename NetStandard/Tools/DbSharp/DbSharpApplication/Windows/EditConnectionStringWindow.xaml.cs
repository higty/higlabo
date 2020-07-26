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
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for EditConnectionStringWindow.xaml
    /// </summary>
    public partial class EditConnectionStringWindow : Window
    {
        public event EventHandler<EditConnectionStringWindowSavedEventArgs> Saved;

        public EditConnectionStringWindow()
            : this(null)
        {
        }
        public EditConnectionStringWindow(ConnectionStringInfo info)
        {
            InitializeComponent();
            for (int i = 0; i < 24; i++)
            {
                this.TimeZoneComboBox.Items.Add(i - 11);
            }

            if (info != null)
            {
                this.NameTextBox.Text = info.Name;
                this.ConnectionStringTextBox.Text = info.ConnectionString;
                this.TimeZoneComboBox.SelectedValue = info.TimeZone;
            }
            AValue.ConfigData.EditConnectionStringWindow.Initialize(this);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("EditConnectionString Execute");

            if (AValue.CanConnectToDatabase(AValue.SchemaData.DatabaseServer, this.ConnectionStringTextBox.Text) == false)
            {
                MessageBox.Show(Properties.Resources.ConnectionStringInvalid);
                return;
            }
            
            this.OnSaved();
            this.Close();
        }
        private void OnSaved()
        {
            var eh = this.Saved;
            if (eh != null)
            {
                eh(this, new EditConnectionStringWindowSavedEventArgs(this.NameTextBox.Text, this.ConnectionStringTextBox.Text, (Int32)(this.TimeZoneComboBox.SelectedValue ?? 9)));
            }
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class EditConnectionStringWindowSavedEventArgs : EventArgs
    {
        public ConnectionStringInfo ConnectionStringInfo { get; private set; }
        public EditConnectionStringWindowSavedEventArgs(String name, String connectionString, Int32 timeZone)
        {
            var ci = new ConnectionStringInfo();
            ci.Name = name;
            ci.ConnectionString = connectionString;
            if (String.IsNullOrEmpty(ci.Name) == true)
            {
                ci.Name = ci.ConnectionString;
            }
            ci.TimeZone = timeZone;
            this.ConnectionStringInfo = ci;
        }
    }
}
