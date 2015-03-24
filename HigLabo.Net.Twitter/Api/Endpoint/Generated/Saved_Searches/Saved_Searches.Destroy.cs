using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Saved_Searches
    {
        public partial class Destroy
        {
            public class Command : TwitterCommand
            {
                public String id { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return String.Format("https://api.twitter.com/1.1/saved_searches/destroy/{0}.json", this.id);
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("created_at")]
                public String created_at { get; set; }
                [JsonProperty("id")]
                public Int64? id { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("position")]
                public String position { get; set; }
                [JsonProperty("query")]
                public String query { get; set; }
            }
        }
    }
}
