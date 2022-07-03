using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public abstract class OAuthClientCodeGenerator
    {
        private protected WebDriver _Driver;
        private List<string> _CreatedFilePathList = new();

        public virtual Boolean UseSelenium { get; } = false;
        public string FolderPath { get; init; } = "";
        public string ServiceName { get; init; } = "";
        public IBrowsingContext Context { get; init; }
        public string UserAgent { get; init; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";

        public OAuthClientCodeGenerator(string folderPath, string serviceName)
        {
            this.FolderPath = folderPath;
            this.ServiceName = serviceName;
            this.Context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            this.SetChromeDriver();
        }
        private void SetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--user-agent=" + this.UserAgent);
            _Driver = new ChromeDriver(options);
        }

        protected async Task<IDocument> GetDocumentAsync(string url)
        {
            if (this.UseSelenium)
            {
                var html = this.GetHtml(url);
                var parser = new HtmlParser();
                return await parser.ParseDocumentAsync(html);
            }
            else
            {
                return await Context.OpenAsync(url);
            }
        }
        protected string GetHtml()
        {
            return _Driver.PageSource;
        }
        protected string GetHtml(string url)
        {
            var dr = _Driver;
            var wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));

            dr.Navigate().GoToUrl(url);
            wait.Until(el => el.FindElement(By.TagName("body")).Displayed);

            return this.GetHtml();
        }
        protected void WriteFile(string filePath, SourceCode sourceCode)
        {
            using (var stream = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var g = new CSharpSourceCodeGenerator(stream);
                g.Write(sourceCode);
                stream.Flush();
                stream.Close();
            }
        }

        public async Task Execute()
        {
            //await CreateScopeSourceCode();

            var urlList = new List<string>();
            
            _CreatedFilePathList.Clear();
            foreach (var url in await GetEntiryUrlList())
            {
                await CreateEntitySourceCode(url);
            }

            foreach (var url in await GetMethodUrlList())
            {
                await CreateMethodSourceCode(url);
            }
        }
        public abstract Task CreateScopeSourceCode();

        protected abstract Task<List<String>> GetEntiryUrlList();
        public async Task CreateEntitySourceCode(string url)
        {
            var doc = await this.GetDocumentAsync(url);
            var enumList = new List<HigLabo.CodeGenerator.Enum>();

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Net.OAuth");
            sc.Namespaces.Add(new Namespace($"HigLabo.Net.{this.ServiceName}"));

            var cName = this.GetClassName(url, doc);
            var filePath = Path.Combine(FolderPath, "Entity", "Generated", cName + ".cs");
            if (_CreatedFilePathList.Contains(filePath)) { return; }

            var c = new Class(AccessModifier.Public, cName);
            c.Comment = url;
            c.Modifier.Partial = true;
            sc.Namespaces[0].Classes.Add(c);

            foreach (var parameter in await this.GetEntityParameterList(doc))
            {
                var property = CreateParameterProperty(parameter);
                //https://api.slack.com/methods/reminders.add
                var tName = GetClassName(cName, property.Name);
                if (tName.IsNullOrEmpty() == false)
                {
                    property.TypeName.Name = tName;
                    property.Initializer = $"new {tName}()";
                }
                var eName = GetEnumName(cName, parameter.Name);
                if (eName.IsNullOrEmpty() == false)
                {
                    property.TypeName.Name = eName;
                }
                c.Properties.Add(property);

                if (parameter.IsEnum && enumList.Exists(el => el.Name == property.TypeName.Name) == false)
                {
                    var eTypeName = c.Name + property.TypeName.Name.Replace("?", "").Replace("[]", "");
                    var em = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, eTypeName);
                    em.Comment = url;
                    if (property.TypeName.Name == "String[]")
                    {
                        property.TypeName.Name = em.Name + "[]";
                    }
                    else
                    {
                        property.TypeName.Name = em.Name;
                    }
                    foreach (var item in parameter.EnumValues)
                    {
                        em.Values.Add(new EnumValue(item));
                    }
                    enumList.Add(em);
                }
                if (parameter.EntityUrl.IsNullOrEmpty() == false)
                {
                    if (_CreatedFilePathList.Contains(parameter.EntityUrl) == false)
                    {
                        _CreatedFilePathList.AddIfNotExist(parameter.EntityUrl);
                        await CreateEntitySourceCode(parameter.EntityUrl);
                    }
                }
            }

            {
                this.WriteFile(filePath, sc);
                _CreatedFilePathList.Add(filePath);
                Console.WriteLine(c.Name);
            }

            foreach (var em in enumList)
            {
                var enumSourceCode = new SourceCode();
                enumSourceCode.Namespaces.Add(new Namespace($"HigLabo.Net.{this.ServiceName}"));
                enumSourceCode.Namespaces[0].Enums.Add(em);

                var enumFilePath = Path.Combine(FolderPath, "Entity", "Generated", em.Name + ".cs");
                if (_CreatedFilePathList.Contains(enumFilePath)) { continue; }
                this.WriteFile(enumFilePath, enumSourceCode);
                _CreatedFilePathList.Add(enumFilePath);
                Console.WriteLine(c.Name);
            }
        }
        protected abstract Task<List<ApiParameter>> GetEntityParameterList(IDocument document);

        protected abstract Task<List<String>> GetMethodUrlList();
        public async Task CreateMethodSourceCode(string url)
        {
            var doc = await this.GetDocumentAsync(url);

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Net.OAuth");
            sc.Namespaces.Add(new Namespace($"HigLabo.Net.{this.ServiceName}"));

            var cName = this.GetClassName(url, doc);
            var c = new Class(AccessModifier.Public, cName + "Parameter");
            c.Modifier.Partial = true;
            c.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
            sc.Namespaces[0].Classes.Add(c);

            var cResponse = new Class(AccessModifier.Public, cName + "Response");
            cResponse.Modifier.Partial = true;
            cResponse.ImplementInterfaces.Add(new TypeName("RestApiResponse"));
            sc.Namespaces[0].Classes.Add(cResponse);

            var cClient = new Class(AccessModifier.Public, this.ServiceName + "Client");
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
                p.Initializer = $"\"{this.GetApiPath(doc)}\"";
                c.Properties.Add(p);
            }
            {
                var p = new Property("string", "IRestApiParameter.HttpMethod", true);
                p.Modifier.AccessModifier = MethodAccessModifier.None;
                p.Set = null;
                p.Initializer = $"\"{this.GetHttpMethod(doc)}\"";
                c.Properties.Add(p);
            }

            var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
            mdAsync.ReturnTypeName.Name = "async Task";
            mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

            foreach (var parameter in await this.GetMethodParameterList(doc))
            {
                var property = CreateParameterProperty(parameter);
                //https://api.slack.com/methods/reminders.add
                var className = GetClassName(cName, property.Name);
                if (className.IsNullOrEmpty() == false)
                {
                    property.TypeName.Name = className;
                    property.Initializer = $"new {className}()";
                }
                var eName = GetEnumName(cName, parameter.Name);
                if (eName.IsNullOrEmpty() == false)
                {
                    property.TypeName.Name = eName;
                }
                c.Properties.Add(property);

                if (parameter.IsNextPageToken)
                {
                    c.ImplementInterfaces.Add(new TypeName("IRestApiPagingParameter"));

                    var pPaging = new Property("string", "IRestApiPagingParameter.NextPageToken");
                    pPaging.Modifier.AccessModifier = MethodAccessModifier.None;
                    pPaging.Get = new PropertyBody(PropertyBodyType.Get);
                    pPaging.Get.Body.Add(SourceCodeLanguage.CSharp, $"return this.{parameter.Name};");
                    pPaging.Set = new PropertyBody(PropertyBodyType.Set);
                    pPaging.Set.Body.Add(SourceCodeLanguage.CSharp, $"this.{parameter.Name} = value;");
                    c.Properties.Add(pPaging);
                }

                if (parameter.Required)
                {
                    mdAsync.Parameters.Add(new MethodParameter(parameter.TypeName, property.Name.ToCamelCase()));
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{property.Name} = {property.Name.ToCamelCase()};");
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

            if (c.ImplementInterfaces.Exists(el => el.Name == "IRestApiPagingParameter"))
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
            foreach (var md in cClient.Methods)
            {
                md.Comment = url;
            }

            var filePath = Path.Combine(FolderPath, "Method", cName + ".cs");
            this.WriteFile(filePath, sc);
            Console.WriteLine(c.Name);
        }

        protected abstract string GetClassName(string url, IDocument document);
        protected abstract string GetHttpMethod(IDocument document);
        protected abstract string GetApiPath(IDocument document);
        protected abstract Task<List<ApiParameter>> GetMethodParameterList(IDocument document);
        protected abstract Property CreateParameterProperty(ApiParameter parameter);
        protected abstract String GetClassName(string className, string propertyName);
        protected abstract String GetEnumName(string className, string propertyName);
    }
}
