using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HigLabo.Core
{
    public class NullableDateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateOnly.TryParse(reader.GetString(), out var date))
            {
                return date;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
