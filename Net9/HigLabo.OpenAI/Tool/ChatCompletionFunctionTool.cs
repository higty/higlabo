using HigLabo.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI;
public class ChatCompletionFunctionTool
{
    public class FunctionObject
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [JsonConverter(typeof(PreserveCaseJsonConverter))]
        public object? Parameters { get; set; }

        public FunctionObject SetParameters(string jsonSchema)
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

    public string Type { get; set; } = "function";
    public FunctionObject Function { get; set; } = new FunctionObject();

    public ChatCompletionFunctionTool()
    {
    }
    public ChatCompletionFunctionTool(string type)
    {
        Type = type;
    }
}
