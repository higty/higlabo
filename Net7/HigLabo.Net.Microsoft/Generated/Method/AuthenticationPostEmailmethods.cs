using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationPostEmailmethodsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_EmailMethods: return $"/me/authentication/emailMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_EmailMethods: return $"/users/{IdOrUserPrincipalName}/authentication/emailMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Authentication_EmailMethods,
            Users_IdOrUserPrincipalName_Authentication_EmailMethods,
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
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
    }
    public partial class AuthenticationPostEmailmethodsResponse : RestApiResponse
    {
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostEmailmethodsResponse> AuthenticationPostEmailmethodsAsync()
        {
            var p = new AuthenticationPostEmailmethodsParameter();
            return await this.SendAsync<AuthenticationPostEmailmethodsParameter, AuthenticationPostEmailmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostEmailmethodsResponse> AuthenticationPostEmailmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationPostEmailmethodsParameter();
            return await this.SendAsync<AuthenticationPostEmailmethodsParameter, AuthenticationPostEmailmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostEmailmethodsResponse> AuthenticationPostEmailmethodsAsync(AuthenticationPostEmailmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationPostEmailmethodsParameter, AuthenticationPostEmailmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationPostEmailmethodsResponse> AuthenticationPostEmailmethodsAsync(AuthenticationPostEmailmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationPostEmailmethodsParameter, AuthenticationPostEmailmethodsResponse>(parameter, cancellationToken);
        }
    }
}
