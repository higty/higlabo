using CsvHelper;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using HigLabo.Service;
using LanguageTextApplication.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.LanguageTextApplication
{
    public class ClassGenerateCommand : ServiceCommand
    {
        private class CsvLine
        {
            public String Language { get; set; } = "";
            public String Key { get; set; } = "";
            public String Value { get; set; } = "";

            public CsvLine(String Language, String Key, String Value)
            {
                this.Language = Language;
                this.Key = Key;
                this.Value = Value;
            }

            public override string ToString()
            {
                return $"{Language},{Key},{Value}";
            }
        }
        public record ExecutedEventArgs(String Text) { }
        public event EventHandler<ExecutedEventArgs>? Executed;

        public FolderSetting FolderSetting { get; set; } 

        public ClassGenerateCommand(FolderSetting folderSetting)
        {
            this.FolderSetting = folderSetting;
        }

        public override async Task ExecuteAsync()
        {
            var l = new List<CsvLine>();

            var copyFolderPath = this.EnsureFolder();

            foreach (var filePath in System.IO.Directory.EnumerateFiles(this.FolderSetting.SourceFolderPath).OrderBy(el => el))
            {
                if (Path.GetExtension(filePath).ToLower() != ".csv") { continue; }

                try
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            await csv.ReadAsync();
                            var language = csv.GetField(1)!;

                            while (await csv.ReadAsync())
                            {
                                var key = csv.GetField(0)!;
                                var value = csv.GetField(1)!;

                                var r = l.Find(el => el.Language == language && el.Key == key);
                                if (r == null)
                                {
                                    r = new CsvLine(language, key, value);
                                    l.Add(r);
                                }
                                else
                                {
                                    r.Value = value;
                                }

                                this.Executed?.Invoke(this, new ExecutedEventArgs(r.ToString()));
                            }
                        }
                    }

                    var fileName = Path.GetFileName(filePath);
                    File.Copy(filePath, Path.Combine(copyFolderPath, fileName));
                }
                catch
                {

                }
            }
            this.GenerateFile(copyFolderPath, l);
        }
        private string EnsureFolder()
        {
            var now = DateTime.Now;
            var generatedFolderPath = Path.Combine(this.FolderSetting.SourceFolderPath, "Generated");
            if (File.Exists(generatedFolderPath) == false)
            {
                Directory.CreateDirectory(generatedFolderPath);
                this.Executed?.Invoke(this, new ExecutedEventArgs(generatedFolderPath));
            }
            var copyFolderPath = Path.Combine(this.FolderSetting.SourceFolderPath, "Generated", now.ToString("yyyyMMdd_HHmmss"));
            if (File.Exists(copyFolderPath) == false)
            {
                Directory.CreateDirectory(copyFolderPath);
                this.Executed?.Invoke(this, new ExecutedEventArgs(copyFolderPath));
            }
            return copyFolderPath;
        }

        private void GenerateFile(String copyFolderPath, List<CsvLine> recordList)
        {
            var l = recordList;
            var languageList = new List<String>();
            languageList.AddRange(l.GroupBy(el => el.Language).Select(el => el.Key));

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("HigLabo.Core");

            var ns = new Namespace(this.FolderSetting.RootNamespaceName);
            sc.Namespaces.Add(ns);

            var cText = new Class(AccessModifier.Public, this.FolderSetting.ClassName);
            ns.Classes.Add(cText);
            cText.BaseClass = new TypeName("LanguageText");

            {
                var p = new Property("string[]", "LanguageList");
                cText.Properties.Add(p);
                p.Modifier.AccessModifier = MethodAccessModifier.Protected;
                p.Modifier.Polymophism = MethodPolymophism.Override;
                var languageArrayCode = String.Join(",", languageList.Select(el => $"\"{el}\""));
                p.Get!.Body.Add(SourceCodeLanguage.CSharp, "return new string[] { " + languageArrayCode + " };");
                p.Set = null;
            }

            foreach (var kv in l.GroupBy(el => el.Key))
            {
                var key = kv.Key;
                var p = new Property("string", key);
                cText.Properties.Add(p);

                p.Get!.Body.Add(SourceCodeLanguage.CSharp, "var language = this.GetLanguage();");
                var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (language)");
                cb.CurlyBracket = true;
                p.Get!.Body.Add(cb);
                p.Set = null;

                foreach (var language_Value in kv.GroupBy(el => el.Language))
                {
                    var language = language_Value.Key;
                    foreach (var line in language_Value)
                    {
                        cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case \"{language}\": return \"{line.Value}\";"));
                    }
                }
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default:throw SwitchStatementNotImplementException.Create(language);"));
            }

            {
                var md = new Method(MethodAccessModifier.Public, "GetText");
                cText.Methods.Add(md);
                md.Modifier.Polymophism = MethodPolymophism.Override;
                md.ReturnTypeName = new TypeName("string");
                md.Parameters.Add(new MethodParameter("string", "key"));
                var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (key)");
                md.Body.Add(cb);
                cb.CurlyBracket = true;
                foreach (var kv in l.GroupBy(el => el.Key))
                {
                    var key = kv.Key;
                    cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case \"{key}\": return this.{key};"));
                }
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"default: return \"\";"));
            }

            var filePath = Path.Combine(copyFolderPath, this.FolderSetting.CSharpFileName);
            using (var writer = new StreamWriter(filePath))
            {
                var g = new CSharpSourceCodeGenerator(writer);
                g.Write(sc);
                g.Flush();

                writer.Close();
            }
            if (this.FolderSetting.CopyFilePath.IsNullOrEmpty() == false)
            {
                try
                {
                    File.Copy(filePath, this.FolderSetting.CopyFilePath, true);
                }
                catch { }
            }

            this.Executed?.Invoke(this, new ExecutedEventArgs(filePath));

            this.Executed?.Invoke(this, new ExecutedEventArgs("Output folder: " + copyFolderPath));
        }
    }
}
