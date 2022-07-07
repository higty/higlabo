using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses_DeviceComplianceUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses_DeviceComplianceUserStatusId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/userStatuses/{DeviceComplianceUserStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceUserStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse> IntuneDeviceconfigDevicecomplianceuserstatusDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter, IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse> IntuneDeviceconfigDevicecomplianceuserstatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter, IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse> IntuneDeviceconfigDevicecomplianceuserstatusDeleteAsync(IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter, IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse> IntuneDeviceconfigDevicecomplianceuserstatusDeleteAsync(IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusDeleteParameter, IntuneDeviceconfigDevicecomplianceuserstatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
