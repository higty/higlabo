namespace HigLabo.OpenAI;

public class JsonSchemaResponseFormat
{
    public string Type { get;set; } = "json_schema";
    public JsonSchemaResponseFormatJsonSchema json_schema { get; set; } = new();
}
public class JsonSchemaResponseFormatJsonSchema
{
    public string Name { get; set; } = "";
    public bool Strict { get; set; } = true;
    public JsonSchema Schema { get; set; } = new();
}
