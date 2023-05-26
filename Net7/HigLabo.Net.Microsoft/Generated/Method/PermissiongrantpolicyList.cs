using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies: return $"/policies/permissionGrantPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Description,
            Excludes,
            Id,
            Includes,
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies,
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
    public partial class PermissiongrantPolicyListResponse : RestApiResponse
    {
        public PermissionGrantPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyListResponse> PermissiongrantPolicyListAsync()
        {
            var p = new PermissiongrantPolicyListParameter();
            return await this.SendAsync<PermissiongrantPolicyListParameter, PermissiongrantPolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyListResponse> PermissiongrantPolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyListParameter();
            return await this.SendAsync<PermissiongrantPolicyListParameter, PermissiongrantPolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyListResponse> PermissiongrantPolicyListAsync(PermissiongrantPolicyListParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyListParameter, PermissiongrantPolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyListResponse> PermissiongrantPolicyListAsync(PermissiongrantPolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyListParameter, PermissiongrantPolicyListResponse>(parameter, cancellationToken);
        }
    }
}
