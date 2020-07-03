using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Statuses
    {
        public partial class Retweet
        {
            public class Command : TwitterCommand
            {
                public String id { get; set; }
                public Boolean? trim_user { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return String.Format("https://api.twitter.com/1.1/statuses/retweet/{0}.json", this.id);
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("truncated")]
                public Boolean? truncated { get; set; }
                [JsonProperty("retweeted")]
                public Boolean? retweeted { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("coordinates")]
                public String coordinates { get; set; }
                [JsonProperty("in_reply_to_screen_name")]
                public String in_reply_to_screen_name { get; set; }
                [JsonProperty("in_reply_to_status_id_str")]
                public String in_reply_to_status_id_str { get; set; }
                [JsonProperty("geo")]
                public String geo { get; set; }
                [JsonProperty("in_reply_to_status_id")]
                public String in_reply_to_status_id { get; set; }
                [JsonProperty("contributors")]
                public String contributors { get; set; }
                [JsonProperty("source")]
                public String source { get; set; }
                [JsonProperty("in_reply_to_user_id_str")]
                public String in_reply_to_user_id_str { get; set; }
                [JsonProperty("created_at")]
                public String created_at { get; set; }
                [JsonProperty("favorited")]
                public Boolean? favorited { get; set; }
                [JsonProperty("entities")]
                public Entity entities { get; set; }
                [JsonProperty("user")]
                public User user { get; set; }
                [JsonProperty("place")]
                public String place { get; set; }
                [JsonProperty("id")]
                public Int64? id { get; set; }
                [JsonProperty("retweeted_status")]
                public Retweeted_Statu retweeted_status { get; set; }
                [JsonProperty("retweet_count")]
                public Int64? retweet_count { get; set; }
                [JsonProperty("in_reply_to_user_id")]
                public String in_reply_to_user_id { get; set; }
                [JsonProperty("text")]
                public String text { get; set; }

                public class Entity
                {
                    [JsonProperty("user_mentions")]
                    public User_Mention[] user_mentions { get; set; }
                    [JsonProperty("hashtags")]
                    public Object[] hashtags { get; set; }
                    [JsonProperty("urls")]
                    public Object[] urls { get; set; }

                    public class User_Mention
                    {
                        [JsonProperty("indices")]
                        public Int64?[] indices { get; set; }
                        [JsonProperty("id_str")]
                        public String id_str { get; set; }
                        [JsonProperty("screen_name")]
                        public String screen_name { get; set; }
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("id")]
                        public Int64? id { get; set; }
                    }
                }
                public class User
                {
                    [JsonProperty("following")]
                    public Boolean? following { get; set; }
                    [JsonProperty("geo_enabled")]
                    public Boolean? geo_enabled { get; set; }
                    [JsonProperty("profile_background_image_url")]
                    public String profile_background_image_url { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("notifications")]
                    public Boolean? notifications { get; set; }
                    [JsonProperty("friends_count")]
                    public Int64? friends_count { get; set; }
                    [JsonProperty("profile_link_color")]
                    public String profile_link_color { get; set; }
                    [JsonProperty("location")]
                    public String location { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("default_profile_image")]
                    public Boolean? default_profile_image { get; set; }
                    [JsonProperty("profile_image_url_https")]
                    public String profile_image_url_https { get; set; }
                    [JsonProperty("favourites_count")]
                    public Int64? favourites_count { get; set; }
                    [JsonProperty("profile_background_color")]
                    public String profile_background_color { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("screen_name")]
                    public String screen_name { get; set; }
                    [JsonProperty("profile_background_tile")]
                    public Boolean? profile_background_tile { get; set; }
                    [JsonProperty("contributors_enabled")]
                    public Boolean? contributors_enabled { get; set; }
                    [JsonProperty("verified")]
                    public Boolean? verified { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("profile_sidebar_fill_color")]
                    public String profile_sidebar_fill_color { get; set; }
                    [JsonProperty("followers_count")]
                    public Int64? followers_count { get; set; }
                    [JsonProperty("lang")]
                    public String lang { get; set; }
                    [JsonProperty("listed_count")]
                    public Int64? listed_count { get; set; }
                    [JsonProperty("profile_sidebar_border_color")]
                    public String profile_sidebar_border_color { get; set; }
                    [JsonProperty("protected")]
                    public Boolean? @protected { get; set; }
                    [JsonProperty("entities")]
                    public Entity entities { get; set; }
                    [JsonProperty("show_all_inline_media")]
                    public Boolean? show_all_inline_media { get; set; }
                    [JsonProperty("follow_request_sent")]
                    public Boolean? follow_request_sent { get; set; }
                    [JsonProperty("statuses_count")]
                    public Int64? statuses_count { get; set; }
                    [JsonProperty("profile_background_image_url_https")]
                    public String profile_background_image_url_https { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("default_profile")]
                    public Boolean? default_profile { get; set; }
                    [JsonProperty("profile_use_background_image")]
                    public Boolean? profile_use_background_image { get; set; }
                    [JsonProperty("profile_image_url")]
                    public String profile_image_url { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("is_translator")]
                    public Boolean? is_translator { get; set; }
                    [JsonProperty("time_zone")]
                    public String time_zone { get; set; }
                    [JsonProperty("utc_offset")]
                    public Int64? utc_offset { get; set; }
                    [JsonProperty("profile_text_color")]
                    public String profile_text_color { get; set; }

                    public class Entity
                    {
                        [JsonProperty("description")]
                        public Description description { get; set; }
                        [JsonProperty("url")]
                        public Url url { get; set; }

                        public class Description
                        {
                            [JsonProperty("urls")]
                            public Object[] urls { get; set; }
                        }
                        public class Url
                        {
                            [JsonProperty("urls")]
                            public Class_Url[] urls { get; set; }

                            public class Class_Url
                            {
                                [JsonProperty("indices")]
                                public Int64?[] indices { get; set; }
                                [JsonProperty("url")]
                                public String url { get; set; }
                                [JsonProperty("display_url")]
                                public String display_url { get; set; }
                                [JsonProperty("expanded_url")]
                                public String expanded_url { get; set; }
                            }
                        }
                    }
                }
                public class Retweeted_Statu
                {
                    [JsonProperty("truncated")]
                    public Boolean? truncated { get; set; }
                    [JsonProperty("retweeted")]
                    public Boolean? retweeted { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("coordinates")]
                    public String coordinates { get; set; }
                    [JsonProperty("in_reply_to_screen_name")]
                    public String in_reply_to_screen_name { get; set; }
                    [JsonProperty("in_reply_to_status_id_str")]
                    public String in_reply_to_status_id_str { get; set; }
                    [JsonProperty("geo")]
                    public String geo { get; set; }
                    [JsonProperty("in_reply_to_status_id")]
                    public String in_reply_to_status_id { get; set; }
                    [JsonProperty("contributors")]
                    public String contributors { get; set; }
                    [JsonProperty("source")]
                    public String source { get; set; }
                    [JsonProperty("in_reply_to_user_id_str")]
                    public String in_reply_to_user_id_str { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("favorited")]
                    public Boolean? favorited { get; set; }
                    [JsonProperty("entities")]
                    public Entity entities { get; set; }
                    [JsonProperty("user")]
                    public User user { get; set; }
                    [JsonProperty("place")]
                    public String place { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("retweet_count")]
                    public Int64? retweet_count { get; set; }
                    [JsonProperty("in_reply_to_user_id")]
                    public String in_reply_to_user_id { get; set; }
                    [JsonProperty("text")]
                    public String text { get; set; }

                    public class Entity
                    {
                        [JsonProperty("user_mentions")]
                        public Object[] user_mentions { get; set; }
                        [JsonProperty("hashtags")]
                        public Object[] hashtags { get; set; }
                        [JsonProperty("urls")]
                        public Object[] urls { get; set; }
                    }
                    public class User
                    {
                        [JsonProperty("following")]
                        public Boolean? following { get; set; }
                        [JsonProperty("geo_enabled")]
                        public Boolean? geo_enabled { get; set; }
                        [JsonProperty("profile_background_image_url")]
                        public String profile_background_image_url { get; set; }
                        [JsonProperty("description")]
                        public String description { get; set; }
                        [JsonProperty("notifications")]
                        public Boolean? notifications { get; set; }
                        [JsonProperty("friends_count")]
                        public Int64? friends_count { get; set; }
                        [JsonProperty("profile_link_color")]
                        public String profile_link_color { get; set; }
                        [JsonProperty("location")]
                        public String location { get; set; }
                        [JsonProperty("id_str")]
                        public String id_str { get; set; }
                        [JsonProperty("default_profile_image")]
                        public Boolean? default_profile_image { get; set; }
                        [JsonProperty("profile_image_url_https")]
                        public String profile_image_url_https { get; set; }
                        [JsonProperty("favourites_count")]
                        public Int64? favourites_count { get; set; }
                        [JsonProperty("profile_background_color")]
                        public String profile_background_color { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                        [JsonProperty("screen_name")]
                        public String screen_name { get; set; }
                        [JsonProperty("profile_background_tile")]
                        public Boolean? profile_background_tile { get; set; }
                        [JsonProperty("contributors_enabled")]
                        public Boolean? contributors_enabled { get; set; }
                        [JsonProperty("verified")]
                        public Boolean? verified { get; set; }
                        [JsonProperty("created_at")]
                        public String created_at { get; set; }
                        [JsonProperty("profile_sidebar_fill_color")]
                        public String profile_sidebar_fill_color { get; set; }
                        [JsonProperty("followers_count")]
                        public Int64? followers_count { get; set; }
                        [JsonProperty("lang")]
                        public String lang { get; set; }
                        [JsonProperty("listed_count")]
                        public Int64? listed_count { get; set; }
                        [JsonProperty("profile_sidebar_border_color")]
                        public String profile_sidebar_border_color { get; set; }
                        [JsonProperty("protected")]
                        public Boolean? @protected { get; set; }
                        [JsonProperty("entities")]
                        public Entity entities { get; set; }
                        [JsonProperty("show_all_inline_media")]
                        public Boolean? show_all_inline_media { get; set; }
                        [JsonProperty("follow_request_sent")]
                        public Boolean? follow_request_sent { get; set; }
                        [JsonProperty("statuses_count")]
                        public Int64? statuses_count { get; set; }
                        [JsonProperty("profile_background_image_url_https")]
                        public String profile_background_image_url_https { get; set; }
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("default_profile")]
                        public Boolean? default_profile { get; set; }
                        [JsonProperty("profile_use_background_image")]
                        public Boolean? profile_use_background_image { get; set; }
                        [JsonProperty("profile_image_url")]
                        public String profile_image_url { get; set; }
                        [JsonProperty("id")]
                        public Int64? id { get; set; }
                        [JsonProperty("is_translator")]
                        public Boolean? is_translator { get; set; }
                        [JsonProperty("time_zone")]
                        public String time_zone { get; set; }
                        [JsonProperty("utc_offset")]
                        public Int64? utc_offset { get; set; }
                        [JsonProperty("profile_text_color")]
                        public String profile_text_color { get; set; }

                        public class Entity
                        {
                            [JsonProperty("description")]
                            public Description description { get; set; }
                            [JsonProperty("url")]
                            public Url url { get; set; }

                            public class Description
                            {
                                [JsonProperty("urls")]
                                public Object[] urls { get; set; }
                            }
                            public class Url
                            {
                                [JsonProperty("urls")]
                                public Class_Url[] urls { get; set; }

                                public class Class_Url
                                {
                                    [JsonProperty("indices")]
                                    public Int64?[] indices { get; set; }
                                    [JsonProperty("url")]
                                    public String url { get; set; }
                                    [JsonProperty("display_url")]
                                    public String display_url { get; set; }
                                    [JsonProperty("expanded_url")]
                                    public String expanded_url { get; set; }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
