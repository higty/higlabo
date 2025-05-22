using Newtonsoft.Json;
using System;

public class NullableUInt16JsonConverter : JsonConverter<ushort?>
{
    public override ushort? ReadJson(JsonReader reader, Type objectType, ushort? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is ushort ushortValue) return ushortValue;

        if (ushort.TryParse(reader.Value.ToString(), out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, ushort? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}