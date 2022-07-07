using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserChangepasswordParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_ChangePassword,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ChangePassword: return $"/me/changePassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
    public partial class UserChangepasswordResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<UserChangepasswordResponse> UserChangepasswordAsync()
        {
            var p = new UserChangepasswordParameter();
            return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<UserChangepasswordResponse> UserChangepasswordAsync(CancellationToken cancellationToken)
        {
            var p = new UserChangepasswordParameter();
            return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<UserChangepasswordResponse> UserChangepasswordAsync(UserChangepasswordParameter parameter)
        {
            return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<UserChangepasswordResponse> UserChangepasswordAsync(UserChangepasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(parameter, cancellationToken);
        }
    }
}
