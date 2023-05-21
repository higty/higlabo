using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
    /// </summary>
    public partial class UserListJoinedteamsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_JoinedTeams: return $"/me/joinedTeams";
                    case ApiPath.Users_IdOrUserPrincipalName_JoinedTeams: return $"/users/{IdOrUserPrincipalName}/joinedTeams";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Classification,
            ClassSettings,
            CreatedDateTime,
            Description,
            DisplayName,
            FunSettings,
            GuestSettings,
            InternalId,
            IsArchived,
            MemberSettings,
            MessagingSettings,
            Specialization,
            Summary,
            TenantId,
            Visibility,
            WebUrl,
            AllChannels,
            Channels,
            IncomingChannels,
            InstalledApps,
            Members,
            Operations,
            Photo,
            PrimaryChannel,
            Schedule,
            Tags,
            Template,
        }
        public enum ApiPath
        {
            Me_JoinedTeams,
            Users_IdOrUserPrincipalName_JoinedTeams,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class UserListJoinedteamsResponse : RestApiResponse
    {
        public Team[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync()
        {
            var p = new UserListJoinedteamsParameter();
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListJoinedteamsParameter();
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(UserListJoinedteamsParameter parameter)
        {
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListJoinedteamsResponse> UserListJoinedteamsAsync(UserListJoinedteamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListJoinedteamsParameter, UserListJoinedteamsResponse>(parameter, cancellationToken);
        }
    }
}
