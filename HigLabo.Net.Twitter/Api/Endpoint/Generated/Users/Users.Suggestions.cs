using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Users
    {
        public partial class Suggestions
        {
            public class Command : TwitterCommand
            {
                public String lang { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/users/suggestions.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("slug")]
                public String slug { get; set; }
                [JsonProperty("size")]
                public Int64? size { get; set; }
            }
        }
    }
}
