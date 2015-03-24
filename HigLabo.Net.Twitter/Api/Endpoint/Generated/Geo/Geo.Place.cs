using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Geo
    {
        public partial class Place
        {
            public class Command : TwitterCommand
            {
                public String name { get; set; }
                public String contained_within { get; set; }
                public String token { get; set; }
                public String lat { get; set; }
                public String @long { get; set; }
                public String attribute_street_address { get; set; }
                public String callback { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/geo/place.json";
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
                [JsonProperty("polylines")]
                public Object[] polylines { get; set; }
                [JsonProperty("country")]
                public String country { get; set; }
                [JsonProperty("country_code")]
                public String country_code { get; set; }
                [JsonProperty("attributes")]
                public Attribute attributes { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }
                [JsonProperty("id")]
                public String id { get; set; }
                [JsonProperty("bounding_box")]
                public Bounding_Box bounding_box { get; set; }
                [JsonProperty("contained_within")]
                public Contained_Within[] contained_within { get; set; }
                [JsonProperty("geometry")]
                public Geometry geometry { get; set; }
                [JsonProperty("full_name")]
                public String full_name { get; set; }
                [JsonProperty("place_type")]
                public String place_type { get; set; }

                public class Attribute
                {
                }
                public class Bounding_Box
                {
                    [JsonProperty("coordinates")]
                    public Double?[][][] coordinates { get; set; }
                    [JsonProperty("type")]
                    public String type { get; set; }
                }
                public class Contained_Within
                {
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("country")]
                    public String country { get; set; }
                    [JsonProperty("country_code")]
                    public String country_code { get; set; }
                    [JsonProperty("attributes")]
                    public Attribute attributes { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }
                    [JsonProperty("id")]
                    public String id { get; set; }
                    [JsonProperty("bounding_box")]
                    public Bounding_Box bounding_box { get; set; }
                    [JsonProperty("full_name")]
                    public String full_name { get; set; }
                    [JsonProperty("place_type")]
                    public String place_type { get; set; }

                    public class Attribute
                    {
                        [JsonProperty("street_address")]
                        public String street_address { get; set; }
                    }
                    public class Bounding_Box
                    {
                        [JsonProperty("coordinates")]
                        public Double?[][][] coordinates { get; set; }
                        [JsonProperty("type")]
                        public String type { get; set; }
                    }
                }
                public class Geometry
                {
                    [JsonProperty("coordinates")]
                    public Double?[] coordinates { get; set; }
                    [JsonProperty("type")]
                    public String type { get; set; }
                }
            }
        }
    }
}
