using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostApproleAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_AppRoleAssignments: return $"/users/{IdOrUserPrincipalName}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_AppRoleAssignments,
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
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    public partial class UserPostApproleAssignmentsResponse : RestApiResponse
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
        public async Task<UserPostApproleAssignmentsResponse> UserPostApproleAssignmentsAsync()
        {
            var p = new UserPostApproleAssignmentsParameter();
            return await this.SendAsync<UserPostApproleAssignmentsParameter, UserPostApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleAssignmentsResponse> UserPostApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostApproleAssignmentsParameter();
            return await this.SendAsync<UserPostApproleAssignmentsParameter, UserPostApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleAssignmentsResponse> UserPostApproleAssignmentsAsync(UserPostApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<UserPostApproleAssignmentsParameter, UserPostApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostApproleAssignmentsResponse> UserPostApproleAssignmentsAsync(UserPostApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostApproleAssignmentsParameter, UserPostApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
