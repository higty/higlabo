using HigLabo.CodeGenerator;
using HigLabo.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.OpenAI.CodeGenerator;

public class OpenAISourceCodeGenerator
{
    public static class RegexList
    {
        public static readonly Regex CurlyBrackets = new Regex("{(?<Value>[^}]*)}", RegexOptions.Compiled);
    }
    public string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36";
    public string OutputFolderPath { get; set; } = "C:\\GitHub\\higty\\HigLabo\\Net9\\HigLabo.OpenAI\\Generated\\";

    public void ExecuteAsync()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--user-agent=" + UserAgent);
        options.AddArguments("-window-size=1920,1080");
        var driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("https://localhost:7054/");
        Thread.Sleep(10000);

        var ee = driver.FindElements(By.CssSelector("div[class='section']"));
        //CreateSourceCode(ee[71]);
        //return;
        Console.WriteLine($"Code generation started");

        for (int i = 0; i < ee.Count; i++)
        {
            CreateSourceCode(ee[i]);
        }
        Console.WriteLine($"Code generation Completed");
    }
    public void CreateSourceCode(IWebElement endpointPanel)
    {
        var endpointAnchor = endpointPanel.FindElement(By.CssSelector("h2.anchor-heading")).Text;
        if (endpointAnchor.Contains("Deprecated") ||
            endpointAnchor.Contains("Legacy")) { return; }
        //Audit will be support when I have a time...
        if (endpointAnchor.Contains("Audit")) { return; }

        var sc = new SourceCode();
        sc.UsingNamespaces.Add("System.Collections.Generic");
        sc.UsingNamespaces.Add("System.IO");
        sc.UsingNamespaces.Add("System.Text");
        sc.UsingNamespaces.Add("System.Net");
        sc.UsingNamespaces.Add("System.Runtime.CompilerServices");
        sc.UsingNamespaces.Add("System.Threading");
        sc.UsingNamespaces.Add("System.Threading.Tasks");
        sc.Namespaces.Add(new Namespace($"HigLabo.OpenAI"));

        var endpointUrl = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-path']")).FirstOrDefault()?.Text ?? "";
        if (endpointUrl.IsNullOrEmpty()) { return; }

        var httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-post']")).FirstOrDefault()?.Text ?? "";
        if (httpMethod.IsNullOrEmpty())
        {
            httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-delete']")).FirstOrDefault()?.Text ?? "";
        }
        if (httpMethod.IsNullOrEmpty())
        {
            httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-get']")).First().Text ?? "";
        }
        var endpointPath = endpointUrl.Replace("https://api.openai.com/v1/", "");

        var cName = this.GetClassName(endpointAnchor.Replace("\r\nBeta", ""));
        if (cName == null) { return; }

        if (cName.IsNullOrEmpty())
        {
            var beforeIsSlash = false;
            foreach (var c in endpointPath)
            {
                if (c == '/')
                {
                    beforeIsSlash = true;
                    continue;
                }
                else
                {
                    if (beforeIsSlash)
                    {
                        cName += c.ToString().ToUpper();
                    }
                    else
                    {
                        if (cName == "")
                        {
                            cName += c.ToString().ToUpper();
                        }
                        else
                        {
                            cName += c.ToString();
                        }
                    }
                    beforeIsSlash = false;
                }
            }
        }
        Console.WriteLine($"{endpointPath} {cName}");

        var streamResult = "";
        if (cName == "ChatCompletionCreate")
        {
            streamResult = "ChatCompletionStreamResult";
        }
        if (cName == "ResponseCreate")
        {
            streamResult = "ResponseStreamResult";
        }
        var hasAssistantStreamMethod = false;
        if (cName == "ThreadRun" ||
            cName == "RunCreate" ||
            cName == "SubmitToolOutputs")
        {
            streamResult = "AssistantMessageStreamResult";
        }

        var cParameter = new Class(AccessModifier.Public, cName + "Parameter");
        sc.Namespaces[0].Classes.Add(cParameter);
        cParameter.Comment = endpointPanel.FindElement(By.CssSelector("[class='endpoint-summary']")).Text + Environment.NewLine
            + $"<seealso href=\"{endpointUrl}\">{endpointUrl}</seealso>";
        cParameter.Modifier.Partial = true;
        cParameter.BaseClass = new TypeName("RestApiParameter");
        cParameter.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
        if (this.IsAssistantApiEndpoint(cName))
        {
            cParameter.ImplementInterfaces.Add(new TypeName("IAssistantApiParameter"));
        }
        cParameter.Properties.Add(this.CreateHttpMethodProperty(httpMethod));
        cParameter.Methods.Add(this.CreateGetApiPathMethod(endpointUrl));

        var responseClassName = this.GetResponseClassName(cName);
        var sendAsyncMethodName = "SendJsonAsync";
        var tResponseName = $"{cName}Response";
        if (responseClassName == "Stream")
        {
            sendAsyncMethodName = "SendJsonAndGetStreamAsync";
            tResponseName = "Stream";
        }

        var cResponse = new Class(AccessModifier.Public, cName + "Response");
        if (responseClassName != "Stream")
        {
            sc.Namespaces[0].Classes.Add(cResponse);
        }
        cResponse.Modifier.Partial = true;
        cResponse.ImplementInterfaces.Add(new TypeName(responseClassName));

        var cClient = new Class(AccessModifier.Public, "OpenAIClient");
        sc.Namespaces[0].Classes.Add(cClient);
        cClient.Modifier.Partial = true;

        var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
        mdAsync.ReturnTypeName.Name = "async ValueTask";
        mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(tResponseName));
        mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

        var mdStreamAsync = new Method(MethodAccessModifier.Public, cName + "StreamAsync");
        mdStreamAsync.ReturnTypeName.Name = "async IAsyncEnumerable";
        mdStreamAsync.ReturnTypeName.GenericTypes.Add(new TypeName("string"));
        mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

        var mdCreateFormDataParameter = new Method(MethodAccessModifier.None, "IFormDataParameter.CreateFormDataParameter");
        mdCreateFormDataParameter.ReturnTypeName = new TypeName("Dictionary<string, string>");
        mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"var d = new Dictionary<string, string>();");

        var hasFileProperty = false;
        var requestBodyPropertyNameList = new List<string>();
        var propertyList = new List<Property>();
        var queryParameterSection = false;
        var cQueryParameter = new Class(AccessModifier.Public, cName + "QueryParameter");
        cQueryParameter.ImplementInterfaces.Add(new TypeName("IQueryParameter"));
        var mdGetQueryString = new Method(MethodAccessModifier.None, "IQueryParameter.GetQueryString");
        cQueryParameter.Methods.Add(mdGetQueryString);
        mdGetQueryString.ReturnTypeName = new TypeName("string");
        mdGetQueryString.Body.Add(SourceCodeLanguage.CSharp, "var sb = new StringBuilder();");
        foreach (var paramSection in endpointPanel.FindElements(By.CssSelector("div[class='param-section']")))
        {
            var h4 = paramSection.FindElement(By.CssSelector("h4")).Text;
            if (h4 == "Query parameters")
            {
                sc.Namespaces[0].Classes.Insert(1, cQueryParameter);
                cParameter.ImplementInterfaces.Add(new TypeName("IQueryParameterProperty"));

                {
                    var q = new Property("IQueryParameter", "IQueryParameterProperty.QueryParameter");
                    q.Modifier.AccessModifier = MethodAccessModifier.None;
                    q.Get = new PropertyBody(PropertyBodyType.Get);
                    q.Get.Body.Add(SourceCodeLanguage.CSharp, "return this.QueryParameter;");
                    q.Set = null;
                    cParameter.Properties.Add(q);
                }
                {
                    var q = new Property($"{cName}QueryParameter", "QueryParameter", true);
                    q.Initializer = $"new {cName}QueryParameter()";
                    cParameter.Properties.Add(q);
                }
            }
            if (h4 == "Request body" || h4 == "Path parameters" || h4 == "Query parameters")
            {
                queryParameterSection = h4 == "Query parameters";

                var isPathParameter = h4 == "Path parameters";
                var paramTableId = paramSection.FindElement(By.CssSelector(".param-table")).GetDomAttribute("id");
                foreach (var paramRow in paramSection.FindElements(By.CssSelector($"#{paramTableId} > div.param-row")))
                {
                    if (paramRow.FindElements(By.CssSelector("[class='param-depr']")).FirstOrDefault()?.Text == "Deprecated") { continue; }

                    var pRawName = paramRow.FindElement(By.CssSelector("[class='param-name']")).Text;
                    var pName = pRawName.ToPascalCase();
                    if (pName == "Timestamp_Granularities[]")
                    {
                        pName = "Timestamp_Granularities";
                    }
                    if (pName.EndsWith("[]"))
                    {
                        pName = pName.Substring(0, pName.Length - 2);
                    }
                    var pRequired = paramRow.FindElements(By.CssSelector("[class='param-reqd']")).FirstOrDefault()?.Text == "Required";
                    var pType = this.GetTypeName(paramRow.FindElement(By.CssSelector("[class='param-type']")).Text, cName, pName, pRequired);
                    if (pType == "string")
                    {
                        if (pRequired == false)
                        {
                            pType += "?";
                        }
                    }
                    else
                    {
                        if (pRequired == false && pType.EndsWith("?") == false)
                        {
                            pType += "?";
                        }
                    }
                    if (pType == "FileParameter?")
                    {
                        pType = "FileParameter";
                    }
                    if (cName == "ConversationUpdate" && pName == "Metadata")
                    {
                        pType = "object?";
                    }

                    var p = new Property(pType, pName, true);
                    p.Name = p.Name.ToPascalCase();
                    if (p.TypeName.Name == "string")
                    {
                        if (pRequired)
                        {
                            p.Initializer = "\"\"";
                        }
                    }
                    if (p.TypeName.Name.StartsWith("List<") && p.TypeName.Name.EndsWith("?") == false)
                    {
                        p.TypeName.Name += "?";
                    }
                    if (cName == "ChatCompletionCreate" && p.Name == "Messages")
                    {
                        p.TypeName.Name = "List<IChatMessage>";
                        p.Initializer = "new ()";
                    }
                    if (cName == "ResponseCreate" && p.Name == "Input")
                    {
                        p.Initializer = "new ()";
                    }
                    if (cName == "ThreadCreate" && p.Name == "Messages")
                    {
                        p.TypeName.Name = "List<Message>?";
                    }
                    if (cName == "MessageCreate" && p.Name == "Content")
                    {
                        p.TypeName.Name = "List<MessageCreateContent>";
                        p.Initializer = "new()";
                    }
                    if (cName == "ThreadCreate" && p.Name == "Messages")
                    {
                        p.TypeName.Name = "List<Message>?";
                    }
                    if (cName == "ChatKitSessionCreate" && p.Name == "Workflow")
                    {
                        p.Initializer = "new()";
                    }
                    if (pType == "FineTuningGrader" || pType == "DataSourceConfig")
                    {
                        p.Initializer = "new()";
                    }
                    if (pType == "FileParameter")
                    {
                        hasFileProperty = true;
                        p.Set!.Modifier = AccessModifier.Private;
                        p.Initializer = $"new FileParameter(\"{p.Name.ToLower()}\")";
                    }
                    if (pType == "FileListParameter")
                    {
                        hasFileProperty = true;
                        p.Initializer = $"new FileListParameter()";
                    }
                    p.Comment = paramRow.FindElements(By.CssSelector("[class='param-desc']")).FirstOrDefault()?.Text ?? "";
                    if (queryParameterSection == true)
                    {
                        cQueryParameter.Properties.Add(p);
                        var cb = new CodeBlock(SourceCodeLanguage.CSharp, $"if (this.{pName} != null)");
                        cb.CurlyBracket = true;
                        {
                            if (pType.StartsWith("string") == true)
                            {
                                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"sb.Append($\"{pName.ToLower()}={{WebUtility.UrlEncode(this.{pName})}}&\");"));
                            }
                            else if (pType.StartsWith("List<") == true)
                            {
                                var cbForEach = new CodeBlock(SourceCodeLanguage.CSharp, $"foreach (var item in this.{pName})");
                                cbForEach.CurlyBracket = true;
                                {
                                    cbForEach.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"sb.Append($\"{pName.ToLower()}[]={{item}}&\");"));
                                }
                                cb.CodeBlocks.Add(cbForEach);
                            }
                            else
                            {
                                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, $"sb.Append($\"{pName.ToLower()}={{this.{pName}}}&\");"));
                            }
                        }
                        mdGetQueryString.Body.Add(cb);
                    }
                    else
                    {
                        cParameter.Properties.Add(p);
                        propertyList.Add(p);
                    }

                    if (isPathParameter == false && queryParameterSection == false)
                    {
                        requestBodyPropertyNameList.Add(p.Name);
                    }

                    if (pRequired)
                    {
                        if (pType == "FileParameter")
                        {
                            mdAsync.Parameters.Add(new MethodParameter("string", p.Name.ToCamelCase() + "FileName"));
                            mdAsync.Parameters.Add(new MethodParameter("Stream", p.Name.ToCamelCase() + "Stream"));
                            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name}.SetFile({p.Name.ToCamelCase()}FileName, {p.Name.ToCamelCase()}Stream);");
                        }
                        else
                        {
                            mdAsync.Parameters.Add(new MethodParameter(p.TypeName.Name, p.Name.ToCamelCase()));
                            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name} = {p.Name.ToCamelCase()};");
                        }

                        mdStreamAsync.Parameters.Add(new MethodParameter(p.TypeName.Name, p.Name.ToCamelCase()));
                        mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name} = {p.Name.ToCamelCase()};");
                    }
                }
            }
        }
        mdGetQueryString.Body.Add(SourceCodeLanguage.CSharp, "return sb.ToString().TrimEnd('&');");

        {
            var md = new Method(MethodAccessModifier.Public, "GetRequestBody");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("object");
            if (requestBodyPropertyNameList.Count == 0)
            {
                md.Body.Add(SourceCodeLanguage.CSharp, "return EmptyParameter;");
            }
            else
            {
                md.Body.Add(SourceCodeLanguage.CSharp, "return new {");
                foreach (var pName in requestBodyPropertyNameList)
                {
                    md.Body.Add(SourceCodeLanguage.CSharp, $"\t{pName.ToString().ToLower()} = this.{pName},");
                }
                md.Body.Add(SourceCodeLanguage.CSharp, "};");
            }
            cParameter.Methods.Add(md);
        }


        if (hasFileProperty)
        {
            cParameter.ImplementInterfaces.Add(new TypeName("IFileParameter"));
            sendAsyncMethodName = "SendFormDataAsync";

            var mdGetFileParameters = new Method(MethodAccessModifier.None, "IFileParameter.GetFileParameters");
            mdGetFileParameters.ReturnTypeName = new TypeName("IEnumerable<FileParameter>");
            cParameter.Methods.Add(mdGetFileParameters);

            foreach (var item in propertyList)
            {
                var pName = item.Name;
                if (pName == "Timestamp_Granularities")
                {
                    mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = $\"[{{string.Format(\",\", this.Timestamp_Granularities)}}]\";");
                    continue;
                }
                if (cName == "AudioTranscriptions")
                {
                    if (pName == "Chunking_Strategy" || pName == "Include")
                    {
                        //TODO: Need to implement
                        continue;
                    }
                }
                var pType = item.TypeName.Name;
                if (hasFileProperty)
                {
                    if (pType.EndsWith("?"))
                    {
                        if (pType.StartsWith("ExpirationPolicy?"))
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"expires_after[anchor]\"] = this.Expires_After.Anchor;");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null && this.{pName}.Seconds != null) d[\"expires_after[seconds]\"] = this.Expires_After.Seconds.Value.ToString();");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null && this.{pName}.Minutes != null) d[\"expires_after[minutes]\"] = this.Expires_After.Minutes.Value.ToString();");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null && this.{pName}.Days != null) d[\"expires_after[days]\"] = this.Expires_After.Days.Value.ToString();");
                        }
                        else if (pType == "string?")
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = this.{pName};");
                        }
                        else if (pType == "FileParameter?")
                        {
                            mdGetFileParameters.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) yield return this.{pName};");
                        }
                        else
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = this.{pName}.Value.ToString();");
                        }
                    }
                    else
                    {
                        if (pType.StartsWith("ExpirationPolicy"))
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"d[\"expires_after[anchor]\"] = this.Expires_After.Anchor;");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName}.Seconds != null) d[\"expires_after[seconds]\"] = this.Expires_After.Seconds.Value.ToString();");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName}.Minutes != null) d[\"expires_after[minutes]\"] = this.Expires_After.Minutes.Value.ToString();");
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName}.Days != null) d[\"expires_after[days]\"] = this.Expires_After.Days.Value.ToString();");
                        }
                        else if (pType == "string")
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"d[\"{pName.ToLower()}\"] = this.{pName};");
                        }
                        else if (pType == "FileParameter")
                        {
                            mdGetFileParameters.Body.Add(SourceCodeLanguage.CSharp, $"yield return this.{pName};");
                        }
                        else if (pType == "FileListParameter")
                        {
                            var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"foreach (var item in this.{pName}.Files)");
                            cb1.CurlyBracket = true;
                            {
                                cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                            }
                            mdGetFileParameters.Body.Add(cb1);
                        }
                        else
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"d[\"{pName.ToLower()}\"] = this.{pName}.ToString();");
                        }
                    }
                }
            }
            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"return d;");
            cParameter.Methods.Add(mdCreateFormDataParameter);
            cParameter.ImplementInterfaces.Add(new TypeName("IFormDataParameter"));
        }

        if (cName == "OrganizationCertificateModify" || cName == "OrganizationCertificateDelete")
        {
            //Document is invalid at 2025-08-23. Path parameter is missing. So, I manually add property.
            var p = new Property("string", "Certificate_Id", true);
            p.Initializer = "\"\"";
            cParameter.Properties.Add(p);
        }
        if (propertyList.Count == 0)
        {
            var f = new Field($"{cName}Parameter", "Empty", $"new {cName}Parameter()");
            f.Modifier.AccessModifier = AccessModifier.Internal;
            f.Modifier.Static = true;
            f.Modifier.ReadOnly = true;
            cParameter.Fields.Add(f);
        }
        {
            var mdAsync0 = mdAsync.Copy();
            if (propertyList.Count == 0)
            {
                mdAsync0.Body.Clear();
                mdAsync0.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>({cName}Parameter.Empty, System.Threading.CancellationToken.None);");
            }
            else
            {
                mdAsync0.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>(p, System.Threading.CancellationToken.None);");
            }
            cClient.Methods.Add(mdAsync0);
        }


        var hasStreamMethod = streamResult.IsNullOrEmpty() == false;
        {
            mdAsync.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
            if (propertyList.Count == 0)
            {
                mdAsync.Body.Clear();
                if (hasStreamMethod)
                {
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = null;");
                }
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>({cName}Parameter.Empty, cancellationToken);");
            }
            else
            {
                if (hasStreamMethod)
                {
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = null;");
                }
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>(p, cancellationToken);");
            }
            cClient.Methods.Add(mdAsync);
        }
        {
            var md2 = new Method(MethodAccessModifier.Public, cName + "Async");
            md2.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
            md2.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
            md2.ReturnTypeName.Name = "async ValueTask";
            md2.ReturnTypeName.GenericTypes.Add(new TypeName(tResponseName));
            if (hasStreamMethod)
            {
                md2.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = null;");
            }
            md2.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>(parameter, cancellationToken);");

            var md1 = md2.Copy();
            md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
            md1.Body.Clear();
            if (hasStreamMethod)
            {
                md1.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = null;");
            }
            md1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {tResponseName}>(parameter, System.Threading.CancellationToken.None);");
     
            cClient.Methods.Add(md1);
            cClient.Methods.Add(md2);
        }

        if (hasStreamMethod)
        {
            {
                var mdStreamAsync0 = mdStreamAsync.Copy();
                mdStreamAsync0.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = true;");
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(p, null, System.Threading.CancellationToken.None))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                mdStreamAsync0.Body.Add(cb1);
                cClient.Methods.Add(mdStreamAsync0);
            }

            {
                mdStreamAsync.Parameters.Add(new MethodParameter("[EnumeratorCancellation] CancellationToken", "cancellationToken"));
                mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = true;");
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                mdStreamAsync.Body.Add(cb1);
                cClient.Methods.Add(mdStreamAsync);
            }
            {
                var md2 = new Method(MethodAccessModifier.Public, cName + "StreamAsync");
                md2.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
                md2.Parameters.Add(new MethodParameter(streamResult, "result"));
                md2.Parameters.Add(new MethodParameter("[EnumeratorCancellation] CancellationToken", "cancellationToken"));
                md2.ReturnTypeName.Name = "async IAsyncEnumerable";
                md2.ReturnTypeName.GenericTypes.Add(new TypeName("string"));

                md2.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = true;");
                var cb2 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))");
                cb2.CurlyBracket = true;
                {
                    cb2.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md2.Body.Add(cb2);

                var md1 = md2.Copy();
                md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
                md1.Body.Clear();
                md1.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = true;");
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, result, System.Threading.CancellationToken.None))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md1.Body.Add(cb1);

                var md0 = md1.Copy();
                md0.Parameters.RemoveAt(md0.Parameters.Count - 1);
                md0.Body.Clear();
                md0.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = true;");
                var cb0 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, null, System.Threading.CancellationToken.None))");
                cb0.CurlyBracket = true;
                {
                    cb0.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md0.Body.Add(cb0);

                cClient.Methods.Add(md0);
                cClient.Methods.Add(md1);
                cClient.Methods.Add(md2);
            }
        }
        if (hasAssistantStreamMethod)
        {

        }

        Directory.CreateDirectory(Path.Combine(OutputFolderPath, "Endpoint"));
        var filePath = Path.Combine(OutputFolderPath, "Endpoint", cName + ".cs");
        this.WriteFile(filePath, sc);
        Console.WriteLine($"{filePath}");
    }
    private string? GetClassName(string endpointAnchor)
    {
        var cName = "";

        if (endpointAnchor == "Create fine-tuning job") { return "FineTuningJobCreate"; }
        if (endpointAnchor == "List fine-tuning jobs") { return "FineTuningJobs"; }
        if (endpointAnchor == "List fine-tuning events") { return "FineTuningJobEvents"; }
        if (endpointAnchor == "List fine-tuning checkpoints") { return "FineTuningCheckpoints"; }
        if (endpointAnchor == "List checkpoint permissions") { return "FineTuningCheckpointsPermissions"; }
        if (endpointAnchor == "Create checkpoint permissions") { return "FineTuningCheckpointsPermissionsCreate"; }
        if (endpointAnchor == "Delete checkpoint permission") { return "FineTuningCheckpointsPermissionDelete"; }
        if (endpointAnchor == "Retrieve fine-tuning job") { return "FineTuningJobRetrieve"; }
        if (endpointAnchor == "Cancel fine-tuning") { return "FineTuningJobCancel"; }
        if (endpointAnchor == "Resume fine-tuning") { return "FineTuningJobResume"; }
        if (endpointAnchor == "Pause fine-tuning") { return "FineTuningJobPause"; }
        if (endpointAnchor == "Run grader") { return "FineTuningAlphaGradersRun"; }
        if (endpointAnchor == "Validate grader") { return "FineTuningAlphaGradersValidate"; }

        if (endpointAnchor == "Create batch") { return "BatchCreate"; }
        if (endpointAnchor == "Retrieve batch") { return "BatchRetrieve"; }
        if (endpointAnchor == "Cancel batch") { return "BatchCancel"; }
 
        if (endpointAnchor == "Upload file") { return "FileUpload"; }
        if (endpointAnchor == "Delete file") { return "FileDelete"; }
        if (endpointAnchor == "Retrieve file") { return "FileRetrieve"; }
        if (endpointAnchor == "Retrieve file content") { return "FileContentGet"; }
        if (endpointAnchor == "Retrieve model") { return "ModelRetrieve"; }
        if (endpointAnchor == "Delete a fine-tuned model") { return "ModelDelete"; }
        if (endpointAnchor == "Create moderation") { return "ModerationCreate"; }

        if (endpointAnchor == "Create upload") { return "UploadCreate"; }
        if (endpointAnchor == "Add upload part") { return "UploadPartAdd"; }
        if (endpointAnchor == "Complete upload") { return "UploadComplete"; }
        if (endpointAnchor == "Cancel upload") { return "UploadCancel"; }

        if (endpointAnchor == "Create session") { return "RealtimeSessionCreate"; }
        if (endpointAnchor == "Create transcription session") { return "RealtimeTranscriptionSessionCreate"; }

        if (endpointAnchor == "Create chat completion") { return "ChatCompletionCreate"; }
        if (endpointAnchor == "Get chat completion") { return "ChatCompletionRetrieve"; }
        if (endpointAnchor == "Get chat messages") { return "ChatCompletionMessageRetrieve"; }
        if (endpointAnchor == "List Chat Completions") { return "ChatCompletions"; }
        if (endpointAnchor == "Update chat completion") { return "ChatCompletionUpdate"; }
        if (endpointAnchor == "Delete chat completion") { return "ChatCompletionDelete"; }

        if (endpointAnchor == "Create assistant") { return "AssistantCreate"; }
        if (endpointAnchor == "Retrieve assistant") { return "AssistantRetrieve"; }
        if (endpointAnchor == "Modify assistant") { return "AssistantModify"; }
        if (endpointAnchor == "Delete assistant") { return "AssistantDelete"; }
        if (endpointAnchor == "Create assistant file") { return "AssistantFileCreate"; }
        if (endpointAnchor == "Retrieve assistant file") { return "AssistantFileRetrieve"; }
        if (endpointAnchor == "Delete assistant file") { return "AssistantFileDelete"; }
        if (endpointAnchor == "List assistant files") { return "AssistantFiles"; }
    
        if (endpointAnchor == "Create thread") { return "ThreadCreate"; }
        if (endpointAnchor == "Retrieve thread") { return "ThreadRetrieve"; }
        if (endpointAnchor == "Modify thread") { return "ThreadModify"; }
        if (endpointAnchor == "Delete thread") { return "ThreadDelete"; }
      
        if (endpointAnchor == "Create message") { return "MessageCreate"; }
        if (endpointAnchor == "Retrieve message") { return "MessageRetrieve"; }
        if (endpointAnchor == "Modify message") { return "MessageModify"; }
        if (endpointAnchor == "List messages") { return "Messages"; }
        if (endpointAnchor == "Delete message") { return "MessageDelete"; }

        if (endpointAnchor == "Create run") { return "RunCreate"; }
        if (endpointAnchor == "Retrieve run") { return "RunRetrieve"; }
        if (endpointAnchor == "Modify run") { return "RunModify"; }
        if (endpointAnchor == "List runs") { return "Runs"; }

        if (endpointAnchor == "Retrieve message file") { return "MessageFileRetrieve"; }
        if (endpointAnchor == "List message files") { return "MessageFiles"; }

        if (endpointAnchor == "Submit tool outputs to run") { return "SubmitToolOutputs"; }
        if (endpointAnchor == "Cancel a run") { return "RunCancel"; }
        if (endpointAnchor == "Create thread and run") { return "ThreadRun"; }
        if (endpointAnchor == "Retrieve run step") { return "RunStepRetrieve"; }
        if (endpointAnchor == "List run steps") { return "RunSteps"; }

        if (endpointAnchor == "Create a model response") { return "ResponseCreate"; }
        if (endpointAnchor == "Get a model response") { return "ResponseRetrieve"; }
        if (endpointAnchor == "Delete a model response") { return "ResponseDelete"; }
        if (endpointAnchor == "List input items") { return "ResponseInputItemRetrieve"; }
        if (endpointAnchor == "Cancel a response") { return "ResponseCcancel"; }

        if (endpointAnchor == "Create conversation") { return "ConversationCreate"; }
        if (endpointAnchor == "List conversations") { return "Conversations"; }
        if (endpointAnchor == "Retrieve a conversation") { return "ConversationRetrieve"; }
        if (endpointAnchor == "Update a conversation") { return "ConversationUpdate"; }
        if (endpointAnchor == "Delete a conversation") { return "ConversationDelete"; }
        if (endpointAnchor == "List items") { return "ConversationItems"; }
        if (endpointAnchor == "Create items") { return "ConversationItemsCreate"; }
        if (endpointAnchor == "Retrieve an item") { return "ConversationItemRetrieve"; }
        if (endpointAnchor == "Delete an item") { return "ConversationItemDelete"; }

        if (endpointAnchor == "Create video") { return "VideoCreate"; }
        if (endpointAnchor == "Remix video") { return "VideoRemix"; }
        if (endpointAnchor == "List videos") { return "Videos"; }
        if (endpointAnchor == "Retrieve video") { return "VideoRetrieve"; }
        if (endpointAnchor == "Delete video") { return "VideoDelete"; }
        if (endpointAnchor == "Retrieve video content") { return "VideoContentGet"; }

        if (endpointAnchor == "Create vector store") { return "VectorStoreCreate"; }
        if (endpointAnchor == "List vector stores") { return "VectorStores"; }
        if (endpointAnchor == "Retrieve vector store") { return "VectorStoreRetrieve"; }
        if (endpointAnchor == "Modify vector store") { return "VectorStoreModify"; }
        if (endpointAnchor == "Delete vector store") { return "VectorStoreDelete"; }
        if (endpointAnchor == "Search vector store") { return "VectorStoreSearch"; }

        if (endpointAnchor == "Create vector store file") { return "VectorStoreFileCreate"; }
        if (endpointAnchor == "List vector store files") { return "VectorStoreFiles"; }
        if (endpointAnchor == "Retrieve vector store file") { return "VectorStoreFileRetrieve"; }
        if (endpointAnchor == "Retrieve vector store file content") { return "VectorStoreFileContentRetrieve"; }
        if (endpointAnchor == "Update vector store file attributes") { return "VectorStoreFileAttributeUpdate"; }
        if (endpointAnchor == "Delete vector store file") { return "VectorStoreFileDelete"; }

        if (endpointAnchor == "Create vector store file batch") { return "VectorStoreFileBatchCreate"; }
        if (endpointAnchor == "Retrieve vector store file batch") { return "VectorStoreFileBatchRetrieve"; }
        if (endpointAnchor == "Cancel vector store file batch") { return "VectorStoreFileBatchCancel"; }
        if (endpointAnchor == "List vector store files in a batch") { return "VectorStoreFileBatches"; }

        if (endpointAnchor == "Create ChatKit session") { return "ChatKitSessionCreate"; }
        if (endpointAnchor == "Cancel chat session") { return "ChatKitSessionCancel"; }
        if (endpointAnchor == "Upload file to ChatKit") { return "ChatKitFileUpload"; }
        if (endpointAnchor == "List ChatKit threads") { return "ChatKitThreads"; }
        if (endpointAnchor == "Retrieve ChatKit thread") { return "ChatKitThreadRetrieve"; }
        if (endpointAnchor == "Delete ChatKit thread") { return "ChatKitThreadDelete"; }
        if (endpointAnchor == "List ChatKit thread items") { return "ChatKitThreadItems"; }

        if (endpointAnchor == "Create container") { return "ContainerCreate"; }
        if (endpointAnchor == "List containers") { return "Containers"; }
        if (endpointAnchor == "Retrieve container") { return "ContainerRetrieve"; }
        if (endpointAnchor == "Delete a container") { return "ContainerDelete"; }
        if (endpointAnchor == "Create container file") { return "ContainerFileCreate"; }
        if (endpointAnchor == "List container files") { return "ContainerFiles"; }
        if (endpointAnchor == "Retrieve container file") { return "ContainerFileRetrieve"; }
        if (endpointAnchor == "Retrieve container file content") { return "ContainerFileContent"; }
        if (endpointAnchor == "Delete a container file") { return "ContainerFileDelete"; }

        //Realtime call may used on browser and build by javascript or typescript. So, C# code is not generated.
        if (endpointAnchor == "Create call") { return null; }
        if (endpointAnchor == "Create client secret") { return null; }
        if (endpointAnchor == "Accept call") { return null; }
        if (endpointAnchor == "Reject call") { return null; }
        if (endpointAnchor == "Refer call") { return null; }
        if (endpointAnchor == "Hang up call") { return null; }


        if (endpointAnchor == "Create eval") { return "EvalCreate"; }
        if (endpointAnchor == "Get an eval") { return "Eval"; }
        if (endpointAnchor == "Update an eval") { return "EvalUpdate"; }
        if (endpointAnchor == "Delete an eval") { return "EvalDelete"; }
        if (endpointAnchor == "List evals") { return "Evals"; }
        if (endpointAnchor == "Get eval runs") { return "EvalRuns"; }
        if (endpointAnchor == "Get an eval run") { return "EvalRunRetrieve"; }
        if (endpointAnchor == "Create eval run") { return "EvalRunCreate"; }
        if (endpointAnchor == "Cancel eval run") { return "EvalRunCancel"; }
        if (endpointAnchor == "Delete eval run") { return "EvalRunDelete"; }
        if (endpointAnchor == "Get an output item of an eval run") { return "EvalRunOutputItemRetrieve"; }
        if (endpointAnchor == "Get eval run output items") { return "EvalRunOutputItems"; }

        if (endpointAnchor == "List all organization and project API keys.") { return "OrganizationAdminApiKeys"; }
        if (endpointAnchor == "Create admin API key") { return "OrganizationAdminApiKeyCreate"; }
        if (endpointAnchor == "Retrieve admin API key") { return "OrganizationAdminApiKeyRetrieve"; }
        if (endpointAnchor == "Delete admin API key") { return "OrganizationAdminApiKeyDelete"; }

        if (endpointAnchor == "Create invite") { return "OrganizationInviteCreate"; }
        if (endpointAnchor == "Retrieve invite") { return "OrganizationInviteRetrieve"; }
        if (endpointAnchor == "Delete invite") { return "OrganizationInviteDelete"; }

        if (endpointAnchor == "Modify user") { return "OrganizationUserCreate"; }
        if (endpointAnchor == "Retrieve user") { return "OrganizationUserRetrieve"; }
        if (endpointAnchor == "Delete user") { return "OrganizationUserDelete"; }

        if (endpointAnchor == "List projects") { return "OrganizationProjects"; }
        if (endpointAnchor == "Create project") { return "OrganizationProjectCreate"; }
        if (endpointAnchor == "Retrieve project") { return "OrganizationProjectRetrieve"; }
        if (endpointAnchor == "Modify project") { return "OrganizationProjectModify"; }
        if (endpointAnchor == "Archive project") { return "OrganizationProjectArchive"; }

        if (endpointAnchor == "List project users") { return "OrganizationProjectUsers"; }
        if (endpointAnchor == "Create project user") { return "OrganizationProjectUserCreate"; }
        if (endpointAnchor == "Retrieve project user") { return "OrganizationProjectUserRetrieve"; }
        if (endpointAnchor == "Modify project user") { return "OrganizationProjectUserModify"; }
        if (endpointAnchor == "Delete project user") { return "OrganizationProjectUserDelete"; }

        if (endpointAnchor == "List project service accounts") { return "OrganizationProjectServiceAccounts"; }
        if (endpointAnchor == "Create project service account") { return "OrganizationProjectServiceAccountCreate"; }
        if (endpointAnchor == "Retrieve project service account") { return "OrganizationProjectServiceAccountRetrieve"; }
        if (endpointAnchor == "Delete project service account") { return "OrganizationProjectServiceAccountDelete"; }

        if (endpointAnchor == "List project API keys") { return "OrganizationProjectApiKeys"; }
        if (endpointAnchor == "Retrieve project API key") { return "OrganizationProjectApiKeyRetrieve"; }
        if (endpointAnchor == "Delete project API key") { return "OrganizationProjectApiKeyDelete"; }

        if (endpointAnchor == "List project rate limits") { return "OrganizationProjectRateLimits"; }
        if (endpointAnchor == "Modify project rate limit") { return "OrganizationProjectRateLimitModify"; }
        if (endpointAnchor == "List audit logs") { return "OrganizationAuditLog"; }

        if (endpointAnchor == "Upload certificate") { return "OrganizationCertificateUpload"; }
        if (endpointAnchor == "Get certificate") { return "OrganizationCertificateGet"; }
        if (endpointAnchor == "Modify certificate") { return "OrganizationCertificateModify"; }
        if (endpointAnchor == "Delete certificate") { return "OrganizationCertificateDelete"; }
        if (endpointAnchor == "List organization certificates") { return "OrganizationCertificates"; }
        if (endpointAnchor == "List project certificates") { return "OrganizationProjectCertificates"; }
        if (endpointAnchor == "Activate certificates for organization") { return "OrganizationCertificateActivate"; }
        if (endpointAnchor == "Deactivate certificates for organization") { return "OrganizationCertificateDeactivate"; }
        if (endpointAnchor == "Activate certificates for project") { return "OrganizationProjectCertificateActivate"; }
        if (endpointAnchor == "Deactivate certificates for project") { return "OrganizationProjectCertificateDeactivate"; }

        if (endpointAnchor == "Audio speeches") { return "OrganizationUsageAudioSpeeches"; }
        if (endpointAnchor == "Audio transcriptions") { return "OrganizationUsageAudioTranscriptions"; }
        if (endpointAnchor == "Vector stores") { return "OrganizationUsageVectorStores"; }
        if (endpointAnchor == "Code interpreter sessions") { return "OrganizationUsageCodeInterpreterSessions"; }

        return cName;
    }
    private string GetTypeName(string typeName, string className, string propertyName, bool required)
    {
        if (className == "ChatCompletionCreate" && propertyName == "Messages") { return "List<IChatMessage>"; }
        if (className == "Embeddings" && typeName == "string or array") { return "string"; }
        
        if (className == "FileUpload" && propertyName == "File") { return "FileParameter"; }
        if (className == "FileUpload" && propertyName == "Expires_After") { return "ExpirationPolicy"; }
        if (className == "ImagesVariations" && propertyName == "Image") { return "FileParameter"; }
        if (className == "ImagesEdits" && propertyName == "Image") { return "FileListParameter"; }

        if (className == "AssistantCreate" && propertyName == "Model") { return "string"; }
        if (className == "AssistantModify" && propertyName == "Model") { return "string"; }
        if (className == "SubmitToolOutputs" && propertyName == "Tool_Outputs") { return "List<ToolOutput>?"; }
        if (className == "SubmitToolOutputs" && propertyName == "Reasoning") { return "Reasoning?"; }
        if (className == "ResponseCreate" && propertyName == "Input") { return "ResponseInput"; }
        if (className == "ResponseCreate" && propertyName == "Reasoning") { return "Reasoning"; }
        if (className == "Responses" && propertyName == "Reasoning") { return "Reasoning"; }
        if (className == "AudioTranscriptions" && string.Equals(propertyName, "include[]", StringComparison.OrdinalIgnoreCase)) { return "List<object>?"; }
        if (className == "ChatKitSessionCreate" && propertyName == "Workflow") { return "ChatKitWorkflow"; }
        if (className == "ChatKitSessionCreate" && propertyName == "Rate_Limits") { return "ChatKitRateLimits"; }
        if (className == "RealtimeSessionCreate" && propertyName == "Client_Secret") { return "object?"; }

        if (propertyName == "Tools")
        {
            if (className == "ChatCompletionCreate" ||
                className == "AssistantCreate")
            {
                return "List<ChatCompletionFunctionTool>";
            }
            else
            {
                return "List<Tool>";
            }
        }

        if (propertyName == "include[]") { return "Include"; }
        if (propertyName == "Modalities") { return "object?"; }
        if (propertyName == "Data_Source") { return "object?"; }
        if (propertyName == "Chunking_Strategy") { return "object?"; }
        if (propertyName == "Expires_After" || propertyName == "Output_Expires_After") { return "ExpirationPolicy?"; }
        if (propertyName == "Tool_choice") { return "object?"; }
        if (propertyName == "Timestamp_Granularities") { return "double[]"; }
        if (propertyName == "Additional_Messages") { return "List<ThreadAdditionalMessageObject>?"; }
        if (propertyName == "Integrations") { return "List<FineTuningIntegrationObject>?"; }
        if (propertyName == "Web_Search_Options") { return "WebSearchOption?"; }
        if (propertyName == "Grader") { return "FineTuningGrader"; }
        if (propertyName == "Data_Source_Config") { return "DataSourceConfig"; }

        if (typeName == "string") { return "string"; }
        if (typeName == "string or null") { return "string?"; }
        if (typeName == "string or object") { return "string?"; }
        if (typeName == "string or array") { return "string"; }
        if (typeName == "string or \"whisper-1\"") { return "string"; }
        if (typeName == "string or \"dall-e-2\"") { return "string"; }
        if (typeName == "boolean") { return "bool"; }
        if (typeName == "boolean or null") { return "bool?"; }
        if (typeName == "integer") { return "int"; }
        if (typeName == "integer?") { return "int?"; }
        if (typeName == "integer or null") { return "int?"; }
        if (typeName == "number") { return "double"; }
        if (typeName == "number or null") { return "double?"; }
        if (typeName == "file") { return "FileParameter"; }
        if (typeName == "array") { return "List<string>"; }
        if (typeName == "string / array / null") { return "List<string>"; }
        if (typeName == "array or null") { return "List<string>"; }
        if (typeName == "map") { return "object?"; }
        if (typeName == "object or null") { return "object?"; }
        if (typeName == "\"auto\" or object") { return "object?"; }
        if (typeName == "integer or \"inf\"") { return "object?"; }
        if (typeName == "object")
        {
            if (required) { return "object"; }
            return "object?";
        }

        return typeName;
    }
    private string GetResponseClassName(string className)
    {
        var cName = className;


        if (cName.EndsWith("Delete"))
        {
            return "DeleteObjectResponse";
        }

        if (cName == "ChatCompletionCreate")
        {
            return "ChatCompletionObjectResponse";
        }
        else if (cName == "Embeddings")
        {
            return "RestApiDataResponse<List<EmbeddingObject>>";
        }
        else if (cName == "EvalCreate" ||
            cName == "EvalUGet" ||
            cName == "EvalUpdate")
        {
            return "EvalObjectResponse";
        }
        else if (cName == "Evals")
        {
            return "RestApiDataResponse<List<EvalObject>>";
        }
        else if (cName == "EvalRunCreate" ||
            cName == "EvalRunUGet" ||
            cName == "EvalRunCancel")
        {
            return "EvalRunObjectResponse";
        }
        else if (cName == "EvalRuns")
        {
            return "RestApiDataResponse<List<EvalRunObject>>";
        }
        else if (cName == "EvalRunOutputItemRetrieve")
        {
            return "EvalRunOutputItemObjectResponse";
        }
        else if (cName == "EvalRunOutputItems")
        {
            return "RestApiDataResponse<List<EvalRunOutputItemObject>>";
        }
        else if (cName == "FineTuningJobCreate" |
            cName == "FineTuningJobRetrieve" ||
            cName == "FineTuningJobCancel")
        {
            return "FineTuningJobResponse";
        }
        else if (cName == "FineTuningJobs")
        {
            return "RestApiDataResponse<List<FineTuningJob>>";
        }
        else if (cName == "FineTuningJobEvents")
        {
            return "RestApiDataResponse<List<FineTuningJob>>";
        }
        else if (cName == "Files")
        {
            return "RestApiDataResponse<List<FileObject>>";
        }
        else if (cName == "FileUpload")
        {
            return "FileObjectResponse";
        }
        else if (cName == "FileRetrieve")
        {
            return "FileObjectResponse";
        }
        else if (cName == "UploadCreate" ||
            cName == "UploadComplete" ||
            cName == "UploadCancel")
        {
            return "UploadObjectResponse";
        }
        else if (cName == "UploadPartAdd")
        {
            return "UploadPartObjectResponse";
        }
        else if (cName == "ImagesGenerations" ||
            cName == "ImagesEdits")
        {
            return "ImagesGenerationObjectRespons";
        }
        else if (cName == "ImagesVariations")
        {
            return "RestApiDataResponse<List<ImageObject>>";
        }
        else if (cName == "Models")
        {
            return "RestApiDataResponse<List<ModelObject>>";
        }
        else if (cName == "ModelRetrieve")
        {
            return "ModelObjectResponse";
        }
        else if (cName == "ModerationCreate")
        {
            return "ModerationObjectResponse";
        }
        else if (cName == "AssistantCreate" ||
            cName == "AssistantModify" ||
            cName == "AssistantRetrieve")
        {
            return "AssistantObjectResponse";
        }
        else if (cName == "Assistants")
        {
            return "RestApiDataResponse<List<AssistantObject>>";
        }
        else if (cName == "AssistantFileCreate" ||
            cName == "AssistantFileRetrieve")
        {
            return "AssistantFileObjectResponse";
        }
        else if (cName == "AssistantFiles")
        {
            return "RestApiDataResponse<List<AssistantFileObject>>";
        }
        else if (cName == "ThreadCreate" ||
            cName == "ThreadRetrieve" ||
            cName == "ThreadModify")
        {
            return "ThreadObjectResponse";
        }
        else if (cName == "MessageCreate" ||
            cName == "MessageRetrieve" ||
            cName == "MessageModify")
        {
            return "MessageObjectResponse";
        }
        else if (cName == "Messages")
        {
            return "RestApiDataResponse<List<MessageObject>>";
        }
        else if (cName == "RunCreate" ||
            cName == "RunRetrieve" ||
            cName == "RunModify" ||
            cName == "RunCancel")
        {
            return "RunObjectResponse";
        }
        else if (cName == "Runs")
        {
            return "RestApiDataResponse<List<RunObject>>";
        }
        else if (cName == "MessageFileCreate")
        {
            return "MessageFileObjectResponse";
        }
        else if (cName == "MessageFileRetrieve")
        {
            return "MessageFileObjectResponse";
        }
        else if (cName == "MessageFiles")
        {
            return "RestApiDataResponse<List<MessageFileObject>>";
        }
        else if (cName == "SubmitToolOutputs")
        {
            return "RunObjectResponse";
        }
        else if (cName == "ThreadRun")
        {
            return "RunObjectResponse";
        }
        else if (cName == "RunStepRetrieve")
        {
            return "RunStepObjectResponse";
        }
        else if (cName == "RunSteps")
        {
            return "RestApiDataResponse<List<RunStepObject>>";
        }
        else if (cName == "VectorStores")
        {
            return "RestApiDataResponse<List<VectorStoreObject>>";
        }
        else if (cName == "VectorStoreCreate" ||
            cName == "VectorStoreModify" ||
            cName == "VectorStoreRetrieve")
        {
            return "VectorStoreObjectResponse";
        }
        else if (cName == "VectorStoreFiles")
        {
            return "RestApiDataResponse<List<VectorStoreFileObject>>";
        }
        else if (cName == "VectorStoreFileCreate")
        {
            return "VectorStoreFileObjectResponse";
        }
        else if (cName == "VectorStoreFileBatches")
        {
            return "RestApiDataResponse<List<VectorStoreFileBatchObject>>";
        }
        else if (cName == "VectorStoreFileBatchCreate" ||
            cName == "VectorStoreFileBatchRetrieve" ||
            cName == "VectorStoreFileBatchCancel")
        {
            return "VectorStoreFileBatchObjectResponse";
        }
        else if (cName == "OrganizationAdminApiKeys")
        {
            return "RestApiDataResponse<List<AdminApiKeyObject>>";
        }
        else if (cName == "OrganizationAdminApiKeyCreate" ||
            cName == "OrganizationAdminApiKeyRetrieve")
        {
            return "AdminApiKeyObjectResponse";
        }
        else if (cName == "OrganizationInvites")
        {
            return "RestApiDataResponse<List<InviteObject>>";
        }
        else if (cName == "OrganizationInviteCreate" ||
            cName == "OrganizationInviteRetrieve")
        {
            return "InviteObjectResponse";
        }
        else if (cName == "OrganizationUsers")
        {
            return "RestApiDataResponse<List<UserObject>>";
        }
        else if (cName == "OrganizationUserCreate" ||
            cName == "OrganizationUserRetrieve")
        {
            return "UserObjectResponse";
        }
        else if (cName == "OrganizationProjects")
        {
            return "RestApiDataResponse<List<ProjectObject>>";
        }
        else if (cName == "OrganizationProjectCreate" ||
            cName == "OrganizationProjectRetrieve" ||
            cName == "OrganizationProjectModify" ||
            cName == "OrganizationProjectArchive")
        {
            return "ProjectObjectResponse";
        }
        else if (cName == "OrganizationProjectUsers")
        {
            return "RestApiDataResponse<List<ProjectUserObject>>";
        }
        else if (cName == "OrganizationProjectUserCreate" ||
            cName == "OrganizationProjectUserRetrieve" ||
            cName == "OrganizationProjectUserModify")
        {
            return "ProjectUserObjectResponse";
        }
        else if (cName == "OrganizationProjectServiceAccounts")
        {
            return "RestApiDataResponse<List<ProjectServiceAccountObject>>";
        }
        else if (cName == "OrganizationProjectServiceAccountCreate" ||
            cName == "OrganizationProjectServiceAccountRetrieve")
        {
            return "ProjectServiceAccountObjectResponse";
        }
        else if (cName == "OrganizationProjectApiKeys")
        {
            return "RestApiDataResponse<List<ProjectApiKeyObject>>";
        }
        else if (cName == "OrganizationProjectApiKeyRetrieve")
        {
            return "ProjectApiKeyObjectResponse";
        }
        else if (cName == "OrganizationAuditLog")
        {
            return "RestApiDataResponse<List<AuditLogObject>>";
        }
        else if (cName == "OrganizationUsageAudioSpeeches")
        {
            return "RestApiDataResponse<List<OrganizationUsageAudioSpeechObject>>";
        }
        else if (cName == "OrganizationUsageAudioTranscriptions")
        {
            return "RestApiDataResponse<List<OrganizationUsageAudioTranscriptionObject>>";
        }
        else if (cName == "OrganizationUsageCodeInterpreterSessions")
        {
            return "RestApiDataResponse<List<OrganizationUsageCodeInterpreterSessionObject>>";
        }
        else if (cName == "OrganizationUsageCompletions")
        {
            return "RestApiDataResponse<List<OrganizationUsageCompletionObject>>";
        }
        else if (cName == "OrganizationUsageEmbeddings")
        {
            return "RestApiDataResponse<List<OrganizationUsageEmbeddingObject>>";
        }
        else if (cName == "OrganizationUsageImages")
        {
            return "RestApiDataResponse<List<OrganizationUsageImageObject>>";
        }
        else if (cName == "OrganizationUsageModerations")
        {
            return "RestApiDataResponse<List<OrganizationUsageModerationObject>>";
        }
        else if (cName == "OrganizationUsageVectorStores")
        {
            return "RestApiDataResponse<List<OrganizationUsageVectorStoreObject>>";
        }
        else if (cName == "OrganizationCertificateUpload" ||
            cName == "OrganizationCertificateGet" ||
            cName == "OrganizationCertificateModify" ||
            cName == "OrganizationCertificateActivate" ||
            cName == "OrganizationCertificateDisactivate" ||
            cName == "OrganizationProjectCertificateActivate" ||
            cName == "OrganizationProjectCertificateDisactivate")
        {
            return "CertificateObjectResponse";
        }
        else if (cName == "OrganizationCertificates" ||
            cName == "OrganizationProjectCertificates")
        {
            return "RestApiDataResponse<List<CertificateObject>>";
        }
        else if (cName == "RealtimeSessionCreate")
        {
            return "RealtimeSessionObjectResponse";
        }
        else if (cName == "ResponseCreate" ||
            cName == "ResponseRetrieve")
        {
            return "ResponseObjectResponse";
        }
        else if (cName == "ResponseInputItemRetrieve")
        {
            return "RestApiDataResponse<List<ResponseInputItem>>";
        }
        else if (cName == "ConversationCreate" ||
            cName == "ConversationUpdate" ||
            cName == "ConversationRetrieve")
        {
            return "ConversationObjectResponse";
        }
        else if (cName == "ConversationItems")
        {
            return "RestApiDataResponse<List<ConversationItemObject>>";
        }
        else if (cName == "VideoCreate" ||
          cName == "VideoRetrieve" ||
          cName == "VideoRemix")
        {
            return "VideoJobObjectResponse";
        }
        else if (cName == "VideoItems")
        {
            return "RestApiDataResponse<List<VideoJobObject>>";
        }
        else if (cName == "VideoContentGet")
        {
            return "Stream";
        }
        else if (cName == "ChatKitSessionCreate" ||
          cName == "ChatKitSessionCancel")
        {
            return "ChatKitSessionResponse";
        }
        else if (cName == "ChatKitThreads")
        {
            return "RestApiDataResponse<List<ChatKitThreadObject>>";
        }
        else if (cName == "ChatKitThreadRetrieve")
        {
            return "ChatKitThreadObjectResponse";
        }
        else if (cName == "ChatKitThreadItems")
        {
            return "RestApiDataResponse<List<ChatKitThreadItemsObject>>";
        }
        else
        {
            return "RestApiResponse";
        }
    }
    
    private Property CreateHttpMethodProperty(string httpMethod)
    {
        var p = new Property("string", "IRestApiParameter.HttpMethod", true);
        p.Modifier.AccessModifier = MethodAccessModifier.None;
        p.Set = null;
        p.Initializer = $"\"{httpMethod.ToUpper()}\"";

        return p;
    }
    private Method CreateGetApiPathMethod(string url)
    {
        var md = new Method(MethodAccessModifier.None, "IRestApiParameter.GetApiPath");
        md.Modifier.AccessModifier = MethodAccessModifier.None;
        md.ReturnTypeName = new TypeName("string");

        var path = RegexList.CurlyBrackets.Replace(url, m => "{" + m.Groups["Value"].Value.ToPascalCase() + "}");
        md.Body.Add(SourceCodeLanguage.CSharp, $"return $\"{path.Replace("https://api.openai.com/v1", "")}\";");

        return md;
    }
    private bool IsAssistantApiEndpoint(string className)
    {
        if (className.StartsWith("Assistant")) { return true; }
        if (className.StartsWith("Thread")) { return true; }
        if (className.StartsWith("Run")) { return true; }
        if (className.StartsWith("SubmitToolOutputs")) { return true; }
        if (className.StartsWith("Message")) { return true; }
        if (className.StartsWith("MessageFile")) { return true; }
        if (className.StartsWith("VectorStore")) { return true; }
        return false;
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
}
