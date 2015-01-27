using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Lists
    {
        public partial class Update
        {
            public class Command : TwitterCommand
            {
                public String list_id { get; set; }
                public String slug { get; set; }
                public String name { get; set; }
                public String mode { get; set; }
                public String description { get; set; }
                public String owner_screen_name { get; set; }
                public String owner_id { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/lists/update.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
