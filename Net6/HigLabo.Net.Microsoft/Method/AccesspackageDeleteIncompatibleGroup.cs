using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageDeleteIncompatibleGroupParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackagesId { get; set; }
            public string? IncompatibleGroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups_Id_ref: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackagesId}/incompatibleGroups/{IncompatibleGroupsId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups_Id_ref,
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
    public partial class AccesspackageDeleteIncompatibleGroupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteIncompatibleGroupResponse> AccesspackageDeleteIncompatibleGroupAsync()
        {
            var p = new AccesspackageDeleteIncompatibleGroupParameter();
            return await this.SendAsync<AccesspackageDeleteIncompatibleGroupParameter, AccesspackageDeleteIncompatibleGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteIncompatibleGroupResponse> AccesspackageDeleteIncompatibleGroupAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageDeleteIncompatibleGroupParameter();
            return await this.SendAsync<AccesspackageDeleteIncompatibleGroupParameter, AccesspackageDeleteIncompatibleGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteIncompatibleGroupResponse> AccesspackageDeleteIncompatibleGroupAsync(AccesspackageDeleteIncompatibleGroupParameter parameter)
        {
            return await this.SendAsync<AccesspackageDeleteIncompatibleGroupParameter, AccesspackageDeleteIncompatibleGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageDeleteIncompatibleGroupResponse> AccesspackageDeleteIncompatibleGroupAsync(AccesspackageDeleteIncompatibleGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageDeleteIncompatibleGroupParameter, AccesspackageDeleteIncompatibleGroupResponse>(parameter, cancellationToken);
        }
    }
}
