using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using HigLabo.CodeGenerator;
using HigLabo.Core;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace HigLabo.OpenAI.CodeGenerator
{
    public class OpenAISourceCodeGenerator
    {
        public static class RegexList
        {
            public static readonly Regex CurlyBrackets = new Regex("{(?<Value>[^}]*)}", RegexOptions.Compiled);
        }
        public string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
        public string OutputFolderPath { get; set; } = "C:\\GitHub\\higty\\HigLabo\\Net7\\HigLabo.OpenAI\\Generated\\";

        public void ExecuteAsync()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--user-agent=" + UserAgent);
            options.AddArguments("-window-size=1920,1080");
            var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://platform.openai.com/docs/api-reference/audio");

            var ee = driver.FindElements(By.CssSelector("div[class='section endpoint']"));
            //CreateSourceCode(ee[71]);
            //return;

            for (int i = 0; i < ee.Count; i++)
            {
                CreateSourceCode(ee[i]);
            }
        }
        public void CreateSourceCode(IWebElement endpointPanel)
        {
            var endpointAnchor = endpointPanel.FindElement(By.CssSelector("h2[class='anchor-heading']")).GetAttribute("textContent");
            if (endpointAnchor == "The completion objectLegacy" ||
                endpointAnchor == "Create completionLegacy" ||
                endpointAnchor.Contains("Deprecated")) { return; }

            var sc = new SourceCode();
            sc.UsingNamespaces.Add("System.Runtime.CompilerServices");
            sc.Namespaces.Add(new Namespace($"HigLabo.OpenAI"));

            var endpointUrl = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-path']")).FirstOrDefault()?.GetAttribute("innerHTML") ?? "";
            if (endpointUrl.IsNullOrEmpty()) { return; }

            var httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-post']")).FirstOrDefault()?.GetAttribute("innerHTML") ?? "";
            if (httpMethod.IsNullOrEmpty())
            {
                httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-delete']")).FirstOrDefault()?.GetAttribute("innerHTML") ?? "";
            }
            if (httpMethod.IsNullOrEmpty())
            {
                httpMethod = endpointPanel.FindElements(By.CssSelector("span[class='endpoint-method endpoint-method-get']")).First().GetAttribute("innerHTML") ?? "";
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
            var hasStreamMethod = false;
            if (endpointUrl == "https://api.openai.com/v1/chat/completions")
            {
                hasStreamMethod = true;
            }

            var cParameter = new Class(AccessModifier.Public, cName + "Parameter");
            sc.Namespaces[0].Classes.Add(cParameter);
            cParameter.Comment = endpointPanel.FindElement(By.CssSelector("[class='endpoint-summary']")).GetAttribute("textContent") + Environment.NewLine
                + $"<seealso href=\"{endpointUrl}\">{endpointUrl}</seealso>";
            cParameter.Modifier.Partial = true;
            cParameter.BaseClass = new TypeName("RestApiParameter");
            cParameter.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
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
            mdStreamAsync.ReturnTypeName.GenericTypes.Add(new TypeName("ChatCompletionChunk"));
            mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");

            var mdCreateFormDataParameter = new Method(MethodAccessModifier.None, "IFormDataParameter.CreateFormDataParameter");
            mdCreateFormDataParameter.ReturnTypeName = new TypeName("Dictionary<string, string>");
            mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"var d = new Dictionary<string, string>();");

            var hasFileProperty = false;
            var requestBodyPropertyNameList = new List<string>();
            var propertyList = new List<Property>();
            foreach (var paramSection in endpointPanel.FindElements(By.CssSelector("div[class='param-section']")))
            {
                var h3 = paramSection.FindElement(By.CssSelector("h3")).GetAttribute("innerHTML");
                if (h3 == "Query parameters")
                {
                    cParameter.ImplementInterfaces.Add(new TypeName("IQueryParameterProperty"));
                    if (cName == "Files")
                    {
                        var q = new Property("IQueryParameter", "QueryParameter", true);
                        q.Initializer = "new FileListQueryParameter()";
                        cParameter.Properties.Add(q);
                    }
                    else if (cName == "FineTuningJobs" || cName == "FineTuningJobsEvents")
                    {
                        var q = new Property("IQueryParameter", "QueryParameter", true);
                        q.Initializer = "new FineTuningQueryParameter()";
                        cParameter.Properties.Add(q);

                        cResponse.Properties.Add(new Property("bool", "Has_More", true));
                    }
                    else
                    {
                        var q = new Property("IQueryParameter", "QueryParameter", true);
                        q.Initializer = "new QueryParameter()";
                        cParameter.Properties.Add(q);

                        cResponse.Properties.Add(new Property("string", "First_Id", true) { Initializer = "\"\"" });
                        cResponse.Properties.Add(new Property("string", "Last_Id", true) { Initializer = "\"\"" });
                        cResponse.Properties.Add(new Property("bool", "Has_More", true));
                    }
                }
                if (h3 == "Request body" || h3 == "Path parameters")
                {
                    var isPathParameter = h3 == "Path parameters";

                    foreach (var paramRow in paramSection.FindElements(By.CssSelector("div[class='param-row']")))
                    {
                        if (paramRow.FindElements(By.CssSelector("[class='param-depr']")).FirstOrDefault()?.GetAttribute("textContent") == "Deprecated") { continue; }

                        var pRawName = paramRow.FindElement(By.CssSelector("[class='param-name']")).GetAttribute("innerHTML");
                        var pName = pRawName.ToPascalCase();
                        var pRequired = paramRow.FindElements(By.CssSelector("[class='param-reqd']")).FirstOrDefault()?.GetAttribute("innerHTML") == "Required";
                        var pType = this.GetTypeName(paramRow.FindElement(By.CssSelector("[class='param-type']")).GetAttribute("innerHTML"), cName, pName, pRequired);
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
                            p.TypeName.Name = "List<ChatMessage>";
                            p.Initializer = "new ()";
                        }
                        if (cName == "Embeddings" && p.Name == "Encoding_format")
                        {
                            p.Initializer = "\"float\"";
                        }
                        if (pType == "Stream?")
                        {
                            hasFileProperty = true;
                            if (p.Set != null)
                            {
                                p.Set.Modifier = AccessModifier.Private;
                            }

                            cParameter.ImplementInterfaces.Add(new TypeName("IFileParameter"));

                            var pParameterName = new Property("string", "IFileParameter.ParameterName");
                            cParameter.Properties.Add(pParameterName);
                            pParameterName.Modifier.AccessModifier = MethodAccessModifier.None;
                            pParameterName.Get = new PropertyBody(PropertyBodyType.Get);
                            pParameterName.Get.Body.Add(SourceCodeLanguage.CSharp, $"return \"{pRawName}\";");
                            pParameterName.Set = null;

                            var pFileName = new Property("string", "IFileParameter.FileName", true);
                            cParameter.Properties.Add(pFileName);
                            pFileName.Modifier.AccessModifier = MethodAccessModifier.None;
                            pFileName.Initializer = "\"\"";

                            var mdGetFileStream = new Method(MethodAccessModifier.None, "IFileParameter.GetFileStream");
                            cParameter.Methods.Add(mdGetFileStream);
                            mdGetFileStream.ReturnTypeName = new TypeName("Stream");
                            mdGetFileStream.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} == null) throw new InvalidOperationException(\"{pName} property must be set.\");");
                            mdGetFileStream.Body.Add(SourceCodeLanguage.CSharp, $"return this.{pName};");

                            var mdSetFile = new Method(MethodAccessModifier.Public, "SetFile");
                            cParameter.Methods.Add(mdSetFile);
                            mdSetFile.Parameters.Add(new MethodParameter("string", "fileName"));
                            mdSetFile.Parameters.Add(new MethodParameter("Stream", "stream"));
                            mdSetFile.Body.Add(SourceCodeLanguage.CSharp, $"((IFileParameter)this).FileName = fileName;");
                            mdSetFile.Body.Add(SourceCodeLanguage.CSharp, $"this.{pName} = stream;");

                        }
                        p.Comment = paramRow.FindElements(By.CssSelector("[class='param-desc']")).FirstOrDefault()?.GetAttribute("textContent") ?? "";
                        cParameter.Properties.Add(p);
                        propertyList.Add(p);

                        if (isPathParameter == false)
                        {
                            requestBodyPropertyNameList.Add(p.Name);
                        }

                        if (pRequired)
                        {
                            if (pType == "Stream?")
                            {
                                mdAsync.Parameters.Add(new MethodParameter("string", "fileName"));
                                mdAsync.Parameters.Add(new MethodParameter("Stream", p.Name.ToCamelCase()));
                                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.SetFile(fileName, {p.Name.ToCamelCase()});");
                            }
                            else
                            {
                                mdAsync.Parameters.Add(new MethodParameter(p.TypeName.Name, p.Name.ToCamelCase()));
                                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name} = {p.Name.ToCamelCase()};");

                                mdStreamAsync.Parameters.Add(new MethodParameter(p.TypeName.Name, p.Name.ToCamelCase()));
                                mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, $"p.{p.Name} = {p.Name.ToCamelCase()};");
                            }
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
                sendAsyncMethodName = "SendFormDataAsync";

                foreach (var item in propertyList)
                {
                    var pName = item.Name;
                    var pType = item.TypeName.Name;
                    if (hasFileProperty && pType != "Stream?")
                    {
                        if (pType.EndsWith("?"))
                        {
                            if (pType == "string?")
                            {
                                mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = this.{pName};");
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

            {
                var mdAsync0 = mdAsync.Copy();
                mdAsync0.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(p, CancellationToken.None);");
                cClient.Methods.Add(mdAsync0);
            }
            {
                mdAsync.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
                if (hasStreamMethod)
                {
                    mdAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = null;");
                }
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(p, cancellationToken);");
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
                    var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(p, CancellationToken.None))");
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
                    var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(p, cancellationToken))");
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
                    md2.Parameters.Add(new MethodParameter("[EnumeratorCancellation] CancellationToken", "cancellationToken"));
                    md2.ReturnTypeName.Name = "async IAsyncEnumerable";
                    md2.ReturnTypeName.GenericTypes.Add(new TypeName("ChatCompletionChunk"));

                    md2.Body.Add(SourceCodeLanguage.CSharp, "parameter.Stream = true;");
                    var cb0 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, cancellationToken))");
                    cb0.CurlyBracket = true;
                    {
                        cb0.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                    }
                    md2.Body.Add(cb0);

                    var md1 = md2.Copy();
                    md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
                    md1.Body.Clear();
                    var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, CancellationToken.None))");
                    cb1.CurlyBracket = true;
                    {
                        cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                    }
                    md1.Body.Add(cb1);
       
                    cClient.Methods.Add(md1);
                    cClient.Methods.Add(md2);
                }
            }

            Directory.CreateDirectory(Path.Combine(OutputFolderPath, "Endpoint"));
            var filePath = Path.Combine(OutputFolderPath, "Endpoint", cName + ".cs");
            this.WriteFile(filePath, sc);
        }
        private string GetClassName(string endpointAnchor)
        {
            var cName = "";
            if (endpointAnchor == "Create fine-tuning job") { cName = "FineTuningJobCreate"; }
            if (endpointAnchor == "List fine-tuning jobs") { cName = "FineTuningJobs"; }
            if (endpointAnchor == "Retrieve fine-tuning job") { cName = "FineTuningJobRetrieve"; }
            if (endpointAnchor == "Cancel fine-tuning") { cName = "FineTuningJobCancel"; }
            if (endpointAnchor == "List fine-tuning events") { cName = "FineTuningJobEvents"; }
            if (endpointAnchor == "Upload file") { cName = "FileUpload"; }
            if (endpointAnchor == "Delete file") { cName = "FileDelete"; }
            if (endpointAnchor == "Retrieve file") { cName = "FileRetrieve"; }
            if (endpointAnchor == "Retrieve file content") { cName = "FileContentGet"; }
            if (endpointAnchor == "Retrieve model") { cName = "ModelRetrieve"; }
            if (endpointAnchor == "Delete fine-tune model") { cName = "ModelDelete"; }
            if (endpointAnchor == "Create moderation") { cName = "ModerationCreate"; }
            if (endpointAnchor == "Create assistantBeta") { cName = "AssistantCreate"; }
            if (endpointAnchor == "Retrieve assistantBeta") { cName = "AssistantRetrieve"; }
            if (endpointAnchor == "Modify assistantBeta") { cName = "AssistantModify"; }
            if (endpointAnchor == "Delete assistantBeta") { cName = "AssistantDelete"; }
            if (endpointAnchor == "Create assistant fileBeta") { cName = "AssistantFileCreate"; }
            if (endpointAnchor == "Retrieve assistant fileBeta") { cName = "AssistantFileRetrieve"; }
            if (endpointAnchor == "Delete assistant fileBeta") { cName = "AssistantFileDelete"; }
            if (endpointAnchor == "List assistant filesBeta") { cName = "AssistantFiles"; }
            if (endpointAnchor == "Create threadBeta") { cName = "ThreadCreate"; }
            if (endpointAnchor == "Retrieve threadBeta") { cName = "ThreadRetrieve"; }
            if (endpointAnchor == "Modify threadBeta") { cName = "ThreadModify"; }
            if (endpointAnchor == "Delete threadBeta") { cName = "ThreadDelete"; }
            if (endpointAnchor == "Create messageBeta") { cName = "MessageCreate"; }
            if (endpointAnchor == "Retrieve messageBeta") { cName = "MessageRetrieve"; }
            if (endpointAnchor == "Modify messageBeta") { cName = "MessageModify"; }
            if (endpointAnchor == "List messagesBeta") { cName = "Messages"; }
            if (endpointAnchor == "Create runBeta") { cName = "RunCreate"; }
            if (endpointAnchor == "Retrieve runBeta") { cName = "RunRetrieve"; }
            if (endpointAnchor == "Modify runBeta") { cName = "RunModify"; }
            if (endpointAnchor == "List runsBeta") { cName = "Runs"; }
            if (endpointAnchor == "Retrieve message fileBeta") { cName = "MessageFileRetrieve"; }
            if (endpointAnchor == "List message filesBeta") { cName = "MessageFiles"; }
            if (endpointAnchor == "Submit tool outputs to runBeta") { cName = "SubmitToolOutputs"; }
            if (endpointAnchor == "Cancel a runBeta") { cName = "RunCancel"; }
            if (endpointAnchor == "Create thread and runBeta") { cName = "ThreadRun"; }
            if (endpointAnchor == "Retrieve run stepBeta") { cName = "RunStepRetrieve"; }
            if (endpointAnchor == "List run stepsBeta") { cName = "RunSteps"; }

            return cName;
        }
        private string GetTypeName(string typeName, string className, string propertyName, bool required)
        {
            if (className == "ChatCompletions" && propertyName == "Messages") { return "List<ChatMessage>"; }
            if (className == "Embeddings" && typeName == "string or array") { return "string"; }
            if (className == "FileUpload" && propertyName == "File") { return "Stream?"; }
            if (className == "ImagesVariations" && propertyName == "Image") { return "Stream?"; }
            if (className == "AssistantCreate" && propertyName == "Model") { return "string"; }
            if (className == "AssistantModify" && propertyName == "Model") { return "string"; }

            if (propertyName == "Tools") { return "List<ToolObject>"; }
            if (propertyName == "Tool_choice") { return "object?"; }

            if (typeName == "string") { return "string"; }
            if (typeName == "string or null") { return "string?"; }
            if (typeName == "string or object") { return "string?"; }
            if (typeName == "string or array") { return "string"; }
            if (typeName == "boolean") { return "bool"; }
            if (typeName == "boolean or null") { return "bool?"; }
            if (typeName == "interger") { return "int"; }
            if (typeName == "integer or null") { return "int?"; }
            if (typeName == "number") { return "double"; }
            if (typeName == "number or null") { return "double?"; }
            if (typeName == "file") { return "Stream?"; }
            if (typeName == "array") { return "List<string>"; }
            if (typeName == "string / array / null") { return "List<string>"; }
            if (typeName == "map") { return "object?"; }
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
            if (cName == "Embeddings")
            {
                return "RestApiDataResponse<List<EmbeddingObject>>";
            }
            else if (cName == "FineTuningJobCreate")
            {
                return "RestApiDataResponse<FineTuningJob>";
            }
            else if (cName == "FineTuningJobs")
            {
                return "RestApiDataResponse<List<FineTuningJob>>";
            }
            else if (cName == "FineTuningJobCancel")
            {
                return "FineTuningJobResponse";
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
}
