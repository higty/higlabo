using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspnetHtmxTodoSample.Converter;

public class GuidJsonConverter : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Guid.Parse(reader.GetString()!);
    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
}