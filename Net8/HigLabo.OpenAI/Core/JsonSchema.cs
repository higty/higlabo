using Newtonsoft.Json;

namespace HigLabo.OpenAI
{
    public class JsonSchema
    {
        public string Type { get; set; } = "object";
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public Dictionary<string, JsonSchemaProperty> Properties { get; init; } = new();
        public bool AdditionalProperties { get; set; } = false;
        public string[]? Required { get; set; }

        public JsonSchema() { }
        public JsonSchema(string type) => Type = type;
    }
}
