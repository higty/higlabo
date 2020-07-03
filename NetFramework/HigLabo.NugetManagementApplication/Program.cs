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
            var l = CreatePackage();
            if (l.Count > 0)
            {
                CreateUploadCommandFile(l);
            }

            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
        private static List<String> CreatePackage()
        {
            List<String> l = new List<string>();

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
                    l.Add(fileName);
                    package.CreateNupkgFile(fileName);
                    Console.WriteLine("Created: " + fileName);
                }
                System.Threading.Thread.Sleep(100);
            }
            return l;
        }
        private static void CreateUploadCommandFile(IEnumerable<String> pathList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var path in pathList)
            {
                var di = new DirectoryInfo(path);
                sb.AppendFormat("nuget push {0} -Source https://www.nuget.org/api/v2/package -ApiKey {1}"
                    , Path.GetFileName(path), ApiKey);
                sb.AppendLine();
            }
            sb.AppendLine("pause");
            var text = sb.ToString();
            var fileName = String.Format("UploadPackage{0}.cmd", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            File.WriteAllText(Path.Combine(NugetPackageFolderPath, fileName), text);
        }
    }
}
