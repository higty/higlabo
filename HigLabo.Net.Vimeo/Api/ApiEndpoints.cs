using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Core;
using Newtonsoft.Json;

namespace HigLabo.Net.Vimeo.Api_3_2
{
    public partial class ApiEndpoints
    {
        private VimeoClient _Client = null;

        public ApiEndpoints(VimeoClient client)
        {
            _Client = client;
        }
    }
}
