using Newtonsoft.Json;
using System;
using System.Globalization;

public class NullableDoubleJsonConverter : JsonConverter<double?>
{
    public override double? ReadJson(JsonReader reader, Type objectType, double? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is double doubleValue) return doubleValue;

        if (double.TryParse(reader.Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, double? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}