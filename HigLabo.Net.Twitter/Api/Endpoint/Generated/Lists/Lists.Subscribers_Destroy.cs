using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Lists
    {
        public partial class Subscribers_Destroy
        {
            public class Command : TwitterCommand
            {
                public String list_id { get; set; }
                public String slug { get; set; }
                public String owner_screen_name { get; set; }
                public String owner_id { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/lists/subscribers/destroy.json ";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
