using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HigLabo.Core;

public class NullableGuidJsonConverter : JsonConverter<Guid?>
{
    public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (Guid.TryParse(reader.GetString(), out var date))
        {
            return date;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
