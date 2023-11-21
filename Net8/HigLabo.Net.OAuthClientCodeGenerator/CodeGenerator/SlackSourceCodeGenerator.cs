using AngleSharp;
using AngleSharp.Dom;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public class SlackSourceCodeGenerator : OAuthClientCodeGenerator
    {
        private static List<String> DeprecatedScopeList = new List<string>();

        static SlackSourceCodeGenerator()
        {
            InitializeDeprecatedScopeList();
        }
        private static void InitializeDeprecatedScopeList()
        {
            var l = DeprecatedScopeList;

            l.Add("client");
            l.Add("conversations.app_home:create");
            l.Add("conversations:history");
            l.Add("conversations:read");
            l.Add("conversations:write");
            l.Add("post");
            l.Add("read");
        }

        public SlackSourceCodeGenerator(string folderPath)
            :base(folderPath, "Slack")
        {
        }

        public override async ValueTask CreateScopeSourceCode()
        {
            var doc = await Context.OpenAsync("https://api.slack.com/scopes");

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Core");
            sc.Namespaces.Add(new Namespace("HigLabo.Net.Slack"));
            var em = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, "Scope");
            sc.Namespaces[0].Enums.Add(em);

            var c = new Class(AccessModifier.Public, "ScopeExtensions");
            sc.Namespaces[0].Classes.Add(c);
            c.Modifier.Static = true;

            var md = new Method(MethodAccessModifier.Public, "GetScopeName");
            c.Methods.Add(md);
            md.Modifier.Static = true;
            md.Parameters.Add(new MethodParameter("this Scope", "value"));
            md.ReturnTypeName.Name = "string";
            var block = new CodeBlock(SourceCodeLanguage.CSharp, "switch(value)");
            block.CurlyBracket = true;
            md.Body.Add(block);

            foreach (var row in doc.QuerySelectorAll(".apiReferenceFilterableList__listItem"))
            {
                if (row.ClassList.Contains("apiReferenceFilterableList__listItem--deprecated")) { continue; }
                var hp = row.QuerySelector(".apiReferenceFilterableList__listItemLink")!;
                var scope = hp.GetAttribute("href")!.Replace("/scopes/", "");
                if (DeprecatedScopeList.Contains(scope)) { continue; }
                var eName = CreateScopeName(scope);
                em.Values.Add(new EnumValue(eName));

                block.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case Scope.{eName}: return \"{scope}\";"));
            }
            block.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default: throw new SwitchStatementNotImplementException<Scope>(value);"));

            Directory.CreateDirectory(Path.Combine(FolderPath, "Enum"));
            var filePath = Path.Combine(FolderPath, "Enum", "Scope.cs");
            using (var stream = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var g = new CSharpSourceCodeGenerator(stream);
                g.Write(sc);
                stream.Flush();
                stream.Close();
            }
            Console.WriteLine("Scope");
        }
        private String CreateScopeName(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0 || name[i - 1] == '.' || name[i - 1] == ':' || name[i - 1] == '-')
                {
                    sb.Append(name[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(name[i]);
                }
            }
            return sb.ToString().Replace(".", "").Replace(":", "").Replace("-", "");
        }

        protected override IEnumerable<string> GetEntiryUrlList()
        {
            yield break;
        }
        protected override ValueTask<List<ApiParameter>> GetEntityParameterList(IDocument document)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<String> GetMethodUrlList()
        {
            var doc = this.Context.OpenAsync("https://api.slack.com/methods").GetAwaiter().GetResult();

            foreach (var item in doc.QuerySelectorAll(".apiReferenceFilterableList__list > div > a"))
            {
                var path = item.GetAttribute("href");
                if (path == "/methods/channels.create") { break; }
                var url = "https://api.slack.com" + path;
                yield return url;
            }
        }

        protected override string GetClassName(string url, IDocument document)
        {
            var apiPath = url.Replace("https://api.slack.com/methods/", "");
            return CreateClassName(apiPath);
        }
        private String CreateClassName(string path)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                if (i == 0 || path[i - 1] == '.')
                {
                    sb.Append(path[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(path[i]);
                }
            }
            return sb.ToString().Replace(".", "");
        }

        protected override ValueTask<List<ApiParameter>> GetMethodParameterList(IDocument document)
        {
            var doc = document;
            var l = new List<ApiParameter>();

            foreach (var row in doc.QuerySelectorAll(".apiMethodPage__argumentRow"))
            {
                var p = new ApiParameter();
                p.Name = row.QuerySelector(".apiMethodPage__argument code")!.TextContent;
                if (p.Name == "token") { continue; }
                p.TypeName = row.QuerySelector(".apiMethodPage__argumentType")!.TextContent;

                p.Required = row.QuerySelector(".apiMethodPage__argumentOptionality")?.TextContent.Contains("required", StringComparison.OrdinalIgnoreCase) == true;
                l.Add(p);
            }
            return ValueTask.FromResult(l);
        }
        protected override Property CreateParameterProperty(ApiParameter parameter)
        {
            var p = parameter;
            var pType = CreatePropertyType(parameter);
            return new Property(pType, CreatePropertyName(parameter.Name), true);
        }

        private String CreatePropertyName(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0 || name[i - 1] == '_')
                {
                    sb.Append(name[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(name[i]);
                }
            }
            return sb.ToString();
        }
        private String CreatePropertyType(ApiParameter parameter)
        {
            var type = parameter.TypeName;

            if (type == "") { type = "string"; }
            if (type.Equals("integer", StringComparison.OrdinalIgnoreCase)) { type = "int"; }
            if (type.Equals("number", StringComparison.OrdinalIgnoreCase)) { type = "double"; }
            if (type.Equals("boolean", StringComparison.OrdinalIgnoreCase)) { type = "bool"; }
            if (type.Equals("array", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            if (type.Equals("null", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            if (type.Equals("blocks[] as string", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            if (type.Equals("manifest object as string", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            if (type.Equals("view as string", StringComparison.OrdinalIgnoreCase)) { type = "string"; }

            type += "?";

            return type;
        }

        protected override string GetClassName(string className, string propertyName)
        {
            if (propertyName == "Recurrence") { return "Recurrence?"; }
            return "";
        }
        protected override String GetEnumName(string className, string propertyName)
        {
            if (propertyName == "sort") { return "Sort"; }
            if (propertyName == "sort_dir") { return "SortDirection"; }
            if (className == "FilesList")
            {
                if (propertyName == "types") { return "FileType"; }
            }
            return "";
        }

        protected override bool IsNextPageTokenProperty(Property property)
        {
            return property.Name == "Cursor";
        }
        protected override Property CreateApiPathProperty(string url, IDocument document)
        {
            var doc = document;
            var apiPath = doc.Url.Replace("https://api.slack.com/methods/", "");

            var p = new Property("string", "IRestApiParameter.ApiPath", true);
            p.Modifier.AccessModifier = MethodAccessModifier.None;
            p.Set = null;
            p.Initializer = $"\"{apiPath}\"";

            return p;
        }
        protected override Property CreateHttpMethodProperty(string url, IDocument document)
        {
            var doc = document;
            var httpMethod = doc.QuerySelector(".apiMethodPage__method")!.TextContent;

            var p = new Property("string", "IRestApiParameter.HttpMethod", true);
            p.Modifier.AccessModifier = MethodAccessModifier.None;
            p.Set = null;
            p.Initializer = $"\"{httpMethod}\"";

            return p;
        }
    }
}
