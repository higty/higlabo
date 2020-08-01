using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.NugetManagementApplication
{
    class Program
    {
        private static String ApiKey = "";
        private static readonly String NugetPackageFolderPath = "C:\\GitHub\\higty\\NugetPackage\\";

        static void Main(string[] args)
        {
            ApiKey = File.ReadAllText("C:\\Dev\\NugetPublishApiKey.txt").Trim();
            var ff = new List<String>();
            ff.Add("C:\\GitHub\\higty\\HigLabo\\NetStandard\\");
            var l = GetPackageList(ff);

            CreateUploadCommandFile(l);

            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
        private static List<String> GetPackageList(List<String> folderPathList)
        {
            List<String> l = new List<string>();
            var createTime = DateTimeOffset.MinValue;

            foreach (var folderPath in folderPathList)
            {
                var ff = new List<FileInfo>();
                foreach (var path in Directory.EnumerateFiles(NugetPackageFolderPath, "*.cmd", SearchOption.AllDirectories))
                {
                    var fi = new FileInfo(path);
                    ff.Add(fi);
                }
                var f = ff.OrderByDescending(el => el.CreationTime).FirstOrDefault();
                if (f != null)
                {
                    createTime = f.CreationTime;
                }

                foreach (var path in Directory.EnumerateFiles(folderPath, "*.nupkg", SearchOption.AllDirectories).OrderBy(el => el))
                {
                    if (path.Contains("Debug")) { continue; }
                    var fi = new FileInfo(path);
                    if (fi.Name.Contains("HigLabo") == false &&
                        fi.Name.Contains("DbSharp") == false) { continue; }
                    if (fi.CreationTime > createTime)
                    {
                        l.Add(fi.FullName);
                        Console.WriteLine(fi.FullName);
                    }
                }
            }
            return l;
        }
        private static void CreateUploadCommandFile(IEnumerable<String> pathList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var path in pathList)
            {
                var di = new DirectoryInfo(path);
                sb.AppendFormat("nuget push {0} {1} -Source https://api.nuget.org/v3/index.json", path, ApiKey);
                sb.AppendLine();
            }
            sb.AppendLine("pause");
            var text = sb.ToString();
            var fileName = String.Format("UploadPackage{0}.cmd", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Console.WriteLine(fileName);
            File.WriteAllText(Path.Combine(NugetPackageFolderPath, fileName), text);
        }
    }
}
