using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSharedpcconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigSharedpcconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationDeleteResponse> IntuneDeviceconfigSharedpcconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationDeleteParameter, IntuneDeviceconfigSharedpcconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationDeleteResponse> IntuneDeviceconfigSharedpcconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationDeleteParameter, IntuneDeviceconfigSharedpcconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationDeleteResponse> IntuneDeviceconfigSharedpcconfigurationDeleteAsync(IntuneDeviceconfigSharedpcconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationDeleteParameter, IntuneDeviceconfigSharedpcconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationDeleteResponse> IntuneDeviceconfigSharedpcconfigurationDeleteAsync(IntuneDeviceconfigSharedpcconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationDeleteParameter, IntuneDeviceconfigSharedpcconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
