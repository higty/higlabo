using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Friendships
    {
        public partial class Create
        {
            public class Command : TwitterCommand
            {
                public String screen_name { get; set; }
                public Int64? user_id { get; set; }
                public Boolean? follow { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/friendships/create.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("profile_sidebar_border_color")]
                public String profile_sidebar_border_color { get; set; }
                [JsonProperty("profile_sidebar_fill_color")]
                public String profile_sidebar_fill_color { get; set; }
                [JsonProperty("profile_background_tile")]
                public Boolean? profile_background_tile { get; set; }
                [JsonProperty("created_at")]
                public String created_at { get; set; }
                [JsonProperty("profile_image_url")]
                public String profile_image_url { get; set; }
                [JsonProperty("location")]
                public String location { get; set; }
                [JsonProperty("profile_link_color")]
                public String profile_link_color { get; set; }
                [JsonProperty("follow_request_sent")]
                public Boolean? follow_request_sent { get; set; }
                [JsonProperty("is_translator")]
                public Boolean? is_translator { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("entities")]
                public Entity entities { get; set; }
                [JsonProperty("default_profile")]
                public Boolean? default_profile { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }
                [JsonProperty("favourites_count")]
                public Int64? favourites_count { get; set; }
                [JsonProperty("contributors_enabled")]
                public Boolean? contributors_enabled { get; set; }
                [JsonProperty("utc_offset")]
                public Int64? utc_offset { get; set; }
                [JsonProperty("id")]
                public Int64? id { get; set; }
                [JsonProperty("profile_image_url_https")]
                public String profile_image_url_https { get; set; }
                [JsonProperty("listed_count")]
                public Int64? listed_count { get; set; }
                [JsonProperty("profile_use_background_image")]
                public Boolean? profile_use_background_image { get; set; }
                [JsonProperty("profile_text_color")]
                public String profile_text_color { get; set; }
                [JsonProperty("protected")]
                public Boolean? @protected { get; set; }
                [JsonProperty("lang")]
                public String lang { get; set; }
                [JsonProperty("followers_count")]
                public Int64? followers_count { get; set; }
                [JsonProperty("geo_enabled")]
                public Boolean? geo_enabled { get; set; }
                [JsonProperty("time_zone")]
                public String time_zone { get; set; }
                [JsonProperty("notifications")]
                public Boolean? notifications { get; set; }
                [JsonProperty("verified")]
                public Boolean? verified { get; set; }
                [JsonProperty("profile_background_image_url_https")]
                public String profile_background_image_url_https { get; set; }
                [JsonProperty("profile_background_color")]
                public String profile_background_color { get; set; }
                [JsonProperty("description")]
                public String description { get; set; }
                [JsonProperty("profile_background_image_url")]
                public String profile_background_image_url { get; set; }
                [JsonProperty("friends_count")]
                public Int64? friends_count { get; set; }
                [JsonProperty("statuses_count")]
                public Int64? statuses_count { get; set; }
                [JsonProperty("default_profile_image")]
                public Boolean? default_profile_image { get; set; }
                [JsonProperty("status")]
                public Statu status { get; set; }
                [JsonProperty("show_all_inline_media")]
                public Boolean? show_all_inline_media { get; set; }
                [JsonProperty("screen_name")]
                public String screen_name { get; set; }
                [JsonProperty("following")]
                public Boolean? following { get; set; }

                public class Entity
                {
                    [JsonProperty("description")]
                    public Description description { get; set; }

                    public class Description
                    {
                        [JsonProperty("urls")]
                        public Object[] urls { get; set; }
                    }
                }
                public class Statu
                {
                    [JsonProperty("coordinates")]
                    public String coordinates { get; set; }
                    [JsonProperty("truncated")]
                    public Boolean? truncated { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("favorited")]
                    public Boolean? favorited { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("entities")]
                    public Entity entities { get; set; }
                    [JsonProperty("in_reply_to_user_id_str")]
                    public String in_reply_to_user_id_str { get; set; }
                    [JsonProperty("text")]
                    public String text { get; set; }
                    [JsonProperty("contributors")]
                    public String contributors { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("retweet_count")]
                    public Int64? retweet_count { get; set; }
                    [JsonProperty("in_reply_to_status_id_str")]
                    public String in_reply_to_status_id_str { get; set; }
                    [JsonProperty("geo")]
                    public String geo { get; set; }
                    [JsonProperty("retweeted")]
                    public Boolean? retweeted { get; set; }
                    [JsonProperty("in_reply_to_user_id")]
                    public String in_reply_to_user_id { get; set; }
                    [JsonProperty("possibly_sensitive")]
                    public Boolean? possibly_sensitive { get; set; }
                    [JsonProperty("place")]
                    public String place { get; set; }
                    [JsonProperty("possibly_sensitive_editable")]
                    public Boolean? possibly_sensitive_editable { get; set; }
                    [JsonProperty("source")]
                    public String source { get; set; }
                    [JsonProperty("in_reply_to_screen_name")]
                    public String in_reply_to_screen_name { get; set; }
                    [JsonProperty("in_reply_to_status_id")]
                    public String in_reply_to_status_id { get; set; }

                    public class Entity
                    {
                        [JsonProperty("urls")]
                        public Object[] urls { get; set; }
                        [JsonProperty("media")]
                        public Media[] media { get; set; }
                        [JsonProperty("hashtags")]
                        public Object[] hashtags { get; set; }
                        [JsonProperty("user_mentions")]
                        public Object[] user_mentions { get; set; }

                        public class Media
                        {
                            [JsonProperty("media_url_https")]
                            public String media_url_https { get; set; }
                            [JsonProperty("expanded_url")]
                            public String expanded_url { get; set; }
                            [JsonProperty("sizes")]
                            public Size sizes { get; set; }
                            [JsonProperty("id_str")]
                            public String id_str { get; set; }
                            [JsonProperty("url")]
                            public String url { get; set; }
                            [JsonProperty("id")]
                            public Int64? id { get; set; }
                            [JsonProperty("type")]
                            public String type { get; set; }
                            [JsonProperty("indices")]
                            public Int64?[] indices { get; set; }
                            [JsonProperty("media_url")]
                            public String media_url { get; set; }
                            [JsonProperty("display_url")]
                            public String display_url { get; set; }

                            public class Size
                            {
                                [JsonProperty("large")]
                                public Large large { get; set; }
                                [JsonProperty("medium")]
                                public Medium medium { get; set; }
                                [JsonProperty("small")]
                                public Small small { get; set; }
                                [JsonProperty("thumb")]
                                public Thumb thumb { get; set; }

                                public class Large
                                {
                                    [JsonProperty("w")]
                                    public Int64? w { get; set; }
                                    [JsonProperty("resize")]
                                    public String resize { get; set; }
                                    [JsonProperty("h")]
                                    public Int64? h { get; set; }
                                }
                                public class Medium
                                {
                                    [JsonProperty("w")]
                                    public Int64? w { get; set; }
                                    [JsonProperty("resize")]
                                    public String resize { get; set; }
                                    [JsonProperty("h")]
                                    public Int64? h { get; set; }
                                }
                                public class Small
                                {
                                    [JsonProperty("w")]
                                    public Int64? w { get; set; }
                                    [JsonProperty("resize")]
                                    public String resize { get; set; }
                                    [JsonProperty("h")]
                                    public Int64? h { get; set; }
                                }
                                public class Thumb
                                {
                                    [JsonProperty("w")]
                                    public Int64? w { get; set; }
                                    [JsonProperty("resize")]
                                    public String resize { get; set; }
                                    [JsonProperty("h")]
                                    public Int64? h { get; set; }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
