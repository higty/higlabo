using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teleconferencedevicemediaquality?view=graph-rest-1.0
    /// </summary>
    public partial class TeleconferenceDeviceMediaQuality
    {
        public string? AverageInboundJitter { get; set; }
        public Double? AverageInboundPacketLossRateInPercentage { get; set; }
        public string? AverageInboundRoundTripDelay { get; set; }
        public string? AverageOutboundJitter { get; set; }
        public Double? AverageOutboundPacketLossRateInPercentage { get; set; }
        public string? AverageOutboundRoundTripDelay { get; set; }
        public Int32? ChannelIndex { get; set; }
        public Int64? InboundPackets { get; set; }
        public string? LocalIPAddress { get; set; }
        public Int32? LocalPort { get; set; }
        public string? MaximumInboundJitter { get; set; }
        public Double? MaximumInboundPacketLossRateInPercentage { get; set; }
        public string? MaximumInboundRoundTripDelay { get; set; }
        public string? MaximumOutboundJitter { get; set; }
        public Double? MaximumOutboundPacketLossRateInPercentage { get; set; }
        public string? MaximumOutboundRoundTripDelay { get; set; }
        public string? MediaDuration { get; set; }
        public Int64? NetworkLinkSpeedInBytes { get; set; }
        public Int64? OutboundPackets { get; set; }
        public string? RemoteIPAddress { get; set; }
        public Int32? RemotePort { get; set; }
    }
}
