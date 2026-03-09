using Newtonsoft.Json;

namespace HigLabo.OpenAI;

[JsonConverter(typeof(TypedJsonSchemaPropertyJsonConverter))]
public class JsonSchemaProperty
{
    public string Type { get; set; } = "object";
    public string? Name { get; set; }
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

public class TypedJsonSchemaPropertyJsonConverter : JsonConverter<JsonSchemaProperty>
{
    public override void WriteJson(JsonWriter writer, JsonSchemaProperty? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();

        WriteProperty(writer, "type", value.Type);
        WriteProperty(writer, "name", value.Name);
        WriteProperty(writer, "description", value.Description);
        WriteArrayProperty(writer, "enum", value.Enum);

        if (value.Items != null)
        {
            writer.WritePropertyName("items");
            serializer.Serialize(writer, value.Items);
        }

        writer.WriteEndObject();
    }
    public override JsonSchemaProperty? ReadJson(JsonReader reader, Type objectType, JsonSchemaProperty? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize<JsonSchemaProperty>(reader);
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
