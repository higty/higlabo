using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroledefinitionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleDefinitions: return $"/deviceManagement/roleDefinitions";
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
    public partial class IntuneRbacDeviceandappmanagementroledefinitionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-deviceandappmanagementroledefinition?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceAndAppManagementRoleDefinition
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public RolePermission[]? RolePermissions { get; set; }
            public bool? IsBuiltIn { get; set; }
        }

        public DeviceAndAppManagementRoleDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionListResponse> IntuneRbacDeviceandappmanagementroledefinitionListAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionListParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionListParameter, IntuneRbacDeviceandappmanagementroledefinitionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionListResponse> IntuneRbacDeviceandappmanagementroledefinitionListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionListParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionListParameter, IntuneRbacDeviceandappmanagementroledefinitionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionListResponse> IntuneRbacDeviceandappmanagementroledefinitionListAsync(IntuneRbacDeviceandappmanagementroledefinitionListParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionListParameter, IntuneRbacDeviceandappmanagementroledefinitionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionListResponse> IntuneRbacDeviceandappmanagementroledefinitionListAsync(IntuneRbacDeviceandappmanagementroledefinitionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionListParameter, IntuneRbacDeviceandappmanagementroledefinitionListResponse>(parameter, cancellationToken);
        }
    }
}
