using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationPostTemporaryaccesspassmethodsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? IsUsableOnce { get; set; }
        public Int32? LifetimeInMinutes { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class AuthenticationPostTemporaryaccesspassmethodsResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsUsableOnce { get; set; }
        public bool? IsUsable { get; set; }
        public Int32? LifetimeInMinutes { get; set; }
        public string? MethodUsabilityReason { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? TemporaryAccessPass { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostTemporaryaccesspassmethodsResponse> AuthenticationPostTemporaryaccesspassmethodsAsync()
        {
            var p = new AuthenticationPostTemporaryaccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationPostTemporaryaccesspassmethodsParameter, AuthenticationPostTemporaryaccesspassmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostTemporaryaccesspassmethodsResponse> AuthenticationPostTemporaryaccesspassmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationPostTemporaryaccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationPostTemporaryaccesspassmethodsParameter, AuthenticationPostTemporaryaccesspassmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostTemporaryaccesspassmethodsResponse> AuthenticationPostTemporaryaccesspassmethodsAsync(AuthenticationPostTemporaryaccesspassmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationPostTemporaryaccesspassmethodsParameter, AuthenticationPostTemporaryaccesspassmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostTemporaryaccesspassmethodsResponse> AuthenticationPostTemporaryaccesspassmethodsAsync(AuthenticationPostTemporaryaccesspassmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationPostTemporaryaccesspassmethodsParameter, AuthenticationPostTemporaryaccesspassmethodsResponse>(parameter, cancellationToken);
        }
    }
}
