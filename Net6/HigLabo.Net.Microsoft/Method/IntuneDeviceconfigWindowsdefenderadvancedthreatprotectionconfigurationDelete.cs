using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
