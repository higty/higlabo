using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_Assignments: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentCreateAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentCreateAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentCreateParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
