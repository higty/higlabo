using Newtonsoft.Json;
using System;

public class NullableUInt32JsonConverter : JsonConverter<uint?>
{
    public override uint? ReadJson(JsonReader reader, Type objectType, uint? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is uint uintValue) return uintValue;

        if (uint.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, uint? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}