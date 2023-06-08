using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json
{
    public class NullableTimeOnlyJsonConverter : JsonConverter<Nullable<TimeOnly>>
    {
        public String TimeFormat { get; set; } = "HH:mm:ss.FFFFFFF";

        public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            if (TimeOnly.TryParse((string)reader.Value, out var t) == true)
            {
                return t;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, TimeOnly? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.Value.ToString(TimeFormat, CultureInfo.InvariantCulture));
            }
        }
    }
}
