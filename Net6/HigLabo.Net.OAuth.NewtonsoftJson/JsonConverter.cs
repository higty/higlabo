using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class JsonConverter : IJsonConverter
    {
        public Newtonsoft.Json.JsonSerializerSettings Settings { get; private set; } = new Newtonsoft.Json.JsonSerializerSettings();

        public JsonConverter()
        {
            //Remove CamelCasePropertyNamesContractResolver to case insensitive
            this.Settings.ContractResolver = null;
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
