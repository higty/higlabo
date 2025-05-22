using Newtonsoft.Json;
using System;

public class NullableInt16JsonConverter : JsonConverter<short?>
{
    public override short? ReadJson(JsonReader reader, Type objectType, short? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is short shortValue) return shortValue;

        if (short.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, short? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}