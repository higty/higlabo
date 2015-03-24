using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Friends
    {
        public partial class List
        {
            public class Command : TwitterCommand
            {
                public Int64? user_id { get; set; }
                public String screen_name { get; set; }
                public String cursor { get; set; }
                public Int32? count { get; set; }
                public Boolean? skip_status { get; set; }
                public Boolean? include_user_entities { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/friends/list.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("previous_cursor")]
                public Int64? previous_cursor { get; set; }
                [JsonProperty("previous_cursor_str")]
                public String previous_cursor_str { get; set; }
                [JsonProperty("next_cursor")]
                public Int64? next_cursor { get; set; }
                [JsonProperty("users")]
                public User[] users { get; set; }
                [JsonProperty("next_cursor_str")]
                public String next_cursor_str { get; set; }

                public class User
                {
                    [JsonProperty("profile_sidebar_fill_color")]
                    public String profile_sidebar_fill_color { get; set; }
                    [JsonProperty("profile_sidebar_border_color")]
                    public String profile_sidebar_border_color { get; set; }
                    [JsonProperty("profile_background_tile")]
                    public Boolean? profile_background_tile { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("profile_image_url")]
                    public String profile_image_url { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("location")]
                    public String location { get; set; }
                    [JsonProperty("follow_request_sent")]
                    public Boolean? follow_request_sent { get; set; }
                    [JsonProperty("profile_link_color")]
                    public String profile_link_color { get; set; }
                    [JsonProperty("is_translator")]
                    public Boolean? is_translator { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("default_profile")]
                    public Boolean? default_profile { get; set; }
                    [JsonProperty("contributors_enabled")]
                    public Boolean? contributors_enabled { get; set; }
                    [JsonProperty("favourites_count")]
                    public Int64? favourites_count { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("profile_banner_url")]
                    public String profile_banner_url { get; set; }
                    [JsonProperty("profile_image_url_https")]
                    public String profile_image_url_https { get; set; }
                    [JsonProperty("utc_offset")]
                    public Int64? utc_offset { get; set; }
                    [JsonProperty("id")]
                    public Int64? id { get; set; }
                    [JsonProperty("profile_use_background_image")]
                    public Boolean? profile_use_background_image { get; set; }
                    [JsonProperty("listed_count")]
                    public Int64? listed_count { get; set; }
                    [JsonProperty("profile_text_color")]
                    public String profile_text_color { get; set; }
                    [JsonProperty("lang")]
                    public String lang { get; set; }
                    [JsonProperty("followers_count")]
                    public Int64? followers_count { get; set; }
                    [JsonProperty("protected")]
                    public Boolean? @protected { get; set; }
                    [JsonProperty("notifications")]
                    public Boolean? notifications { get; set; }
                    [JsonProperty("profile_background_image_url_https")]
                    public String profile_background_image_url_https { get; set; }
                    [JsonProperty("profile_background_color")]
                    public String profile_background_color { get; set; }
                    [JsonProperty("verified")]
                    public Boolean? verified { get; set; }
                    [JsonProperty("geo_enabled")]
                    public Boolean? geo_enabled { get; set; }
                    [JsonProperty("time_zone")]
                    public String time_zone { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("default_profile_image")]
                    public Boolean? default_profile_image { get; set; }
                    [JsonProperty("profile_background_image_url")]
                    public String profile_background_image_url { get; set; }
                    [JsonProperty("statuses_count")]
                    public Int64? statuses_count { get; set; }
                    [JsonProperty("friends_count")]
                    public Int64? friends_count { get; set; }
                    [JsonProperty("following")]
                    public Boolean? following { get; set; }
                    [JsonProperty("screen_name")]
                    public String screen_name { get; set; }
                }
            }
        }
    }
}
