using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class AccessTokenUpdatedEventArgs
    {
        public RequestCodeResponse Response { get; init; }

        public AccessTokenUpdatedEventArgs(RequestCodeResponse response)
        {
            this.Response = response;
        }
    }
}
