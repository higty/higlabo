using System;
using System.Collections.Generic;

namespace HigLabo.Net.Vimeo
{
    public abstract class VimeoCommand
    {
        public abstract HttpMethodName GetHttpMethodName();
        public abstract String GetApiEndpointUrl();
    }
}
