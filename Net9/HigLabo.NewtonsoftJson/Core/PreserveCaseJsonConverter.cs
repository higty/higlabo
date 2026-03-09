using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace HigLabo.Newtonsoft;

public class PreserveCaseJsonConverter : JsonConverter
{
    private static readonly JsonSerializer _Serializer = CreateSerializer();

    public override bool CanRead => true;
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(object);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        var token = JToken.FromObject(value, _Serializer);
        token.WriteTo(writer);
    }
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return JToken.Load(reader);
    }

    private static JsonSerializer CreateSerializer()
    {
        var serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        });
        serializer.Converters.Add(new StringEnumConverter());
        serializer.Converters.Add(new EnumToLowerStringConverter());
        return serializer;
    }
}
