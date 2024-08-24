using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackagePostIncompatibleAccessPackageParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages_ref: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleAccessPackages/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AccessPackagePostIncompatibleAccessPackageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackagePostIncompatibleAccessPackageResponse> AccessPackagePostIncompatibleAccessPackageAsync()
        {
            var p = new AccessPackagePostIncompatibleAccessPackageParameter();
            return await this.SendAsync<AccessPackagePostIncompatibleAccessPackageParameter, AccessPackagePostIncompatibleAccessPackageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackagePostIncompatibleAccessPackageResponse> AccessPackagePostIncompatibleAccessPackageAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackagePostIncompatibleAccessPackageParameter();
            return await this.SendAsync<AccessPackagePostIncompatibleAccessPackageParameter, AccessPackagePostIncompatibleAccessPackageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackagePostIncompatibleAccessPackageResponse> AccessPackagePostIncompatibleAccessPackageAsync(AccessPackagePostIncompatibleAccessPackageParameter parameter)
        {
            return await this.SendAsync<AccessPackagePostIncompatibleAccessPackageParameter, AccessPackagePostIncompatibleAccessPackageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackagePostIncompatibleAccessPackageResponse> AccessPackagePostIncompatibleAccessPackageAsync(AccessPackagePostIncompatibleAccessPackageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackagePostIncompatibleAccessPackageParameter, AccessPackagePostIncompatibleAccessPackageResponse>(parameter, cancellationToken);
        }
    }
}
