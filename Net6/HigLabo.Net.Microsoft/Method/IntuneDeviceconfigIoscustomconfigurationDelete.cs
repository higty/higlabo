using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscustomconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigIoscustomconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationDeleteResponse> IntuneDeviceconfigIoscustomconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigIoscustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationDeleteParameter, IntuneDeviceconfigIoscustomconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationDeleteResponse> IntuneDeviceconfigIoscustomconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationDeleteParameter, IntuneDeviceconfigIoscustomconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationDeleteResponse> IntuneDeviceconfigIoscustomconfigurationDeleteAsync(IntuneDeviceconfigIoscustomconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationDeleteParameter, IntuneDeviceconfigIoscustomconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscustomconfigurationDeleteResponse> IntuneDeviceconfigIoscustomconfigurationDeleteAsync(IntuneDeviceconfigIoscustomconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscustomconfigurationDeleteParameter, IntuneDeviceconfigIoscustomconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
