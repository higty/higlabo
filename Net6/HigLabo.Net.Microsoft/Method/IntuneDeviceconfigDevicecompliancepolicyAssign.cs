using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assign: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DeviceCompliancePolicyAssignment[]? Assignments { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyAssignResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancepolicyassignment?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceCompliancePolicyAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public DeviceCompliancePolicyAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyAssignResponse> IntuneDeviceconfigDevicecompliancepolicyAssignAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyAssignParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyAssignParameter, IntuneDeviceconfigDevicecompliancepolicyAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyAssignResponse> IntuneDeviceconfigDevicecompliancepolicyAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyAssignParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyAssignParameter, IntuneDeviceconfigDevicecompliancepolicyAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyAssignResponse> IntuneDeviceconfigDevicecompliancepolicyAssignAsync(IntuneDeviceconfigDevicecompliancepolicyAssignParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyAssignParameter, IntuneDeviceconfigDevicecompliancepolicyAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyAssignResponse> IntuneDeviceconfigDevicecompliancepolicyAssignAsync(IntuneDeviceconfigDevicecompliancepolicyAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyAssignParameter, IntuneDeviceconfigDevicecompliancepolicyAssignResponse>(parameter, cancellationToken);
        }
    }
}
