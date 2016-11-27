using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using NuGet;
using HtmlAgilityPack;

namespace HigLabo.NugetManagementApplication
{
    class Program
    {
        private static String ApiKey = "";
        private static readonly String RootFolderPath = "C:\\GitHub\\higty\\HigLabo\\";
        private static readonly String NugetPackageFolderPath = "C:\\GitHub\\higty\\HigLabo\\NugetPackage\\";

        static void Main(string[] args)
        {
            ApiKey = args[0];
            CreatePackage();
            CreateUploadCommandFile();

            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
        private static void CreatePackage()
        {
            foreach (var path in Directory.EnumerateFiles(RootFolderPath, "*.csproj", SearchOption.AllDirectories).OrderBy(el => el))
            {
                if (path.Contains("_Pcl_")) { continue; }
                if (path.Contains(".Test.")) { continue; }
                var package = NugetPackageInfo.Create(path);
                if (package == null) { continue; }
                if (package.PackageBuilder.Files.Count == 0) { continue; }
                var fileName = String.Format("C:\\GitHub\\higty\\HigLabo\\NugetPackage\\{0}.{1}.nupkg", package.Nuspec.Id, package.Nuspec.Version);
                if (File.Exists(fileName) == false)
                {
                    package.CreateNupkgFile(fileName);
                    Console.WriteLine("Created: " + fileName);
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        private static void CreateUploadCommandFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var path in Directory.EnumerateFiles(NugetPackageFolderPath, "*.nupkg", SearchOption.TopDirectoryOnly).OrderBy(el => el))
            {
                var di = new DirectoryInfo(path);
                var fileName = Path.GetFileName(path);
                sb.AppendFormat("nuget push {0} -Source https://nuget.org -ApiKey {1}", fileName, ApiKey).AppendLine();
            }
            sb.AppendLine("pause");
            var text = sb.ToString();
            File.WriteAllText(Path.Combine(NugetPackageFolderPath, "UploadPackage.cmd"), text);
        }
    }
}
