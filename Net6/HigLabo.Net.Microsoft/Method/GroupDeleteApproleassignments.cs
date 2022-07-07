using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_AppRoleAssignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_AppRoleAssignments_Id: return $"/groups/{GroupsId}/appRoleAssignments/{AppRoleAssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupsId { get; set; }
        public string AppRoleAssignmentsId { get; set; }
    }
    public partial class GroupDeleteApproleassignmentsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteApproleassignmentsResponse> GroupDeleteApproleassignmentsAsync()
        {
            var p = new GroupDeleteApproleassignmentsParameter();
            return await this.SendAsync<GroupDeleteApproleassignmentsParameter, GroupDeleteApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteApproleassignmentsResponse> GroupDeleteApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteApproleassignmentsParameter();
            return await this.SendAsync<GroupDeleteApproleassignmentsParameter, GroupDeleteApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteApproleassignmentsResponse> GroupDeleteApproleassignmentsAsync(GroupDeleteApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<GroupDeleteApproleassignmentsParameter, GroupDeleteApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteApproleassignmentsResponse> GroupDeleteApproleassignmentsAsync(GroupDeleteApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteApproleassignmentsParameter, GroupDeleteApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
