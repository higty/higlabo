using HigLabo.Newtonsoft;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HigLabo.X;

public class XJsonConverter : IJsonConverter
{
    public JsonSerializerSettings SerializeSetting = new JsonSerializerSettings();
    public JsonSerializerSettings DeserializeSetting = new JsonSerializerSettings();

    public XJsonConverter()
    {
        this.SerializeSetting.ContractResolver = new LowercaseContractResolver();
        this.SerializeSetting.NullValueHandling = NullValueHandling.Ignore;
        this.SerializeSetting.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

        this.DeserializeSetting.NullValueHandling = NullValueHandling.Ignore;
        this.DeserializeSetting.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    }
    public string SerializeObject(object obj)
    {
        return JsonConvert.SerializeObject(obj, SerializeSetting);
    }
    public T DeserializeObject<T>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json, DeserializeSetting)!;
        }
        catch (Exception ex)
        {
#if DEBUG
            Debugger.Break();
            Debug.Write(ex.ToString());
#else
            throw;
#endif
        }
        return default(T)!;
    }
}
