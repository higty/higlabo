using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2authenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/fido2";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2,
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
    public partial class Fido2authenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum Fido2AuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public bool? IsAttestationEnforced { get; set; }
        public bool? IsSelfServiceRegistrationAllowed { get; set; }
        public Fido2KeyRestrictions? KeyRestrictions { get; set; }
        public Fido2AuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationGetResponse> Fido2authenticationmethodConfigurationGetAsync()
        {
            var p = new Fido2authenticationmethodConfigurationGetParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationGetParameter, Fido2authenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationGetResponse> Fido2authenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodConfigurationGetParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationGetParameter, Fido2authenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationGetResponse> Fido2authenticationmethodConfigurationGetAsync(Fido2authenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationGetParameter, Fido2authenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationGetResponse> Fido2authenticationmethodConfigurationGetAsync(Fido2authenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationGetParameter, Fido2authenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
