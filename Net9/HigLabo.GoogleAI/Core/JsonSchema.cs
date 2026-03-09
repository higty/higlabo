using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HigLabo.GoogleAI;

[JsonConverter(typeof(JsonSchemaJsonConverter))]
public class JsonSchema
{
    public string? Name { get; set; }
    public string Type { get; set; } = "object";
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? Enum { get; set; }
    public List<JsonSchema> Properties { get; init; } = new();
    public bool? AdditionalProperties { get; set; }
    public string[]? Required { get; set; }
    public JsonSchema? Items { get; set; }

    public JsonSchema() { }
    public JsonSchema(string type)
    {
        this.Type = type;
    }
}

public class JsonSchemaJsonConverter : JsonConverter<JsonSchema>
{
    private static readonly CamelCaseNamingStrategy NamingStrategy = new();

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

        if (value.Items != null)
        {
            writer.WritePropertyName("items");
            WriteJson(writer, value.Items, serializer);
        }
        if (value.Properties.Count > 0)
        {
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            foreach (var item in value.Properties)
            {
                if (string.IsNullOrWhiteSpace(item.Name)) { continue; }
                writer.WritePropertyName(ToCamelCase(item.Name));
                WriteJson(writer, item, serializer);
            }
            writer.WriteEndObject();
        }
        if (value.Required != null && value.Required.Length > 0)
        {
            writer.WritePropertyName("required");
            writer.WriteStartArray();
            foreach (var item in value.Required)
            {
                writer.WriteValue(ToCamelCase(item));
            }
            writer.WriteEndArray();
        }

        writer.WriteEndObject();
    }

    public override JsonSchema? ReadJson(JsonReader reader, Type objectType, JsonSchema? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize<JsonSchema>(reader);
    }

    private static string ToCamelCase(string text)
    {
        return NamingStrategy.GetPropertyName(text, false);
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
