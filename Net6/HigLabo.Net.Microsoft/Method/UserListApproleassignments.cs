using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListApproleassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserListApproleassignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/approleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class AppRoleAssignment
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

        public AppRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleassignmentsResponse> UserListApproleassignmentsAsync()
        {
            var p = new UserListApproleassignmentsParameter();
            return await this.SendAsync<UserListApproleassignmentsParameter, UserListApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleassignmentsResponse> UserListApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListApproleassignmentsParameter();
            return await this.SendAsync<UserListApproleassignmentsParameter, UserListApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleassignmentsResponse> UserListApproleassignmentsAsync(UserListApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<UserListApproleassignmentsParameter, UserListApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleassignmentsResponse> UserListApproleassignmentsAsync(UserListApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListApproleassignmentsParameter, UserListApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
