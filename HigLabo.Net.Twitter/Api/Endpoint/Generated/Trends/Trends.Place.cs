using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Trends
    {
        public partial class Place
        {
            public class Command : TwitterCommand
            {
                public String id { get; set; }
                public String exclude { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/trends/place.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("as_of")]
                public DateTime? as_of { get; set; }
                [JsonProperty("created_at")]
                public DateTime? created_at { get; set; }
                [JsonProperty("locations")]
                public Location[] locations { get; set; }
                [JsonProperty("trends")]
                public Trend[] trends { get; set; }

                public class Location
                {
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("woeid")]
                    public Int64? woeid { get; set; }
                }
                public class Trend
                {
                    [JsonProperty("events")]
                    public String events { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("promoted_content")]
                    public String promoted_content { get; set; }
                    [JsonProperty("query")]
                    public String query { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                }
            }
        }
    }
}
