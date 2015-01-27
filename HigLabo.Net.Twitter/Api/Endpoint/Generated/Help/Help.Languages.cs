using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Help
    {
        public partial class Languages
        {
            public class Command : TwitterCommand
            {
                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/help/languages.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("code")]
                public String code { get; set; }
                [JsonProperty("status")]
                public String status { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
            }
        }
    }
}
