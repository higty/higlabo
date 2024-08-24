using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageUpdateParameter : IRestApiParameter
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
    public partial class AccessPackageUpdateResponse : RestApiResponse
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
        public async ValueTask<AccessPackageUpdateResponse> AccessPackageUpdateAsync()
        {
            var p = new AccessPackageUpdateParameter();
            return await this.SendAsync<AccessPackageUpdateParameter, AccessPackageUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageUpdateResponse> AccessPackageUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageUpdateParameter();
            return await this.SendAsync<AccessPackageUpdateParameter, AccessPackageUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageUpdateResponse> AccessPackageUpdateAsync(AccessPackageUpdateParameter parameter)
        {
            return await this.SendAsync<AccessPackageUpdateParameter, AccessPackageUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageUpdateResponse> AccessPackageUpdateAsync(AccessPackageUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageUpdateParameter, AccessPackageUpdateResponse>(parameter, cancellationToken);
        }
    }
}
