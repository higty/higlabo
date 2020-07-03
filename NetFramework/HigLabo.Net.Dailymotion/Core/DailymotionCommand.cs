using System;
using System.Collections.Generic;

namespace HigLabo.Net.Dailymotion
{
    public abstract class DailymotionCommand
    {
        public abstract HttpMethodName GetHttpMethodName();
        public abstract String GetApiEndpointUrl();
    }
}
