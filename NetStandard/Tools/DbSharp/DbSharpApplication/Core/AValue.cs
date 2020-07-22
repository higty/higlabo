using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using HigLabo.DbSharpApplication.Core;
using System.IO;
using HigLabo.Core;
using HigLabo.DbSharp.CodeGenerator;
using System.Globalization;
using System.Windows;
using HigLabo.Data;
using HigLabo.DbSharp.MetaData;
using HigLabo.Wpf.UI;

namespace HigLabo.DbSharpApplication.Core
{
    public class AValue
    {
        private static readonly String ErrorFolderPath = "\\ErrorLog\\";
        public static readonly String DialogFilter = "XMLファイル (*.xml)|*.xml|すべてのファイル (*.*)|*.*";
        public static ConfigData ConfigData { get; private set; }
        public static SchemaData SchemaData { get; private set; }
        public static void Initialize()
        {
            WindowStateInfo.DefaultIcon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Icon\\DbSharp.ico"));
            AValue.ConfigData = ConfigData.LoadConfigData();

            var l = AValue.ConfigData.RecentSchemaFiles.Where(el => String.IsNullOrEmpty(el.FilePath)).ToList();
            foreach (var item in l)
            {
                AValue.ConfigData.RecentSchemaFiles.Remove(item);
            }
            AValue.ConfigData.ChangeCultureInfo();

            if (String.IsNullOrEmpty(AValue.ConfigData.SchemaFilePath) == false)
            {
                try
                {
                    String xml = File.ReadAllText(AValue.ConfigData.SchemaFilePath);
                    AValue.LoadSchemaData(xml);
                }
                catch (DirectoryNotFoundException)
                {
                    AValue.ConfigData.SchemaFilePath = "";
                }
                catch (FileNotFoundException)
                {
                    AValue.ConfigData.SchemaFilePath = "";
                }
            }
            if (AValue.SchemaData == null)
            {
                AValue.SchemaData = new SchemaData();
            }
            AValue.CreateErrorLogFolder();
            Application.Current.DispatcherUnhandledException += DispatcherUnhandledException;
        }
        static void DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            AValue.AddErrorLog(e.Exception);
            var w = new MessageWindow(e.Exception.ToString());
            w.ShowDialog();
        }
        private static void CreateErrorLogFolder()
        {
            var path = Environment.CurrentDirectory + ErrorFolderPath;
            if (Directory.Exists(path) == true) { return; }
            try
            {
                Directory.CreateDirectory(path);
            }
            catch { }
        }
        public static void AddErrorLog(Exception exception)
        {
            try
            {
                var path = Environment.CurrentDirectory + ErrorFolderPath;
                var Now = DateTime.Now;
                File.WriteAllText(String.Format("{0}ErrorLog_{1}_{2}.txt"
                    , path, Now.ToString("yyyyMMdd_HHmmss_fff"), exception.GetType().Name)
                    , exception.ToString());
            }
            catch { }
        }
        public static ImageSource CreateImageSource(String url)
        {
            Uri u = null;

            if (String.IsNullOrEmpty(url) == false && Uri.TryCreate(url, UriKind.Absolute, out u) == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = u;
                image.EndInit();
                return image;
            }
            return null;
        }
        public static void LoadSchemaData(String xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText) == true)
            {
                AValue.SchemaData = new SchemaData();
                return;
            }
            AValue.SchemaData = AppEnvironment.Settings.XmlSerializer.Deserialize<SchemaData>(xmlText);
        }
        public static void EnsureGenerateSourceCodeFolder(String path)
        {
            var tablePath = Path.Combine(path, "Table");
            var tableStoredProcedurePath = Path.Combine(path, "TableStoredProcedure");
            var storedProcedurePath = Path.Combine(path, "StoredProcedure");
            var userDefinedTableTypePath = Path.Combine(path, "UserDefinedTableType");

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            if (Directory.Exists(tablePath) == false)
            {
                Directory.CreateDirectory(tablePath);
            }
            if (Directory.Exists(tableStoredProcedurePath) == false)
            {
                Directory.CreateDirectory(tableStoredProcedurePath);
            }
            if (Directory.Exists(storedProcedurePath) == false)
            {
                Directory.CreateDirectory(storedProcedurePath);
            }
            if (Directory.Exists(userDefinedTableTypePath) == false)
            {
                Directory.CreateDirectory(userDefinedTableTypePath);
            }
        }
        public static Boolean CanConnectToDatabase(DatabaseServer server, String connectionString)
        {
            switch (server)
            {
                case DatabaseServer.SqlServer:
                    {
                        var cn = new SqlServerDatabase(connectionString);
                        return cn.CanOpen();
                    }
                case DatabaseServer.MySql:
                    {
                        var cn = new MySqlDatabase(connectionString);
                        return cn.CanOpen();
                    }
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new NotImplementedException();
            }
        }
    }
}
