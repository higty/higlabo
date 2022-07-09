using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageDeleteParameter : IRestApiParameter
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
    public partial class AccesspackageDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteResponse> AccesspackageDeleteAsync()
        {
            var p = new AccesspackageDeleteParameter();
            return await this.SendAsync<AccesspackageDeleteParameter, AccesspackageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteResponse> AccesspackageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageDeleteParameter();
            return await this.SendAsync<AccesspackageDeleteParameter, AccesspackageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteResponse> AccesspackageDeleteAsync(AccesspackageDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackageDeleteParameter, AccesspackageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteResponse> AccesspackageDeleteAsync(AccesspackageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageDeleteParameter, AccesspackageDeleteResponse>(parameter, cancellationToken);
        }
    }
}
