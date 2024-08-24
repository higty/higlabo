using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AccessPackageDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteResponse> AccessPackageDeleteAsync()
        {
            var p = new AccessPackageDeleteParameter();
            return await this.SendAsync<AccessPackageDeleteParameter, AccessPackageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteResponse> AccessPackageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageDeleteParameter();
            return await this.SendAsync<AccessPackageDeleteParameter, AccessPackageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteResponse> AccessPackageDeleteAsync(AccessPackageDeleteParameter parameter)
        {
            return await this.SendAsync<AccessPackageDeleteParameter, AccessPackageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteResponse> AccessPackageDeleteAsync(AccessPackageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageDeleteParameter, AccessPackageDeleteResponse>(parameter, cancellationToken);
        }
    }
}
