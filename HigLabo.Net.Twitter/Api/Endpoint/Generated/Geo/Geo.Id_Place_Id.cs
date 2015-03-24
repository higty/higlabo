using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Geo
    {
        public partial class Id_Place_Id
        {
            public class Command : TwitterCommand
            {
                public String place_id { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/geo/id/:place_id.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("attributes")]
                public Attribute attributes { get; set; }
                [JsonProperty("bounding_box")]
                public Bounding_Box bounding_box { get; set; }
                [JsonProperty("contained_within")]
                public Contained_Within[] contained_within { get; set; }
                [JsonProperty("country")]
                public String country { get; set; }
                [JsonProperty("country_code")]
                public String country_code { get; set; }
                [JsonProperty("full_name")]
                public String full_name { get; set; }
                [JsonProperty("geometry")]
                public Geometry geometry { get; set; }
                [JsonProperty("id")]
                public String id { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("place_type")]
                public String place_type { get; set; }
                [JsonProperty("polylines")]
                public String[] polylines { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }

                public class Attribute
                {
                    [JsonProperty("162834:id")]
                    public String _162834_id { get; set; }
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
                    [JsonProperty("attributes")]
                    public Attribute attributes { get; set; }
                    [JsonProperty("bounding_box")]
                    public Bounding_Box bounding_box { get; set; }
                    [JsonProperty("country")]
                    public String country { get; set; }
                    [JsonProperty("country_code")]
                    public String country_code { get; set; }
                    [JsonProperty("full_name")]
                    public String full_name { get; set; }
                    [JsonProperty("id")]
                    public String id { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("place_type")]
                    public String place_type { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }

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
                }
                public class Geometry
                {
                    [JsonProperty("coordinates")]
                    public Double?[][][] coordinates { get; set; }
                    [JsonProperty("type")]
                    public String type { get; set; }
                }
            }
        }
    }
}
