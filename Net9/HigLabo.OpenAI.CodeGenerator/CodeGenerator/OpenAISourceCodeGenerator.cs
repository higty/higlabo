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

        var ee = driver.FindElements(By.CssSelector("#root div[class='section']"));
        //CreateSourceCode(ee[71]);
        //return;

        for (int i = 0; i < ee.Count; i++)
        {
            CreateSourceCode(ee[i]);
        }
        Console.WriteLine($"Code generation Completed");
    }
    public void CreateSourceCode(IWebElement endpointPanel)
    {
        var endpointAnchor = endpointPanel.FindElement(By.CssSelector("h2[class='anchor-heading']")).GetDomAttribute("textContent");
        if (endpointAnchor.Contains("Deprecated") ||
            endpointAnchor.Contains("Legacy")) { return; }
        //Audit will be support when I have a time...
        if (endpointAnchor.Contains("Audit")) { return; }

        var sc = new SourceCode();
        sc.UsingNamespaces.Add("System.Collections.Generic");
        sc.UsingNamespaces.Add("System.IO");
        sc.UsingNamespaces.Add("System.Runtime.CompilerServices");
        sc.UsingNamespaces.Add("System.Threading");
        sc.UsingNamespaces.Add("System.Threading.Tasks");
        sc.Namespaces.Add(new Namespace($"HigLabo.OpenAI"));

        var endpointUrl = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-path']")).FirstOrDefault()?.GetDomAttribute("innerHTML") ?? "";
        if (endpointUrl.IsNullOrEmpty()) { return; }

        var httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-post']")).FirstOrDefault()?.GetDomAttribute("innerHTML") ?? "";
        if (httpMethod.IsNullOrEmpty())
        {
            httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-delete']")).FirstOrDefault()?.GetDomAttribute("innerHTML") ?? "";
        }
        if (httpMethod.IsNullOrEmpty())
        {
            httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-get']")).First().GetDomAttribute("innerHTML") ?? "";
        }
        var endpointPath = endpointUrl.Replace("https://api.openai.com/v1/", "");

        var cName = this.GetClassName(endpointAnchor);
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
        if (endpointUrl == "https://api.openai.com/v1/chat/completions")
        {
            streamResult = "ChatCompletionStreamResult";
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
        cParameter.Comment = endpointPanel.FindElement(By.CssSelector("[class='endpoint-summary']")).GetDomAttribute("textContent") + Environment.NewLine
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

        var cResponse = new Class(AccessModifier.Public, cName + "Response");
        sc.Namespaces[0].Classes.Add(cResponse);
        cResponse.Modifier.Partial = true;
        cResponse.ImplementInterfaces.Add(new TypeName(this.GetResponseClassName(cName)));

        var cClient = new Class(AccessModifier.Public, "OpenAIClient");
        sc.Namespaces[0].Classes.Add(cClient);
        cClient.Modifier.Partial = true;

        var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
        mdAsync.ReturnTypeName.Name = "async ValueTask";
        mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
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
        foreach (var paramSection in endpointPanel.FindElements(By.CssSelector("div[class='param-section']")))
        {
            var h3 = paramSection.FindElement(By.CssSelector("h3")).GetDomAttribute("innerHTML");
            if (h3 == "Query parameters")
            {
                cParameter.ImplementInterfaces.Add(new TypeName("IQueryParameterProperty"));

                string? qName = null;
                if (cName == "Files")
                {
                    qName = "FileList";
                }
                else if (cName == "FineTuningJobs" || cName == "FineTuningJobsEvents")
                {
                    qName = "FineTuning";
                    cResponse.Properties.Add(new Property("bool", "Has_More", true));
                }
                else
                {
                    qName = "";
                    cResponse.Properties.Add(new Property("string", "First_Id", true) { Initializer = "\"\"" });
                    cResponse.Properties.Add(new Property("string", "Last_Id", true) { Initializer = "\"\"" });
                    cResponse.Properties.Add(new Property("bool", "Has_More", true));
                }
                {
                    var q = new Property("IQueryParameter", "IQueryParameterProperty.QueryParameter");
                    q.Modifier.AccessModifier = MethodAccessModifier.None;
                    q.Get = new PropertyBody(PropertyBodyType.Get);
                    q.Get.Body.Add(SourceCodeLanguage.CSharp, "return this.QueryParameter;");
                    q.Set = null;
                    cParameter.Properties.Add(q);
                }
                {
                    var q = new Property($"{qName}QueryParameter", "QueryParameter", true);
                    q.Initializer = $"new {qName}QueryParameter()";
                    cParameter.Properties.Add(q);
                }
            }
            if (h3 == "Request body" || h3 == "Path parameters")
            {
                var isPathParameter = h3 == "Path parameters";

                foreach (var paramRow in paramSection.FindElements(By.CssSelector("div[class='param-row']")))
                {
                    if (paramRow.FindElements(By.CssSelector("[class='param-depr']")).FirstOrDefault()?.GetDomAttribute("textContent") == "Deprecated") { continue; }

                    var pRawName = paramRow.FindElement(By.CssSelector("[class='param-name']")).GetDomAttribute("innerHTML");
                    var pName = pRawName.ToPascalCase();
                    if (pName == "Timestamp_Granularities[]")
                    {
                        pName = "Timestamp_Granularities";
                    }
                    var pRequired = paramRow.FindElements(By.CssSelector("[class='param-reqd']")).FirstOrDefault()?.GetDomAttribute("innerHTML") == "Required";
                    var pType = this.GetTypeName(paramRow.FindElement(By.CssSelector("[class='param-type']")).GetDomAttribute("textContent"), cName, pName, pRequired);
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
                    if (cName == "ChatCompletions" && p.Name == "Messages")
                    {
                        p.TypeName.Name = "List<IChatMessage>";
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
                    if (cName == "Embeddings" && p.Name == "Encoding_format")
                    {
                        p.Initializer = "\"float\"";
                    }
                    if (pType == "FileParameter")
                    {
                        hasFileProperty = true;
                        p.Set!.Modifier = AccessModifier.Private;
                        p.Initializer = $"new FileParameter(\"{p.Name.ToLower()}\")";
                    }
                    p.Comment = paramRow.FindElements(By.CssSelector("[class='param-desc']")).FirstOrDefault()?.GetDomAttribute("textContent") ?? "";
                    cParameter.Properties.Add(p);
                    propertyList.Add(p);

                    if (isPathParameter == false)
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


        var sendAsyncMethodName = "SendJsonAsync";
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
                var pType = item.TypeName.Name;
                if (hasFileProperty)
                {
                    if (pType.EndsWith("?"))
                    {
                        if (pType == "string?")
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
                        if (pType == "string")
                        {
                            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"d[\"{pName.ToLower()}\"] = this.{pName};");
                        }
                        else if (pType == "FileParameter")
                        {
                            mdGetFileParameters.Body.Add(SourceCodeLanguage.CSharp, $"yield return this.{pName};");
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
                mdAsync0.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>({cName}Parameter.Empty, CancellationToken.None);");
            }
            else
            {
                mdAsync0.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(p, CancellationToken.None);");
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
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>({cName}Parameter.Empty, cancellationToken);");
            }
            else
            {
                if (hasStreamMethod)
                {
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = null;");
                }
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(p, cancellationToken);");
            }
            cClient.Methods.Add(mdAsync);
        }
        {
            var md2 = new Method(MethodAccessModifier.Public, cName + "Async");
            md2.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
            md2.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
            md2.ReturnTypeName.Name = "async ValueTask";
            md2.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
            md2.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(parameter, cancellationToken);");

            var md1 = md2.Copy();
            md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
            md1.Body.Clear();
            md1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(parameter, CancellationToken.None);");
     
            cClient.Methods.Add(md1);
            cClient.Methods.Add(md2);
        }

        if (hasStreamMethod)
        {
            {
                var mdStreamAsync0 = mdStreamAsync.Copy();
                mdStreamAsync0.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = true;");
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))");
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
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, result, CancellationToken.None))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md1.Body.Add(cb1);

                var md0 = md1.Copy();
                md0.Parameters.RemoveAt(md0.Parameters.Count - 1);
                md0.Body.Clear();
                md0.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = true;");
                var cb0 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))");
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
    private string GetClassName(string endpointAnchor)
    {
        var cName = "";
        if (endpointAnchor == "Create fine-tuning job") { return "FineTuningJobCreate"; }
        if (endpointAnchor == "List fine-tuning jobs") { return "FineTuningJobs"; }
        if (endpointAnchor == "Retrieve fine-tuning job") { return "FineTuningJobRetrieve"; }
        if (endpointAnchor == "Cancel fine-tuning") { return "FineTuningJobCancel"; }
        if (endpointAnchor == "List fine-tuning events") { return "FineTuningJobEvents"; }
        if (endpointAnchor == "List fine-tuning checkpoints") { return "FineTuningJobsCheckpoints"; }

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

        if (endpointAnchor == "Create assistantBeta") { return "AssistantCreate"; }
        if (endpointAnchor == "Retrieve assistantBeta") { return "AssistantRetrieve"; }
        if (endpointAnchor == "Modify assistantBeta") { return "AssistantModify"; }
        if (endpointAnchor == "Delete assistantBeta") { return "AssistantDelete"; }
        if (endpointAnchor == "Create assistant fileBeta") { return "AssistantFileCreate"; }
        if (endpointAnchor == "Retrieve assistant fileBeta") { return "AssistantFileRetrieve"; }
        if (endpointAnchor == "Delete assistant fileBeta") { return "AssistantFileDelete"; }
        if (endpointAnchor == "List assistant filesBeta") { return "AssistantFiles"; }
    
        if (endpointAnchor == "Create threadBeta") { return "ThreadCreate"; }
        if (endpointAnchor == "Retrieve threadBeta") { return "ThreadRetrieve"; }
        if (endpointAnchor == "Modify threadBeta") { return "ThreadModify"; }
        if (endpointAnchor == "Delete threadBeta") { return "ThreadDelete"; }
        if (endpointAnchor == "Create messageBeta") { return "MessageCreate"; }
        if (endpointAnchor == "Retrieve messageBeta") { return "MessageRetrieve"; }
        if (endpointAnchor == "Modify messageBeta") { return "MessageModify"; }
        if (endpointAnchor == "List messagesBeta") { return "Messages"; }
        if (endpointAnchor == "Delete messageBeta") { return "MessageDelete"; }

        if (endpointAnchor == "Create runBeta") { return "RunCreate"; }
        if (endpointAnchor == "Retrieve runBeta") { return "RunRetrieve"; }
        if (endpointAnchor == "Modify runBeta") { return "RunModify"; }
        if (endpointAnchor == "List runsBeta") { return "Runs"; }

        if (endpointAnchor == "Retrieve message fileBeta") { return "MessageFileRetrieve"; }
        if (endpointAnchor == "List message filesBeta") { return "MessageFiles"; }

        if (endpointAnchor == "Submit tool outputs to runBeta") { return "SubmitToolOutputs"; }
        if (endpointAnchor == "Cancel a runBeta") { return "RunCancel"; }
        if (endpointAnchor == "Create thread and runBeta") { return "ThreadRun"; }
        if (endpointAnchor == "Retrieve run stepBeta") { return "RunStepRetrieve"; }
        if (endpointAnchor == "List run stepsBeta") { return "RunSteps"; }

        if (endpointAnchor == "Create vector storeBeta") { return "VectorStoreCreate"; }
        if (endpointAnchor == "List vector storesBeta") { return "VectorStores"; }
        if (endpointAnchor == "Retrieve vector storeBeta") { return "VectorStoreRetrieve"; }
        if (endpointAnchor == "Modify vector storeBeta") { return "VectorStoreModify"; }
        if (endpointAnchor == "Delete vector storeBeta") { return "VectorStoreDelete"; }

        if (endpointAnchor == "Create vector store fileBeta") { return "VectorStoreFileCreate"; }
        if (endpointAnchor == "List vector store filesBeta") { return "VectorStoreFiles"; }
        if (endpointAnchor == "Retrieve vector store fileBeta") { return "VectorStoreFileRetrieve"; }
        if (endpointAnchor == "Delete vector store fileBeta") { return "VectorStoreFileDelete"; }

        if (endpointAnchor == "Create vector store file batchBeta") { return "VectorStoreFileBatchCreate"; }
        if (endpointAnchor == "Retrieve vector store file batchBeta") { return "VectorStoreFileBatchRetrieve"; }
        if (endpointAnchor == "Cancel vector store file batchBeta") { return "VectorStoreFileBatchCancel"; }
        if (endpointAnchor == "List vector store files in a batchBeta") { return "VectorStoreFileBatches"; }

        if (endpointAnchor == "List admin API keys") { return "OrganizationAdminApiKeys"; }
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

        if (endpointAnchor == "Audio speeches") { return "OrganizationUsageAudioSpeeches"; }
        if (endpointAnchor == "Audio transcriptions") { return "OrganizationUsageAudioTranscriptions"; }
        if (endpointAnchor == "Vector stores") { return "OrganizationUsageVectorStores"; }
        if (endpointAnchor == "Code interpreter sessions") { return "OrganizationUsageCodeInterpreterSessions"; }

        return cName;
    }
    private string GetTypeName(string typeName, string className, string propertyName, bool required)
    {
        if (className == "ChatCompletions" && propertyName == "Messages") { return "List<IChatMessage>"; }
        if (className == "Embeddings" && typeName == "string or array") { return "string"; }
        if (className == "FileUpload" && propertyName == "File") { return "FileParameter"; }
        if (className == "ImagesVariations" && propertyName == "Image") { return "FileParameter"; }
        if (className == "AssistantCreate" && propertyName == "Model") { return "string"; }
        if (className == "AssistantModify" && propertyName == "Model") { return "string"; }
        if (className == "SubmitToolOutputs" && propertyName == "Tool_Outputs") { return "List<ToolOutput>?"; }

        if (propertyName == "Modalities") { return "object?"; }
        if (propertyName == "Chunking_Strategy") { return "ChunkingStrategy?"; }
        if (propertyName == "Tools") { return "List<ToolObject>"; }
        if (propertyName == "Tool_choice") { return "object?"; }
        if (propertyName == "Timestamp_Granularities") { return "double[]"; }
        if (propertyName == "Additional_Messages") { return "List<ThreadAdditionalMessageObject>?"; }
        if (propertyName == "Integrations") { return "List<FineTuningIntegrationObject>?"; }

        if (typeName == "string") { return "string"; }
        if (typeName == "string or null") { return "string?"; }
        if (typeName == "string or object") { return "string?"; }
        if (typeName == "string or array") { return "string"; }
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
        if (cName == "ChatCompletions")
        {
            return "ChatCompletionObjectResponse";
        }
        else if (cName == "Embeddings")
        {
            return "RestApiDataResponse<List<EmbeddingObject>>";
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
        else if (cName == "FileDelete")
        {
            return "DeleteObjectResponse";
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
            cName == "ImagesEdits" ||
            cName == "ImagesVariations")
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
        else if (cName == "ModelDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "AssistantDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "AssistantFileDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "ThreadDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "MessageDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "RunDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "OrganizationAdminApiKeyDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "OrganizationInviteDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "OrganizationUserDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "OrganizationProjectUserDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "OrganizationProjectServiceAccountDelete")
        {
            return "DeleteObjectResponse";
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
        else if (cName == "RealtimeSessions")
        {
            return "RealtimeSessionObjectResponse";
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
