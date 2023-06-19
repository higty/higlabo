using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyListExcludesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Excludes: return $"/policies/permissionGrantPolicies/{Id}/excludes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClientApplicationsFromVerifiedPublisherOnly,
            ClientApplicationIds,
            ClientApplicationPublisherIds,
            ClientApplicationTenantIds,
            Id,
            PermissionClassification,
            Permissions,
            PermissionType,
            ResourceApplication,
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id_Excludes,
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
    public partial class PermissiongrantPolicyListExcludesResponse : RestApiResponse
    {
        public PermissionGrantConditionSet[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListExcludesResponse> PermissiongrantPolicyListExcludesAsync()
        {
            var p = new PermissiongrantPolicyListExcludesParameter();
            return await this.SendAsync<PermissiongrantPolicyListExcludesParameter, PermissiongrantPolicyListExcludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListExcludesResponse> PermissiongrantPolicyListExcludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyListExcludesParameter();
            return await this.SendAsync<PermissiongrantPolicyListExcludesParameter, PermissiongrantPolicyListExcludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListExcludesResponse> PermissiongrantPolicyListExcludesAsync(PermissiongrantPolicyListExcludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyListExcludesParameter, PermissiongrantPolicyListExcludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListExcludesResponse> PermissiongrantPolicyListExcludesAsync(PermissiongrantPolicyListExcludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyListExcludesParameter, PermissiongrantPolicyListExcludesResponse>(parameter, cancellationToken);
        }
    }
}
