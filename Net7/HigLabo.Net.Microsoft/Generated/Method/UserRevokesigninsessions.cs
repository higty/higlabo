using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
    /// </summary>
    public partial class UserRevokesigninsessionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_RevokeSignInSessions: return $"/me/revokeSignInSessions";
                    case ApiPath.Users_IdOrUserPrincipalName_RevokeSignInSessions: return $"/users/{IdOrUserPrincipalName}/revokeSignInSessions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_RevokeSignInSessions,
            Users_IdOrUserPrincipalName_RevokeSignInSessions,
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
    }
    public partial class UserRevokesigninsessionsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync()
        {
            var p = new UserRevokesigninsessionsParameter();
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(CancellationToken cancellationToken)
        {
            var p = new UserRevokesigninsessionsParameter();
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(UserRevokesigninsessionsParameter parameter)
        {
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-revokesigninsessions?view=graph-rest-1.0
        /// </summary>
        public async Task<UserRevokesigninsessionsResponse> UserRevokesigninsessionsAsync(UserRevokesigninsessionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserRevokesigninsessionsParameter, UserRevokesigninsessionsResponse>(parameter, cancellationToken);
        }
    }
}
