using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace HigLabo.Nuget
{
    public class NugetManager
    {
        public String FolderPath { get; private set; }

        public NugetManager(String folderPath)
        {
            this.FolderPath = folderPath;
        }
        private List<string> CreateHigLaboProjectNames()
        {
            var l = new List<string>();

            l.Add("HigLabo.CodeGenerator");
            l.Add("HigLabo.CodeGenerator.Json");
            l.Add("HigLabo.Converter");
            l.Add("HigLabo.Core");
            l.Add("HigLabo.Data");
            l.Add("HigLabo.Data.MySql");
            l.Add("HigLabo.Data.Oracle");
            l.Add("HigLabo.Data.PostgreSql");
            l.Add("HigLabo.Data.SQLite");
            l.Add("HigLabo.Mail");
            l.Add("HigLabo.Mapper");
            l.Add("HigLabo.Mime");
            l.Add("HigLabo.Net");
            l.Add("HigLabo.Net.Ftp");
            l.Add("HigLabo.Net.Twitter");
            l.Add("HigLabo.Rss");
            l.Add("HigLabo.Web");
            l.Add("HigLabo.Wpf");

            return l;
        }
        private List<string> CreateHigLaboDbSharpProjectNames()
        {
            var l = new List<string>();

            l.Add("HigLabo.DbSharp");
            l.Add("HigLabo.DbSharp.SqlServer");

            return l;
        }
        public void CopyDll()
        {
            var targetFolderPath = Path.Combine(this.FolderPath, @"Tools\Nuget\HigLabo.Nuget\Reference\_Net_4_5\");
            foreach (var item in CreateHigLaboProjectNames())
            {
                var fileName = item + ".dll";
                var srcPath = Path.Combine(this.FolderPath, item, @"bin\Release\_Net_4_5\", fileName);
                var targetPath = Path.Combine(targetFolderPath, fileName);
                File.Copy(srcPath, targetPath, true);
            }
            foreach (var item in CreateHigLaboDbSharpProjectNames())
            {
                var fileName = item + ".dll";
                var srcPath = Path.Combine(this.FolderPath, @"Tools\DbSharp\", item, @"bin\Release\", fileName);
                var targetPath = Path.Combine(targetFolderPath, fileName);
                File.Copy(srcPath, targetPath, true);
            }
        }
        public void CreatePackageFile()
        {
            this.CreatePackageFile("CoreLibrary");
            this.CreatePackageFile("Mail");
            this.CreatePackageFile("DbSharp");
            this.CreatePackageFile("DbSharp.SqlServer");
            this.CreatePackageFile("Net.Twitter");
            this.CreatePackageFile("Web");
            this.CreatePackageFile("Wpf");
        }
        private void CreatePackageFile(String packageName)
        {
            var exePath = Path.Combine(this.FolderPath, @"Tools\Nuget\nuget.exe");
            var packagePath = String.Format(@"Tools\Nuget\HigLabo.Nuget\HigLabo.{0}._Net_4_5.nuspec", packageName);
            var nuspecPath = Path.Combine(this.FolderPath, packagePath);

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = exePath;
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = "pack " + nuspecPath;
            Process process = Process.Start(startInfo);
            process.WaitForExit();

        }
        public void UploadPackageFiles()
        {
            //this.UploadPackageFiles("CoreLibrary", "1.0.1.0");
            this.UploadPackageFiles("DbSharp", "1.1.0.2");
            this.UploadPackageFiles("DbSharp.SqlServer", "1.1.0.2");
            //this.UploadPackageFiles("Mail", "1.0.1.1");
            //this.UploadPackageFiles("Net.Twitter", "1.0.0.0");
            //this.UploadPackageFiles("Web", "1.0.1.1");
            //this.UploadPackageFiles("Wpf", "1.0.1.1");
        }
        public void UploadPackageFiles(String packageName, String version)
        {
            var exePath = Path.Combine(this.FolderPath, @"Tools\Nuget\nuget.exe");
            var pkgName = String.Format(@"HigLabo.{0}._Net_4_5.{1}.nupkg", packageName, version);
            var apiKey = File.ReadAllText(this.FolderPath + @"Tools\Nuget\NugetKey.txt");
            
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = exePath;
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = String.Format("push {0} {1}", pkgName, apiKey);
            Process process = Process.Start(startInfo);
            process.WaitForExit();
        }
    }
}
