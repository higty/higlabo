using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_GroupId_AppRoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_GroupId_AppRoleAssignments: return $"/groups/{GroupId}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Guid? AppRoleId { get; set; }
        public Guid? PrincipalId { get; set; }
        public Guid? ResourceId { get; set; }
        public string GroupId { get; set; }
    }
    public partial class GroupPostApproleassignmentsResponse : RestApiResponse
    {
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostApproleassignmentsResponse> GroupPostApproleassignmentsAsync()
        {
            var p = new GroupPostApproleassignmentsParameter();
            return await this.SendAsync<GroupPostApproleassignmentsParameter, GroupPostApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostApproleassignmentsResponse> GroupPostApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostApproleassignmentsParameter();
            return await this.SendAsync<GroupPostApproleassignmentsParameter, GroupPostApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostApproleassignmentsResponse> GroupPostApproleassignmentsAsync(GroupPostApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<GroupPostApproleassignmentsParameter, GroupPostApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostApproleassignmentsResponse> GroupPostApproleassignmentsAsync(GroupPostApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostApproleassignmentsParameter, GroupPostApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
