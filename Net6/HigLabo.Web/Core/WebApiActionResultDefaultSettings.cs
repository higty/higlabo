using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class WebApiActionResultDefaultSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();

        public WebApiActionResultDefaultSettings()
        {
            var s = this.JsonSerializerSettings;
            s.NullValueHandling = NullValueHandling.Ignore;
            s.Converters.Add(new StringEnumConverter());
        }
    }
}
