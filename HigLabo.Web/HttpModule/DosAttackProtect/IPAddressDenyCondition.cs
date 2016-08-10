using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HigLabo.Core;

namespace HigLabo.Web.Module
{
    public class IPAddressDenyCondition : IDosAttackProtectCondition
    {
        public List<IPAddress_v4> IPAddresses { get; private set; }

        public IPAddressDenyCondition()
        {
            this.IPAddresses = new List<IPAddress_v4>();
        }
        public bool? Validate(HttpRequest request)
        {
            IPAddress_v4 ip = IPAddress_v4.TryCreate(request.UserHostAddress);
            if (ip == null) { return null; }

            if (this.IPAddresses.Contains(ip) == true) { return false; }
            return null;
        }
    }
}