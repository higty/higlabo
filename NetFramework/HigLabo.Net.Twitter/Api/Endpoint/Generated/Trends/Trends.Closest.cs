using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Trends
    {
        public partial class Closest
        {
            public class Command : TwitterCommand
            {
                public String lat { get; set; }
                public String @long { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/trends/closest.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("country")]
                public String country { get; set; }
                [JsonProperty("countryCode")]
                public String countryCode { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("parentid")]
                public Int64? parentid { get; set; }
                [JsonProperty("placeType")]
                public PlaceType placeType { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }
                [JsonProperty("woeid")]
                public Int64? woeid { get; set; }

                public class PlaceType
                {
                    [JsonProperty("code")]
                    public Int64? code { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                }
            }
        }
    }
}
