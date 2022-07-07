using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignments_Id,
            RoleManagement_EntitlementManagement_RoleAssignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignments_Id: return $"/roleManagement/directory/roleAssignments/{Id}";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments_Id: return $"/roleManagement/entitlementManagement/roleAssignments/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class UnifiedroleassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentDeleteResponse> UnifiedroleassignmentDeleteAsync()
        {
            var p = new UnifiedroleassignmentDeleteParameter();
            return await this.SendAsync<UnifiedroleassignmentDeleteParameter, UnifiedroleassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentDeleteResponse> UnifiedroleassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentDeleteParameter();
            return await this.SendAsync<UnifiedroleassignmentDeleteParameter, UnifiedroleassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentDeleteResponse> UnifiedroleassignmentDeleteAsync(UnifiedroleassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentDeleteParameter, UnifiedroleassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentDeleteResponse> UnifiedroleassignmentDeleteAsync(UnifiedroleassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentDeleteParameter, UnifiedroleassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
