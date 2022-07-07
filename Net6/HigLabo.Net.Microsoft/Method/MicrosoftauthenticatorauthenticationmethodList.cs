using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_MicrosoftAuthenticatorMethods,
            Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_MicrosoftAuthenticatorMethods: return $"/me/authentication/microsoftAuthenticatorMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods: return $"/users/{IdOrUserPrincipalName}/authentication/microsoftAuthenticatorMethods";
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
    public partial class MicrosoftauthenticatorauthenticationmethodListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorauthenticationmethod?view=graph-rest-1.0
        /// </summary>
        public partial class MicrosoftAuthenticatorAuthenticationMethod
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? DeviceTag { get; set; }
            public string? PhoneAppVersion { get; set; }
        }

        public MicrosoftAuthenticatorAuthenticationMethod[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodListParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodListParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(MicrosoftauthenticatorauthenticationmethodListParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(MicrosoftauthenticatorauthenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(parameter, cancellationToken);
        }
    }
}
