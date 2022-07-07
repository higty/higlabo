using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserRevokesigninsessionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_RevokeSignInSessions,
            Users_IdOrUserPrincipalName_RevokeSignInSessions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_RevokeSignInSessions: return $"/me/revokeSignInSessions";
                    case ApiPath.Users_IdOrUserPrincipalName_RevokeSignInSessions: return $"/users/{IdOrUserPrincipalName}/revokeSignInSessions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserRevokesigninsessionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync()
        {
            var p = new UserRevokesigninsessionsParameter();
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(CancellationToken cancellationToken)
        {
            var p = new UserRevokesigninsessionsParameter();
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(UserRevokesigninsessionsParameter parameter)
        {
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(UserRevokesigninsessionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(parameter, cancellationToken);
        }
    }
}
