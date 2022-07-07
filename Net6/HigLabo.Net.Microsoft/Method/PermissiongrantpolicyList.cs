using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies: return $"/policies/permissionGrantPolicies";
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
    public partial class PermissiongrantpolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/permissiongrantpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class PermissionGrantPolicy
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public PermissionGrantConditionSet[]? Includes { get; set; }
            public PermissionGrantConditionSet[]? Excludes { get; set; }
        }

        public PermissionGrantPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListResponse> PermissiongrantpolicyListAsync()
        {
            var p = new PermissiongrantpolicyListParameter();
            return await this.SendAsync<PermissiongrantpolicyListParameter, PermissiongrantpolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListResponse> PermissiongrantpolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyListParameter();
            return await this.SendAsync<PermissiongrantpolicyListParameter, PermissiongrantpolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListResponse> PermissiongrantpolicyListAsync(PermissiongrantpolicyListParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyListParameter, PermissiongrantpolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListResponse> PermissiongrantpolicyListAsync(PermissiongrantpolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyListParameter, PermissiongrantpolicyListResponse>(parameter, cancellationToken);
        }
    }
}
