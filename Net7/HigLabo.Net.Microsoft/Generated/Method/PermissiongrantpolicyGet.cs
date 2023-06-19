using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id: return $"/policies/permissionGrantPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class PermissiongrantPolicyGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public PermissionGrantConditionSet[]? Excludes { get; set; }
        public string? Id { get; set; }
        public PermissionGrantConditionSet[]? Includes { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyGetResponse> PermissiongrantPolicyGetAsync()
        {
            var p = new PermissiongrantPolicyGetParameter();
            return await this.SendAsync<PermissiongrantPolicyGetParameter, PermissiongrantPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyGetResponse> PermissiongrantPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyGetParameter();
            return await this.SendAsync<PermissiongrantPolicyGetParameter, PermissiongrantPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyGetResponse> PermissiongrantPolicyGetAsync(PermissiongrantPolicyGetParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyGetParameter, PermissiongrantPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyGetResponse> PermissiongrantPolicyGetAsync(PermissiongrantPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyGetParameter, PermissiongrantPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
