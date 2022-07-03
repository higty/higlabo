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

namespace HigLabo.Net.CodeGenerator
{
    public class MicrosoftSourceCodeGenerator : OAuthClientCodeGenerator
    {
        public override bool UseSelenium => true;

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

        public override Task CreateScopeSourceCode()
        {
            var html = this.GetHtml("https://docs.microsoft.com/en-us/graph/permissions-reference");
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
            Console.WriteLine("Scope");

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

        protected override Task<List<string>> GetEntiryUrlList()
        {
            var l = new List<String>();
            var html = this.GetHtml("https://docs.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0");

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
                if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/"))
                {
                    l.AddIfNotExist(url);
                }
            }
            return Task.FromResult(l);
        }
        private Boolean IsAvailabelUrl(string url)
        {
            if (url.Contains("-overview?") ||
                url.Contains("-conceptual?") ||
                url == "https://docs.microsoft.com/en-US/graph/api/resources/parentalcontrolsettings") 
            { return false; }
            return true;
        }
        protected override Task<List<ApiParameter>> GetEntityParameterList(IDocument document)
        {
            var doc = document;
            var l = new List<ApiParameter>();
            var div = doc.QuerySelector("[id='properties']");
            if (div == null) { return Task.FromResult(l); }
            IElement tbl = null;
            while (div != null)
            {
                div = div.NextElementSibling;
                if (div == null) { break; }
                tbl = div.QuerySelector("table[aria-label='Properties']");
                if (tbl != null) { break; }
            }
            if (tbl == null) { return Task.FromResult(l); }

            foreach (var row in tbl.QuerySelectorAll("> tbody > tr"))
            {
                var p = new ApiParameter();

                var td1 = row.QuerySelector("> td:nth-child(1)");
                if (td1 == null) { continue; }
                p.Name = td1.TextContent.ToPascalCase();

                if (p.Name == "elevationOfPrivilege,maliciousInsider,passwordCracking,phishingOrWhaling,spoofing).") { continue; }
                if (p.Name.Contains("(deprecated)")) { continue; }
                if (p.Name == "@odata.etag") { continue; }

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
                if (hp != null && hp.GetAttribute("href").StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/"))
                {
                    var url = hp.GetAttribute("href");
                    if (this.IsAvailabelUrl(url))
                    {
                        p.EntityUrl = url;
                        p.EntityClassName = p.TypeName;
                    }
                }

                var td3 = row.QuerySelector("td:nth-child(3)");
                if (td3 != null && p.TypeName != "String" && p.TypeName != "DateTimeOffset" && p.TypeName != "Boolean")
                {
                    if (td3.TextContent.Contains("The possible values are: ") ||
                        td3.TextContent.Contains("The supported values") ||
                        td3.TextContent.Contains("Supported values are:") ||
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
                        td3.TextContent.Contains("The type of event message"))
                    {
                        foreach (var code in td3.QuerySelectorAll("code"))
                        {
                            var eValue = code.TextContent;
                            if (eValue == "Prefer: include-unknown-enum-members") { continue; }
                            if (eValue.StartsWith("$")) { break; }

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

        protected override Task<List<string>> GetMethodUrlList()
        {
            var l = new List<String>();
            var html = this.GetHtml("https://docs.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0");

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
                if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0")) { continue; }
                if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resource/")) { continue; }
                l.AddIfNotExist(url);
            }
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "ServiceUpdateCategory".ToLower());
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "ServiceUpdateSeverity".ToLower());
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "DisplayNameLocalization".ToLower());
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "DocumentSetContent".ToLower());
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "ContentTypeInfo".ToLower());
            l.Add("https://docs.microsoft.com/en-us/graph/api/resource/" + "InvitationParticipantInfo".ToLower());

            return Task.FromResult(l);
        }

        protected override string GetClassName(string url, IDocument document)
        {
            var doc = document;
            var h1 = doc.QuerySelector("[id='main'] > div > h1");
            var cName = CreateClassName(h1.TextContent.ExtractString(null, ' '));
            if (cName == "List")
            {
                cName = "SiteList";
            }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/callrecords-useragent", StringComparison.InvariantCulture)) { return "CallRecordsUserAgent"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/callrecords-endpoint", StringComparison.InvariantCulture)) { return "CallRecordsEndpoint"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/callrecords-failureinfo", StringComparison.InvariantCulture)) { return "CallRecordsFailureInfo"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/termstore-set", StringComparison.OrdinalIgnoreCase)) { return "TermStoreSet"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/termstore-term", StringComparison.OrdinalIgnoreCase)) { return "TermStoreTerm"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/termstore-localizedname", StringComparison.OrdinalIgnoreCase)) { return "TermStoreLocalizedName"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/termstore-localizedlabel", StringComparison.OrdinalIgnoreCase)) { return "TermStoreLocalizedLabel"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/termstore-localizeddescription", StringComparison.OrdinalIgnoreCase)) { return "TermStoreLocalizedDescription"; }
            if (url.StartsWith("https://docs.microsoft.com/en-us/graph/api/resources/callrecords-"))
            {
                var path = url.Replace("https://docs.microsoft.com/en-us/graph/api/resources/", "").ExtractString(null, '?');
                return CreateClassName(path);
            }
            return cName;
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
            return sb.ToString().Replace(".", "").Replace("-", "").Replace("_", "");
        }
        protected override string GetHttpMethod(IDocument document)
        {
            var doc = document;
            var h2 = doc.QuerySelector("[id='http-request']");
            IElement node = h2.NextElementSibling;
            while (true)
            {
                if (string.Equals(node.TagName, "pre", StringComparison.OrdinalIgnoreCase))
                {
                    var span = node.QuerySelector("span.hljs-attribute");
                    return span.TextContent.ExtractString(null, '/').Trim();
                }
                node = node.NextElementSibling;
            }
        }
        protected override string GetApiPath(IDocument document)
        {
            var doc = document;
            var h2 = doc.QuerySelector("[id='http-request']");
            if (h2 == null) { return ""; }
            IElement node = h2.NextElementSibling;
            while (true)
            {
                if (string.Equals(node.TagName, "pre", StringComparison.OrdinalIgnoreCase))
                {
                    var span = node.QuerySelector("span.hljs-attribute");
                    return span.TextContent.ExtractString('/', null).Trim();
                }
                node = node.NextElementSibling;
            }
        }

        protected override Task<List<ApiParameter>> GetMethodParameterList(IDocument document)
        {
            var doc = document;
            var l = new List<ApiParameter>();
            var tbl = doc.QuerySelector("table[aria-label='Request body']");

            foreach (var row in doc.QuerySelectorAll("tbody tr"))
            {
                var p = new ApiParameter();
                p.Name = row.QuerySelector("td:nth-child(1)").TextContent.ToPascalCase();
                p.TypeName = row.QuerySelector("td:nth-child(2)").TextContent;
                l.Add(p);
            }
            return Task.FromResult(l);
        }
        protected override Property CreateParameterProperty(ApiParameter parameter)
        {
            var p = parameter;
            var pType = CreatePropertyType(parameter);
            return new Property(pType, parameter.Name, true);
        }
        private String CreatePropertyType(ApiParameter parameter)
        {
            var type = parameter.TypeName;

            if (type == "string collection" || type == "collection(string)" || type.ToLower() == "collection of string") { return "string[]"; }
            else if (type.ToLower() == "string (url)" || type == "string (readonly)") { return "string"; }
            else if (type == "string (enum)") { return "string"; }
            else if (type == "** Unknown Type microsoft.management.services.genericWorkloadActivity.models.operation ** collection") { return "object[]"; }
            else if (type == "String" || type == "Edm.String") { return "string"; }
            else if (type.ToLower() == "url") { return "string"; }
            else if (type == "Boolean" || type.ToLower() == "bool" || type == "Edm.Boolean") { return "bool"; }
            else if (type.ToLower() == "int") { return "int"; }
            else if (type == "Edm.DateTimeOffset" || type.Equals("DateTimeOffSet", StringComparison.OrdinalIgnoreCase)) { return "DateTimeOffset"; }
            else if (type == "Timestamp") { return "string"; }
            else if (type == "Duration") { return "string"; }
            else if (type == "Date") { return "DateOnly"; }
            else if (type == "Edm.TimeOfDay") { return "TimeOnly"; }
            else if (type == "TimeOfDay") { return "TimeOnly"; }
            else if (type == "columnTypes") { return "string"; }
            else if (type.Equals("SharepointIds", StringComparison.OrdinalIgnoreCase)) { return "SharePointIds"; }
            else if (type.Equals("TeamFunSettingsString (enum)", StringComparison.OrdinalIgnoreCase)) { return "GiphyContentRating"; }
            else if (type.Equals("EducationTeacher", StringComparison.OrdinalIgnoreCase)) { return "Teacher"; }
            else if (type == "Collection(recipient)") { return "Recipient[]"; }
            else if (type == "Collection(keyValuePair)") { return "KeyValuePair<string, string>[]"; }
            else if (type == "Collection(microsoft.graph.displayNameLocalization)") { return "string[]"; }
            else if (type == "Collection(microsoft.graph.documentSetContent)") { return "DocumentSetContent[]"; }
            else if (type == "Collection(microsoft.graph.contentTypeInfo)") { return "ContentTypeInfo[]"; }
            else if (type == "appHostedMediaConfig or serviceHostedMediaConfig") { return "MediaConfig"; }
            else if (type == "organizerMeetingInfo or tokenMeetingInfo") { return "MeetingInfo"; }
            else if (type.ToLower() == "sharepointids") { return "SharePointIds"; }
            else if (type == "AccessReviewNotificationRecipientScope") { return "Accessreviewnotificationrecipientscope"; }
            else if (type == "Untyped JSON object") { return "object"; }
            else if (type == "Edm.Binary" || type == "Binary") { return "string"; }
            else if (type == "ExternalConnectorsAcl collection") { return "Acl[]"; }
            else if (type == "invitationParticipantInfo collection") { return "ParticipantInfo[]"; }
            else if (type.Equals("ExternalConnectorsExternalItemContent", StringComparison.OrdinalIgnoreCase)) { return "ExternalItemContent"; }
            else if (type.Equals("ExternalConnectorsProperties", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.Equals("ExternalConnectorsConfiguration", StringComparison.OrdinalIgnoreCase)) { return "Configuration"; }
            else if (type.Equals("AccessReviewNotificationRecipientScope", StringComparison.OrdinalIgnoreCase)) { return "Accessreviewnotificationrecipientscope"; }
            else if (type.Equals("ChatMessagePolicyViolationPolicyTip", StringComparison.OrdinalIgnoreCase)) { return "ChatMessagePolicyTip"; }
            else if (type.Equals("LocationUniqueIdType", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.Equals("TermStoreLocalizedName", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.Equals("TermStoreLocalizedName", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.Equals("CallRecordsPstnCallDurationSource", StringComparison.OrdinalIgnoreCase)) { return "PstnCallDurationSource"; }
            else if (type.Equals("UserFlowType", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.Equals("CategoryColor", StringComparison.OrdinalIgnoreCase)) { return "string"; }
            else if (type.EndsWith("collection")) { return type.ExtractString(null, ' ').ToPascalCase() + "[]"; }
            else if (type.StartsWith("Collection(") && type.EndsWith(")"))
            {
                return type.ExtractString('(', ')').ToPascalCase() + "[]";
            }
            else
            {
                type = type.ToPascalCase();
            }

            if (parameter.Required == false && type != "string")
            {
                type += "?";
            }
            return type;
        }

        protected override string GetClassName(string className, string propertyName)
        {
            if (propertyName == "InvitationParticipantInfo") { return "ParticipantInfo"; }
            if (propertyName == "PasswordProfile") { return propertyName; }
            return "";
        }
        protected override string GetEnumName(string className, string propertyName)
        {
            if (className == "TeamFunSettings" && propertyName == "GiphyContentRating") { return "GiphyContentRating"; }
            return "";
        }
    }
}
