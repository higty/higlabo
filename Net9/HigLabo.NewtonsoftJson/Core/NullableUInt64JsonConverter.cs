using Newtonsoft.Json;
using System;

public class NullableUInt64JsonConverter : JsonConverter<ulong?>
{
    public override ulong? ReadJson(JsonReader reader, Type objectType, ulong? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is ulong ulongValue) return ulongValue;

        if (ulong.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, ulong? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}