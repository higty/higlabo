using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Core;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class ApiEndpoints
    {
        private TwitterClient _Client = null;

        public ApiEndpoints(TwitterClient client)
        {
            _Client = client;
        }
    }
}
