using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicemanagementexchangeconnector?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceManagementExchangeConnector
    {
        public string Id { get; set; }
        public DateTimeOffset LastSyncDateTime { get; set; }
        public DeviceManagementExchangeConnectorDeviceManagementExchangeConnectorStatus Status { get; set; }
        public string PrimarySmtpAddress { get; set; }
        public string ServerName { get; set; }
        public string ConnectorServerName { get; set; }
        public DeviceManagementExchangeConnectorDeviceManagementExchangeConnectorType ExchangeConnectorType { get; set; }
        public string Version { get; set; }
        public string ExchangeAlias { get; set; }
        public string ExchangeOrganization { get; set; }
    }
}
