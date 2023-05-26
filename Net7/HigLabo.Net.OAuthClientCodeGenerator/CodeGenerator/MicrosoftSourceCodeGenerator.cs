using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Io;
using HigLabo.CodeGenerator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;
using AngleSharp.Dom;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace HigLabo.Net.CodeGenerator
{
    public class MicrosoftSourceCodeGenerator : OAuthClientCodeGenerator
    {
        private static List<string> _ClassNameList = new List<string>();
        private List<UrlClassNameMapping> _UrlClassNameMappingList = new List<UrlClassNameMapping>();

        public override bool UseSelenium => true;

        static MicrosoftSourceCodeGenerator()
        {
            var l = _ClassNameList;
            l.Add("Store");
            l.Add("Management");
            l.Add("Account");
            l.Add("Type");
            l.Add("Token");
            l.Add("Partner");
            l.Add("Expense");
            l.Add("Option");
            l.Add("Generation");
            l.Add("Content");
            l.Add("Target");
            l.Add("Assignment");
            l.Add("Group");
            l.Add("Enrollment");
            l.Add("AppManagement");
            l.Add("Manager");
            l.Add("Collection");
            l.Add("Status");
            l.Add("Enterprise");
            l.Add("Always");
            l.Add("PackageType");
            l.Add("User");
            l.Add("TokenState");
            l.Add("Color");
            l.Add("Settings");
            l.Add("School");
            l.Add("Conditional");
            l.Add("Access");
            l.Add("Connector");
            l.Add("Threat");
            l.Add("Defense");
            l.Add("Brand");
            l.Add("Configuration");
            l.Add("Exchange");
            l.Add("Sync");
            l.Add("Resource");
            l.Add("Policy");
            l.Add("Protection");
            l.Add("Information");
            l.Add("Requirements");
            l.Add("Summary");
            l.Add("Learning");
            l.Add("Network");
            l.Add("Level");
            l.Add("Desktop");
            l.Add("Operation");
            l.Add("Location");
            l.Add("Identifier");
            l.Add("Action");
            l.Add("Result");
            l.Add("Root");
            l.Add("MessageRule");
        }

        public MicrosoftSourceCodeGenerator(string folderPath)
            : base(folderPath, "Microsoft")
        {
        }
        private void SetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--user-agent=" + this.UserAgent);
            _Driver = new ChromeDriver(options);
        }
        private string GetResouceUrlMappingFilePath()
        {
            return Path.Combine(FolderPath, "ResouceUrlMapping.txt");
        }

        public override Task CreateScopeSourceCode()
        {
            var html = this.GetHtml("https://learn.microsoft.com/en-us/graph/permissions-reference");
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("HigLabo.Core");
            sc.Namespaces.Add(new Namespace("HigLabo.Net.Microsoft"));
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

            var addedScopeList = new List<String>();
            foreach (var table in doc.QuerySelectorAll("table"))
            {
                foreach (var item in table.QuerySelectorAll("tbody tr td:nth-child(1) em"))
                {
                    var scope = item.TextContent;
                    if (addedScopeList.Contains(scope)) { continue; }

                    var eName = CreateScopeName(scope);
                    em.Values.Add(new EnumValue(eName));
                    block.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case Scope.{eName}: return \"{scope}\";"));
                    addedScopeList.Add(scope);
                }
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
            ConsoleWriteText("Scope");

            return Task.FromResult(0);
        }
        private String CreateScopeName(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0 || name[i - 1] == '.' || name[i - 1] == ':' || name[i - 1] == '-' || name[i - 1] == '_')
                {
                    sb.Append(name[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(name[i]);
                }
            }
            return sb.ToString().Replace(".", "").Replace(":", "").Replace("-", "").Replace("_", "");
        }

        private Boolean IsAvailabelUrl(string url)
        {
            if (url.Contains("overview?") ||
                url.Contains("-overview?") ||
                url.Contains("-conceptual?") ||
                url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/enums?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-US/graph/api/resources/parentalcontrolsettings", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-us/graph/api/resources/users?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-us/graph/api/resources/security-error-codes?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-us/graph/api/resources/report?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-us/graph/api/resources/excel?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase) ||
                url.Equals("https://learn.microsoft.com/en-us/graph/api/resources/onedrive?view=graph-rest-1.0", StringComparison.OrdinalIgnoreCase))
            { return false; }
            if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/intune-", StringComparison.OrdinalIgnoreCase) == true) { return false; }
            return true;
        }

        protected override IEnumerable<string> GetEntiryUrlList()
        {
            var html = this.GetHtml("https://learn.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0", false);

            while (true)
            {
                var hasElement = false;
                foreach (var li in _Driver.FindElements(By.CssSelector("[id='title-8-1'] > ul li.tree-item")).Reverse())
                {
                    if (li.GetAttribute("class").Contains("is-expanded")) { continue; }

                    var span = li.FindElement(By.CssSelector("span.tree-expander-indicator[aria-hidden='true']"));
                    _Driver.ExecuteScript("arguments[0].scrollIntoView(false);", span);
                    span.Click();

                    hasElement = true;
                }
                if (hasElement == false) { break; }
            }

            var parser = new HtmlParser();
            var doc = parser.ParseDocument(this.GetHtml());
            var linkList = doc.QuerySelectorAll("[id='title-8-1'] li > a");

            foreach (var item in linkList)
            {
                var url = item.GetAttribute("href").ToString();
                if (this.IsAvailabelUrl(url) == false) { continue; }
                if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/"))
                {
                    yield return url;
                }
            }
            yield return "https://learn.microsoft.com/en-us/graph/api/resources/actionresultpart?view=graph-rest-1.0";
            yield return "https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestrequirements?view=graph-rest-1.0";
        }
        protected override async Task<List<ApiParameter>> GetEntityParameterList(IDocument document)
        {
            var l = new List<ApiParameter>();
            var divList = new List<IElement>();
            {
                var div = document.QuerySelector("[id='properties']");
                if (div != null)
                {
                    divList.Add(div.ParentElement);
                }
            }
            {
                var div = document.QuerySelector("[id='relationships']");
                if (div != null)
                {
                    divList.Add(div.ParentElement);
                }
            }

            IElement tbl = null;
            foreach (var item in divList)
            {
                IElement div = item;
                while (div != null)
                {
                    div = div.NextElementSibling;
                    if (div == null) { break; }
                    if (div.QuerySelector("#methods") != null) { break; }

                    tbl = div.QuerySelector($"table[aria-label]");
                    if (tbl != null)
                    {
                        foreach (var parameter in await this.GetParameterList(document, tbl))
                        {
                            if (l.Exists(el => el.Name == parameter.Name)) { continue; }
                            l.Add(parameter);
                        }
                        break;
                    }
                }
            }
            return l;
        }
        public async Task CreateResourceUrlMappingFile()
        {
            var l = new List<UrlClassNameMapping>();
            var context = new CreateEntityClassContext();
            foreach (var url in this.GetEntiryUrlList())
            {
                var c = await CreateEntityClass(url, context);
                l.Add(new UrlClassNameMapping(url, c.Name));
                ConsoleWriteText(c.Name + " " + url);
            }
            File.WriteAllText(this.GetResouceUrlMappingFilePath(), Newtonsoft.Json.JsonConvert.SerializeObject(l, Formatting.Indented));
        }
        public async Task LoadUrlClassNameMappingList()
        {
            var json = await File.ReadAllTextAsync(this.GetResouceUrlMappingFilePath());
            _UrlClassNameMappingList = JsonConvert.DeserializeObject<List<UrlClassNameMapping>>(json)!;
        }

        protected override IEnumerable<string> GetMethodUrlList()
        {
            var html = this.GetHtml("https://learn.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0", false);

            while (true)
            {
                var hasElement = false;
                foreach (var li in _Driver.FindElements(By.CssSelector("[id='title-8-1'] > ul li.tree-item"))
                    .Reverse())
                {
                    if (li.GetAttribute("class").Contains("is-expanded")) { continue; }

                    var span = li.FindElement(By.CssSelector("span.tree-expander-indicator[aria-hidden='true']"));
                    _Driver.ExecuteScript("arguments[0].scrollIntoView(false);", span);
                    span.Click();

                    hasElement = true;
                }
                if (hasElement == false) { break; }
            }

            var parser = new HtmlParser();
            var doc = parser.ParseDocument(this.GetHtml());
            var linkList = doc.QuerySelectorAll("[id='title-8-1'] li > a");

            foreach (var item in linkList)
            {
                var url = item.GetAttribute("href").ToString();
                if (this.IsAvailabelUrl(url) == false) { continue; }
                if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/intune-", StringComparison.OrdinalIgnoreCase) == true) { continue; }

                if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/", StringComparison.OrdinalIgnoreCase) == false) { continue; }
                var pDoc = this.GetDocumentAsync(url).GetAwaiter().GetResult();
                var mm = this.GetApiRequestPathList(pDoc);
                if (mm.Length == 0) { continue; }
                yield return url;
            }
        }
        protected override Task<List<ApiParameter>> GetMethodParameterList(IDocument document)
        {
            var doc = document;
            var l = new List<ApiParameter>();
            var h2 = doc.QuerySelector("#request-body");
            if (h2 == null) { return Task.FromResult(l); }
            var node = h2.ParentElement.NextElementSibling;
            IElement? tbl = null;

            while (node != null)
            {
                tbl = node.QuerySelector("table[aria-label]");
                if (tbl != null) { break; }
                if (node.QuerySelector("#response") != null) { return Task.FromResult(l); }
                node = node.NextElementSibling;
            }
            if (tbl == null) { return Task.FromResult(l); }

            return this.GetParameterList(document, tbl);
        }
        public override async Task<SourceCode> CreateMethodSourceCode(string url, IDocument document, string className)
        {
            var sc = await base.CreateMethodSourceCode(url, document, className);
            var context = new CreateEntityClassContext();

            var cParameter = sc.Namespaces[0].Classes.Find(el => el.Name == className + "Parameter");
            cParameter.Comment = url;
            var cResponse = sc.Namespaces[0].Classes.Find(el => el.Name == className + "Response");
            var rx = new Regex("{[^}]*}");

            var entityUrl = "";
            if (cParameter.Name.Contains("Get"))
            {
                var resourceName = cParameter.Name.Substring(0, cParameter.Name.IndexOf("Get"));
                var u = this._UrlClassNameMappingList.Find(el => el.ClassName == resourceName);
                if (u != null)
                {
                    entityUrl = u.Url;
                }
            }

            var httpMethod = cParameter.Properties.Find(el => el.Name == "IRestApiParameter.HttpMethod").Initializer.Replace("\"", "");
            if (httpMethod == "GET")
            {
                var cField = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, "Field");
                cParameter.Enums.Add(cField);
                if (entityUrl.IsNullOrEmpty() == false)
                {
                    try
                    {
                        var doc = this.GetDocumentAsync(entityUrl).GetAwaiter().GetResult();
                        var cEntity = this.CreateEntityClass(entityUrl, context).GetAwaiter().GetResult();
                        this.CreateEntitySourceCodeFile(entityUrl, cEntity);
                        foreach (var item in cEntity.Properties)
                        {
                            cField.Values.AddIfNotExist(new EnumValue(item.Name), el => el.Text == item.Name);
                        }
                    }
                    catch { }
                }
                var pValueList = cResponse.Properties.Find(el => el.Name == "Value");
                if (pValueList != null && pValueList.TypeName.Name.Contains("[]"))
                {
                    var responseListClassName = pValueList.TypeName.Name.Replace("[]?", "");
                    var responseListUrl = this._UrlClassNameMappingList.Find(el => el.ClassName == responseListClassName)?.Url;
                    if (responseListUrl.IsNullOrEmpty() == false)
                    {
                        var cValue = await this.CreateEntityClass(responseListUrl, context);
                        foreach (var item in cValue.Properties)
                        {
                            cField.Values.AddIfNotExist(new EnumValue(item.Name), el => el.Text == item.Name);
                        }
                    }
                }
                else
                {

                }

                var p = new Property("QueryParameter<Field>", "Query", true);
                p.Initializer = "new QueryParameter<Field>()";
                cParameter.Properties.Add(p);

                cParameter.ImplementInterfaces.Add(new TypeName("IQueryParameterProperty"));
                var pQuery = new Property("IQueryParameter", "IQueryParameterProperty.Query");
                pQuery.Modifier.AccessModifier = MethodAccessModifier.None;
                pQuery.Get = new PropertyBody(PropertyBodyType.Get);
                pQuery.Get.Body.Add(SourceCodeLanguage.CSharp, "return this.Query;");
                pQuery.Set = null;
                cParameter.Properties.Add(pQuery);
            }
            else if (httpMethod == "POST")
            {
                foreach (var item in cResponse.Properties)
                {
                    if (item.Name == "Value" && item.TypeName.Name.Contains("[]")) { continue; }
                    cParameter.Properties.AddIfNotExist(item, el => el.Name == item.Name);
                }
                foreach (var item in cResponse.Enums)
                {
                    cParameter.Enums.AddIfNotExist(item, el => el.Name == item.Name);
                }
            }

            cParameter.Properties.Insert(0, new Property("ApiPathSettings", "ApiPathSetting", true) {  Initializer = "new ApiPathSettings()" });

            var hasBinaryMethod = false;
            {
                var cSetting = new Class(AccessModifier.Public, "ApiPathSettings");
                cParameter.Classes.Add(cSetting);
                cSetting.Properties.Add(new Property("ApiPath", "ApiPath", true));

                var md = new Method(MethodAccessModifier.Public, "GetApiPath");
                md.ReturnTypeName = new TypeName("string");
                cSetting.Methods.Add(md);
                var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (this.ApiPath)");
                cb.CurlyBracket = true;
                md.Body.Add(cb);

                var em = new HigLabo.CodeGenerator.Enum(AccessModifier.Public, "ApiPath");
                cParameter.Enums.Add(em);
                foreach (var item in this.GetApiRequestPathList(document))
                {
                    var apiPath = item.ApiPath.Substring(1, item.ApiPath.Length - 1);
                    var apiPathFormat = "/" + apiPath;
                    var eValue = this.CreateEnumValue(apiPath);

                    hasBinaryMethod = apiPath.EndsWith("$value", StringComparison.OrdinalIgnoreCase);

                    var vv = rx.Matches(apiPath).Select(el => el.Value).ToList();
                    var isIdDuplicate = false;
                    foreach (var kv in vv.GroupBy(el => el))
                    {
                        if (kv.Count() > 1)
                        {
                            isIdDuplicate = true;
                            break;
                        }
                    }
                    if (isIdDuplicate)
                    {
                        var ss = apiPathFormat.Split('/');
                        var vIndex = 0;
                        for (int i = 0; i < ss.Length; i++)
                        {
                            if (ss[i].StartsWith("{"))
                            {
                                ss[i] = "{" + ss[i - 1] + ss[i].Substring(1, ss[i].Length - 2).ToPascalCase() + "}";
                                vv[vIndex] = ss[i];
                                vIndex++;
                            }
                        }
                        apiPathFormat = String.Join("/", ss);
                    }
                    foreach (var v in vv)
                    {
                        var pName = CreateParameterNameFromApiPath(v.Replace("{", "").Replace("}", ""));
                        apiPathFormat = apiPathFormat.Replace(v, "{" + pName + "}", StringComparison.OrdinalIgnoreCase);

                        var p = new Property("string?", pName, true);
                        if (cSetting.Properties.Exists(el => el.Name == p.Name)) { continue; }
                        cSetting.Properties.Add(p);
                    }
                    if (em.Values.Exists(el => el.Text == eValue) == false)
                    {
                        em.Values.Add(new EnumValue(eValue));
                        cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"case ApiPath.{eValue}: return $\"{apiPathFormat}\";"));
                    }
                }
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);"));
            }

            var pApiPath = cParameter.Properties.Find(el => el.Name == "IRestApiParameter.ApiPath");
            pApiPath.Get.IsAutomaticProperty = false;
            pApiPath.Get.Body.Clear();
            pApiPath.Get.Body.Add(SourceCodeLanguage.CSharp, "return this.ApiPathSetting.GetApiPath();");

            if (hasBinaryMethod == true)
            {
                var cClient = sc.Namespaces[0].Classes.Find(el => el.Name == "MicrosoftClient");
                var md = new Method(MethodAccessModifier.Public, className + "StreamAsync");
                md.Comment = url;
                md.Parameters.Add(new MethodParameter(className + "Parameter", "parameter"));
                md.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
                md.ReturnTypeName.Name = "async Task";
                md.ReturnTypeName.GenericTypes.Add(new TypeName("Stream"));
                md.Body.Add(SourceCodeLanguage.CSharp, $"return await this.DownloadStreamAsync(parameter, cancellationToken);");
                if (cClient.Methods.Exists(el => el.Name == md.Name) == false)
                {
                    cClient.Methods.Add(md);
                }
            }

            return sc;
        }
        private String CreateParameterNameFromApiPath(string path)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                var c = path[i];
                if (i == 0 || path[i - 1] == '-' || path[i - 1] == '|' || path[i - 1] == ' ')
                {
                    sb.Append(c.ToString().ToUpper());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Replace("|", "Or").Replace("-", "").Replace("$", "").Replace(".", "").Replace(":", "").Replace(" ", "");
        }
        private String CreateEnumValue(string path)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                var c = path[i];
                if (i == 0 || path[i - 1] == '/' || path[i - 1] == '{' || path[i - 1] == '}' || path[i - 1] == '-' || path[i - 1] == ' ')
                {
                    sb.Append(c.ToString().ToUpper());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Replace("|", "Or").Replace(".", "").Replace("-", "").Replace("{", "").Replace("}", "").Replace("/", "_").Replace("$", "").Replace(":", "").Replace(" ", "");
        }

        private Task<List<ApiParameter>> GetParameterList(IDocument document, IElement table)
        {
            var doc = document;
            var l = new List<ApiParameter>();
            var tbl = table;

            foreach (var row in tbl.QuerySelectorAll("> tbody > tr"))
            {
                var p = new ApiParameter();

                var td1 = row.QuerySelector("> td:nth-child(1)");
                if (td1 == null) { continue; }
                p.Name = td1.TextContent.ToPascalCase();

                if (p.Name == "elevationOfPrivilege,maliciousInsider,passwordCracking,phishingOrWhaling,spoofing).") { continue; }
                if (p.Name.Contains("(deprecated)")) { continue; }
                if (p.Name.Equals("If-match", StringComparison.OrdinalIgnoreCase)) { continue; }
                if (p.Name.Equals("Group@odata.bind", StringComparison.OrdinalIgnoreCase)) { continue; }
                if (p.Name == "@odata.id" || p.Name == "@odata.etag" || p.Name == "@odata.type") { continue; }

                var td2 = row.QuerySelector("> td:nth-child(2)");
                p.TypeName = td2.TextContent.Trim();
                if (p.TypeName.StartsWith("microsoft.graph.", StringComparison.OrdinalIgnoreCase))
                {
                    p.TypeName = CreateClassName(p.TypeName.Replace("microsoft.graph.", "", StringComparison.OrdinalIgnoreCase));
                }
                if (p.TypeName.IsNullOrEmpty()) { continue; }
                if (p.TypeName.Contains("ElevationOfPrivilege,maliciousInsider,passwordCracking,phishingOrWhaling,spoofing)")) { continue; }
                if (p.TypeName.Contains("Default. Enforces the legal minimum. This means parental consent is required for minors in the European Union and Korea")) { break; }

                var hp = td2.QuerySelector("a");
                if (hp != null && hp.GetAttribute("href").StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/"))
                {
                    var url = hp.GetAttribute("href");
                    if (this.IsAvailabelUrl(url))
                    {
                        p.EntityUrl = url;
                    }
                }

                var td3 = row.QuerySelector("td:nth-child(3)");
                if (td3 != null && p.TypeName != "String" && p.TypeName != "String collection" && p.TypeName != "DateTimeOffset" && p.TypeName != "Boolean")
                {
                    if (td3.TextContent.Contains("The possible values are: ") ||
                        td3.TextContent.Contains("The supported values") ||
                        td3.TextContent.Contains("Supported values are") ||
                        td3.TextContent.Contains("Possible values are") ||
                        td3.TextContent.Contains("Possible value: ") ||
                        td3.TextContent.Contains("Possible values:") ||
                        td3.TextContent.Contains("Possible values are ") ||
                        td3.TextContent.Contains("The possible value are ") ||
                        td3.TextContent.Contains("The possible values are ") ||
                        td3.TextContent.Contains("The property values are: ") ||
                        td3.TextContent.Contains("the values for this property will be") ||
                        td3.TextContent.Contains("which can be") ||
                        td3.TextContent.Contains("the condition or exception to apply") ||
                        td3.TextContent.Contains("Allowed values: ") ||
                        td3.TextContent.Contains("The recurrence pattern type") ||
                        td3.TextContent.Contains("The current status of the operation") ||
                        td3.TextContent.Contains("The type of event message"))
                    {
                        foreach (var code in td3.QuerySelectorAll("code"))
                        {
                            var eValue = code.TextContent.Replace(".", "");
                            if (eValue == "Prefer: include-unknown-enum-members") { continue; }
                            if (eValue == "Prefer: include - unknown -enum-members") { continue; }
                            if (eValue.StartsWith("$")) { continue; }

                            p.IsEnum = true;
                            if (eValue.ToInt32().HasValue) { continue; }
                            p.EnumValues.AddIfNotExist(eValue.ToPascalCase());
                        }
                    }
                }
                l.Add(p);
            }
            return Task.FromResult(l);
        }
        protected override string GetClassName(string url, IDocument document)
        {
            var doc = document;

            if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/security-alert?view=graph-rest-1.0"))
            {
                return "SecurityAlert";
            }
            if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/"))
            {
                if (url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/callrecords-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/intune-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/microsoft-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/email-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/office-365-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/onedrive-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-") ||
                    url.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/termstore-"))
                {
                    var path = url.Replace("https://learn.microsoft.com/en-us/graph/api/resources/", "").ExtractString(null, '?');
                    return CreateClassName(path);
                }
                var h1 = doc.QuerySelector("[id='main'] > div > h1");
                if (h1 == null) { return ""; }
                var cName = CreateClassName(h1.TextContent.ExtractString(null, ' '));
                if (cName == "List")
                {
                    cName = "SiteList";
                }
                return cName;
            }
            else
            {
                var apiPath = url.Replace("https://learn.microsoft.com/en-us/graph/api/", "").ExtractString(null, '?');
                return CreateClassName(apiPath);
            }
        }
        private String CreateClassName(string path)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                if (i == 0 || path[i - 1] == '.' || path[i - 1] == '-' || path[i - 1] == '_')
                {
                    sb.Append(path[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(path[i]);
                }
            }
            var cName = sb.ToString().Replace(".", "").Replace("-", "").Replace("_", "");
            foreach (var item in _ClassNameList)
            {
                cName = cName.Replace(item.ToLower(), item);
            }
            return cName;
        }
        protected override Property CreateParameterProperty(ApiParameter parameter)
        {
            var p = parameter;
            var pType = CreatePropertyType(parameter);
            if (parameter.Name == "Anonymous Sharing Link")
            {
                parameter.Name = "AnonymousSharingLink";
            }
            return new Property(pType, parameter.Name, true);
        }
        private String CreatePropertyType(ApiParameter parameter)
        {
            var type = parameter.TypeName;

            if (type == "string collection" || type == "collection(string)" || type.ToLower() == "collection of string") { type = "string[]"; }
            else if (type.Equals("GUID collection", StringComparison.OrdinalIgnoreCase)) { type = "Guid[]"; }
            else if (type.ToLower() == "string (url)" || type == "string (readonly)") { type = "string"; }
            else if (type == "string (enum)") { type = "string"; }
            else if (type.Equals("String (optional)", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type == "** Unknown Type microsoft.management.services.genericWorkloadActivity.models.operation ** collection") { type = "object[]"; }
            else if (type.Equals("String", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Number", StringComparison.OrdinalIgnoreCase)) { type = "double"; }
            else if (type.Equals("url", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Boolean", StringComparison.OrdinalIgnoreCase) || type.ToLower() == "bool") { type = "bool"; }
            else if (type.Equals("int", StringComparison.OrdinalIgnoreCase)) { type = "int"; }
            else if (type.Equals("Integer", StringComparison.OrdinalIgnoreCase)) { type = "int"; }
            else if (type.Equals("float", StringComparison.OrdinalIgnoreCase)) { type = "float"; }
            else if (type.Equals("DateTimeOffSet", StringComparison.OrdinalIgnoreCase)) { type = "DateTimeOffset"; }
            else if (type.Equals("Edm.Duration", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Duration", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Timestamp", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Date", StringComparison.OrdinalIgnoreCase)) { type = "DateOnly"; }
            else if (type.Equals("Binary", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("Edm.Binary", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("TimeOfDay", StringComparison.OrdinalIgnoreCase)) { type = "TimeOnly"; }
            else if (type.Equals("Edm.TimeOfDay", StringComparison.OrdinalIgnoreCase)) { type = "TimeOnly"; }
            else if (type.Equals("(Optional) String", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("String/number", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.StartsWith("Edm.", StringComparison.OrdinalIgnoreCase)) { type = type.Replace("Edm.", ""); }
            else if (type == "columnTypes") { type = "string"; }
            else if (type.Equals("SharepointIds", StringComparison.OrdinalIgnoreCase)) { type = "SharePointIds"; }
            else if (type.Equals("TeamFunSettingsString (enum)", StringComparison.OrdinalIgnoreCase)) { type = "GiphyContentRating"; }
            else if (type.Equals("EducationTeacher", StringComparison.OrdinalIgnoreCase)) { type = "Teacher"; }
            else if (type.Equals("Collection(microsoft.graph.displayNameLocalization)", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type == "Collection(recipient)") { type = "Recipient[]"; }
            else if (type == "Collection(keyValuePair)") { type = "KeyValuePair<string, string>[]"; }
            else if (type == "appHostedMediaConfig or serviceHostedMediaConfig") { type = "MediaConfig"; }
            else if (type == "organizerMeetingInfo or tokenMeetingInfo") { type = "MeetingInfo"; }
            else if (type.ToLower() == "sharepointids") { type = "SharePointIds"; }
            else if (type == "AccessReviewNotificationRecipientScope") { type = "Accessreviewnotificationrecipientscope"; }
            else if (type == "Untyped JSON object") { type = "object"; }
            else if (type == "ExternalConnectorsAcl collection") { type = "Acl[]"; }
            else if (type == "invitationParticipantInfo collection") { type = "ParticipantInfo[]"; }
            else if (type.Equals("ExternalConnectorsExternalItemContent", StringComparison.OrdinalIgnoreCase)) { type = "ExternalItemContent"; }
            else if (type.Equals("ExternalConnectorsProperties", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("ExternalConnectorsConfiguration", StringComparison.OrdinalIgnoreCase)) { type = "Configuration"; }
            else if (type.Equals("AccessReviewNotificationRecipientScope", StringComparison.OrdinalIgnoreCase)) { type = "Accessreviewnotificationrecipientscope"; }
            else if (type.Equals("ChatMessagePolicyViolationPolicyTip", StringComparison.OrdinalIgnoreCase)) { type = "ChatMessagePolicyTip"; }
            else if (type.Equals("LocationUniqueIdType", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("TermStoreLocalizedName", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("TermStoreLocalizedName", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("CallRecordsPstnCallDurationSource", StringComparison.OrdinalIgnoreCase)) { type = "PstnCallDurationSource"; }
            else if (type.Equals("ExchangeIdFormat", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("StagedFeatureName", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("UserFlowType", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("CategoryColor", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("%unique_string%", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("TeamVisibilityType (optional)", StringComparison.OrdinalIgnoreCase)) { type = "TeamVisibilityType"; }
            else if (type.Equals("Error object", StringComparison.OrdinalIgnoreCase)) { type = "string"; }
            else if (type.Equals("roles", StringComparison.OrdinalIgnoreCase)) { type = "string[]"; }
            else if (type.Equals("expirationDateTime", StringComparison.OrdinalIgnoreCase)) { type = "DateTimeOffset"; }
            else if (type.EndsWith("collection", StringComparison.OrdinalIgnoreCase)) { type = type.ExtractString(null, ' ').ToPascalCase() + "[]"; }
            else if (type.StartsWith("Collection(") && type.EndsWith(")"))
            {
                type = type.Replace("microsoft.graph.", "", StringComparison.OrdinalIgnoreCase);
                type = type.ExtractString('(', ')').ToPascalCase() + "[]";
                if (type == "Edm.String[]")
                {
                    type = "string[]";
                }
            }
            else
            {
                type = type.ToPascalCase();
            }

            if (parameter.Required == false)
            {
                type += "?";
            }
            return type;
        }

        protected override string GetClassName(string className, string propertyName)
        {
            if (className.Equals("AccesspackageassignmentpolicyUpdate") && propertyName.Equals("AccessPackageReviewSettings", StringComparison.OrdinalIgnoreCase)) { return "AccessPackageAssignmentReviewSettings"; }
            if (propertyName == "InvitationParticipantInfo") { return "ParticipantInfo"; }
            if (propertyName == "PasswordProfile") { return propertyName; }
            return "";
        }
        protected override string GetEnumName(string className, string propertyName)
        {
            if (className == "TeamFunSettings" && propertyName == "GiphyContentRating") { return "GiphyContentRating"; }
            return "";
        }

        protected override bool IsNextPageTokenProperty(Property property)
        {
            return false;
        }
        protected override Property CreateApiPathProperty(string url, IDocument document)
        {
            var doc = document;

            var p = new Property("string", "IRestApiParameter.ApiPath", true);
            p.Modifier.AccessModifier = MethodAccessModifier.None;
            p.Set = null;

            return p;
        }
        protected override Property CreateHttpMethodProperty(string url, IDocument document)
        {
            var doc = document;
            var pp = this.GetApiRequestPathList(doc);
            if (pp.Length == 0) { throw new InvalidOperationException(); }

            var httpMethod = pp[0].HttpMethod;

            var p = new Property("string", "IRestApiParameter.HttpMethod", true);
            p.Modifier.AccessModifier = MethodAccessModifier.None;
            p.Set = null;
            p.Initializer = $"\"{httpMethod}\"";

            return p;
        }
        private ApiRequestPath[] GetApiRequestPathList(IDocument document)
        {
            var doc = document;
            var l = new List<ApiRequestPath>();
            var h2 = doc.QuerySelector("[id='http-request']");
            if (h2 == null) { return new ApiRequestPath[0]; }
            IElement node = h2.ParentElement.NextElementSibling;
            while (true)
            {
                foreach (var code in node.QuerySelectorAll("[data-author-content]"))
                {
                    var apiText = code.GetAttribute("data-author-content");
                    using (var reader = new StringReader(apiText))
                    {
                        while (reader.Peek() > -1)
                        {
                            var line = reader.ReadLine();
                            if (line.IsNullOrEmpty()) { continue; }
                            var httpMethod = line.ExtractString(null, ' ');
                            var apiPath = line.Replace(httpMethod, "").Trim();
                            //https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0&tabs=http
                            apiPath = apiPath.ExtractString(null, '?');
                            apiPath = apiPath.ExtractString(null, '=');
                            apiPath = apiPath.ExtractString(null, '[');
                            //https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0&tabs=http
                            apiPath = apiPath.ExtractString(null, '(');
                            if (apiPath.IsNullOrEmpty()) { continue; }
                            l.Add(new ApiRequestPath(httpMethod, apiPath));
                        }
                    }
                }
                node = node.NextElementSibling;
                if (node == null) { break; }
                var requestBodyNode = node.QuerySelector("h2#request-body");
                if (requestBodyNode != null) { break; }
                var responseNode = node.QuerySelector("h2#response");
                if (responseNode != null) { break; }
            }
            return l.ToArray();
        }

        protected override Class CreateResponseClass(IDocument document, string className, CreateEntityClassContext context)
        {
            var c = base.CreateResponseClass(document, className, context);

            var entityUrl = "";

            var node = document.QuerySelector("[id='response']");
            if (node != null)
            {
                var pNode = node.ParentElement.NextElementSibling;
                if (pNode != null)
                {
                    var hp = pNode.QuerySelector("a");
                    if (hp != null)
                    {
                        var href = hp.GetAttribute("href").ToString();
                        if (href.StartsWith("https://learn.microsoft.com/en-us/graph/api/resources/", StringComparison.OrdinalIgnoreCase))
                        {
                            if (pNode.TextContent.Contains("collection of") ||
                                pNode.TextContent.Contains(" collection"))
                            {
                                var doc = this.GetDocumentAsync(href).GetAwaiter().GetResult();
                                var cValue = this.CreateEntityClass(href, context).GetAwaiter().GetResult();
                                this.CreateEntitySourceCodeFile(href, cValue);
                                c.Properties.Add(new Property(cValue.Name + "[]?", "Value", true));
                            }
                            else
                            {
                                entityUrl = href;
                            }
                        }
                    }
                }
            }
            if (c.Name.Contains("GetResponse"))
            {
                var resourceName = c.Name.Substring(0, c.Name.IndexOf("GetResponse"));
                var u = this._UrlClassNameMappingList.Find(el => el.ClassName == resourceName);
                if (u != null)
                {
                    entityUrl = u.Url;
                }
            }
            if (c.Name.Contains("ListResponse"))
            {
                var resourceName = c.Name.Substring(0, c.Name.IndexOf("ListResponse"));
                var u = this._UrlClassNameMappingList.Find(el => el.ClassName == resourceName);
                if (u != null)
                {
                    c.Properties.AddIfNotExist(new Property(resourceName + "[]?", "Value", true), el => el.Name == resourceName);
                }
            }

            
            if (entityUrl.IsNullOrEmpty() == false)
            {
                try
                {
                    var doc = this.GetDocumentAsync(entityUrl).GetAwaiter().GetResult();
                    var cEntity = this.CreateEntityClass(entityUrl, context).GetAwaiter().GetResult();
                    this.CreateEntitySourceCodeFile(entityUrl, cEntity);
                    foreach (var item in cEntity.Classes)
                    {
                        c.Classes.Add(item);
                    }
                    foreach (var item in cEntity.Enums)
                    {
                        c.Enums.Add(item);
                    }
                    foreach (var item in cEntity.Properties)
                    {
                        c.Properties.Add(item);
                    }
                }
                catch { }
            }
            return c;
        }
    }
}
