using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackagePostIncompatibleAccesspackageParameter : IRestApiParameter
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
    public partial class AccesspackagePostIncompatibleAccesspackageResponse : RestApiResponse
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
        public async Task<AccesspackagePostIncompatibleAccesspackageResponse> AccesspackagePostIncompatibleAccesspackageAsync()
        {
            var p = new AccesspackagePostIncompatibleAccesspackageParameter();
            return await this.SendAsync<AccesspackagePostIncompatibleAccesspackageParameter, AccesspackagePostIncompatibleAccesspackageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagePostIncompatibleAccesspackageResponse> AccesspackagePostIncompatibleAccesspackageAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagePostIncompatibleAccesspackageParameter();
            return await this.SendAsync<AccesspackagePostIncompatibleAccesspackageParameter, AccesspackagePostIncompatibleAccesspackageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagePostIncompatibleAccesspackageResponse> AccesspackagePostIncompatibleAccesspackageAsync(AccesspackagePostIncompatibleAccesspackageParameter parameter)
        {
            return await this.SendAsync<AccesspackagePostIncompatibleAccesspackageParameter, AccesspackagePostIncompatibleAccesspackageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatibleaccesspackage?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagePostIncompatibleAccesspackageResponse> AccesspackagePostIncompatibleAccesspackageAsync(AccesspackagePostIncompatibleAccesspackageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagePostIncompatibleAccesspackageParameter, AccesspackagePostIncompatibleAccesspackageResponse>(parameter, cancellationToken);
        }
    }
}
