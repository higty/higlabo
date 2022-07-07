using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/fido2";
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
    public partial class Fido2authenticationmethodconfigurationGetResponse : RestApiResponse
    {
        public enum Fido2AuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public string? Id { get; set; }
        public bool? IsAttestationEnforced { get; set; }
        public bool? IsSelfServiceRegistrationAllowed { get; set; }
        public Fido2KeyRestrictions? KeyRestrictions { get; set; }
        public Fido2AuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationGetResponse> Fido2authenticationmethodconfigurationGetAsync()
        {
            var p = new Fido2authenticationmethodconfigurationGetParameter();
            return await this.SendAsync<Fido2authenticationmethodconfigurationGetParameter, Fido2authenticationmethodconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationGetResponse> Fido2authenticationmethodconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodconfigurationGetParameter();
            return await this.SendAsync<Fido2authenticationmethodconfigurationGetParameter, Fido2authenticationmethodconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationGetResponse> Fido2authenticationmethodconfigurationGetAsync(Fido2authenticationmethodconfigurationGetParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodconfigurationGetParameter, Fido2authenticationmethodconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationGetResponse> Fido2authenticationmethodconfigurationGetAsync(Fido2authenticationmethodconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodconfigurationGetParameter, Fido2authenticationmethodconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
