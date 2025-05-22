using Newtonsoft.Json;
using System;

public class NullableSByteJsonConverter : JsonConverter<sbyte?>
{
    public override sbyte? ReadJson(JsonReader reader, Type objectType, sbyte? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is sbyte sbyteValue) return sbyteValue;

        if (sbyte.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, sbyte? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}