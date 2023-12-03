using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
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
}
