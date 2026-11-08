using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI;

/// <summary>Retains string arguments for functions and JSON arguments for tool-search events.</summary>
public class ResponseArgumentsConverter : JsonConverter<string>
{
    public override string? ReadJson(JsonReader reader, Type objectType, string? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        return token.Type switch
        {
            JTokenType.Null => null,
            JTokenType.String => token.Value<string>(),
            _ => token.ToString(Formatting.None),
        };
    }

    public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
        => writer.WriteValue(value);
}
