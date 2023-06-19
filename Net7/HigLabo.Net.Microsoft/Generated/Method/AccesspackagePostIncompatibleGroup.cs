using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackagePostIncompatibleGroupParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups_ref: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleGroups/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups_ref,
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
    public partial class AccesspackagePostIncompatibleGroupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackagePostIncompatibleGroupResponse> AccesspackagePostIncompatibleGroupAsync()
        {
            var p = new AccesspackagePostIncompatibleGroupParameter();
            return await this.SendAsync<AccesspackagePostIncompatibleGroupParameter, AccesspackagePostIncompatibleGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackagePostIncompatibleGroupResponse> AccesspackagePostIncompatibleGroupAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagePostIncompatibleGroupParameter();
            return await this.SendAsync<AccesspackagePostIncompatibleGroupParameter, AccesspackagePostIncompatibleGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackagePostIncompatibleGroupResponse> AccesspackagePostIncompatibleGroupAsync(AccesspackagePostIncompatibleGroupParameter parameter)
        {
            return await this.SendAsync<AccesspackagePostIncompatibleGroupParameter, AccesspackagePostIncompatibleGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-post-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackagePostIncompatibleGroupResponse> AccesspackagePostIncompatibleGroupAsync(AccesspackagePostIncompatibleGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagePostIncompatibleGroupParameter, AccesspackagePostIncompatibleGroupResponse>(parameter, cancellationToken);
        }
    }
}
