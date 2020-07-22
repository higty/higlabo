using HigLabo.DbSharpApplication.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HigLabo.Core;
using HigLabo.Wpf.Converter;
using System.Windows.Media;
using HigLabo.DbSharp.Service;
using HigLabo.DbSharp.MetaData;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
            AValue.ConfigData.Save();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppCenter.Start("3e041512-b1c3-4a20-950f-e157db4e7f24", typeof(Analytics), typeof(Crashes));

            AValue.Initialize();
            this.InitializeConverter();
        }
        private void InitializeConverter()
        {
            this.SetProcessTypeBackgroundConverter();
            this.SetDatabaseObjectTypeBackgroundConverter();
        }
        private void SetProcessTypeBackgroundConverter()
        {
            var cv = this.FindResource("ProcessTypeBackgroundConverter") as StringBrushConverter;
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.ImportTable.ToString(), new SolidColorBrush(Color.FromRgb(255, 250, 220)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.ImportStoredProcedure.ToString(), new SolidColorBrush(Color.FromRgb(100, 180, 255)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.ImportUserDefinedTable.ToString(), new SolidColorBrush(Color.FromRgb(100, 255, 180)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.DeleteObject.ToString(), new SolidColorBrush(Color.FromRgb(230, 230, 200)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.GenerateCSharpFile.ToString(), new SolidColorBrush(Color.FromRgb(100, 255, 220)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.GenerateDataConvertFile.ToString(), new SolidColorBrush(Color.FromRgb(255, 180, 0)));
            cv.MappingData.Add(ImportObjectGenerateFileProcessType.Completed.ToString(), new SolidColorBrush(Color.FromRgb(255, 255, 255)));
        }
        private void SetDatabaseObjectTypeBackgroundConverter()
        {
            var cv = this.FindResource("DatabaseObjectTypeBackgroundConverter") as StringBrushConverter;
            cv.MappingData.Add(DatabaseObjectType.Table.ToString(), new SolidColorBrush(Color.FromRgb(255, 250, 220)));
            cv.MappingData.Add(DatabaseObjectType.StoredProcedure.ToString(), new SolidColorBrush(Color.FromRgb(200, 220, 255)));
            cv.MappingData.Add(DatabaseObjectType.UserDefinedTableType.ToString(), new SolidColorBrush(Color.FromRgb(200, 250, 220)));
        }
    }
}
