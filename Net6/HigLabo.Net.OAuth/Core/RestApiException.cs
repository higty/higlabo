using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class RestApiException : Exception
    {
        public RestApiResponse Response { get; init; }

        public RestApiException(RestApiResponse response)
        {
            this.Response = response;
        }
    }
}
