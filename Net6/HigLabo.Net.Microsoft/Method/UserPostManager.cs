using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
    /// </summary>
    public partial class UserPostManagerParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Id_Manager_ref: return $"/users/{Id}/manager/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_Id_Manager_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class UserPostManagerResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync()
        {
            var p = new UserPostManagerParameter();
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostManagerParameter();
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(UserPostManagerParameter parameter)
        {
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostManagerResponse> UserPostManagerAsync(UserPostManagerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostManagerParameter, UserPostManagerResponse>(parameter, cancellationToken);
        }
    }
}
