using System;
using System.Collections.Generic;

namespace HigLabo.Net.Twitter
{
    public abstract class TwitterCommand
    {
        public abstract HttpMethodName GetHttpMethodName();
        public abstract String GetApiEndpointUrl();
    }
}
