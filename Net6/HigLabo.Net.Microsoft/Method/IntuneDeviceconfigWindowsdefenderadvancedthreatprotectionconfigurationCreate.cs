using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? AllowSampleSharing { get; set; }
        public bool? EnableExpeditedTelemetryReporting { get; set; }
    }
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? AllowSampleSharing { get; set; }
        public bool? EnableExpeditedTelemetryReporting { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
