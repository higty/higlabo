using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    public String TimeFormat { get; set; } = "HH:mm:ss.FFFFFFF";

    public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return TimeOnly.Parse((string)reader.Value!, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
