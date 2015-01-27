using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Account
    {
        public partial class Update_Profile_Banner
        {
            public class Command : TwitterCommand
            {
                public String banner { get; set; }
                public String width { get; set; }
                public String height { get; set; }
                public String offset_left { get; set; }
                public String offset_top { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/account/update_profile_banner.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
