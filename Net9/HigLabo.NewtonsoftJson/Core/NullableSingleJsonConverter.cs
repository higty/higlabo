using Newtonsoft.Json;
using System;
using System.Globalization;

public class NullableSingleJsonConverter : JsonConverter<float?>
{
    public override float? ReadJson(JsonReader reader, Type objectType, float? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is float floatValue) return floatValue;

        if (float.TryParse(reader.Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, float? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}