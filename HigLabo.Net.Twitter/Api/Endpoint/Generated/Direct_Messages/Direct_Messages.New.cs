using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Direct_Messages
    {
        public partial class New
        {
            public class Command : TwitterCommand
            {
                public Int64? user_id { get; set; }
                public String screen_name { get; set; }
                public String text { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/direct_messages/new.json";
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
                [JsonProperty("entities")]
                public Entity entities { get; set; }
                [JsonProperty("id")]
                public Int64? id { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("recipient")]
                public Recipient recipient { get; set; }
                [JsonProperty("recipient_id")]
                public Int64? recipient_id { get; set; }
                [JsonProperty("recipient_screen_name")]
                public String recipient_screen_name { get; set; }
                [JsonProperty("sender")]
                public Sender sender { get; set; }
                [JsonProperty("sender_id")]
                public Int64? sender_id { get; set; }
                [JsonProperty("sender_screen_name")]
                public String sender_screen_name { get; set; }
                [JsonProperty("text")]
                public String text { get; set; }

                public class Entity
                {
                    [JsonProperty("hashtags")]
                    public Object[] hashtags { get; set; }
                    [JsonProperty("urls")]
                    public Object[] urls { get; set; }
                    [JsonProperty("user_mentions")]
                    public Object[] user_mentions { get; set; }
                }
                public class Recipient
                {
                    [JsonProperty("contributors_enabled")]
                    public Boolean? contributors_enabled { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("default_profile")]
                    public Boolean? default_profile { get; set; }
                    [JsonProperty("default_profile_image")]
                    public Boolean? default_profile_image { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("favourites_count")]
                    public Int64? favourites_count { get; set; }
                    [JsonProperty("follow_request_sent")]
                    public Boolean? follow_request_sent { get; set; }
                    [JsonProperty("followers_count")]
                    public Int64? followers_count { get; set; }
                    [JsonProperty("following")]
                    public Boolean? following { get; set; }
                    [JsonProperty("friends_count")]
                    public Int64? friends_count { get; set; }
                    [JsonProperty("geo_enabled")]
                    public Boolean? geo_enabled { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("is_translator")]
                    public Boolean? is_translator { get; set; }
                    [JsonProperty("lang")]
                    public String lang { get; set; }
                    [JsonProperty("listed_count")]
                    public Int64? listed_count { get; set; }
                    [JsonProperty("location")]
                    public String location { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("notifications")]
                    public Boolean? notifications { get; set; }
                    [JsonProperty("profile_background_color")]
                    public String profile_background_color { get; set; }
                    [JsonProperty("profile_background_image_url")]
                    public String profile_background_image_url { get; set; }
                    [JsonProperty("profile_background_image_url_https")]
                    public String profile_background_image_url_https { get; set; }
                    [JsonProperty("profile_background_tile")]
                    public Boolean? profile_background_tile { get; set; }
                    [JsonProperty("profile_image_url")]
                    public String profile_image_url { get; set; }
                    [JsonProperty("profile_image_url_https")]
                    public String profile_image_url_https { get; set; }
                    [JsonProperty("profile_link_color")]
                    public String profile_link_color { get; set; }
                    [JsonProperty("profile_sidebar_border_color")]
                    public String profile_sidebar_border_color { get; set; }
                    [JsonProperty("profile_sidebar_fill_color")]
                    public String profile_sidebar_fill_color { get; set; }
                    [JsonProperty("profile_text_color")]
                    public String profile_text_color { get; set; }
                    [JsonProperty("profile_use_background_image")]
                    public Boolean? profile_use_background_image { get; set; }
                    [JsonProperty("protected")]
                    public Boolean? @protected { get; set; }
                    [JsonProperty("screen_name")]
                    public String screen_name { get; set; }
                    [JsonProperty("show_all_inline_media")]
                    public Boolean? show_all_inline_media { get; set; }
                    [JsonProperty("statuses_count")]
                    public Int64? statuses_count { get; set; }
                    [JsonProperty("time_zone")]
                    public String time_zone { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("utc_offset")]
                    public Int64? utc_offset { get; set; }
                    [JsonProperty("verified")]
                    public Boolean? verified { get; set; }
                }
                public class Sender
                {
                    [JsonProperty("contributors_enabled")]
                    public Boolean? contributors_enabled { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("default_profile")]
                    public Boolean? default_profile { get; set; }
                    [JsonProperty("default_profile_image")]
                    public Boolean? default_profile_image { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("favourites_count")]
                    public Int64? favourites_count { get; set; }
                    [JsonProperty("follow_request_sent")]
                    public Boolean? follow_request_sent { get; set; }
                    [JsonProperty("followers_count")]
                    public Int64? followers_count { get; set; }
                    [JsonProperty("following")]
                    public Boolean? following { get; set; }
                    [JsonProperty("friends_count")]
                    public Int64? friends_count { get; set; }
                    [JsonProperty("geo_enabled")]
                    public Boolean? geo_enabled { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("is_translator")]
                    public Boolean? is_translator { get; set; }
                    [JsonProperty("lang")]
                    public String lang { get; set; }
                    [JsonProperty("listed_count")]
                    public Int64? listed_count { get; set; }
                    [JsonProperty("location")]
                    public String location { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("notifications")]
                    public Boolean? notifications { get; set; }
                    [JsonProperty("profile_background_color")]
                    public String profile_background_color { get; set; }
                    [JsonProperty("profile_background_image_url")]
                    public String profile_background_image_url { get; set; }
                    [JsonProperty("profile_background_image_url_https")]
                    public String profile_background_image_url_https { get; set; }
                    [JsonProperty("profile_background_tile")]
                    public Boolean? profile_background_tile { get; set; }
                    [JsonProperty("profile_image_url")]
                    public String profile_image_url { get; set; }
                    [JsonProperty("profile_image_url_https")]
                    public String profile_image_url_https { get; set; }
                    [JsonProperty("profile_link_color")]
                    public String profile_link_color { get; set; }
                    [JsonProperty("profile_sidebar_border_color")]
                    public String profile_sidebar_border_color { get; set; }
                    [JsonProperty("profile_sidebar_fill_color")]
                    public String profile_sidebar_fill_color { get; set; }
                    [JsonProperty("profile_text_color")]
                    public String profile_text_color { get; set; }
                    [JsonProperty("profile_use_background_image")]
                    public Boolean? profile_use_background_image { get; set; }
                    [JsonProperty("protected")]
                    public Boolean? @protected { get; set; }
                    [JsonProperty("screen_name")]
                    public String screen_name { get; set; }
                    [JsonProperty("show_all_inline_media")]
                    public Boolean? show_all_inline_media { get; set; }
                    [JsonProperty("statuses_count")]
                    public Int64? statuses_count { get; set; }
                    [JsonProperty("time_zone")]
                    public String time_zone { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("utc_offset")]
                    public Int64? utc_offset { get; set; }
                    [JsonProperty("verified")]
                    public Boolean? verified { get; set; }
                }
            }
        }
    }
}
