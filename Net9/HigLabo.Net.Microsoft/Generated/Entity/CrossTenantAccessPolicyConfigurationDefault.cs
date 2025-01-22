using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicyconfigurationdefault?view=graph-rest-1.0
/// </summary>
public partial class CrossTenantAccessPolicyConfigurationDefault
{
    public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
    public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
    public bool? IsServiceDefault { get; set; }
}
