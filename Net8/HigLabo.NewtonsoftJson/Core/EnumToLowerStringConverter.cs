using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class EnumToLowerStringConverter : StringEnumConverter
{
    public EnumToLowerStringConverter()
    {
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return base.ReadJson(reader, objectType, existingValue, serializer); 
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
        return objectType.IsEnum || Nullable.GetUnderlyingType(objectType)?.IsEnum == true;
    }
}
