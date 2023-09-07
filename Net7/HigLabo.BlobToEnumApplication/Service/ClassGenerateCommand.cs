using BlobToEnumApplication;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using HigLabo.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace HigLabo.LanguageTextApplication
{
    public class ClassGenerateCommand : ServiceCommand
    {
        private static class RegexList
        {
            public static readonly Regex A_Z = new Regex("[a-z]{1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        private class BlobRecord
        {
            public string BlobName { get; set; }
            public string EnumName { get; set; }
            public string EnumValueName { get; set; }

            public BlobRecord(string blobName, string enumName, string enumValueName) 
            {
                this.BlobName = blobName;
                this.EnumName = enumName;
                this.EnumValueName = enumValueName;
            }
        }

        public record PercentageProgressEventArgs(double Percentage) { }
        public record ExecutedEventArgs(String Text) { }

        public event EventHandler<PercentageProgressEventArgs>? PercentageProgressed;
        public event EventHandler<ExecutedEventArgs>? Executed;

        public BlobContainerSetting Setting { get; set; } 

        public ClassGenerateCommand(BlobContainerSetting folderSetting)
        {
            this.Setting = folderSetting;
        }

        public override async ValueTask ExecuteAsync()
        {
            if (this.EnsureFolder() == false) { return; }

            var l = new List<BlobRecord>();
            try
            {
                var cl = new AzureBlobClient(this.Setting.ConnectionString);
                var container = cl.GetBlobContainer(this.Setting.ContainerName);

                await foreach (var item in container.GetBlobsAsync())
                {
                    var folderName = Path.GetDirectoryName(item.Name);
                    if (folderName == null) { continue; }

                    var enumName = this.Setting.ContainerName.ToPascalCase() + "__" + folderName.Replace("-", "_").Replace("\\", "__");
                    var enumValueName = Path.GetFileName(item.Name).Replace("-", "_").Replace(" ", "_").Replace(".", "__");
                    if (RegexList.A_Z.IsMatch(enumValueName[0].ToString()) == false)
                    {
                        enumValueName = "_" + enumValueName;
                    }

                    if (l.Exists(el => el.EnumName == enumName && el.EnumValueName == enumValueName) == false)
                    {
                        l.Add(new BlobRecord(item.Name, enumName, enumValueName));
                    }
                }
            }
            catch
            {
                this.Executed?.Invoke(this, new ExecutedEventArgs($"■Failed to get container the name is {this.Setting.ContainerName}. Please ensure connection string or container name."));
            }

            try
            {
                var totalEnumValueCount = l.Count;
                Double enumCount = 0;

                var sc = new SourceCode();
                sc.UsingNamespaces.Add("System");
                sc.Namespaces.Add(new Namespace(this.Setting.RootNamespaceName));
                var ns = sc.Namespaces[0];
                foreach (var kv in l.GroupBy(el => el.EnumName))
                {
                    var enumName = kv.Key;
                    this.Executed?.Invoke(this, new ExecutedEventArgs($"Enum added. {enumName}"));
                    
                    var e = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, enumName);
                    ns.Enums.Add(e);

                    var c = new Class(AccessModifier.Public, enumName + "Extensions");
                    c.Modifier.Static = true;
                    ns.Classes.Add(c);

                    var md = new Method(MethodAccessModifier.Public, "GetBlobName");
                    md.Modifier.Static = true;
                    md.ReturnTypeName = new TypeName("string");
                    md.Parameters.Add(new MethodParameter("this " + enumName, "value"));
                    c.Methods.Add(md);

                    var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (value)");
                    cb.CurlyBracket = true;
                    md.Body.Add(cb);

                    foreach (var item in kv)
                    {
                        var eValue = new EnumValue(item.EnumValueName);
                        e.Values.Add(eValue);

                        cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case {enumName}.{eValue}: return \"{item.BlobName}\";"));

                        this.PercentageProgressed?.Invoke(this, new PercentageProgressEventArgs(enumCount / totalEnumValueCount));
                        enumCount++;
                        this.Executed?.Invoke(this, new ExecutedEventArgs($"Enum value added. {item.EnumValueName}"));
                        Thread.Sleep(4);
                    }
                    cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"default: throw new InvalidOperationException();"));

                }
                this.Executed?.Invoke(this, new ExecutedEventArgs($"Generating file..."));
                Thread.Sleep(4);
                using (var stream = new StreamWriter(this.Setting.OutputFileName, false, Encoding.UTF8))
                {
                    var cs = new CSharpSourceCodeGenerator(stream);
                    cs.Write(sc);
                }
                this.Executed?.Invoke(this, new ExecutedEventArgs($"File generated to {this.Setting.OutputFileName}."));
                this.PercentageProgressed?.Invoke(this, new PercentageProgressEventArgs(1));
            }
            catch (Exception ex)
            {
                this.Executed?.Invoke(this, new ExecutedEventArgs($"■File generation failed. {Environment.NewLine}{ex.ToString()}"));
            }

        }
        private bool EnsureFolder()
        {
            var folderPath = Path.GetDirectoryName(this.Setting.OutputFileName);
            if (folderPath == null)
            {
                this.Executed?.Invoke(this, new ExecutedEventArgs($"File path is invalid."));
                return false;
            }

            if (File.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
                this.Executed?.Invoke(this, new ExecutedEventArgs($"Folder created. {folderPath}"));
            }
            return true;
        }
    }
}
