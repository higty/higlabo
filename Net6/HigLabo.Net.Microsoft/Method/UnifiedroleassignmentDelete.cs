using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleAssignmentDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignments_Id: return $"/roleManagement/directory/roleAssignments/{Id}";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments_Id: return $"/roleManagement/entitlementManagement/roleAssignments/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignments_Id,
            RoleManagement_EntitlementManagement_RoleAssignments_Id,
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
    public partial class UnifiedroleAssignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentDeleteResponse> UnifiedroleAssignmentDeleteAsync()
        {
            var p = new UnifiedroleAssignmentDeleteParameter();
            return await this.SendAsync<UnifiedroleAssignmentDeleteParameter, UnifiedroleAssignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentDeleteResponse> UnifiedroleAssignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentDeleteParameter();
            return await this.SendAsync<UnifiedroleAssignmentDeleteParameter, UnifiedroleAssignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentDeleteResponse> UnifiedroleAssignmentDeleteAsync(UnifiedroleAssignmentDeleteParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentDeleteParameter, UnifiedroleAssignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentDeleteResponse> UnifiedroleAssignmentDeleteAsync(UnifiedroleAssignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentDeleteParameter, UnifiedroleAssignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
