using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListJoinedteamsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_JoinedTeams,
            Users_IdOrUserPrincipalName_JoinedTeams,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_JoinedTeams: return $"/me/joinedTeams";
                    case ApiPath.Users_IdOrUserPrincipalName_JoinedTeams: return $"/users/{IdOrUserPrincipalName}/joinedTeams";
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
    public partial class UserListJoinedteamsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/team?view=graph-rest-1.0
        /// </summary>
        public partial class Team
        {
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public string? Classification { get; set; }
            public TeamSpecialization? Specialization { get; set; }
            public TeamVisibilityType? Visibility { get; set; }
            public TeamFunSettings? FunSettings { get; set; }
            public TeamGuestSettings? GuestSettings { get; set; }
            public string? InternalId { get; set; }
            public bool? IsArchived { get; set; }
            public TeamMemberSettings? MemberSettings { get; set; }
            public TeamMessagingSettings? MessagingSettings { get; set; }
            public string? WebUrl { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
        }

        public Team[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync()
        {
            var p = new UserListJoinedteamsParameter();
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListJoinedteamsParameter();
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(UserListJoinedteamsParameter parameter)
        {
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(UserListJoinedteamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(parameter, cancellationToken);
        }
    }
}
