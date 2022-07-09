using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-networkinfo?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsNetworkinfo
    {
        public enum CallrecordsNetworkinfoCallRecordsNetworkConnectionType
        {
            Unknown,
            Wired,
            Wifi,
            Mobile,
            Tunnel,
            UnknownFutureValue,
        }
        public enum CallrecordsNetworkinfoCallRecordsNetworkTransportProtocol
        {
            Unknown,
            Udp,
            Tcp,
            UnknownFutureValue,
        }
        public enum CallrecordsNetworkinfoCallRecordsWifiBand
        {
            Unknown,
            Frequency24GHz,
            Frequency50GHz,
            Frequency60GHz,
            UnknownFutureValue,
        }
        public enum CallrecordsNetworkinfoCallRecordsWifiRadioType
        {
            Unknown,
            Wifi80211a,
            Wifi80211b,
            Wifi80211g,
            Wifi80211n,
            Wifi80211ac,
            Wifi80211ax,
            UnknownFutureValue,
        }

        public Double? BandwidthLowEventRatio { get; set; }
        public string? BasicServiceSetIdentifier { get; set; }
        public CallrecordsNetworkinfoCallRecordsNetworkConnectionType ConnectionType { get; set; }
        public Double? DelayEventRatio { get; set; }
        public string? DnsSuffix { get; set; }
        public string? IpAddress { get; set; }
        public Int64? LinkSpeed { get; set; }
        public string? MacAddress { get; set; }
        public CallrecordsNetworkinfoCallRecordsNetworkTransportProtocol NetworkTransportProtocol { get; set; }
        public Int32? Port { get; set; }
        public Double? ReceivedQualityEventRatio { get; set; }
        public string? ReflexiveIPAddress { get; set; }
        public string? RelayIPAddress { get; set; }
        public Int32? RelayPort { get; set; }
        public Double? SentQualityEventRatio { get; set; }
        public string? Subnet { get; set; }
        public CallrecordsTraceroutehop[]? TraceRouteHops { get; set; }
        public CallrecordsNetworkinfoCallRecordsWifiBand WifiBand { get; set; }
        public Int32? WifiBatteryCharge { get; set; }
        public Int32? WifiChannel { get; set; }
        public string? WifiMicrosoftDriver { get; set; }
        public string? WifiMicrosoftDriverVersion { get; set; }
        public CallrecordsNetworkinfoCallRecordsWifiRadioType WifiRadioType { get; set; }
        public Int32? WifiSignalStrength { get; set; }
        public string? WifiVendorDriver { get; set; }
        public string? WifiVendorDriverVersion { get; set; }
    }
}
