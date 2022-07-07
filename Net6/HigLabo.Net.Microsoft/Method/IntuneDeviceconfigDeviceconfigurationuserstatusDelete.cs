using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses_DeviceConfigurationUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses_DeviceConfigurationUserStatusId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/userStatuses/{DeviceConfigurationUserStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
        public string DeviceConfigurationUserStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationuserstatusDeleteAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationuserstatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationuserstatusDeleteAsync(IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationuserstatusDeleteAsync(IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationuserstatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
