using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
