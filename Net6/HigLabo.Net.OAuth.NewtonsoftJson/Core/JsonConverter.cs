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
        private static string[] _EmptyPropertyNameList = new string[0];
        public Newtonsoft.Json.JsonSerializerSettings Settings { get; private set; } = new Newtonsoft.Json.JsonSerializerSettings();

        public JsonConverter()
            : this(_EmptyPropertyNameList)
        {
        }
        public JsonConverter(IEnumerable<string> propertyNameList)
        {
            this.Settings.ContractResolver = new IgnorePropertyResolver(propertyNameList);
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
namespace HigLabo.Net.Microsoft
{
    public class JsonConverter : OAuth.JsonConverter
    {
        public JsonConverter()
            : base(new[] { "ApiPathSetting" })
        {
        }
    }
}

