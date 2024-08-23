using HigLabo.Core;
using HigLabo.Net.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

namespace HigLabo.Net.Microsoft
{
    public class MicrosoftJsonConverter : IJsonConverter
    {
        public JsonSerializerSettings Setting = new JsonSerializerSettings();

        public MicrosoftJsonConverter()
        {
            this.Setting.ContractResolver = new MicrosoftContractResolver();
            this.Setting.NullValueHandling = NullValueHandling.Ignore;
            this.Setting.Converters.Add(new EnumToLowerStringConverter());
        }
        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Setting);
        }
        public T DeserializeObject<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, Setting)!;
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
}
