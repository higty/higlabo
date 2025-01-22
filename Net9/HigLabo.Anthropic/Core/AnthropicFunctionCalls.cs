using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HigLabo.Anthropic;

public class AnthropicFunctionCalls 
{
    public List<AnthropicInvoke> InvokeList { get; init; } = new();

    public override string ToString()
    {
        var sb = new StringBuilder(256);
        foreach (var item in this.InvokeList)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString();
    }
    public static async ValueTask<AnthropicFunctionCalls> ParseAsync(string text)
    {
        var calls = new AnthropicFunctionCalls();
        var insideFunctionCallsTag = false;
        var sb = new StringBuilder(512);
        using (var reader = new StringReader(text))
        {
            while (reader.Peek() > -1)
            {
                var line = reader.ReadLine()!;
                if (string.Equals(line, "<function_calls>"))
                {
                    insideFunctionCallsTag = true;
                    continue;
                }
                if (string.Equals(line, "</function_calls>"))
                {
                    insideFunctionCallsTag = false;

                    var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + sb.ToString();
                    var xDocument = await XDocument.LoadAsync(new StringReader(xml), LoadOptions.None, CancellationToken.None);
                    foreach (var invokeItem in xDocument.Descendants("invoke"))
                    {
                        var invoke = new AnthropicInvoke();
                        var toolNode = invokeItem.Element("tool_name");
                        invoke.ToolName = toolNode?.Value ?? "";
                        foreach (var pNode in xDocument.Descendants("parameters"))
                        {
                            foreach (var item in pNode.Elements())
                            {
                                var p = new AnthropicInvokeParameter();
                                p.Name = item.Name.ToString();
                                p.Value = item.Value;
                                invoke.Parameters.Add(p);
                            }
                        }
                        calls.InvokeList.Add(invoke);
                    }

                    sb.Clear();
                    continue;
                }
                if (insideFunctionCallsTag)
                {
                    sb.AppendLine(line);
                }
            }
        }

        return calls;
    }
}
public class AnthropicInvoke
{
    private static class RegexList
    {
        public static Regex Tool_Name = new Regex("<tool_name>(?<Name>[^<]*)</tool_name>", RegexOptions.Compiled);
        public static Regex Parameter = new Regex("<(?<Name>[^>]*)>(?<Value>[^<]*)</[^>]*>", RegexOptions.Compiled);
    }

    public string ToolName { get; set; } = "";

    public List<AnthropicInvokeParameter> Parameters { get; init; } = new();

    public string? GetParameterValue(string name)
    {
        return this.Parameters.Find(el => el.Name == name)?.Value;
    }
    public override string ToString()
    {
        var sb = new StringBuilder(128);
        sb.Append($"{this.ToolName}");
        if (this.Parameters.Count > 0)
        {
            sb.Append("(");
            for (int i = 0; i < this.Parameters.Count; i++)
            {
                var p = this.Parameters[i];
                sb.Append($"{p.Name}={p.Value}");
                if (i <  this.Parameters.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(")");
        }

        return sb.ToString();
    }
}
public class AnthropicInvokeParameter
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
}
