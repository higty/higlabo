using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_AppRoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_AppRoleAssignments: return $"/users/{IdOrUserPrincipalName}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserPostApproleassignmentsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleassignmentsResponse> UserPostApproleassignmentsAsync()
        {
            var p = new UserPostApproleassignmentsParameter();
            return await this.SendAsync<UserPostApproleassignmentsParameter, UserPostApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleassignmentsResponse> UserPostApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostApproleassignmentsParameter();
            return await this.SendAsync<UserPostApproleassignmentsParameter, UserPostApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleassignmentsResponse> UserPostApproleassignmentsAsync(UserPostApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<UserPostApproleassignmentsParameter, UserPostApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleassignmentsResponse> UserPostApproleassignmentsAsync(UserPostApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostApproleassignmentsParameter, UserPostApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
