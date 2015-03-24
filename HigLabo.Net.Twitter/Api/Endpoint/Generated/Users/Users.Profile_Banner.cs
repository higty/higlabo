using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Users
    {
        public partial class Profile_Banner
        {
            public class Command : TwitterCommand
            {
                public Int64? user_id { get; set; }
                public String screen_name { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/users/profile_banner.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("sizes")]
                public Size sizes { get; set; }

                public class Size
                {
                    [JsonProperty("ipad")]
                    public Ipad ipad { get; set; }
                    [JsonProperty("ipad_retina")]
                    public Ipad_Retina ipad_retina { get; set; }
                    [JsonProperty("web")]
                    public Web web { get; set; }
                    [JsonProperty("web_retina")]
                    public Web_Retina web_retina { get; set; }
                    [JsonProperty("mobile")]
                    public Mobile mobile { get; set; }
                    [JsonProperty("mobile_retina")]
                    public Mobile_Retina mobile_retina { get; set; }
                    [JsonProperty("300x100")]
                    public Class_300x100 _300x100 { get; set; }
                    [JsonProperty("600x200")]
                    public Class_600x200 _600x200 { get; set; }
                    [JsonProperty("1500x500")]
                    public Class_1500x500 _1500x500 { get; set; }

                    public class Ipad
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Ipad_Retina
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Web
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Web_Retina
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Mobile
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Mobile_Retina
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Class_300x100
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Class_600x200
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                    public class Class_1500x500
                    {
                        [JsonProperty("h")]
                        public Int64? h { get; set; }
                        [JsonProperty("w")]
                        public Int64? w { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }
                    }
                }
            }
        }
    }
}
