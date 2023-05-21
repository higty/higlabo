using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/inboundoutboundpolicyconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class InboundOutboundPolicyConfiguration
    {
        public bool? InboundAllowed { get; set; }
        public bool? OutboundAllowed { get; set; }
    }
}
