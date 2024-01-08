using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class OpenAIJsonConverter : IJsonConverter
    {
        public JsonSerializerSettings Setting = new JsonSerializerSettings();

        public OpenAIJsonConverter()
        {
            this.Setting.ContractResolver = new LowercaseContractResolver();
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
