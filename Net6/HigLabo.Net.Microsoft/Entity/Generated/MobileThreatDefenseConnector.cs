using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-mobilethreatdefenseconnector?view=graph-rest-1.0
    /// </summary>
    public partial class MobileThreatDefenseConnector
    {
        public enum MobileThreatDefenseConnectorMobileThreatPartnerTenantState
        {
            Unavailable,
            Available,
            Enabled,
            Unresponsive,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public MobileThreatPartnerTenantState? PartnerState { get; set; }
        public bool? AndroidEnabled { get; set; }
        public bool? IosEnabled { get; set; }
        public bool? AndroidDeviceBlockedOnMissingPartnerData { get; set; }
        public bool? IosDeviceBlockedOnMissingPartnerData { get; set; }
        public bool? PartnerUnsupportedOsVersionBlocked { get; set; }
        public Int32? PartnerUnresponsivenessThresholdInDays { get; set; }
    }
}
