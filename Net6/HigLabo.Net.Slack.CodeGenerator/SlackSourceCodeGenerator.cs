using AngleSharp;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack.CodeGenerator
{
    public class SlackSourceCodeGenerator
    {
        private static List<String> DeprecatedScopeList = new List<string>();

        public string FolderPath = "";
        public IBrowsingContext Context { get; init; }

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
        {
            this.FolderPath = folderPath;
            this.Context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
        }

        public async Task Execute()
        {
            var doc = await this.Context.OpenAsync("https://api.slack.com/methods");
            var linkList = doc.QuerySelectorAll(".apiReferenceFilterableList__list > div > a");

            await CreateScopeSourceCode();

            foreach (var item in linkList)
            {
                var path = item.GetAttribute("href");
                if (path == "/methods/channels.create") { break; }
                await CreateMethodSourceCode(path);
            }
        }

        private async Task CreateScopeSourceCode()
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
                var hp = row.QuerySelector(".apiReferenceFilterableList__listItemLink");
                var scope = hp.GetAttribute("href").Replace("/scopes/", "");
                if (DeprecatedScopeList.Contains(scope)) { continue; }
                var eName = CreateScopeName(scope);
                em.Values.Add(new EnumValue(eName));

                block.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case Scope.{eName}: return \"{scope}\";"));
            }
            block.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default: throw new SwitchStatementNotImplementException<Scope>(value);"));

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
        private async Task CreateMethodSourceCode(string path)
        {
            var url = "https://api.slack.com" + path;
            var doc = await Context.OpenAsync(url);

            var sc = new SourceCode();
            sc.Namespaces.Add(new Namespace("HigLabo.Net.Slack"));
            var apiPath = path.Replace("/methods/", "");
            var cName = CreateClassName(apiPath);
            var c = new Class(AccessModifier.Public, cName + "Parameter");
            c.Modifier.Partial = true;
            c.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
            sc.Namespaces[0].Classes.Add(c);

            var cResponse = new Class(AccessModifier.Public, cName + "Response");
            cResponse.Modifier.Partial = true;
            cResponse.ImplementInterfaces.Add(new TypeName("RestApiResponse"));
            sc.Namespaces[0].Classes.Add(cResponse);

            var cClient = new Class(AccessModifier.Public, "SlackClient");
            cClient.Modifier.Partial = true;
            sc.Namespaces[0].Classes.Add(cClient);
            {
                var md = new Method(MethodAccessModifier.Public, cName + "Async");
                md.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
                md.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
                md.ReturnTypeName.Name = "async Task";
                md.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
                md.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendAsync<{cName}Parameter, {cName}Response>(parameter, cancellationToken);");
                cClient.Methods.Add(md);

                var md1 = md.Copy();
                md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
                md1.Body.Clear();
                md1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendAsync<{cName}Parameter, {cName}Response>(parameter, CancellationToken.None);");
                cClient.Methods.Add(md1);
            }

            {
                var p = new Property("string", "IRestApiParameter.ApiPath", true);
                p.Modifier.AccessModifier = MethodAccessModifier.None;
                p.Set = null;
                p.Initializer = $"\"{apiPath}\"";
                c.Properties.Add(p);
            }
            {
                var httpMethod = doc.QuerySelector(".apiMethodPage__method").TextContent;
                var p = new Property("string", "IRestApiParameter.HttpMethod", true);
                p.Modifier.AccessModifier = MethodAccessModifier.None;
                p.Set = null;
                p.Initializer = $"\"{httpMethod}\"";
                c.Properties.Add(p);
            }

            var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
            mdAsync.ReturnTypeName.Name = "async Task";
            mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

            foreach (var row in doc.QuerySelectorAll(".apiMethodPage__argumentRow"))
            {
                var aName = row.QuerySelector(".apiMethodPage__argument code").TextContent;
                if (aName == "token") { continue; }
                var aType = row.QuerySelector(".apiMethodPage__argumentType").TextContent;
                var optional = row.QuerySelector(".apiMethodPage__argumentOptionality");
                var aRequired = "";
                if (optional != null)
                {
                    aRequired = optional.TextContent.Replace("·", "");
                }
                var pType = CreatePropertyType(aType);
                if (aRequired == "Optional" && pType != "string")
                {
                    pType += "?";
                }
                var p = new Property(pType, CreatePropertyName(aName), true);
                //https://api.slack.com/methods/reminders.add
                if (p.Name == "Recurrence")
                {
                    p.TypeName.Name = "Recurrence";
                    p.Initializer = "new Recurrence()";
                }
                else
                {
                    var eName = GetEnumName(cName, aName);
                    if (eName .IsNullOrEmpty() == false)
                    {
                        p.TypeName.Name = eName;
                    }
                }
                c.Properties.Add(p);

                if (p.Name == "Cursor")
                {
                    c.ImplementInterfaces.Add(new TypeName("ICursor"));
                }

                if (aRequired == "Required")
                {
                    mdAsync.Parameters.Add(new MethodParameter(pType, p.Name.ToCamelCase()));
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name} = {p.Name.ToCamelCase()};");
                }
            }
            mdAsync.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendAsync<{cName}Parameter, {cName}Response>(p, cancellationToken);");
            cClient.Methods.Add(mdAsync);


            var mdAsync1 = mdAsync.Copy();
            mdAsync1.Parameters.RemoveAt(mdAsync1.Parameters.Count - 1);
            mdAsync1.Body.RemoveAt(mdAsync1.Body.Count - 1);
            mdAsync1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendAsync<{cName}Parameter, {cName}Response>(p, CancellationToken.None);");
            cClient.Methods.Add(mdAsync1);

            if (c.ImplementInterfaces.Exists(el => el.Name == "ICursor"))
            {
                var mdBatch = cClient.Methods[0].Copy();
                mdBatch.Parameters.Insert(1, new MethodParameter($"PagingContext<{cName}Response>", "context"));
                mdBatch.ReturnTypeName = new TypeName("async Task");
                mdBatch.ReturnTypeName.GenericTypes.Add(new TypeName($"List<{cName}Response>"));
                mdBatch.Body.Clear();
                mdBatch.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendBatchAsync(parameter, context, cancellationToken);");
                cClient.Methods.Insert(0, mdBatch);

                var mdBatch1 = mdBatch.Copy();
                mdBatch1.Parameters.RemoveAll(el => el.Name == "cancellationToken");
                mdBatch1.Body.Clear();
                mdBatch1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendBatchAsync(parameter, context, CancellationToken.None);");
                cClient.Methods.Insert(1, mdBatch1);

                var mdBatchParameter = mdAsync.Copy();
                mdBatchParameter.Parameters.Insert(1, new MethodParameter($"PagingContext<{cName}Response>", "context"));
                mdBatchParameter.ReturnTypeName = new TypeName("async Task");
                mdBatchParameter.ReturnTypeName.GenericTypes.Add(new TypeName($"List<{cName}Response>"));
                mdBatchParameter.Body.RemoveAt(mdBatchParameter.Body.Count - 1);
                mdBatchParameter.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendBatchAsync(p, context, cancellationToken);");
                cClient.Methods.Insert(2, mdBatchParameter);

                var mdBatchParameter1 = mdBatchParameter.Copy();
                mdBatchParameter1.Parameters.RemoveAll(el => el.Name == "cancellationToken");
                mdBatchParameter1.Body.RemoveAt(mdBatchParameter.Body.Count - 1);
                mdBatchParameter1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.SendBatchAsync(p, context, CancellationToken.None);");
                cClient.Methods.Insert(3, mdBatchParameter1);
            }

            cClient.Methods.Reverse();

            var filePath = Path.Combine(FolderPath, "Method", cName + ".cs");
            using (var stream = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var g = new CSharpSourceCodeGenerator(stream);
                g.Write(sc);
                stream.Flush();
                stream.Close();
            }
            Console.WriteLine(c.Name);
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
        private String CreatePropertyType(string type)
        {
            if (type == "integer") { return "int"; }
            if (type == "number") { return "double"; }
            if (type == "boolean") { return "bool"; }
            if (type == "") { return "string"; }
            if (type == "array") { return "string"; }
            if (type == "null") { return "string"; }
            if (type == "blocks[] as string") { return "string"; }
            if (type == "manifest object as string") { return "string"; }
            if (type == "view as string") { return "string"; }
            return type;
        }
        private String GetEnumName(string className, string propertyName)
        {
            if (propertyName == "sort") { return "Sort"; }
            if (propertyName == "sort_dir") { return "SortDirection"; }
            if (className == "FilesList")
            {
                if (propertyName == "types") { return "FileType"; }
            }
            return "";
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
    }
}
