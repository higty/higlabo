using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId,
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
        public bool? IsHidden { get; set; }
    }
    public partial class AccesspackageUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageUpdateResponse> AccesspackageUpdateAsync()
        {
            var p = new AccesspackageUpdateParameter();
            return await this.SendAsync<AccesspackageUpdateParameter, AccesspackageUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageUpdateResponse> AccesspackageUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageUpdateParameter();
            return await this.SendAsync<AccesspackageUpdateParameter, AccesspackageUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageUpdateResponse> AccesspackageUpdateAsync(AccesspackageUpdateParameter parameter)
        {
            return await this.SendAsync<AccesspackageUpdateParameter, AccesspackageUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageUpdateResponse> AccesspackageUpdateAsync(AccesspackageUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageUpdateParameter, AccesspackageUpdateResponse>(parameter, cancellationToken);
        }
    }
}
