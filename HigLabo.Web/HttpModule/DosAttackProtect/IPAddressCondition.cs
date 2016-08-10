using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HigLabo.Core;

namespace HigLabo.Web.Module
{
    public class IPAddressCondition : IDosAttackProtectCondition
    {
        public IPAddress_v4 Start { get; set; }
        public IPAddress_v4 End { get; set; }
        public Boolean Allow { get; set; }

        public IPAddressCondition(IPAddress_v4 address)
        {
            this.Start = address;
            this.End = address;
            this.Allow = false;
        }
        public IPAddressCondition(IPAddress_v4 start, IPAddress_v4 end)
        {
            this.Start = start;
            this.End = end;
            this.Allow = false;
        }
        public IPAddressCondition(IPAddress_v4 start, IPAddress_v4 end, Boolean allow)
        {
            this.Start = start;
            this.End = end;
            this.Allow = allow;
        }

        public Boolean? Validate(HttpRequest request)
        {
            var req = request;
            IPAddress_v4 ip = IPAddress_v4.TryCreate(req.UserHostAddress);
            if (ip == null) { return null; }

            if (this.Start.Value <= ip.Value && ip.Value <= this.End.Value)
            {
                return this.Allow;
            }
            return !this.Allow;
        }
        public override string ToString()
        {
            var allow = this.Allow ? "Allow" : "Deny";
            return String.Format("{0}: {1} - {2}", allow, this.Start, this.End);
        }
    }
}