using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageDeleteIncompatibleGroupParameter : IRestApiParameter
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
    public partial class AccessPackageDeleteIncompatibleGroupResponse : RestApiResponse
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
        public async ValueTask<AccessPackageDeleteIncompatibleGroupResponse> AccessPackageDeleteIncompatibleGroupAsync()
        {
            var p = new AccessPackageDeleteIncompatibleGroupParameter();
            return await this.SendAsync<AccessPackageDeleteIncompatibleGroupParameter, AccessPackageDeleteIncompatibleGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleGroupResponse> AccessPackageDeleteIncompatibleGroupAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageDeleteIncompatibleGroupParameter();
            return await this.SendAsync<AccessPackageDeleteIncompatibleGroupParameter, AccessPackageDeleteIncompatibleGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleGroupResponse> AccessPackageDeleteIncompatibleGroupAsync(AccessPackageDeleteIncompatibleGroupParameter parameter)
        {
            return await this.SendAsync<AccessPackageDeleteIncompatibleGroupParameter, AccessPackageDeleteIncompatibleGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-delete-incompatiblegroup?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageDeleteIncompatibleGroupResponse> AccessPackageDeleteIncompatibleGroupAsync(AccessPackageDeleteIncompatibleGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageDeleteIncompatibleGroupParameter, AccessPackageDeleteIncompatibleGroupResponse>(parameter, cancellationToken);
        }
    }
}
