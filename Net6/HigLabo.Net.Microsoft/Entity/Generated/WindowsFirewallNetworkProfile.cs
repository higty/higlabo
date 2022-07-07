using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsfirewallnetworkprofile?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsFirewallNetworkProfile
    {
        public enum WindowsFirewallNetworkProfileStateManagementSetting
        {
            NotConfigured,
            Blocked,
            Allowed,
        }

        public StateManagementSetting? FirewallEnabled { get; set; }
        public bool? StealthModeBlocked { get; set; }
        public bool? IncomingTrafficBlocked { get; set; }
        public bool? UnicastResponsesToMulticastBroadcastsBlocked { get; set; }
        public bool? InboundNotificationsBlocked { get; set; }
        public bool? AuthorizedApplicationRulesFromGroupPolicyMerged { get; set; }
        public bool? GlobalPortRulesFromGroupPolicyMerged { get; set; }
        public bool? ConnectionSecurityRulesFromGroupPolicyMerged { get; set; }
        public bool? OutboundConnectionsBlocked { get; set; }
        public bool? InboundConnectionsBlocked { get; set; }
        public bool? SecuredPacketExemptionAllowed { get; set; }
        public bool? PolicyRulesFromGroupPolicyMerged { get; set; }
    }
}
