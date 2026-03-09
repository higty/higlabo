using HigLabo.Newtonsoft;
using Newtonsoft.Json;

namespace HigLabo.OpenAI;

public class FunctionTool : Tool
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    [JsonConverter(typeof(PreserveCaseJsonConverter))]
    public object? Parameters { get; set; }
    public bool? Strict { get; set; }

    public FunctionTool()
        : base("function")
    { }
}
