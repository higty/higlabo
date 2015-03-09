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
            l.Add("HigLabo.CodeGenerator.Twitter");
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
        public void CopyDll()
        {
            var l = CreateHigLaboProjectNames();
            var targetFolderPath = Path.Combine(this.FolderPath, @"Tools\Nuget\HigLabo.Nuget\Reference\_Net_4_5\");
            for (int i = 0; i < l.Count; i++)
            {
                var fileName = l[i] + ".dll";
                var path = Path.Combine(this.FolderPath, l[i], @"bin\Release\_Net_4_5\", fileName);

                if (File.Exists(path) == true)
                {
                    File.Copy(path, Path.Combine(targetFolderPath, fileName), true);
                }
            }

            var dbSharpFilePath = Path.Combine(this.FolderPath, @"Tools\DbSharp\HigLabo.DbSharp\bin\Release\HigLabo.DbSharp.dll");
            File.Copy(dbSharpFilePath, Path.Combine(targetFolderPath, "HigLabo.DbSharp.dll"), true);
        }
        public void CreatePackageFile()
        {
            this.CreatePackageFile("CoreLibrary");
            this.CreatePackageFile("Mail");
            this.CreatePackageFile("DbSharp");
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
            this.UploadPackageFiles("CoreLibrary");
            this.UploadPackageFiles("Mail");
            this.UploadPackageFiles("DbSharp");
            //this.UploadPackageFiles("Net.Twitter");
            this.UploadPackageFiles("Web");
            this.UploadPackageFiles("Wpf");
        }
        public void UploadPackageFiles(String packageName)
        {
            var exePath = Path.Combine(this.FolderPath, @"Tools\Nuget\nuget.exe");
            var pkgName = String.Format(@"HigLabo.{0}._Net_4_5.1.0.0.0.nupkg", packageName);
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
