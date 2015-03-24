using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Followers
    {
        public partial class Ids
        {
            public class Command : TwitterCommand
            {
                public Int64? user_id { get; set; }
                public String screen_name { get; set; }
                public String cursor { get; set; }
                public Boolean? stringify_ids { get; set; }
                public Int64? count { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/followers/ids.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
        }
    }
}
