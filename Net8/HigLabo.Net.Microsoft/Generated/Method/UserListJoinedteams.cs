using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
    /// </summary>
    public partial class UserListJoinedTeamsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class UserListJoinedTeamsResponse : RestApiResponse<Team>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListJoinedTeamsResponse> UserListJoinedTeamsAsync()
        {
            var p = new UserListJoinedTeamsParameter();
            return await this.SendAsync<UserListJoinedTeamsParameter, UserListJoinedTeamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListJoinedTeamsResponse> UserListJoinedTeamsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListJoinedTeamsParameter();
            return await this.SendAsync<UserListJoinedTeamsParameter, UserListJoinedTeamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListJoinedTeamsResponse> UserListJoinedTeamsAsync(UserListJoinedTeamsParameter parameter)
        {
            return await this.SendAsync<UserListJoinedTeamsParameter, UserListJoinedTeamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListJoinedTeamsResponse> UserListJoinedTeamsAsync(UserListJoinedTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListJoinedTeamsParameter, UserListJoinedTeamsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-joinedteams?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Team> UserListJoinedTeamsEnumerateAsync(UserListJoinedTeamsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListJoinedTeamsParameter, UserListJoinedTeamsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Team>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
