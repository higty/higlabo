using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse> IntuneDeviceconfigEditionupgradeconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter, IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse> IntuneDeviceconfigEditionupgradeconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter, IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse> IntuneDeviceconfigEditionupgradeconfigurationDeleteAsync(IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter, IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse> IntuneDeviceconfigEditionupgradeconfigurationDeleteAsync(IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationDeleteParameter, IntuneDeviceconfigEditionupgradeconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
