using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class TenantappManagementPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_DefaultAppManagementPolicy: return $"/policies/defaultAppManagementPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_DefaultAppManagementPolicy,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }
        public AppManagementConfiguration? ApplicationRestrictions { get; set; }
        public AppManagementConfiguration? ServicePrincipalRestrictions { get; set; }
    }
    public partial class TenantappManagementPolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantappManagementPolicyUpdateResponse> TenantappManagementPolicyUpdateAsync()
        {
            var p = new TenantappManagementPolicyUpdateParameter();
            return await this.SendAsync<TenantappManagementPolicyUpdateParameter, TenantappManagementPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantappManagementPolicyUpdateResponse> TenantappManagementPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TenantappManagementPolicyUpdateParameter();
            return await this.SendAsync<TenantappManagementPolicyUpdateParameter, TenantappManagementPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantappManagementPolicyUpdateResponse> TenantappManagementPolicyUpdateAsync(TenantappManagementPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<TenantappManagementPolicyUpdateParameter, TenantappManagementPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantappManagementPolicyUpdateResponse> TenantappManagementPolicyUpdateAsync(TenantappManagementPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TenantappManagementPolicyUpdateParameter, TenantappManagementPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
