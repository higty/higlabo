using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
