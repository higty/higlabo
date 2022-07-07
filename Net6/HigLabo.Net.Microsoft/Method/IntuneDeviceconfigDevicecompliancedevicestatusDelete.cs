using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses_DeviceComplianceDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses_DeviceComplianceDeviceStatusId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceStatuses/{DeviceComplianceDeviceStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceDeviceStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse> IntuneDeviceconfigDevicecompliancedevicestatusDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter, IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse> IntuneDeviceconfigDevicecompliancedevicestatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter, IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse> IntuneDeviceconfigDevicecompliancedevicestatusDeleteAsync(IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter, IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse> IntuneDeviceconfigDevicecompliancedevicestatusDeleteAsync(IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusDeleteParameter, IntuneDeviceconfigDevicecompliancedevicestatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
