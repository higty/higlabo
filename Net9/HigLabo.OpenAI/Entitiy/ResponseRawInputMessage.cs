using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI;

/// <summary>Preserves heterogeneous API items, including encrypted reasoning and compaction items.</summary>
[JsonConverter(typeof(ResponseRawInputMessageConverter))]
public class ResponseRawInputMessage : ResponseInputMessage
{
    public JObject Item { get; }

    public ResponseRawInputMessage(JObject item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Item = (JObject)item.DeepClone();
    }
}

public class ResponseRawInputMessageConverter : JsonConverter<ResponseRawInputMessage>
{
    public override void WriteJson(JsonWriter writer, ResponseRawInputMessage? value, JsonSerializer serializer)
    {
        if (value == null) { writer.WriteNull(); return; }
        value.Item.WriteTo(writer);
    }

    public override ResponseRawInputMessage ReadJson(JsonReader reader, Type objectType, ResponseRawInputMessage? existingValue, bool hasExistingValue, JsonSerializer serializer)
        => new(JObject.Load(reader));
}
