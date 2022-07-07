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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public abstract class OAuthClientCodeGenerator
    {
        private protected WebDriver _Driver;
        private List<string> _CreatedUrlList = new();

        public virtual Boolean UseSelenium { get; } = false;
        public string FolderPath { get; init; } = "";
        public string HtmlCacheFolderPath { get; set; }
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
            return this.GetHtml(url, true);
        }
        protected string GetHtml(string url, Boolean useCache)
        {
            if (useCache && this.HtmlCacheFolderPath.IsNullOrEmpty() == false)
            {
                var filePath = Path.Combine(this.HtmlCacheFolderPath, WebUtility.UrlEncode(url));
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            }
            var dr = _Driver;
            var wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));

            dr.Navigate().GoToUrl(url);
            wait.Until(el => el.FindElement(By.TagName("body")).Displayed);

            var html = this.GetHtml();
            if (this.HtmlCacheFolderPath.IsNullOrEmpty() == false)
            {
                var filePath = Path.Combine(this.HtmlCacheFolderPath, WebUtility.UrlEncode(url));
                File.WriteAllText(filePath, html, Encoding.UTF8);
            }
            return html;
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
            var random = new Random();

            //await CreateScopeSourceCode();

            _CreatedUrlList.Clear();
            //foreach (var url in this.GetEntiryUrlList())
            //{
            //    await CreateEntitySourceCodeFile(url);
            //}

            foreach (var url in GetMethodUrlList())
            {
                try
                {
                    await CreateMethodSourceCodeFile(url);
                    Thread.Sleep(random.Next(0, 10) * 100 + 1);
                }
                catch (Exception ex)
                {
                    var s = ex.ToString();
                }
            }
            Console.WriteLine("Completed!");
        }
        public abstract Task CreateScopeSourceCode();

        protected abstract IEnumerable<String> GetEntiryUrlList();
        public async Task CreateEntitySourceCodeFile(string url)
        {
            var doc = await this.GetDocumentAsync(url);
            var cName = this.GetClassName(url, doc);
            var c = await this.CreateEntityClass(url, new CreateEntityClassContext());
            this.CreateEntitySourceCodeFile(url, c);
        }
        public void CreateEntitySourceCodeFile(string url, Class @class)
        {
            var c = @class;
            var filePath = Path.Combine(FolderPath, "Entity", "Generated", c.Name + ".cs");

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Net.OAuth");
            sc.Namespaces.Add(new Namespace($"HigLabo.Net.{this.ServiceName}"));
            sc.Namespaces[0].Classes.Add(c);

            if (_CreatedUrlList.Contains(url) == false)
            {
                this.WriteFile(filePath, sc);
                _CreatedUrlList.Add(url);
                Console.WriteLine(filePath);
            }
        }
        public async Task<Class> CreateEntityClass(string url, CreateEntityClassContext context)
        {
            context.UrlList.Add(url);

            var doc = await this.GetDocumentAsync(url);
            var cName = this.GetClassName(url, doc);
            var c = new Class(AccessModifier.Public, cName);
            c.Comment = url;
            c.Modifier.Partial = true;

            var entityUrlList = new List<String>();
            var pp = await this.GetEntityParameterList(doc);
            foreach (var parameter in pp)
            {
                var property = await this.AddProperty(c, cName, parameter);

                if (context.UrlList.Contains(parameter.EntityUrl)) { continue; }
                if (url != parameter.EntityUrl && parameter.EntityUrl.IsNullOrEmpty() == false)
                {
                    entityUrlList.Add(parameter.EntityUrl);
                    var eDoc = await this.GetDocumentAsync(parameter.EntityUrl);
                    var eName = this.GetClassName(parameter.EntityUrl, eDoc);
                    if (property.TypeName.Name.Contains("[]"))
                    {
                        property.TypeName.Name = eName + "[]?";
                    }
                    else
                    {
                        property.TypeName.Name = eName + "?";
                    }
                }
            }
            return c;
        }
        protected abstract Task<List<ApiParameter>> GetEntityParameterList(IDocument document);

        protected abstract IEnumerable<String> GetMethodUrlList();
        public async Task CreateMethodSourceCodeFile(string url)
        {
            Console.WriteLine(url);

            var doc = await this.GetDocumentAsync(url);
            var cName = this.GetClassName(url, doc);
            var sc = await this.CreateMethodSourceCode(url, doc, cName);
            var filePath = Path.Combine(FolderPath, "Method", cName + ".cs");
            this.WriteFile(filePath, sc);

            Console.WriteLine(filePath);
        }
        public virtual async Task<SourceCode> CreateMethodSourceCode(string url, IDocument document, string className)
        {
            var doc = document;
            var cName = className;

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Net.OAuth");
            sc.Namespaces.Add(new Namespace($"HigLabo.Net.{this.ServiceName}"));

            var c = new Class(AccessModifier.Public, cName + "Parameter");
            c.Modifier.Partial = true;
            c.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
            sc.Namespaces[0].Classes.Add(c);

            sc.Namespaces[0].Classes.Add(CreateResponseClass(document, cName + "Response"));

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

            c.Properties.Add(this.CreateApiPathProperty(url, doc));
            c.Properties.Add(this.CreateHttpMethodProperty(url, doc));

            var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
            mdAsync.ReturnTypeName.Name = "async Task";
            mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

            foreach (var parameter in await this.GetMethodParameterList(doc))
            {
                var property = await this.AddProperty(c, cName, parameter);

                if (parameter.EntityUrl.IsNullOrEmpty() == false)
                {
                    await this.CreateEntitySourceCodeFile(parameter.EntityUrl);
                }

                if (this.IsNextPageTokenProperty(property))
                {
                    c.ImplementInterfaces.Add(new TypeName("IRestApiPagingParameter"));

                    var pPaging = new Property("string", "IRestApiPagingParameter.NextPageToken");
                    pPaging.Modifier.AccessModifier = MethodAccessModifier.None;
                    pPaging.Get = new PropertyBody(PropertyBodyType.Get);
                    pPaging.Get.Body.Add(SourceCodeLanguage.CSharp, $"return this.{property.Name};");
                    pPaging.Set = new PropertyBody(PropertyBodyType.Set);
                    pPaging.Set.Body.Add(SourceCodeLanguage.CSharp, $"this.{property.Name} = value;");
                    c.Properties.Add(pPaging);
                }

                if (parameter.Required)
                {
                    mdAsync.Parameters.Add(new MethodParameter(property.TypeName.Name, property.Name.ToCamelCase()));
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
            return sc;
        }
        private async Task<Property> AddProperty(Class @class, string className, ApiParameter parameter)
        {
            var c = @class;
            var cName = className;
            var property = CreateParameterProperty(parameter);
            var typeName = GetClassName(cName, property.Name);
            if (parameter.IsEnum == false && parameter.EntityUrl.IsNullOrEmpty() == false)
            {
                var url = parameter.EntityUrl;
                var doc = await this.GetDocumentAsync(url);
                var entityClassName = this.GetClassName(url, doc);
                if (property.TypeName.Name.Contains("[]"))
                {
                    property.TypeName.Name = entityClassName + "[]?";
                }
                else
                {
                    property.TypeName.Name = entityClassName + "?";
                }
            }
            if (typeName.IsNullOrEmpty() == false)
            {
                property.TypeName.Name = typeName;
            }
            var eName = GetEnumName(cName, parameter.Name);
            if (eName.IsNullOrEmpty() == false)
            {
                property.TypeName.Name = eName;
            }
            c.Properties.Add(property);

            if (parameter.IsEnum && c.Enums.Exists(el => el.Name == property.TypeName.Name) == false)
            {
                var eTypeName = c.Name + property.TypeName.Name.Replace("?", "").Replace("[]", "");
                var em = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, eTypeName);
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
                if (c.Enums.Exists(el => el.Name == em.Name) == false)
                {
                    c.Enums.Add(em);
                }
            }
            return property;
        }

        protected abstract string GetClassName(string url, IDocument document);

        protected abstract Task<List<ApiParameter>> GetMethodParameterList(IDocument document);
        protected abstract Property CreateParameterProperty(ApiParameter parameter);
        protected abstract String GetClassName(string className, string propertyName);
        protected abstract String GetEnumName(string className, string propertyName);
        
        protected abstract bool IsNextPageTokenProperty(Property property);
        protected abstract Property CreateApiPathProperty(string url, IDocument document);
        protected abstract Property CreateHttpMethodProperty(string url, IDocument document);
        protected virtual Class CreateResponseClass(IDocument document, string className)
        {
            var c = new Class(AccessModifier.Public, className);
            c.Modifier.Partial = true;
            c.ImplementInterfaces.Add(new TypeName("RestApiResponse"));

            return c;
        }
    }
}
