using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class EnumToStringConverter : JsonConverter
{
    public EnumToStringConverter()
    {
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) { return null; }
        return ((Enum)reader.Value).ToStringFromEnum();
    }
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }
        writer.WriteValue(value.ToString()!.ToLower());
    }
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum;
    }
}
