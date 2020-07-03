using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Core;
using Newtonsoft.Json;

namespace HigLabo.Net.Dailymotion.Api_1_0
{
    public partial class ApiEndpoints
    {
        private DailymotionClient _Client = null;

        public ApiEndpoints(DailymotionClient client)
        {
            _Client = client;
        }
    }
}
