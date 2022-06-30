using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class JsonConverter : IJsonConverter
    {
        private class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }

        public Newtonsoft.Json.JsonSerializerSettings Settings { get; private set; } = new Newtonsoft.Json.JsonSerializerSettings();

        public JsonConverter()
        {
            this.Settings.ContractResolver = new LowercaseContractResolver();
            this.Settings.NullValueHandling = NullValueHandling.Ignore;
            this.Settings.Converters.Add(new StringEnumConverter());
        }
        public string SerializeObject(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, this.Settings);
        }
        public T DeserializeObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, this.Settings);
        }
    }
}
