using HigLabo.CodeGenerator;
using HigLabo.Core;
using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DbSharpApplication
{
    /// <summary>
    /// StoredProcedureWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class StoredProcedureWindow : Window
    {
        private Boolean _IsResultSetLoaded = false;
        public StoredProcedureWindowViewModel ViewModel { get; set; }
        public GenerateSetting GenerateSetting
        {
            get { return this.ViewModel.GenerateSetting; }
        }
        public StoredProcedure StoredProcedure
        {
            get { return this.ViewModel.StoredProcedure; }
        }
        public List<DatabaseObject> TableList { get; init; } = new();

        public StoredProcedureWindow(StoredProcedureWindowViewModel viewModel)
        {
            InitializeComponent();

            this.SetText();

            this.ViewModel = viewModel;
            this.DataContext = viewModel;

			this.ResultSetListBox.SelectionChanged += ResultSetListBox_SelectionChanged;
            this.TableListBox.ItemsSource = this.TableList;

            this.SetParameterProperty();
        }

		private void SetText()
        {
            this.OutputFolderPathLabel.Content = T.Text.OutputFolder;
            this.NamespaceNameLabel.Content = T.Text.Namespace;
            this.DatabaseKeyLabel.Content = T.Text.DatabaseKey;
            this.LoadResultSetButton.Content = T.Text.LoadResultSet;
            this.GenerateButton.Content = T.Text.Generate + "(_G)";
            this.CloseButton.Content = T.Text.Close + "(_C)";
        }
        private void SetParameterProperty()
        {
            var sp = this.ViewModel.GenerateSetting.StoredProcedureList.FirstOrDefault(el => el.Name == this.StoredProcedure.Name);
            if (sp != null)
            {
                foreach (var item in sp.Parameters)
                {
                    var p = this.StoredProcedure.Parameters.Find(el => el.Name == item.Name);
                    if (p != null)
                    {
                        p.EnumName = item.EnumName;
                        p.ValueForTest = item.ValueForTest;
                    }
                }
            }
        }

        protected override async void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_IsResultSetLoaded == false)
            {
                _IsResultSetLoaded = true;
                var sp = this.ViewModel.GenerateSetting.StoredProcedureList.FirstOrDefault(el => el.Name == this.StoredProcedure.Name);
                if (sp != null && sp.ResultSets.Count > 0)
                {
                    try
                    {
                        await this.LoadResultSet();
                    }
                    catch
                    {
                        MessageBox.Show(T.Text.LoadResultSetFailed);
                    }
                }
            }
        }
        private async void LoadResultSetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.LoadResultSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(T.Text.LoadResultSetFailed + Environment.NewLine + ex.ToString());
            }
        }
        private async ValueTask LoadResultSet()
        {
            var reader = this.ViewModel.GenerateSetting.CreateDatabaseSchemaReader(this.ViewModel.ConnectionString);
            var d = this.StoredProcedure.Parameters.Where(el => String.IsNullOrEmpty(el.ValueForTest) == false)
                .ToDictionary(el => el.Name, el => el.ValueForTest as Object);
            await reader.SetResultSetsListAsync(this.StoredProcedure, d);

            var sp = this.ViewModel.GenerateSetting.StoredProcedureList.FirstOrDefault(el => el.Name == this.StoredProcedure.Name);
            if (sp != null)
            {
                foreach (var c in this.StoredProcedure.Parameters)
                {
                    var currentColumn = sp.Parameters.Find(el => el.Name == c.Name);
                    if (currentColumn != null)
                    {
                        c.AllowNull = currentColumn.AllowNull;
                        c.EnumName = currentColumn.EnumName;
                    }
                }
                for (int i = 0; i < this.StoredProcedure.ResultSets.Count; i++)
                {
                    if (i < sp.ResultSets.Count)
                    {
                        this.StoredProcedure.ResultSets[i].Name = sp.ResultSets[i].Name;
                        foreach (var c in this.StoredProcedure.ResultSets[i].Columns)
                        {
                            var currentColumn = sp.ResultSets[i].Columns.Find(el => el.Name == c.Name);
                            if (currentColumn != null)
                            {
                                c.AllowNull = currentColumn.AllowNull;
                                c.EnumName = currentColumn.EnumName;
                            }
                        }
                    }
                }
            }

            if (this.StoredProcedure.ResultSets.Count > 0)
            {
                this.ResultSetListBox.SelectedItem = this.StoredProcedure.ResultSets[0];
            }

            this.TableList.Clear();
            foreach (var item in await reader.GetTablesAsync())
            {
                this.TableList.Add(item);
            }

            this.LoadButtonPanel.Visibility = Visibility.Hidden;
            this.ResultSetPanel.Visibility = Visibility.Visible;

			this.SelectTable();
		}

		private void ResultSetNameTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var rs = this.ResultSetListBox.SelectedItem as StoredProcedureResultSetColumn;
            if (rs == null) { return; }

            var index = this.ResultSetListBox.SelectedIndex;
            if (e.Key == Key.Up)
            {
                index = index - 1;
            }
            else if (e.Key == Key.Down)
            {
                index = index + 1;
            }
            else { return; }
            if (index < 0 || index >= this.ResultSetListBox.Items.Count) { return; }

            rs.Name = this.ResultSetNameTextBox.Text;
            this.ResultSetListBox.SelectedIndex = index;
        }

		private void ResultSetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            this.SelectTable();
		}
        private void SelectTable()
        {
			var resultSet = this.ResultSetListBox.SelectedItem as StoredProcedureResultSetColumn;
			if (resultSet == null) { return; }
			var t = this.TableList.Find(el => el.Name == resultSet.Name);
			if (t == null) { return; }
			this.TableListBox.SelectedItem = t;
		}

		private async void SetTableColumnButton_Click(object sender, RoutedEventArgs e)
        {
            var t = this.TableListBox.SelectedItem as DatabaseObject;
            if (t == null) { return; }
			var resultSet = this.ResultSetListBox.SelectedItem as StoredProcedureResultSetColumn;
            if (resultSet == null) { return; }

			var tableName = t.Name;
			var reader = this.ViewModel.GenerateSetting.CreateDatabaseSchemaReader(this.ViewModel.ConnectionString);
            foreach (var c in await reader.GetColumnListAsync(tableName))
            {
                var rColumn = resultSet.Columns.Find(el => el.Name == c.Name);
                if (rColumn == null) { continue; }
                rColumn.AllowNull = c.AllowNull;
            }
		}
		private void SetAllowNullButton_Click(object sender, RoutedEventArgs e)
        {
            this.SetStoredProcedureColumnAllowNullValue(true);
        }
        private void SetNotNullButton_Click(object sender, RoutedEventArgs e)
        {
            this.SetStoredProcedureColumnAllowNullValue(false);
        }

        private void SetStoredProcedureColumnAllowNullValue(Boolean allowNull)
        {
            var sp = this.StoredProcedure;
            var rs = this.ResultSetListBox.SelectedItem as StoredProcedureResultSetColumn;
            if (rs == null) { return; }

            foreach (var item in rs.Columns)
            {
                item.AllowNull = allowNull;
            }

        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = this.ViewModel.GenerateSetting;
            var sp = this.StoredProcedure;

            if (setting.OutputFolderPath.IsNullOrEmpty())
            {
                MessageBox.Show("Please input output folder path.");
                return;
            }
            if (setting.NamespaceName.IsNullOrEmpty())
            {
                MessageBox.Show("Please input NamespaceName.");
                return;
            }
            if (setting.DatabaseKey.IsNullOrEmpty())
            {
                MessageBox.Show("Please input DatabaseKey.");
                return;
            }

            var folderPath = System.IO.Path.Combine(setting.OutputFolderPath, "StoredProcedure");
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch
            {
                MessageBox.Show($"Failed to create folder to {setting.OutputFolderPath}.");
                return;
            }
            var f = new StoredProcedureClassSourceCodeFileFactory(sp, setting.DatabaseKey);
            var sc = f.Create(folderPath, setting.NamespaceName);
            var filePath = System.IO.Path.Combine(folderPath, $"{sp.Name}.cs");
            using (var stm = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                stm.WriteLine("//Generated by DbSharpApplication.");
                stm.WriteLine("//https://github.com/higty/higlabo/tree/master/Net7");
                var cs = new CSharpSourceCodeGenerator(stm);
                cs.Write(sc.SourceCode);
            }
            setting.StoredProcedureList.RemoveAll(el => el.Name == sp.Name);
            setting.StoredProcedureList.Add(sp);
            ConfigData.Current.Save();

            this.Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
