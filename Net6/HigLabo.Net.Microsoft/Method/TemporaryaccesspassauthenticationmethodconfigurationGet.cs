using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TemporaryaccesspassauthenticationmethodconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/temporaryAccessPass";
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
    }
    public partial class TemporaryaccesspassauthenticationmethodconfigurationGetResponse : RestApiResponse
    {
        public enum TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public int? DefaultLength { get; set; }
        public int? DefaultLifetimeInMinutes { get; set; }
        public string? Id { get; set; }
        public bool? IsUsableOnce { get; set; }
        public int? MinimumLifetimeInMinutes { get; set; }
        public int? MaximumLifetimeInMinutes { get; set; }
        public TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationGetResponse> TemporaryaccesspassauthenticationmethodconfigurationGetAsync()
        {
            var p = new TemporaryaccesspassauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationGetParameter, TemporaryaccesspassauthenticationmethodconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationGetResponse> TemporaryaccesspassauthenticationmethodconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryaccesspassauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationGetParameter, TemporaryaccesspassauthenticationmethodconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationGetResponse> TemporaryaccesspassauthenticationmethodconfigurationGetAsync(TemporaryaccesspassauthenticationmethodconfigurationGetParameter parameter)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationGetParameter, TemporaryaccesspassauthenticationmethodconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationGetResponse> TemporaryaccesspassauthenticationmethodconfigurationGetAsync(TemporaryaccesspassauthenticationmethodconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationGetParameter, TemporaryaccesspassauthenticationmethodconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
