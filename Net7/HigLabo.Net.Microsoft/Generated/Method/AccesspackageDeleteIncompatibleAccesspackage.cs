using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageDeleteIncompatibleAccesspackageParameter : IRestApiParameter
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
    public partial class AccesspackageDeleteIncompatibleAccesspackageResponse : RestApiResponse
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
        public async ValueTask<AccesspackageDeleteIncompatibleAccesspackageResponse> AccesspackageDeleteIncompatibleAccesspackageAsync()
        {
            var p = new AccesspackageDeleteIncompatibleAccesspackageParameter();
            return await this.SendAsync<AccesspackageDeleteIncompatibleAccesspackageParameter, AccesspackageDeleteIncompatibleAccesspackageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageDeleteIncompatibleAccesspackageResponse> AccesspackageDeleteIncompatibleAccesspackageAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageDeleteIncompatibleAccesspackageParameter();
            return await this.SendAsync<AccesspackageDeleteIncompatibleAccesspackageParameter, AccesspackageDeleteIncompatibleAccesspackageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageDeleteIncompatibleAccesspackageResponse> AccesspackageDeleteIncompatibleAccesspackageAsync(AccesspackageDeleteIncompatibleAccesspackageParameter parameter)
        {
            return await this.SendAsync<AccesspackageDeleteIncompatibleAccesspackageParameter, AccesspackageDeleteIncompatibleAccesspackageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageDeleteIncompatibleAccesspackageResponse> AccesspackageDeleteIncompatibleAccesspackageAsync(AccesspackageDeleteIncompatibleAccesspackageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageDeleteIncompatibleAccesspackageParameter, AccesspackageDeleteIncompatibleAccesspackageResponse>(parameter, cancellationToken);
        }
    }
}
