using Newtonsoft.Json;
using System;

public class NullableByteJsonConverter : JsonConverter<byte?>
{
    public override byte? ReadJson(JsonReader reader, Type objectType, byte? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is byte byteValue) return byteValue;

        if (byte.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, byte? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}