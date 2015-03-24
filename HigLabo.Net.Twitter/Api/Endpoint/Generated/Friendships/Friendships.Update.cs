using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Friendships
    {
        public partial class Update
        {
            public class Command : TwitterCommand
            {
                public String screen_name { get; set; }
                public Int64? user_id { get; set; }
                public String device { get; set; }
                public String retweets { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/friendships/update.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("relationship")]
                public Relationship relationship { get; set; }

                public class Relationship
                {
                    [JsonProperty("target")]
                    public Target target { get; set; }
                    [JsonProperty("source")]
                    public Source source { get; set; }

                    public class Target
                    {
                        [JsonProperty("id_str")]
                        public String id_str { get; set; }
                        [JsonProperty("id")]
                        public Int64? id { get; set; }
                        [JsonProperty("followed_by")]
                        public Boolean? followed_by { get; set; }
                        [JsonProperty("screen_name")]
                        public String screen_name { get; set; }
                        [JsonProperty("following")]
                        public Boolean? following { get; set; }
                    }
                    public class Source
                    {
                        [JsonProperty("can_dm")]
                        public Boolean? can_dm { get; set; }
                        [JsonProperty("blocking")]
                        public Boolean? blocking { get; set; }
                        [JsonProperty("id_str")]
                        public String id_str { get; set; }
                        [JsonProperty("all_replies")]
                        public Boolean? all_replies { get; set; }
                        [JsonProperty("want_retweets")]
                        public Boolean? want_retweets { get; set; }
                        [JsonProperty("id")]
                        public Int64? id { get; set; }
                        [JsonProperty("marked_spam")]
                        public Boolean? marked_spam { get; set; }
                        [JsonProperty("followed_by")]
                        public Boolean? followed_by { get; set; }
                        [JsonProperty("notifications_enabled")]
                        public Boolean? notifications_enabled { get; set; }
                        [JsonProperty("screen_name")]
                        public String screen_name { get; set; }
                        [JsonProperty("following")]
                        public Boolean? following { get; set; }
                    }
                }
            }
        }
    }
}
