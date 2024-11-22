namespace HigLabo.OpenAI;

public class JsonSchemaProperty
{
    public string Type { get; set; } = "object";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string[]? Enum { get; set; } 
    public JsonSchema? Items { get; set; }

    public JsonSchemaProperty() { }
    public JsonSchemaProperty(string type)
    {
        this.Type = type;
    }
    public JsonSchemaProperty(string type, string description)
    {
        this.Type = type;
        this.Description = description;
    }
}
