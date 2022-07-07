using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroleassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleAssignments_DeviceAndAppManagementRoleAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleAssignments_DeviceAndAppManagementRoleAssignmentId: return $"/deviceManagement/roleAssignments/{DeviceAndAppManagementRoleAssignmentId}";
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
        public string DeviceAndAppManagementRoleAssignmentId { get; set; }
    }
    public partial class IntuneRbacDeviceandappmanagementroleassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
        public String[]? Members { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentGetResponse> IntuneRbacDeviceandappmanagementroleassignmentGetAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentGetParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentGetParameter, IntuneRbacDeviceandappmanagementroleassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentGetResponse> IntuneRbacDeviceandappmanagementroleassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentGetParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentGetParameter, IntuneRbacDeviceandappmanagementroleassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentGetResponse> IntuneRbacDeviceandappmanagementroleassignmentGetAsync(IntuneRbacDeviceandappmanagementroleassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentGetParameter, IntuneRbacDeviceandappmanagementroleassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentGetResponse> IntuneRbacDeviceandappmanagementroleassignmentGetAsync(IntuneRbacDeviceandappmanagementroleassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentGetParameter, IntuneRbacDeviceandappmanagementroleassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
