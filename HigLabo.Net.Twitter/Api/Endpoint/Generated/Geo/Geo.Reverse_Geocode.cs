using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Geo
    {
        public partial class Reverse_Geocode
        {
            public class Command : TwitterCommand
            {
                public String lat { get; set; }
                public String @long { get; set; }
                public String accuracy { get; set; }
                public String granularity { get; set; }
                public String max_results { get; set; }
                public String callback { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/geo/reverse_geocode.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("query")]
                public Query query { get; set; }
                [JsonProperty("result")]
                public Class_Result result { get; set; }

                public class Query
                {
                    [JsonProperty("params")]
                    public Param @params { get; set; }
                    [JsonProperty("type")]
                    public String type { get; set; }
                    [JsonProperty("url")]
                    public String url { get; set; }

                    public class Param
                    {
                        [JsonProperty("accuracy")]
                        public Int64? accuracy { get; set; }
                        [JsonProperty("coordinates")]
                        public Coordinate coordinates { get; set; }
                        [JsonProperty("granularity")]
                        public String granularity { get; set; }

                        public class Coordinate
                        {
                            [JsonProperty("coordinates")]
                            public Double?[] coordinates { get; set; }
                            [JsonProperty("type")]
                            public String type { get; set; }
                        }
                    }
                }
                public class Class_Result
                {
                    [JsonProperty("places")]
                    public Place[] places { get; set; }

                    public class Place
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
                    }
                }
            }
        }
    }
}
