using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public String DateFormat { get; set; } = "yyyy/MM/dd";

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateOnly.Parse((string)reader.Value!);
        }

        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(DateFormat));
        }
    }

}
