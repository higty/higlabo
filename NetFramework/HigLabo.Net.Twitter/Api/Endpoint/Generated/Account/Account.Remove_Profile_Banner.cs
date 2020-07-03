using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Account
    {
        public partial class Remove_Profile_Banner
        {
            public class Command : TwitterCommand
            {
                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/account/remove_profile_banner.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
