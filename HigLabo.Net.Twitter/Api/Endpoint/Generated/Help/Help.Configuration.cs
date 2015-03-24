using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Help
    {
        public partial class Configuration
        {
            public class Command : TwitterCommand
            {
                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/help/configuration.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("characters_reserved_per_media")]
                public Int64? characters_reserved_per_media { get; set; }
                [JsonProperty("max_media_per_upload")]
                public Int64? max_media_per_upload { get; set; }
                [JsonProperty("non_username_paths")]
                public String[] non_username_paths { get; set; }
                [JsonProperty("photo_size_limit")]
                public Int64? photo_size_limit { get; set; }
                [JsonProperty("photo_sizes")]
                public Photo_Size photo_sizes { get; set; }
                [JsonProperty("short_url_length")]
                public Int64? short_url_length { get; set; }
                [JsonProperty("short_url_length_https")]
                public Int64? short_url_length_https { get; set; }

                public class Photo_Size
                {
                    [JsonProperty("thumb")]
                    public Thumb thumb { get; set; }
                    [JsonProperty("small")]
                    public Small small { get; set; }
                    [JsonProperty("medium")]
                    public Medium medium { get; set; }
                    [JsonProperty("large")]
                    public Large large { get; set; }

                    public class Thumb
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("resize")]
                        public String resize { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                    }
                    public class Small
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("resize")]
                        public String resize { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                    }
                    public class Medium
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("resize")]
                        public String resize { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                    }
                    public class Large
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("resize")]
                        public String resize { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                    }
                }
            }
        }
    }
}
