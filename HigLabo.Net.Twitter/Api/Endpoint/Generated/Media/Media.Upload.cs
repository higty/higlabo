using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Media
    {
        public partial class Upload
        {
            public class Command : TwitterCommand
            {
                public String media { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://upload.twitter.com/1.1/media/upload.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("media_id")]
                public Int64? media_id { get; set; }
                [JsonProperty("media_id_string")]
                public String media_id_string { get; set; }
                [JsonProperty("size")]
                public Int64? size { get; set; }
                [JsonProperty("image")]
                public Image image { get; set; }

                public class Image
                {
                    [JsonProperty("w")]
                    public Int64? w { get; set; }
                    [JsonProperty("h")]
                    public Int64? h { get; set; }
                    [JsonProperty("image_type")]
                    public String image_type { get; set; }
                }
            }
        }
    }
}
