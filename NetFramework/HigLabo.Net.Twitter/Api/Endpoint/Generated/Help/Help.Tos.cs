using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Help
    {
        public partial class Tos
        {
            public class Command : TwitterCommand
            {
                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/help/tos.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("tos")]
                public String tos { get; set; }
            }
        }
    }
}
