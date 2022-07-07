using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoledefinitionListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneRbacRoledefinitionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-roledefinition?view=graph-rest-1.0
        /// </summary>
        public partial class RoleDefinition
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public RolePermission[]? RolePermissions { get; set; }
            public bool? IsBuiltIn { get; set; }
        }

        public RoleDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionListResponse> IntuneRbacRoledefinitionListAsync()
        {
            var p = new IntuneRbacRoledefinitionListParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionListParameter, IntuneRbacRoledefinitionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionListResponse> IntuneRbacRoledefinitionListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoledefinitionListParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionListParameter, IntuneRbacRoledefinitionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionListResponse> IntuneRbacRoledefinitionListAsync(IntuneRbacRoledefinitionListParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionListParameter, IntuneRbacRoledefinitionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionListResponse> IntuneRbacRoledefinitionListAsync(IntuneRbacRoledefinitionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionListParameter, IntuneRbacRoledefinitionListResponse>(parameter, cancellationToken);
        }
    }
}
