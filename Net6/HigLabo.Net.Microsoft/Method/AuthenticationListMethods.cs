using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationListMethodsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_Methods,
            Users_IdOrUserPrincipalName_Authentication_Methods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_Methods: return $"/me/authentication/methods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_Methods: return $"/users/{IdOrUserPrincipalName}/authentication/methods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class AuthenticationListMethodsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/authenticationmethod?view=graph-rest-1.0
        /// </summary>
        public partial class AuthenticationMethod
        {
            public string? Id { get; set; }
        }

        public AuthenticationMethod[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-methods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListMethodsResponse> AuthenticationListMethodsAsync()
        {
            var p = new AuthenticationListMethodsParameter();
            return await this.SendAsync<AuthenticationListMethodsParameter, AuthenticationListMethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-methods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListMethodsResponse> AuthenticationListMethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationListMethodsParameter();
            return await this.SendAsync<AuthenticationListMethodsParameter, AuthenticationListMethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-methods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListMethodsResponse> AuthenticationListMethodsAsync(AuthenticationListMethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationListMethodsParameter, AuthenticationListMethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-methods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListMethodsResponse> AuthenticationListMethodsAsync(AuthenticationListMethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationListMethodsParameter, AuthenticationListMethodsResponse>(parameter, cancellationToken);
        }
    }
}
