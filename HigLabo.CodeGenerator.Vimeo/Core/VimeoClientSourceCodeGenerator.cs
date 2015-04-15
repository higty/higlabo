using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;
using HigLabo.Net;
using HigLabo.Core;
using HigLabo.CodeGenerator.Json;
using HigLabo.Converter;

namespace HigLabo.CodeGenerator.Vimeo
{
    public class VimeoClientSourceCodeGenerator
    {
        private static List<String> _IDParameterNames = new List<String>();
        private static Dictionary<String, String> _IDParameterValues = new Dictionary<string, string>();
        public String AppID { get; set; }
        public String AccessToken { get; set; }

        static VimeoClientSourceCodeGenerator()
        {
            InitializeIDParameterNames();
        }
        private static void InitializeIDParameterNames()
        {
            var l = _IDParameterNames;
            var d = _IDParameterValues;

            l.Add("video_id"); d["video_id"] = "122959827"; d["video_id"] = "53332757";
            l.Add("user_id"); d["user_id"] = "user34273722"; d["user_id"] = "user26726486";
            l.Add("follow_user_id");
            l.Add("channel_id"); d["channel_id"] = "staffpicks";
            l.Add("album_id");
            l.Add("preset_id");
            l.Add("group_id");
            l.Add("portraitset_id");
            l.Add("portfolio_id");
            l.Add("ondemand_id");
        }
        public VimeoClientSourceCodeGenerator()
        {
            this.AppID = "2221";//API Playground
        }

        public void GenerateSourceCode(String folderPath)
        {
            var d = new Dictionary<VimeoApiEndpointInfo, SourceCode>();
            var documentUrls = new List<String>();
            var cl = new HttpClient();
            var html = cl.GetBodyText("https://developer.vimeo.com/api/endpoints/");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var playgroundUrls = new List<string>();

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='list js-endpoint_list']//div[@class='item js-endpoint_name txt_md']//a");
            foreach (var node in nodes)
            {
                var href = "https://developer.vimeo.com" + node.Attributes["href"].Value;
                Console.WriteLine(href);
                playgroundUrls.AddRange(this.GetPlaygroundUrls(href));
            }
            playgroundUrls = playgroundUrls.Distinct().ToList();

            playgroundUrls.Add("https://developer.vimeo.com/api/playground/users/");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/users/{user_id}");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/channels/");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/channels/{channel_id}");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/channels/{channel_id}/videos");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/users/{user_id}/videos");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/videos/");
            playgroundUrls.Add("https://developer.vimeo.com/api/playground/videos/{video_id}");

            var apiInfoList = new List<VimeoApiEndpointInfo>();
            foreach (var url in playgroundUrls)
            {
                foreach (var apiInfo in CreateApiInfoList(url))
                {
                    if (apiInfo.HttpMethodName != "Get") { continue; }
                    if (apiInfoList.Exists(el => el.Name1 == apiInfo.Name1 &&
                        el.Name2 == apiInfo.Name2) == true) { continue; }

                    var sc = GenerateApiEntityClasses(apiInfo.ApiPlaygroundUrl, apiInfo);
                    d.Add(apiInfo, sc);
                    apiInfoList.AddIfNotExist(apiInfo);

                    Console.WriteLine(String.Format("{0}: {1}.{2}"
                        , apiInfo.ApiPath, apiInfo.Name1, apiInfo.Name2));
                }
            }
            this.EnsureDirectory(folderPath);

            foreach (var apiInfo in d.Keys)
            {
                var sc = d[apiInfo];
                var fileName = String.Format("{0}.{1}.cs", apiInfo.Name1, apiInfo.Name2);
                this.EnsureDirectory(Path.Combine(folderPath, apiInfo.Name1));
                var filePath = Path.Combine(folderPath, apiInfo.Name1, fileName);
                this.CreateSourceCodeFile(filePath, sc);
                Console.WriteLine(fileName);
            }

            var sc1 = GenerateApiEndpointClasses(apiInfoList);
            this.CreateSourceCodeFile(Path.Combine(folderPath, "ApiEndpoints.Api.cs"), sc1);

            Console.WriteLine("Completed...Please press enter key");
            Console.ReadLine();
        }
        private List<String> GetPlaygroundUrls(String url)
        {
            var l = new List<String>();
            var cl = new HttpClient();
            var html = cl.GetBodyText(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//a[starts-with(@href, '/api/playground')]");

            foreach (var node in nodes)
            {
                if (node.Attributes["href"].Value == "/api/playground/") { continue; }
                l.Add("https://developer.vimeo.com" + node.Attributes["href"].Value);
            }

            return l;
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
        private List<VimeoApiEndpointInfo> CreateApiInfoList(String apiPlaygroundUrl)
        {
            var l = new List<VimeoApiEndpointInfo>();
            HttpClient cl = new HttpClient();
            var html = cl.GetBodyText(apiPlaygroundUrl);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//div[@id='playground_table']//ul[@class='switch_menu js-switch_menu']//a[@class='http_method']");
            if (nodes == null)
            {
                nodes = doc.DocumentNode.SelectNodes("//div[@id='playground_table']//div[@class='switch_current js-switch_current ']//span[@class='http_method']");
            }
            foreach (var item in nodes)
            {
                var apiInfo = new VimeoApiEndpointInfo();

                apiInfo.ApiPlaygroundUrl = apiPlaygroundUrl;
                apiInfo.ApiPath = apiPlaygroundUrl.Replace("https://developer.vimeo.com/api/playground/", "");
                apiInfo.HttpMethodName = ToPascalCase(item.InnerText.Trim().ToLower());

                var apiNames = apiInfo.ApiPath;
                var ss = apiNames.Split('/');
                apiInfo.Name1 = ss[0];

                if (ss.Length == 1)
                {
                    apiInfo.Name2 = ToPascalCase(apiInfo.HttpMethodName);
                }
                if (ss.Length == 2)
                {
                    apiInfo.Name2 = ss[1];
                }
                else
                {
                    for (int i = 1; i < ss.Length; i++)
                    {
                        apiInfo.Name2 += ss[i];
                        if (i < ss.Length - 1)
                        {
                            apiInfo.Name2 += "_";
                        }
                    }
                }
                apiInfo.Name2 = apiInfo.Name2.Replace("_id", "ID").Replace("{", "").Replace("}", "");
                if (apiInfo.Name2.IsNullOrEmpty() == true)
                {
                    apiInfo.Name2 = apiInfo.HttpMethodName;
                }
                else
                {
                    apiInfo.Name2 = apiInfo.Name2 + "_" + apiInfo.HttpMethodName;
                }
                
                apiInfo.Name1 = ToPascalCase(apiInfo.Name1);
                apiInfo.Name2 = ToPascalCase(apiInfo.Name2);

                l.Add(apiInfo);
            }

            return l;
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
        private SourceCode GenerateApiEntityClasses(String url, VimeoApiEndpointInfo apiInfo)
        {
            var cl = new HttpClient();
            var html = cl.GetBodyText(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            SourceCode sc = new SourceCode();
            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Collections.Generic");
            sc.UsingNamespaces.Add("Newtonsoft.Json");

            Namespace ns = new Namespace("HigLabo.Net.Vimeo.Api_3_2");
            sc.Namespaces.Add(ns);

            AddEntityClasses(doc, ns, apiInfo);

            return sc;
        }
        private void AddEntityClasses(HtmlDocument document, Namespace nameSpace, VimeoApiEndpointInfo apiInfo)
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

            var resultClass = CreateResultClass(apiInfo);
            if (resultClass != null)
            {
                api2.Classes.Add(resultClass);
            }
        }
        private Class CreateCommandClass(HtmlDocument document, VimeoApiEndpointInfo apiInfo)
        {
            var doc = document;
            var c = new Class(AccessModifier.Public, "Command");

            c.BaseClass = new TypeName("VimeoCommand");

            var returnApiPath = "\"" + apiInfo.ApiPath + "\"";
            foreach (var item in _IDParameterNames)
            {
                if (apiInfo.ApiPath.Contains("{" + item + "}") == true)
                {
                    returnApiPath = returnApiPath.Replace("{" + item + "}", "\" + this." + item + " + \"");

                    apiInfo.CommandParameters.Add(new VimeoApiCommandParameterInfo(item, new TypeName("String"), true));

                    var p = new Property("String", item);
                    p.Get.IsAutomaticProperty = true;
                    p.Set.IsAutomaticProperty = true;
                    c.Properties.Add(p);
                }
            }
            {
                var md = new Method(MethodAccessModifier.Public, "GetApiEndpointUrl");
                md.ReturnTypeName = new TypeName("String");
                md.Modifier.Polymophism = MethodPolymophism.Override;

                if (returnApiPath.EndsWith(" + \"\""))
                {
                    returnApiPath = returnApiPath.Replace(" + \"\"", "");
                }
                md.Body.Add(SourceCodeLanguage.CSharp, String.Format("return {0};", returnApiPath));

                c.Methods.Add(md);
            }
            {
                var md = new Method(MethodAccessModifier.Public, "GetHttpMethodName");
                md.ReturnTypeName = new TypeName("HttpMethodName");
                md.Modifier.Polymophism = MethodPolymophism.Override;
                md.Body.Add(SourceCodeLanguage.CSharp, "return HttpMethodName.{0};", apiInfo.HttpMethodName);
                c.Methods.Add(md);
            }

            var xPath = String.Format("//section[@id='{0}']//table[@class='params']//tbody//tr", apiInfo.HttpMethodName.ToUpper());
            var paramsNode = doc.DocumentNode.SelectNodes(xPath);
            if (paramsNode != null)
            {
                foreach (var div in paramsNode)
                {
                    var pName = div.SelectSingleNode("child::td[position()=1]").InnerText.Trim();
                    var description = div.SelectSingleNode("child::td[position()=3]").InnerText.Trim();
                    var requiredText = div.SelectSingleNode("child::td[position()=4]").InnerText.Trim();
                    var required = false;
                    if (requiredText == "Yes")
                    {
                        required = true;
                    }
                    else if (requiredText == "No")
                    {
                        required = false;
                    }
                    else { throw new InvalidOperationException(); }

                    var typeName = "String";
                    var typeNode = div.SelectSingleNode("child::td[position()=2]");
                    var tx = typeNode.SelectSingleNode("child::input[@type='text']");
                    if (tx != null)
                    {
                        typeName = this.GetCSharpTypeName(tx.Attributes["placeholder"].Value.Trim(), required);
                    }
                    var dl = typeNode.SelectSingleNode("child::select");
                    if (dl != null)
                    {
                        //Enum
                        var em = new Enum(AccessModifier.Public, ToPascalCase(pName + "Values"));
                        var options = dl.SelectNodes("child::option");
                        foreach (var item in options)
                        {
                            if (item.Attributes["value"].Value.IsNullOrEmpty()) { continue; }
                            var eValue = item.Attributes["value"].Value.Replace("-", "_").Replace(" ", "");
                            if (eValue == "true" || eValue == "false" || eValue == "default")
                            {
                                eValue = "@" + eValue;
                            }
                            em.Values.Add(new EnumValue(eValue));
                        }
                        c.Enums.Add(em);
                        typeName = String.Format("{0}.{1}.Command.{2}", apiInfo.Name1, apiInfo.Name2, em.Name);
                    }

                    var p = new Property(typeName, pName.Replace(".", "_"));
                    p.Attributes.Add(String.Format("[VimeoParameterName(\"{0}\")]", pName));
                    p.Get.IsAutomaticProperty = true;
                    p.Set.IsAutomaticProperty = true;
                    c.Properties.Add(p);

                    apiInfo.CommandParameters.Add(new VimeoApiCommandParameterInfo(p.Name, p.TypeName, required));
                }
            }
            return c;
        }
        private Class CreateResultClass(VimeoApiEndpointInfo apiInfo)
        {
            var d = apiInfo.CommandParameters.Where(el => el.Required).ToDictionary(el => el.Name, el => "messi");
            d["access_token"] = this.AccessToken;
            var json = this.CallApi(apiInfo, d);
            JsonParser parser = new JsonParser();
            var c = parser.Parse(json, "Result");

            apiInfo.ResultClassName = String.Format("{0}.{1}.Result", apiInfo.Name1, apiInfo.Name2);

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

            return c;
        }
        private String CallApi(VimeoApiEndpointInfo apiInfo, Dictionary<String, String> parameters)
        {
            var cl = new HttpClient();
            var methodName = apiInfo.HttpMethodName.ToEnum<HttpMethodName>().Value;
            var qs = new QueryStringConverter();
            var url = String.Format("https://api.vimeo.com/{0}?{1}", apiInfo.ApiPath, qs.Write(parameters));
            foreach (var key in _IDParameterValues.Keys)
            {
                url = url.Replace("{" + key + "}", _IDParameterValues[key]);
            }

            var cm = new HttpRequestCommand(url);
            cm.MethodName = methodName;
            if (cm.MethodName != HttpMethodName.Get)
            {
                cm.SetBodyStream(new HttpBodyFormUrlEncodedData(parameters));
            }
            var json = cl.GetBodyText(cm);
            return json;
        }
        private String GetCSharpTypeName(String typeName, Boolean required)
        {
            if (typeName == "string") { return "String"; }
            if (typeName == "int")
            {
                if (required == true)
                {
                    return "Int32";
                }
                return "Int32?";
            }
            throw new InvalidOperationException();
        }

        private SourceCode GenerateApiEndpointClasses(List<VimeoApiEndpointInfo> apiList)
        {
            SourceCode sc = new SourceCode();
            sc.UsingNamespaces.Add("System");

            Namespace ns = new Namespace("HigLabo.Net.Vimeo.Api_3_2");
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
        private Method CreateApiMethod(VimeoApiEndpointInfo apiInfo)
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
        private List<Method> CreateApiMethod1(VimeoApiEndpointInfo apiInfo)
        {
            var l = new List<Method>();
            var pp = new List<List<VimeoApiCommandParameterInfo>>();
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
        private Method CreateApiMethod1(VimeoApiEndpointInfo apiInfo, IEnumerable<VimeoApiCommandParameterInfo> parameters)
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
