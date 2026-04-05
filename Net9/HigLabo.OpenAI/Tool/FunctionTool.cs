using HigLabo.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    public FunctionTool SetParameters(string jsonSchema)
    {
        if (String.IsNullOrWhiteSpace(jsonSchema))
        {
            throw new ArgumentException("JSON schema must not be null or empty.", nameof(jsonSchema));
        }

        var token = JToken.Parse(jsonSchema);
        if (token.Type != JTokenType.Object)
        {
            throw new ArgumentException("JSON schema root must be an object.", nameof(jsonSchema));
        }

        this.Parameters = token;
        return this;
    }
}
