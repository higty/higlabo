using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostManagerParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_Id_Manager_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_Id_Manager_ref: return $"/users/{Id}/manager/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string Id { get; set; }
    }
    public partial class UserPostManagerResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync()
        {
            var p = new UserPostManagerParameter();
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostManagerParameter();
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(UserPostManagerParameter parameter)
        {
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(UserPostManagerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(parameter, cancellationToken);
        }
    }
}
