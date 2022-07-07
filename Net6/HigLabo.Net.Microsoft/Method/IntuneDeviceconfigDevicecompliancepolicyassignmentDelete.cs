using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assignments_DeviceCompliancePolicyAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assignments_DeviceCompliancePolicyAssignmentId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/assignments/{DeviceCompliancePolicyAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceCompliancePolicyAssignmentId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
