using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageDeleteIncompatibleAccessPackageParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackagesId { get; set; }
            public string? IncompatibleAccessPackagesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages_Id_ref: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackagesId}/incompatibleAccessPackages/{IncompatibleAccessPackagesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages_Id_ref,
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
    public partial class AccessPackageDeleteIncompatibleAccessPackageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleAccessPackageResponse> AccessPackageDeleteIncompatibleAccessPackageAsync()
        {
            var p = new AccessPackageDeleteIncompatibleAccessPackageParameter();
            return await this.SendAsync<AccessPackageDeleteIncompatibleAccessPackageParameter, AccessPackageDeleteIncompatibleAccessPackageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleAccessPackageResponse> AccessPackageDeleteIncompatibleAccessPackageAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageDeleteIncompatibleAccessPackageParameter();
            return await this.SendAsync<AccessPackageDeleteIncompatibleAccessPackageParameter, AccessPackageDeleteIncompatibleAccessPackageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleAccessPackageResponse> AccessPackageDeleteIncompatibleAccessPackageAsync(AccessPackageDeleteIncompatibleAccessPackageParameter parameter)
        {
            return await this.SendAsync<AccessPackageDeleteIncompatibleAccessPackageParameter, AccessPackageDeleteIncompatibleAccessPackageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleAccessPackageResponse> AccessPackageDeleteIncompatibleAccessPackageAsync(AccessPackageDeleteIncompatibleAccessPackageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageDeleteIncompatibleAccessPackageParameter, AccessPackageDeleteIncompatibleAccessPackageResponse>(parameter, cancellationToken);
        }
    }
}
