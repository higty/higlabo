using Newtonsoft.Json;

namespace HigLabo.OpenAI;

[JsonConverter(typeof(JsonSchemaJsonConverter))]
public class JsonSchema
{
    public string Type { get; set; } = "object";
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? Enum { get; set; }
    public Dictionary<string, JsonSchemaProperty> Properties { get; init; } = new();
    public bool AdditionalProperties { get; set; } = false;
    public string[]? Required { get; set; }

    public JsonSchema() { }
    public JsonSchema(string type) => Type = type;
}

public class JsonSchemaJsonConverter : JsonConverter<JsonSchema>
{
    public override void WriteJson(JsonWriter writer, JsonSchema? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();

        WriteProperty(writer, "type", value.Type);
        WriteProperty(writer, "title", value.Title);
        WriteProperty(writer, "description", value.Description);
        WriteArrayProperty(writer, "enum", value.Enum);
        WriteProperty(writer, "additionalProperties", value.AdditionalProperties);

        if (value.Properties.Count > 0)
        {
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            foreach (var item in value.Properties)
            {
                writer.WritePropertyName(item.Key);
                serializer.Serialize(writer, item.Value);
            }
            writer.WriteEndObject();
        }
        if (value.Required != null && value.Required.Length > 0)
        {
            writer.WritePropertyName("required");
            writer.WriteStartArray();
            foreach (var item in value.Required)
            {
                writer.WriteValue(item);
            }
            writer.WriteEndArray();
        }

        writer.WriteEndObject();
    }
    public override JsonSchema? ReadJson(JsonReader reader, Type objectType, JsonSchema? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize<JsonSchema>(reader);
    }

    private static void WriteProperty<T>(JsonWriter writer, string name, T value)
    {
        if (value == null) { return; }
        writer.WritePropertyName(name);
        writer.WriteValue(value);
    }
    private static void WriteArrayProperty(JsonWriter writer, string name, IEnumerable<string>? values)
    {
        if (values == null) { return; }
        writer.WritePropertyName(name);
        writer.WriteStartArray();
        foreach (var item in values)
        {
            writer.WriteValue(item);
        }
        writer.WriteEndArray();
    }
}
