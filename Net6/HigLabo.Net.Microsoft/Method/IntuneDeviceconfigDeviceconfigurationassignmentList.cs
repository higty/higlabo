using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/assignments";
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
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationassignment?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceConfigurationAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public DeviceConfigurationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentListResponse> IntuneDeviceconfigDeviceconfigurationassignmentListAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentListParameter, IntuneDeviceconfigDeviceconfigurationassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentListResponse> IntuneDeviceconfigDeviceconfigurationassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentListParameter, IntuneDeviceconfigDeviceconfigurationassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentListResponse> IntuneDeviceconfigDeviceconfigurationassignmentListAsync(IntuneDeviceconfigDeviceconfigurationassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentListParameter, IntuneDeviceconfigDeviceconfigurationassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentListResponse> IntuneDeviceconfigDeviceconfigurationassignmentListAsync(IntuneDeviceconfigDeviceconfigurationassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentListParameter, IntuneDeviceconfigDeviceconfigurationassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
