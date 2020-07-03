using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using HigLabo.Core;
using HigLabo.Net;
using System.Net;
using HigLabo.CodeGenerator.Json;

namespace HigLabo.CodeGenerator.Twitter
{
    public class TwitterClientSourceCodeGenerator
    {
        public void GenerateSourceCode(String folderPath)
        {
            var d = new Dictionary<TwitterApiEndpointInfo, SourceCode>();
            var documentUrls = new List<String>();
            var cl = new HttpClient();
            var html = cl.GetBodyText("https://dev.twitter.com/rest/public");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//a[starts-with(@href,'/rest/reference/get/') or starts-with(@href,'/rest/reference/post/')]");
            var apiInfoList = new List<TwitterApiEndpointInfo>();
            foreach (var a in nodes)
            {
                var documentUrl = WebUtility.UrlDecode(a.Attributes["href"].Value);
                //This endpoint has been DEPRECATED.So we skip this endpoint
                if (documentUrl == "/rest/reference/post/statuses/update_with_media") { continue; }

                //documentUrl = "/rest/reference/get/lists/members";//Use when debug...
                if (documentUrls.Contains(documentUrl) == true) { continue; }
                documentUrls.Add(documentUrl);

                var apiInfo = CreateApiInfo(documentUrl);

                //statuses/mentions_timeline
                //statuses/update_with_media
                //application/rate_limit_status
                //user/profile_banner
                //friendships/no_retweets/ids
                //geo/reverse_geocode
                var sc = GenerateApiEntityClasses("https://dev.twitter.com" + apiInfo.DocumentUrl, apiInfo);
                d.Add(apiInfo, sc);
                apiInfoList.AddIfNotExist(apiInfo);

                Console.WriteLine(apiInfo.DocumentUrl);
            }
            this.EnsureDirectory(folderPath);
            
            var sc1 = GenerateApiEndpointClasses(apiInfoList);
            this.CreateSourceCodeFile(Path.Combine(folderPath, "ApiEndpoints.Api.cs"), sc1);

            foreach (var apiInfo in d.Keys)
            {
                var sc = d[apiInfo];
                var fileName = String.Format("{0}.{1}.cs", apiInfo.Name1, apiInfo.Name2);
                this.EnsureDirectory(Path.Combine(folderPath, apiInfo.Name1));
                var filePath = Path.Combine(folderPath, apiInfo.Name1, fileName);
                this.CreateSourceCodeFile(filePath, sc);
                Console.WriteLine(fileName);
            }
            Console.WriteLine("Completed...Please press enter key");
            Console.ReadLine();
        }
        private void CreateSourceCodeFile(String filePath, SourceCode sourceCode)
        {
            using (var stm = new FileStream(filePath, FileMode.Create))
            {
                var cs = new CSharpSourceCodeGenerator(new StreamWriter(stm));
                cs.Write(sourceCode);
                cs.Flush();
                stm.Close();
            }
        }
        private void EnsureDirectory(String folderPath)
        {
            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        private TwitterApiEndpointInfo CreateApiInfo(String url)
        {
            var apiInfo = new TwitterApiEndpointInfo();
            
            apiInfo.DocumentUrl = url;
            var apiNames = apiInfo.DocumentUrl;
            if (apiNames.EndsWith("/:id") == true)
            {
                apiNames = apiNames.Substring(0, apiNames.Length - 4);
            }
            var ss = apiNames.Split('/');
            if (String.Equals(ss[3], "get", StringComparison.OrdinalIgnoreCase) == true)
            {
                apiInfo.HttpMethodName = "Get";
            }
            else if (String.Equals(ss[3], "post", StringComparison.OrdinalIgnoreCase) == true)
            {
                apiInfo.HttpMethodName = "Post";
            }
            apiInfo.Name1 = ss[4];
            if (ss.Length < 6)
            {
                apiInfo.Name2 = "Get";
            }
            else if (ss.Length == 6)
            {
                apiInfo.Name2 = ss[5];
            }
            else
            {
                for (int i = 5; i < ss.Length; i++)
                {
                    apiInfo.Name2 += ss[i];
                    if (i < ss.Length - 1)
                    {
                        apiInfo.Name2 += "_";
                    }
                }
            }
            if (apiInfo.Name2.Contains(":slug") == true)
            {
                apiInfo.Name2 = apiInfo.Name2.Replace(":slug", "Category");
            }
            if (apiInfo.Name2.Contains(":place_id") == true)
            {
                apiInfo.Name2 = apiInfo.Name2.Replace(":place_id", "place_id");
            }
            if (String.Equals(apiInfo.Name1, "Account", StringComparison.OrdinalIgnoreCase) &&
                String.Equals(apiInfo.Name2, "Settings", StringComparison.OrdinalIgnoreCase))
            {
                apiInfo.Name2 = apiInfo.Name2 + "_" + apiInfo.HttpMethodName;
            }
            apiInfo.Name1 = ToPascalCase(apiInfo.Name1);
            apiInfo.Name2 = ToPascalCase(apiInfo.Name2);

            return apiInfo;
        }
        private String ToPascalCase(String value)
        {
            StringBuilder sb = new StringBuilder();
            var previousIsUnderscore = true;
            for (int i = 0; i < value.Length; i++)
            {
                if (previousIsUnderscore == true)
                {
                    sb.Append(value[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(value[i]);
                }
                if (value[i] == '_')
                {
                    previousIsUnderscore = true;
                }
                else
                {
                    previousIsUnderscore = false;
                }
            }
            return sb.ToString();
        }
        private SourceCode GenerateApiEntityClasses(String url, TwitterApiEndpointInfo apiInfo)
        {
            var cl = new HttpClient();
            var html = cl.GetBodyText(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            SourceCode sc = new SourceCode();
            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Collections.Generic");
            sc.UsingNamespaces.Add("Newtonsoft.Json");

            Namespace ns = new Namespace("HigLabo.Net.Twitter.Api_1_1");
            sc.Namespaces.Add(ns);

            AddEntityClasses(doc, ns, apiInfo);

            return sc;
        }
        private void AddEntityClasses(HtmlDocument document, Namespace nameSpace, TwitterApiEndpointInfo apiInfo)
        {
            var ns = nameSpace;
            var doc = document;

            Class api1 = new Class(AccessModifier.Public, apiInfo.Name1);
            api1.Modifier.Partial = true;
            ns.Classes.Add(api1);

            Class api2 = new Class(AccessModifier.Public, apiInfo.Name2);
            api2.Modifier.Partial = true;
            api1.Classes.Add(api2);

            api2.Classes.Add(this.CreateCommandClass(doc, apiInfo));

            //Result class
            var exampleNode = doc.DocumentNode.SelectSingleNode("//article[@id='main-content']"
                + "//pre[@class='brush: jscript' or @class='brush: javascript']");
            if (exampleNode == null) { return; }

            var json = exampleNode.InnerText.Trim();
            json = json.Replace(".json\";", ".json\"");//https://dev.twitter.com/rest/reference/post/geo/place
            json = json.Replace("  ...", "");//https://dev.twitter.com/rest/reference/get/trends/available
            JsonParser parser = new JsonParser();
            var resultClass = parser.Parse(json, "Result");
            //friendships/no_retweets/ids
            if (apiInfo.Name1 == "Friendships" && apiInfo.Name2 == "No_Retweets_Ids")
            {
                apiInfo.ResultClassName = "String";
            }
            else
            {
                api2.Classes.Add(resultClass);
                apiInfo.ResultClassName = String.Format("{0}.{1}.Result", apiInfo.Name1, apiInfo.Name2);
            }
            if (json.StartsWith("[") == true)
            {
                apiInfo.ResultIsArray = true;
            }
            else if (json.StartsWith("{") == true)
            {
                apiInfo.ResultIsArray = false;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        private Class CreateCommandClass(HtmlDocument document, TwitterApiEndpointInfo apiInfo)
        {
            var doc = document;
            var c = new Class(AccessModifier.Public, "Command");

            c.BaseClass = new TypeName("TwitterCommand");
            {
                var md = new Method(MethodAccessModifier.Public, "GetApiEndpointUrl");
                md.ReturnTypeName = new TypeName("String");
                md.Modifier.Polymophism = MethodPolymophism.Override;

                //Api Url
                var urlNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'Node-apiDocsUrl')]//div[@class='Field-items-item even ']");
                var apiUrl = urlNode.InnerText;
                if (apiUrl.EndsWith(":id.json") == true)
                {
                    var url = apiUrl.Replace("/:id.json", "/{0}.json");
                    md.Body.Add(SourceCodeLanguage.CSharp, String.Format("return String.Format(\"{0}\", this.id);", url));
                }
                else
                {
                    md.Body.Add(SourceCodeLanguage.CSharp, String.Format("return \"{0}\";", apiUrl));
                }
                c.Methods.Add(md);
            }
            {
                var md = new Method(MethodAccessModifier.Public, "GetHttpMethodName");
                md.ReturnTypeName = new TypeName("HttpMethodName");
                md.Modifier.Polymophism = MethodPolymophism.Override;
                md.Body.Add(SourceCodeLanguage.CSharp, "return HttpMethodName.{0};", apiInfo.HttpMethodName);
                c.Methods.Add(md);
            }

            var paramsNode = doc.DocumentNode.SelectNodes("//article[@id='main-content']//div[@class='parameter']");
            if (paramsNode != null)
            {
                foreach (var div in paramsNode)
                {
                    var span = div.SelectSingleNode("child::span[@class='param']");
                    var description = div.SelectSingleNode("child::p[position()=1]").InnerText;
                    var exampleValueNode = div.SelectSingleNode("child::p[position()=2]");
                    var requiredNode = div.SelectNodes("descendant::span")
                        .FirstOrDefault(el => String.Equals(el.InnerHtml.Trim(), "required", StringComparison.OrdinalIgnoreCase));
                    var required = requiredNode != null && requiredNode.InnerText.Trim() == "required";

                    var pName = span.FirstChild.InnerText.Trim();
                    pName = pName.Replace(":", "_");
                    var typeName = "String";
                    #region
                    if (pName == "user_id" ||
                        description.StartsWith("Specifies the number of"))
                    {
                        if (required == true)
                        {
                            typeName = "Int64";
                        }
                        else
                        {
                            typeName = "Int64?";
                        }
                    }
                    else if (pName == "count")
                    {
                        if (required == true)
                        {
                            typeName = "Int32";
                        }
                        else
                        {
                            typeName = "Int32?";
                        }
                    }
                    else if (exampleValueNode != null)
                    {
                        if (exampleValueNode.InnerText == "Example Values: true" ||
                            exampleValueNode.InnerText == "Example Values: false")
                        {
                            if (required == true)
                            {
                                typeName = "Boolean";
                            }
                            else
                            {
                                typeName = "Boolean?";
                            }
                        }
                    }
                    #endregion

                    var p = new Property(typeName, pName);
                    p.Get.IsAutomaticProperty = true;
                    p.Set.IsAutomaticProperty = true;
                    c.Properties.Add(p);

                    apiInfo.CommandParameters.Add(new TwitterApiCommandParameterInfo(p.Name, p.TypeName, required));
                }
            }

            apiInfo.CommandParameters.Sort(el =>
            {
                if (el.Required) return "0";
                if (el.Name == "count") return "1";
                if (el.Name == "since_id") return "2";
                if (el.Name == "max_id") return "3";
                return "9";
            });
            //Replace C# keyword
            foreach (var item in apiInfo.CommandParameters.Where(el => el.Name == "long"))
            {
                item.Name = "@long";
            }
            return c;
        }

        private SourceCode GenerateApiEndpointClasses(List<TwitterApiEndpointInfo> apiList)
        {
            SourceCode sc = new SourceCode();
            sc.UsingNamespaces.Add("System");

            Namespace ns = new Namespace("HigLabo.Net.Twitter.Api_1_1");
            sc.Namespaces.Add(ns);

            Class apiEndpointsClass = new Class(AccessModifier.Public, "ApiEndpoints");
            apiEndpointsClass.Modifier.Partial = true;
            ns.Classes.Add(apiEndpointsClass);

            foreach (var apiName1 in apiList.Select(el => el.Name1).Distinct())
            {
                apiEndpointsClass.Fields.Add(new Field("Api_" + apiName1, "_" + apiName1));
                var p = new Property("Api_" + apiName1, apiName1);
                p.Get.Body.Add(SourceCodeLanguage.CSharp, "if (_{0} == null) _{0} = new Api_{0}(this);", apiName1);
                p.Get.Body.Add(SourceCodeLanguage.CSharp, "return _{0};", apiName1);
                p.Set = null;
                apiEndpointsClass.Properties.Add(p);

                Class apiClass = new Class(AccessModifier.Public, "Api_" + apiName1);
                apiClass.Modifier.Partial = true;
                apiEndpointsClass.Classes.Add(apiClass);

                apiClass.Fields.Add(new Field("ApiEndpoints", "_ApiEndpoints"));
                var ct = new Constructor(AccessModifier.Public, "Api_" + apiName1);
                ct.Parameters.Add(new MethodParameter("ApiEndpoints", "apiEndpoints"));
                ct.Body.Add(SourceCodeLanguage.CSharp, "_ApiEndpoints = apiEndpoints;");
                apiClass.Constructors.Add(ct);

                foreach (var apiName2 in apiList.Where(el => el.Name1 == apiName1).Select(el => el.Name2))
                {
                    var apiInfo = apiList.Find(el => el.Name1 == apiName1 && el.Name2 == apiName2);
                    if (apiInfo.HasResult == false) { continue; }

                    apiClass.Methods.Add(this.CreateApiMethod(apiInfo));
                    if (apiInfo.CommandParameters.Count > 0)
                    {
                        apiClass.Methods.AddRange(this.CreateApiMethod1(apiInfo));
                    }
                }
            }
            return sc;
        }
        private Method CreateApiMethod(TwitterApiEndpointInfo apiInfo)
        {
            var arrayText = "";
            if (apiInfo.ResultIsArray == true)
            {
                arrayText = "[]";
            }
            var md = new Method(MethodAccessModifier.Public, apiInfo.Name2);
            md.ReturnTypeName = new TypeName(String.Format("{0}{1}", apiInfo.ResultClassName, arrayText));
            md.Parameters.Add(new MethodParameter(String.Format("{0}.{1}.Command", apiInfo.Name1, apiInfo.Name2), "command"));
            md.Body.Add(SourceCodeLanguage.CSharp
                , "return _ApiEndpoints._Client.GetResult<{0}.{1}.Command, {2}{3}>(command);"
                , apiInfo.Name1, apiInfo.Name2, apiInfo.ResultClassName, arrayText);

            return md;
        }
        private List<Method> CreateApiMethod1(TwitterApiEndpointInfo apiInfo)
        {
            var l = new List<Method>();
            var pp = new List<List<TwitterApiCommandParameterInfo>>();
            if (apiInfo.CommandParameters.Count(el => el.Name == "screen_name" || el.Name == "user_id") == 2)
            {
                pp.Add(apiInfo.CommandParameters.Where(el => el.Name != "screen_name").ToList());
                pp.Add(apiInfo.CommandParameters.Where(el => el.Name != "user_id").ToList());
            }
            else
            {
                pp.Add(apiInfo.CommandParameters.ToList());
            }
            if (apiInfo.CommandParameters.Exists(el => el.Required == false) == true)
            {
                var p1 = apiInfo.CommandParameters.Where(el => el.Required).ToList();
                foreach (var p in p1)
                {
                    if (p.TypeName.Name.EndsWith("?") == true)
                    {
                        p.TypeName.Name = p.TypeName.Name.Replace("?", "");
                    }
                }
                if (p1.Count > 0 || p1.All(el => el.Required == false))
                {
                    pp.Add(p1);
                }

                var p2 = apiInfo.CommandParameters.Where(el => el.Required ||
                    el.Name == "since_id" || el.Name == "max_id").ToList();
                if (p1.Count != p2.Count)
                {
                    pp.Add(p2);
                }
            }
            foreach (var p in pp)
            {
                l.Add(this.CreateApiMethod1(apiInfo, p));
            }
            l.Sort(el => el.Parameters.Count);

            return l;
        }
        private Method CreateApiMethod1(TwitterApiEndpointInfo apiInfo, IEnumerable<TwitterApiCommandParameterInfo> parameters)
        {
            var arrayText = "";
            if (apiInfo.ResultIsArray == true)
            {
                arrayText = "[]";
            }
            var md = new Method(MethodAccessModifier.Public, apiInfo.Name2);
            md.ReturnTypeName = new TypeName(String.Format("{0}{1}", apiInfo.ResultClassName, arrayText));

            var commandClassName = String.Format("{0}.{1}.Command", apiInfo.Name1, apiInfo.Name2);
            md.Body.Add(SourceCodeLanguage.CSharp, "var cm = new {0}();", commandClassName);
            foreach (var p in parameters)
            {
                md.Parameters.Add(new MethodParameter(p.TypeName.ToString(), p.Name.ToLower()));
                md.Body.Add(SourceCodeLanguage.CSharp, "cm.{0} = {0};", p.Name);
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return this.{0}(cm);", apiInfo.Name2);

            return md;
        }
    }
}
