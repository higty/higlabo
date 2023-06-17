using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class NullableDateOnlyJsonConverter : JsonConverter<Nullable<DateOnly>>
    {
        public String DateFormat { get; set; } = "yyyy/MM/dd";

        public override DateOnly? ReadJson(JsonReader reader, Type objectType, DateOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            if (DateOnly.TryParse((string)reader.Value, out var d) == true)
            {
                return d;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, DateOnly? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.Value.ToString(DateFormat));
            }
            else
            {
            }
        }
    }
}
