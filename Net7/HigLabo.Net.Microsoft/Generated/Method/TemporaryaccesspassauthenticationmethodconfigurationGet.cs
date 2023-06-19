using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class TemporaryAccesspassauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/temporaryAccessPass";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass,
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
    public partial class TemporaryAccesspassauthenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public int? DefaultLength { get; set; }
        public int? DefaultLifetimeInMinutes { get; set; }
        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public bool? IsUsableOnce { get; set; }
        public int? MaximumLifetimeInMinutes { get; set; }
        public int? MinimumLifetimeInMinutes { get; set; }
        public TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationGetResponse> TemporaryAccesspassauthenticationmethodConfigurationGetAsync()
        {
            var p = new TemporaryAccesspassauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationGetParameter, TemporaryAccesspassauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationGetResponse> TemporaryAccesspassauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryAccesspassauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationGetParameter, TemporaryAccesspassauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationGetResponse> TemporaryAccesspassauthenticationmethodConfigurationGetAsync(TemporaryAccesspassauthenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationGetParameter, TemporaryAccesspassauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationGetResponse> TemporaryAccesspassauthenticationmethodConfigurationGetAsync(TemporaryAccesspassauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationGetParameter, TemporaryAccesspassauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
