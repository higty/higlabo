using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HigLabo.Web.Module
{
    public class RequestHeaderDenyCondition : IDosAttackProtectCondition
    {
        public Boolean Allow { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }

        public RequestHeaderDenyCondition()
        {
            this.Allow = false;
        }
        public RequestHeaderDenyCondition(String key, String value, Boolean allow)
        {
            this.Key = key;
            this.Value = value;
            this.Allow = allow;
        }

        public bool? Validate(HttpRequest request)
        {
            if (String.IsNullOrEmpty(this.Key) == true) { return null; }
            
            var req = request;
            var val = req.Headers[this.Key];
            if (val != null &&
                val.Contains(this.Value) == true) { return this.Allow; }
            return null;
        }
    }
}