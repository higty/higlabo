using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Account
    {
        public partial class Settings_Post
        {
            public class Command : TwitterCommand
            {
                public String trend_location_woeid { get; set; }
                public Boolean? sleep_time_enabled { get; set; }
                public String start_sleep_time { get; set; }
                public String end_sleep_time { get; set; }
                public String time_zone { get; set; }
                public String lang { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/account/settings.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
            public class Result
            {
                [JsonProperty("sleep_time")]
                public Sleep_Time sleep_time { get; set; }
                [JsonProperty("use_cookie_personalization")]
                public Boolean? use_cookie_personalization { get; set; }
                [JsonProperty("trend_location")]
                public Trend_Location[] trend_location { get; set; }
                [JsonProperty("language")]
                public String language { get; set; }
                [JsonProperty("discoverable_by_email")]
                public Boolean? discoverable_by_email { get; set; }
                [JsonProperty("always_use_https")]
                public Boolean? always_use_https { get; set; }
                [JsonProperty("protected")]
                public Boolean? @protected { get; set; }
                [JsonProperty("geo_enabled")]
                public Boolean? geo_enabled { get; set; }
                [JsonProperty("show_all_inline_media")]
                public Boolean? show_all_inline_media { get; set; }
                [JsonProperty("screen_name")]
                public String screen_name { get; set; }

                public class Sleep_Time
                {
                    [JsonProperty("end_time")]
                    public String end_time { get; set; }
                    [JsonProperty("enabled")]
                    public Boolean? enabled { get; set; }
                    [JsonProperty("start_time")]
                    public String start_time { get; set; }
                }
                public class Trend_Location
                {
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("placeType")]
                    public PlaceType placeType { get; set; }
                    [JsonProperty("woeid")]
                    public Int64? woeid { get; set; }
                    [JsonProperty("country")]
                    public String country { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("countryCode")]
                    public String countryCode { get; set; }
                    [JsonProperty("parentid")]
                    public Int64? parentid { get; set; }

                    public class PlaceType
                    {
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("code")]
                        public Int64? code { get; set; }
                    }
                }
            }
        }
    }
}
