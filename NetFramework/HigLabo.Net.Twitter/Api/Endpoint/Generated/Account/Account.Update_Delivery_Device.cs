using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Account
    {
        public partial class Update_Delivery_Device
        {
            public class Command : TwitterCommand
            {
                public String device { get; set; }
                public Boolean? include_entities { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/account/update_delivery_device.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Post;
                }
            }
        }
    }
}
