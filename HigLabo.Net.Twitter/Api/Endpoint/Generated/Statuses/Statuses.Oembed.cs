using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Statuses
    {
        public partial class Oembed
        {
            public class Command : TwitterCommand
            {
                public String id { get; set; }
                public String url { get; set; }
                public String maxwidth { get; set; }
                public Boolean? hide_media { get; set; }
                public Boolean? hide_thread { get; set; }
                public Boolean? omit_script { get; set; }
                public String align { get; set; }
                public String related { get; set; }
                public String lang { get; set; }
                public String widget_type { get; set; }
                public String hide_tweet { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/statuses/oembed.{format}";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("cache_age")]
                public String cache_age { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }
                [JsonProperty("provider_url")]
                public String provider_url { get; set; }
                [JsonProperty("provider_name")]
                public String provider_name { get; set; }
                [JsonProperty("author_name")]
                public String author_name { get; set; }
                [JsonProperty("version")]
                public String version { get; set; }
                [JsonProperty("author_url")]
                public String author_url { get; set; }
                [JsonProperty("type")]
                public String type { get; set; }
                [JsonProperty("html")]
                public String html { get; set; }
                [JsonProperty("height")]
                public String height { get; set; }
                [JsonProperty("width")]
                public Int64? width { get; set; }
            }
        }
    }
}
