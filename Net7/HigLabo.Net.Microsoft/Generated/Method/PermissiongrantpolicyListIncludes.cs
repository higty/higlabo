using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyListIncludesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Includes: return $"/policies/permissionGrantPolicies/{Id}/includes";
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
            Policies_PermissionGrantPolicies_Id_Includes,
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
    public partial class PermissiongrantPolicyListIncludesResponse : RestApiResponse
    {
        public PermissionGrantConditionSet[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListIncludesResponse> PermissiongrantPolicyListIncludesAsync()
        {
            var p = new PermissiongrantPolicyListIncludesParameter();
            return await this.SendAsync<PermissiongrantPolicyListIncludesParameter, PermissiongrantPolicyListIncludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListIncludesResponse> PermissiongrantPolicyListIncludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyListIncludesParameter();
            return await this.SendAsync<PermissiongrantPolicyListIncludesParameter, PermissiongrantPolicyListIncludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListIncludesResponse> PermissiongrantPolicyListIncludesAsync(PermissiongrantPolicyListIncludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyListIncludesParameter, PermissiongrantPolicyListIncludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-includes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissiongrantPolicyListIncludesResponse> PermissiongrantPolicyListIncludesAsync(PermissiongrantPolicyListIncludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyListIncludesParameter, PermissiongrantPolicyListIncludesResponse>(parameter, cancellationToken);
        }
    }
}
