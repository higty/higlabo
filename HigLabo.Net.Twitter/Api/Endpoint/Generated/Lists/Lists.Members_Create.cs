using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Lists
    {
        public partial class Members_Create
        {
            public class Command : TwitterCommand
            {
                public String list_id { get; set; }
                public String slug { get; set; }
                public Int64 user_id { get; set; }
                public String screen_name { get; set; }
                public String owner_screen_name { get; set; }
                public String owner_id { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/lists/members/create.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
