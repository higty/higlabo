using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using System.Threading;
using HigLabo.Wpf.UI;

namespace HigLabo.DbSharpApplication.Core
{
    public class ConfigData : INotifyPropertyChanged
    {
        public static String DefaultFilePath = Environment.CurrentDirectory + "\\Config.xml";
        public event PropertyChangedEventHandler PropertyChanged;

        private String _CultureName = "";
        private String _SchemaFilePath = "";

        public String CultureName
        {
            get { return this._CultureName; }
            set { this.SetPropertyValue(ref _CultureName, value, this.PropertyChanged); }
        }
        public String SchemaFilePath
        {
            get { return this._SchemaFilePath; }
            set { this.SetPropertyValue(ref _SchemaFilePath, value, this.PropertyChanged); }
        }
        public ObservableCollection<SchemaFileInfo> RecentSchemaFiles { get; private set; }
        public ObservableCollection<ConnectionStringInfo> ConnectionStrings { get; private set; }
        public MainWindowStateInfo MainWindow { get; set; }
        public WindowStateInfo GenerateSourceCodeWindow { get; set; }
        public WindowStateInfo ManageConnectionStringWindow { get; set; }
        public WindowStateInfo EditConnectionStringWindow { get; set; }
        public WindowStateInfo ImportObjectWindow { get; set; }
        public WindowStateInfo DeleteObjectWindow { get; set; }
        public WindowStateInfo ImportObjectGenerateFileWindow { get; set; }
        public WindowStateInfo ProgressWindow { get; set; }
        public WindowStateInfo MessageWindow { get; set; }
        public WindowStateInfo ManageIgnoreObjectWindow { get; set; }

        public ConfigData()
        {
            this.CultureName = "en-US";
            this.RecentSchemaFiles = new ObservableCollection<SchemaFileInfo>();
            this.ConnectionStrings = new ObservableCollection<ConnectionStringInfo>();

            this.MainWindow = new MainWindowStateInfo(800, 600);
            this.ManageConnectionStringWindow = new WindowStateInfo(700, 400);
            this.EditConnectionStringWindow = new WindowStateInfo(500, 160);
            this.ImportObjectWindow = new WindowStateInfo(900, 700);
            this.DeleteObjectWindow = new WindowStateInfo(800, 500);
            this.ImportObjectGenerateFileWindow = new WindowStateInfo(600, 300);
            this.GenerateSourceCodeWindow = new WindowStateInfo(800, 600);
            this.ProgressWindow = new WindowStateInfo(900, 700);
            this.MessageWindow = new WindowStateInfo(700, 400);
            this.ManageIgnoreObjectWindow = new WindowStateInfo(800, 600);
        }
        public void Save()
        {
            this.Save(DefaultFilePath);
        }
        public void Save(String filePath)
        {
            if (String.IsNullOrEmpty(AValue.ConfigData.SchemaFilePath) == false)
            {
                var fi = AValue.ConfigData.RecentSchemaFiles.FirstOrDefault(el => el.FilePath == AValue.ConfigData.SchemaFilePath);
                if (fi != null)
                {
                    //順番を入れ替えるため削除して追加
                    AValue.ConfigData.RecentSchemaFiles.Remove(fi);
                }
                if (fi == null)
                {
                    fi = new SchemaFileInfo();
                    fi.FilePath = AValue.ConfigData.SchemaFilePath;
                }
                AValue.ConfigData.RecentSchemaFiles.Insert(0, fi);
            }
            File.WriteAllText(filePath, AppEnvironment.Settings.XmlSerializer.Serialize(this));
        }
        public static ConfigData LoadConfigData()
        {
            return LoadConfigData(DefaultFilePath);
        }
        public static ConfigData LoadConfigData(String filePath)
        {
            if (File.Exists(filePath) == true)
            {
                var xmlText = File.ReadAllText(filePath);
                try
                {
                    return AppEnvironment.Settings.XmlSerializer.Deserialize<ConfigData>(xmlText);
                }
                catch
                {
                    return new ConfigData();
                }
            }
            else
            {
                return new ConfigData();
            }
        }

        public void ChangeCultureInfo()
        {
            ChangeCultureInfo(this.CultureName);
        }
        public void ChangeCultureInfo(String cultureName)
        {
            this.CultureName = cultureName;

            try
            {
                var ci = new CultureInfo(this.CultureName);
                Thread.CurrentThread.CurrentUICulture = ci;
                Properties.Resources.Culture = CultureInfo.CurrentUICulture;
            }
            catch { }
        }
        public void MoveConnectionStringToFirst(ConnectionStringInfo info)
        {
            if (this.ConnectionStrings.Remove(info) == true)
            {
                this.ConnectionStrings.Insert(0, info);
            }
            var f = this.GetCurrentRecentSchemaFile();
            if (f != null)
            {
                f.ConnectionStringName = info.Name;
            }
            this.Save();
        }

        public String GetSqlScriptOutputDirectoryPath()
        {
            var fi = this.GetCurrentRecentSchemaFile();
            return fi.SqlScriptOutputDirectoryPath;
        }
        public void SetSqlScriptOutputDirectoryPath(String path)
        {
            var fi = this.GetCurrentRecentSchemaFile();
            fi.SqlScriptOutputDirectoryPath = path;
        }
        public String GetOutputDirectoryPath()
        {
            var fi = this.GetCurrentRecentSchemaFile();
            return fi.OutputDirectoryPath;
        }
        public void SetOutputDirectoryPath(String path)
        {
            var fi = this.GetCurrentRecentSchemaFile();
            if (fi != null)
            {
                fi.OutputDirectoryPath = path;
            }
        }
        public SchemaFileInfo GetCurrentRecentSchemaFile()
        {
            return this.RecentSchemaFiles.FirstOrDefault(el => el.FilePath == AValue.ConfigData.SchemaFilePath);
        }
    }
}
