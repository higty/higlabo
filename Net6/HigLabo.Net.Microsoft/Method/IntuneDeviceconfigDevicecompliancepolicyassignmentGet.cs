using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string DeviceCompliancePolicyAssignmentId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentGetAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse> IntuneDeviceconfigDevicecompliancepolicyassignmentGetAsync(IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyassignmentGetParameter, IntuneDeviceconfigDevicecompliancepolicyassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
