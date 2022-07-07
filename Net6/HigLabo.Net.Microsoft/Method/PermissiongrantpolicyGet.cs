using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id: return $"/policies/permissionGrantPolicies/{Id}";
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
        public string Id { get; set; }
    }
    public partial class PermissiongrantpolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public PermissionGrantConditionSet[]? Includes { get; set; }
        public PermissionGrantConditionSet[]? Excludes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyGetResponse> PermissiongrantpolicyGetAsync()
        {
            var p = new PermissiongrantpolicyGetParameter();
            return await this.SendAsync<PermissiongrantpolicyGetParameter, PermissiongrantpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyGetResponse> PermissiongrantpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyGetParameter();
            return await this.SendAsync<PermissiongrantpolicyGetParameter, PermissiongrantpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyGetResponse> PermissiongrantpolicyGetAsync(PermissiongrantpolicyGetParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyGetParameter, PermissiongrantpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyGetResponse> PermissiongrantpolicyGetAsync(PermissiongrantpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyGetParameter, PermissiongrantpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
