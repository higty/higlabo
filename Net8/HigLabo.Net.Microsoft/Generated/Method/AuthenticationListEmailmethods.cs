using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationListEmailmethodsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            EmailAddress,
            Id,
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
    public partial class AuthenticationListEmailmethodsResponse : RestApiResponse
    {
        public EmailAuthenticationMethod[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListEmailmethodsResponse> AuthenticationListEmailmethodsAsync()
        {
            var p = new AuthenticationListEmailmethodsParameter();
            return await this.SendAsync<AuthenticationListEmailmethodsParameter, AuthenticationListEmailmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListEmailmethodsResponse> AuthenticationListEmailmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationListEmailmethodsParameter();
            return await this.SendAsync<AuthenticationListEmailmethodsParameter, AuthenticationListEmailmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListEmailmethodsResponse> AuthenticationListEmailmethodsAsync(AuthenticationListEmailmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationListEmailmethodsParameter, AuthenticationListEmailmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-emailmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListEmailmethodsResponse> AuthenticationListEmailmethodsAsync(AuthenticationListEmailmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationListEmailmethodsParameter, AuthenticationListEmailmethodsResponse>(parameter, cancellationToken);
        }
    }
}
