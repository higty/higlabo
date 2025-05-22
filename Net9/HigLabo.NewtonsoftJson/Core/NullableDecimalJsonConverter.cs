using Newtonsoft.Json;
using System;
using System.Globalization;

public class NullableDecimalJsonConverter : JsonConverter<decimal?>
{
    public override decimal? ReadJson(JsonReader reader, Type objectType, decimal? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        if (reader.Value is decimal decimalValue) return decimalValue;

        if (decimal.TryParse(reader.Value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out var result)) return result;

        return null;
    }

    public override void WriteJson(JsonWriter writer, decimal? value, JsonSerializer serializer)
    {
        if (value.HasValue)
            writer.WriteValue(value.Value);
        else
            writer.WriteNull();
    }
}