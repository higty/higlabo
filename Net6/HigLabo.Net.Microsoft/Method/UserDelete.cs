using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName: return $"/users/{IdOrUserPrincipalName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteResponse> UserDeleteAsync()
        {
            var p = new UserDeleteParameter();
            return await this.SendAsync<UserDeleteParameter, UserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteResponse> UserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UserDeleteParameter();
            return await this.SendAsync<UserDeleteParameter, UserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteResponse> UserDeleteAsync(UserDeleteParameter parameter)
        {
            return await this.SendAsync<UserDeleteParameter, UserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteResponse> UserDeleteAsync(UserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserDeleteParameter, UserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
