using HtmlAgilityPack;
using NuGet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.NugetManagementApplication
{
    public class NugetPackageInfo
    {
        private static readonly Dictionary<String, String> FrameworkVersions = new Dictionary<string, string>();
        private static readonly Dictionary<String, FrameworkName> FrameworkNames = new Dictionary<string, FrameworkName>();

        public String ProjectFilePath { get; private set; }
        public String TargetFrameworkVersion { get; set; }

        public ManifestMetadata Nuspec { get; private set; }
        public PackageBuilder PackageBuilder { get; private set; }
        public List<NugetPackageInfo> DependencyPackages { get; private set; }

        static NugetPackageInfo()
        {
            InitializeFrameworkVersionMap();
            InitializeFrameworkNameMap();
        }
        private static void InitializeFrameworkVersionMap()
        {
            var d = FrameworkVersions;

            d["v1.1"] = "net11";
            d["v2.0"] = "net20";
            d["v3.5"] = "net35";
            d["v4.0"] = "net40";
            d["v4.0.3"] = "net403";
            d["v4.5"] = "net45";
            d["v4.5.1"] = "net451";
            d["v4.5.2"] = "net452";
            d["v4.6"] = "net46";
            d["v4.6.1"] = "net461";
            d["v4.6.2"] = "net462";


        }
        private static void InitializeFrameworkNameMap()
        {
            var d = FrameworkNames;

            d["v1.1"] = new FrameworkName(".NET Framework, Version=1.1");
            d["v2.0"] = new FrameworkName(".NET Framework, Version=2.0");
            d["v3.5"] = new FrameworkName(".NET Framework, Version=3.5");
            d["v4.0"] = new FrameworkName(".NET Framework, Version=4.0");
            d["v4.0.3"] = new FrameworkName(".NET Framework, Version=4.0.3");
            d["v4.5"] = new FrameworkName(".NET Framework, Version=4.5");
            d["v4.5.1"] = new FrameworkName(".NET Framework, Version=4.5.1");
            d["v4.5.2"] = new FrameworkName(".NET Framework, Version=4.5.2");
            d["v4.6"] = new FrameworkName(".NET Framework, Version=4.6");
            d["v4.6.1"] = new FrameworkName(".NET Framework, Version=4.6.1");
            d["v4.6.2"] = new FrameworkName(".NET Framework, Version=4.6.2");

        }

        public NugetPackageInfo()
        {
            this.Nuspec = new ManifestMetadata();
            this.PackageBuilder = new PackageBuilder();
            this.DependencyPackages = new List<NugetPackageInfo>();
        }
        public static NugetPackageInfo Create(String projectFilePath)
        {
            var n = new NugetPackageInfo();
            var folderPath = Path.GetDirectoryName(projectFilePath);
            var di = new DirectoryInfo(folderPath);
            var projectName = di.Name;

            n.Nuspec.Id = Path.GetFileNameWithoutExtension(projectFilePath);
            n.Nuspec.Authors = "Higty";
            n.Nuspec.Owners = "Higty";
            n.Nuspec.ProjectUrl = "https://github.com/higty/higlabo";
            n.Nuspec.Tags = n.Nuspec.Id;

            var AssemblyInfo_cs = File.ReadAllText(Path.Combine(folderPath, "Properties", "AssemblyInfo.cs"));
            {
                var sr = new StringReader(AssemblyInfo_cs);
                while (sr.Peek() > -1)
                {
                    var line = sr.ReadLine();
                    if (line.StartsWith("[assembly: AssemblyVersion("))
                    {
                        n.Nuspec.Version = line.ExtractString('"', '"');
                    }
                    if (line.StartsWith("[assembly: AssemblyDescription("))
                    {
                        n.Nuspec.Description = line.ExtractString('"', '"');
                    }
                    if (line.StartsWith("[assembly: AssemblyCopyright("))
                    {
                        n.Nuspec.Copyright = line.ExtractString('"', '"');
                    }
                }
            }
            if (n.Nuspec.Version.IsNullOrEmpty()) { return null; }
            if (n.Nuspec.Description.IsNullOrEmpty())
            {
                n.Nuspec.Description = "HigLabo library provide features of Mail, Ftp, Rss, ObjectMapper, Converter, ORM, ASP.NET Mvc...etc.See on GitHub(https://github.com/higty/higlabo)";
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(File.ReadAllText(projectFilePath));

            var outputTypeNode = doc.DocumentNode.SelectSingleNode("//propertygroup//outputtype");
            var outputType = outputTypeNode.InnerText;
            if (outputType != "Library") { return null; }

            var outputPathNode = doc.DocumentNode.SelectSingleNode("//propertygroup[contains(@condition, 'Release')]//outputpath");
            var dllFolderPath = String.Format("{0}\\{1}", di.FullName, outputPathNode.InnerText);
            if (Directory.Exists(dllFolderPath) == false) { return null; }

            var targetFrameworkVersionNode = doc.DocumentNode.SelectSingleNode("//propertygroup//targetframeworkversion");
            n.TargetFrameworkVersion = targetFrameworkVersionNode.InnerText;
            if (n.TargetFrameworkVersion.Contains("Pcl")) { return null; }

            //var dependencyNodes = doc.DocumentNode.SelectNodes("//itemgroup//projectreference");
            //if (dependencyNodes != null)
            //{
            //    foreach (var node in dependencyNodes)
            //    {
            //        var path = node.Attributes["Include"].Value;
            //        var u = new Uri(new Uri(projectFilePath), path);
            //        LoadDependencyPackages(n.DependencyPackages, u.LocalPath);
            //    }
            //    var dd = new List<PackageDependency>();
            //    foreach (var item in n.DependencyPackages)
            //    {
            //        VersionSpec sVersion = new VersionSpec();
            //        sVersion.MinVersion = new SemanticVersion(item.Nuspec.Version);
            //        sVersion.IsMinInclusive = true;
            //        dd.Add(new PackageDependency(item.Nuspec.Id, sVersion));
            //    }
            //    if (dd.Count > 0)
            //    {
            //        n.PackageBuilder.DependencySets.Add(new PackageDependencySet(FrameworkNames[n.TargetFrameworkVersion], dd));
            //    }
            //}

            //var referenceNodes = doc.DocumentNode.SelectNodes("//itemgroup//reference");
            //if (referenceNodes != null)
            //{
            //    var dd = new List<PackageDependency>();
            //    foreach (var node in referenceNodes)
            //    {
            //        if (node.Attributes["Include"] == null) { continue; }
            //        var include = node.Attributes["Include"].Value;
            //        var p = ProjectReferenceInfo.Parse(include);
            //        if (String.IsNullOrEmpty(p.Version)) { continue; }

            //        VersionSpec sVersion = new VersionSpec();
            //        sVersion.MinVersion = new SemanticVersion(p.Version);
            //        sVersion.IsMinInclusive = true;
            //        dd.Add(new PackageDependency(p.ID, sVersion));
            //    }
            //    if (dd.Count > 0)
            //    {
            //        n.PackageBuilder.DependencySets.Add(new PackageDependencySet(FrameworkNames[n.TargetFrameworkVersion], dd));
            //    }
            //}
            var ff = new List<ManifestFile>();
            var f = new ManifestFile();
            f.Source = projectName + ".dll";
            f.Target = "lib\\" + FrameworkVersions[n.TargetFrameworkVersion];
            ff.Add(f);
            n.PackageBuilder.PopulateFiles(dllFolderPath, ff);
            n.PackageBuilder.Populate(n.Nuspec);

            return n;
        }
        private static void LoadDependencyPackages(List<NugetPackageInfo> packages, String projectFilePath)
        {
            var dependencyPackage = NugetPackageInfo.Create(projectFilePath);
            if (dependencyPackage == null) { return; }

            packages.Add(dependencyPackage);
        }

        public void CreateNupkgFile(String filePath)
        {
            using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                this.PackageBuilder.Save(stream);
            }
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", this.Nuspec.Id, this.Nuspec.Version);
        }
    }
}
