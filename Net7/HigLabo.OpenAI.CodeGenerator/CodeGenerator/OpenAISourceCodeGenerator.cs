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
            //CreateSourceCode(ee[22]);
            //return;

            for (int i = 0; i < 23; i++)
            {
                CreateSourceCode(ee[i]);
            }
        }
        public void CreateSourceCode(IWebElement endpointPanel)
        {
            var endpointAnchor = endpointPanel.FindElement(By.CssSelector("h2[class='anchor-heading']")).GetAttribute("textContent");
            if (endpointAnchor == "The completion objectLegacy" ||
                endpointAnchor == "Create completionLegacy") { return; }

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
            var contentType = "";
            foreach (var item in endpointPanel.FindElements(By.CssSelector("[class='hljs-string']")))
            {
                var text = item.GetAttribute("textContent").Trim('\"');
                if (text.StartsWith("Content-Type:"))
                {
                    contentType = text.Replace("Content-Type: ", "");
                    break;
                }
            }
            var hasStreamMethod = false;
            if (endpointUrl == "https://api.openai.com/v1/chat/completions")
            {
                hasStreamMethod = true;
            }
            var endpointPath = endpointUrl.Replace("https://api.openai.com/v1/", "");
            var cName = "";
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
            if (endpointAnchor == "Create fine-tuning job") { cName = "FineTuningJobCreate"; }
            if (endpointAnchor == "List fine-tuning jobs") { cName = "FineTuningJobs"; }
            if (endpointAnchor == "Retrieve fine-tuning job") { cName = "FineTuningJobRetrieve"; }
            if (endpointAnchor == "Cancel fine-tuning") { cName = "FineTuningJobCancel"; }
            if (endpointAnchor == "List fine-tuning events") { cName = "FineTuningJobEvents"; }
            if (endpointAnchor == "Upload file") { cName = "FileUpload"; }
            if (endpointAnchor == "Delete file") { cName = "FileDelete"; }
            if (endpointAnchor == "Retrieve file") { cName = "FileRetrieve"; }
            if (endpointAnchor == "Retrieve file content") { cName = "FileContentGet"; }

            if (cName == "FileUpload") { contentType = "multipart/form-data"; }

            var cParameter = new Class(AccessModifier.Public, cName + "Parameter");
            sc.Namespaces[0].Classes.Add(cParameter);
            cParameter.Comment = endpointPanel.FindElement(By.CssSelector("[class='endpoint-summary']")).GetAttribute("textContent") + Environment.NewLine
                + $"<seealso href=\"{endpointUrl}\">{endpointUrl}</seealso>";
            cParameter.Modifier.Partial = true;
            cParameter.ImplementInterfaces.Add(new TypeName("IRestApiParameter"));
            cParameter.Properties.Add(this.CreateHttpMethodProperty(httpMethod));
            cParameter.Methods.Add(this.CreateGetApiPathMethod(endpointUrl));

            var sendAsyncMethodName = "SendJsonAsync";
            Method? mdCreateFormDataParameter = null;
            if (contentType == "multipart/form-data")
            {
                sendAsyncMethodName = "SendFormDataAsync";

                cParameter.ImplementInterfaces.Add(new TypeName("IFormDataParameter"));
                mdCreateFormDataParameter = new Method(MethodAccessModifier.None, "IFormDataParameter.CreateFormDataParameter");
                cParameter.Methods.Add(mdCreateFormDataParameter);
                mdCreateFormDataParameter.ReturnTypeName = new TypeName("Dictionary<string, string>");
                mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"var d = new Dictionary<string, string>();");
            }

            var cResponse = new Class(AccessModifier.Public, cName + "Response");
            sc.Namespaces[0].Classes.Add(cResponse);
            cResponse.Modifier.Partial = true;
            if (cName == "Embeddings")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiDataResponse<List<EmbeddingObject>>"));
            }
            else if (cName == "FineTuningJobCreate")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiDataResponse<FineTuningJob>"));
            }
            else if (cName == "FineTuningJobs")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiDataResponse<List<FineTuningJob>>"));
            }
            else if (cName == "FineTuningJobCancel")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("FineTuningJobResponse"));
            }
            else if (cName == "FineTuningJobEvents")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiDataResponse<List<FineTuningJob>>"));
            }
            else if (cName == "Files")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiDataResponse<List<FileObject>>"));
            }
            else if (cName == "FileUpload")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("FileObjectResponse"));
            }
            else if (cName == "FileRetrieve")
            {
                cResponse.ImplementInterfaces.Add(new TypeName("FileObjectResponse"));
            }
            else
            {
                cResponse.ImplementInterfaces.Add(new TypeName("RestApiResponse"));
            }

            var cClient = new Class(AccessModifier.Public, "OpenAIClient");
            sc.Namespaces[0].Classes.Add(cClient);
            cClient.Modifier.Partial = true;
    
            {
                var md = new Method(MethodAccessModifier.Public, cName + "Async");
                md.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
                md.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
                md.ReturnTypeName.Name = "async ValueTask";
                md.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
                md.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(parameter, cancellationToken);");
                cClient.Methods.Add(md);

                var md1 = md.Copy();
                md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
                md1.Body.Clear();
                md1.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(parameter, CancellationToken.None);");
                cClient.Methods.Add(md1);
            }
            var mdAsync = new Method(MethodAccessModifier.Public, cName + "Async");
            mdAsync.ReturnTypeName.Name = "async ValueTask";
            mdAsync.ReturnTypeName.GenericTypes.Add(new TypeName(cName + "Response"));
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");
            cClient.Methods.Add(mdAsync);

            if (hasStreamMethod)
            {
                var md = new Method(MethodAccessModifier.Public, cName + "StreamAsync");
                md.Parameters.Add(new MethodParameter(cName + "Parameter", "parameter"));
                md.Parameters.Add(new MethodParameter("[EnumeratorCancellation] CancellationToken", "cancellationToken"));
                md.ReturnTypeName.Name = "async IAsyncEnumerable";
                md.ReturnTypeName.GenericTypes.Add(new TypeName("ChatCompletionChunk"));
                var cb0 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, cancellationToken))");
                cb0.CurlyBracket = true;
                {
                    cb0.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md.Body.Add(cb0);
                cClient.Methods.Add(md);

                var md1 = md.Copy();
                md1.Parameters.RemoveAt(md1.Parameters.Count - 1);
                md1.Body.Clear();
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.GetStreamAsync(parameter, CancellationToken.None))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                md1.Body.Add(cb1);
                cClient.Methods.Add(md1);
            }
            var mdStreamAsync = new Method(MethodAccessModifier.Public, cName + "StreamAsync");
            mdStreamAsync.ReturnTypeName.Name = "async IAsyncEnumerable";
            mdStreamAsync.ReturnTypeName.GenericTypes.Add(new TypeName("ChatCompletionChunk"));
            mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, $"var p = new {cName}Parameter();");
            if (hasStreamMethod)
            {
                cClient.Methods.Add(mdStreamAsync);
            }

            foreach (var paramSection in endpointPanel.FindElements(By.CssSelector("div[class='param-section']")))
            {
                var h3 = paramSection.FindElement(By.CssSelector("h3")).GetAttribute("innerHTML");
                if (h3 == "Request body" || h3 == "Path parameters")
                {
                    foreach (var paramRow in paramSection.FindElements(By.CssSelector("div[class='param-row']")))
                    {
                        if (paramRow.FindElements(By.CssSelector("[class='param-depr']")).FirstOrDefault()?.GetAttribute("textContent") == "Deprecated") { continue; }

                        var pRawName = paramRow.FindElement(By.CssSelector("[class='param-name']")).GetAttribute("innerHTML");
                        var pName = pRawName.ToPascalCase();
                        var pRequired = paramRow.FindElements(By.CssSelector("[class='param-reqd']")).FirstOrDefault()?.GetAttribute("innerHTML") == "Required";
                        var pType = this.GetTypeName(paramRow.FindElement(By.CssSelector("[class='param-type']")).GetAttribute("innerHTML"), cName, pName, pRequired);

                        var p = new Property(pType, pName, true);
                        p.Name = p.Name.ToPascalCase();
                        if (p.TypeName.Name == "string")
                        {
                            p.Initializer = "\"\"";
                        }
                        if (cName == "ChatCompletions" && p.TypeName.Name.StartsWith("List<"))
                        {
                            if (p.Name == "Messages")
                            {
                                p.Initializer = "new ()";
                            }
                            else
                            {
                                p.TypeName.Name += "?";
                            }
                        }
                        if (cName == "Embeddings" && p.Name == "Encoding_format")
                        {
                            p.Initializer = "\"float\"";
                        }
                        if (pType == "Stream?")
                        {
                            p.Set.Modifier = AccessModifier.Private;

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
                        p.Comment = paramRow.FindElement(By.CssSelector("[class='param-desc']")).GetAttribute("textContent");
                        cParameter.Properties.Add(p);

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
                        if (mdCreateFormDataParameter != null && pType != "Stream?")
                        {
                            if (pType.EndsWith("?"))
                            {
                                if (pType == "string")
                                {
                                    mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = this.{pName};");
                                }
                                else
                                {
                                    mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"if (this.{pName} != null) d[\"{pName.ToLower()}\"] = this.{pName}.ToString();");
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
                }
                if (h3 == "Returns")
                {

                }
            }
            if (mdCreateFormDataParameter != null)
            {
                mdCreateFormDataParameter.Body.Add(SourceCodeLanguage.CSharp, $"return d;");
            }

            mdAsync.Parameters.Add(new MethodParameter("CancellationToken", "cancellationToken"));
            if (hasStreamMethod)
            {
                mdAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = null;");
            }
            mdAsync.Body.Add(SourceCodeLanguage.CSharp, $"return await this.{sendAsyncMethodName}<{cName}Parameter, {cName}Response>(p, cancellationToken);");

            if (hasStreamMethod)
            {
                mdStreamAsync.Parameters.Add(new MethodParameter("[EnumeratorCancellation] CancellationToken", "cancellationToken"));

                mdStreamAsync.Body.Add(SourceCodeLanguage.CSharp, "p.Stream = true;");
                var cb1 = new CodeBlock(SourceCodeLanguage.CSharp, $"await foreach (var item in this.{cName}StreamAsync(p, cancellationToken))");
                cb1.CurlyBracket = true;
                {
                    cb1.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "yield return item;"));
                }
                mdStreamAsync.Body.Add(cb1);
            }

            cClient.Methods.Reverse();

            Directory.CreateDirectory(Path.Combine(OutputFolderPath, "Endpoint"));
            var filePath = Path.Combine(OutputFolderPath, "Endpoint", cName + ".cs");
            this.WriteFile(filePath, sc);
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

        private string GetTypeName(string typeName, string className, string propertyName, bool required)
        {
            if (className == "ChatCompletions" && propertyName == "Messages") { return "List<ChatMessage>"; }
            if (className == "Embeddings" && typeName == "string or array") { return "string"; }
            if (className == "FileUpload" && propertyName == "File") { return "Stream?"; }

            if (propertyName == "Tools") { return "List<Tool>"; }
            if (propertyName == "Tool_choice") { return "object?"; }

            if (typeName == "string") { return "string"; }
            if (typeName == "string or null") { return "string?"; }
            if (typeName == "string or object") { return "string?"; }
            if (typeName == "boolean") { return "bool"; }
            if (typeName == "boolean or null") { return "bool?"; }
            if (typeName == "interger") { return "int"; }
            if (typeName == "integer or null") { return "int?"; }
            if (typeName == "number") { return "double"; }
            if (typeName == "number or null") { return "double?"; }
            if (typeName == "file") { return "Stream?"; }
            if (typeName == "string / array / null") { return "List<string>"; }
            if (typeName == "map") { return "object?"; }
            if (typeName == "object")
            {
                if (required) { return "object"; }
                return "object?";
            }

            return typeName;
        }
        protected Property CreateHttpMethodProperty(string httpMethod)
        {
            var p = new Property("string", "IRestApiParameter.HttpMethod", true);
            p.Modifier.AccessModifier = MethodAccessModifier.None;
            p.Set = null;
            p.Initializer = $"\"{httpMethod.ToUpper()}\"";

            return p;
        }
        protected Method CreateGetApiPathMethod(string url)
        {
            var md = new Method(MethodAccessModifier.None, "IRestApiParameter.GetApiPath");
            md.Modifier.AccessModifier = MethodAccessModifier.None;
            md.ReturnTypeName = new TypeName("string");

            var path = RegexList.CurlyBrackets.Replace(url, m => "{" + m.Groups["Value"].Value.ToPascalCase() + "}");
            md.Body.Add(SourceCodeLanguage.CSharp, $"return $\"{path.Replace("https://api.openai.com/v1", "")}\";");

            return md;
        }
    }
}
