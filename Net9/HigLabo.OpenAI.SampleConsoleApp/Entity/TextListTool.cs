using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;
public class TextListTool : FunctionTool
{
    public class Result
    {
        public List<string> TextList { get; init; } = new();
    }
    public TextListTool(string functionName, string description)
    {
        var tool = this;
        tool.Name = functionName;
        tool.Description = description;
        tool.Parameters = CreateJsonSchema();
    }
    private JsonSchema CreateJsonSchema()
    {
        var o = new JsonSchema();
        o.Properties.Add("textList", new JsonSchemaProperty("array", "テキストのリスト")
        {
            Items = new JsonSchema("string"),
        });
        //o.Required = new string[] { "textList" };
        return o;
    }

    public Result GetResult(string json)
    {
        return JsonConvert.DeserializeObject<Result>(json)!;
    }
}
