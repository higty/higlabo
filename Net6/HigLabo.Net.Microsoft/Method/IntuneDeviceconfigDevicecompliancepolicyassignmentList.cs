using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentListAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentListAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentListAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentListParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
