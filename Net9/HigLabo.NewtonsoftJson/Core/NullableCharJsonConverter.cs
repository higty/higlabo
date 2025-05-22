using Newtonsoft.Json;
using System;

public class NullableCharJsonConverter : JsonConverter<char?>
{
    public override char? ReadJson(JsonReader reader, Type objectType, char? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        var str = reader.Value.ToString();
        if (string.IsNullOrEmpty(str)) return null;

        return str[0];
    }

    public override void WriteJson(JsonWriter writer, char? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value.ToString());
        else
            writer.WriteNull();
    }
}