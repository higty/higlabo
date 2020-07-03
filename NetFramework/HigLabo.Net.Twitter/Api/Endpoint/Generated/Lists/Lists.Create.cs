using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Lists
    {
        public partial class Create
        {
            public class Command : TwitterCommand
            {
                public String name { get; set; }
                public String mode { get; set; }
                public String description { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/lists/create.json";
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
                [JsonProperty("slug")]
                public String slug { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("full_name")]
                public String full_name { get; set; }
                [JsonProperty("description")]
                public String description { get; set; }
                [JsonProperty("mode")]
                public String mode { get; set; }
                [JsonProperty("following")]
                public Boolean? following { get; set; }
                [JsonProperty("user")]
                public User user { get; set; }
                [JsonProperty("member_count")]
                public Int64? member_count { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("subscriber_count")]
                public Int64? subscriber_count { get; set; }
                [JsonProperty("id")]
                public Int64? id { get; set; }
                [JsonProperty("uri")]
                public String uri { get; set; }

                public class User
                {
                    [JsonProperty("geo_enabled")]
                    public Boolean? geo_enabled { get; set; }
                    [JsonProperty("profile_background_image_url_https")]
                    public String profile_background_image_url_https { get; set; }
                    [JsonProperty("profile_background_color")]
                    public String profile_background_color { get; set; }
                    [JsonProperty("protected")]
                    public Boolean? @protected { get; set; }
                    [JsonProperty("default_profile")]
                    public Boolean? default_profile { get; set; }
                    [JsonProperty("listed_count")]
                    public Int64? listed_count { get; set; }
                    [JsonProperty("profile_background_tile")]
                    public Boolean? profile_background_tile { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("friends_count")]
                    public Int64? friends_count { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("profile_sidebar_fill_color")]
                    public String profile_sidebar_fill_color { get; set; }
                    [JsonProperty("notifications")]
                    public Boolean? notifications { get; set; }
                    [JsonProperty("utc_offset")]
                    public Int64? utc_offset { get; set; }
                    [JsonProperty("profile_image_url_https")]
                    public String profile_image_url_https { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("display_url")]
                    public String display_url { get; set; }
                    [JsonProperty("following")]
                    public Boolean? following { get; set; }
                    [JsonProperty("verified")]
                    public Boolean? verified { get; set; }
                    [JsonProperty("favourites_count")]
                    public Int64? favourites_count { get; set; }
                    [JsonProperty("profile_sidebar_border_color")]
                    public String profile_sidebar_border_color { get; set; }
                    [JsonProperty("followers_count")]
                    public Int64? followers_count { get; set; }
                    [JsonProperty("profile_image_url")]
                    public String profile_image_url { get; set; }
                    [JsonProperty("default_profile_image")]
                    public Boolean? default_profile_image { get; set; }
                    [JsonProperty("contributors_enabled")]
                    public Boolean? contributors_enabled { get; set; }
                    [JsonProperty("deactivated_bit")]
                    public Boolean? deactivated_bit { get; set; }
                    [JsonProperty("statuses_count")]
                    public Int64? statuses_count { get; set; }
                    [JsonProperty("profile_use_background_image")]
                    public Boolean? profile_use_background_image { get; set; }
                    [JsonProperty("location")]
                    public String location { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("show_all_inline_media")]
                    public Boolean? show_all_inline_media { get; set; }
                    [JsonProperty("profile_text_color")]
                    public String profile_text_color { get; set; }
                    [JsonProperty("screen_name")]
                    public String screen_name { get; set; }
                    [JsonProperty("follow_request_sent")]
                    public Boolean? follow_request_sent { get; set; }
                    [JsonProperty("profile_background_image_url")]
                    public String profile_background_image_url { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("expanded_url")]
                    public String expanded_url { get; set; }
                    [JsonProperty("is_translator")]
                    public Boolean? is_translator { get; set; }
                    [JsonProperty("time_zone")]
                    public String time_zone { get; set; }
                    [JsonProperty("profile_link_color")]
                    public String profile_link_color { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("entities")]
                    public Entity entities { get; set; }
                    [JsonProperty("suspended")]
                    public Boolean? suspended { get; set; }
                    [JsonProperty("lang")]
                    public String lang { get; set; }

                    public class Entity
                    {
                        [JsonProperty("urls")]
                        public Object[] urls { get; set; }
                        [JsonProperty("user_mentions")]
                        public Object[] user_mentions { get; set; }
                        [JsonProperty("hashtags")]
                        public Object[] hashtags { get; set; }
                    }
                }
            }
        }
    }
}
