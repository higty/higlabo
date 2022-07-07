using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroleassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleAssignments: return $"/deviceManagement/roleAssignments";
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
    }
    public partial class IntuneRbacDeviceandappmanagementroleassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-deviceandappmanagementroleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceAndAppManagementRoleAssignment
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public String[]? ResourceScopes { get; set; }
            public String[]? Members { get; set; }
        }

        public DeviceAndAppManagementRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentListResponse> IntuneRbacDeviceandappmanagementroleassignmentListAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentListParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentListParameter, IntuneRbacDeviceandappmanagementroleassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentListResponse> IntuneRbacDeviceandappmanagementroleassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentListParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentListParameter, IntuneRbacDeviceandappmanagementroleassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentListResponse> IntuneRbacDeviceandappmanagementroleassignmentListAsync(IntuneRbacDeviceandappmanagementroleassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentListParameter, IntuneRbacDeviceandappmanagementroleassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentListResponse> IntuneRbacDeviceandappmanagementroleassignmentListAsync(IntuneRbacDeviceandappmanagementroleassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentListParameter, IntuneRbacDeviceandappmanagementroleassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
