using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareoathauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_SoftwareOath: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/softwareOath";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_SoftwareOath,
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
    public partial class SoftwareoathauthenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum SoftwareOathAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public SoftwareOathAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationGetResponse> SoftwareoathauthenticationmethodConfigurationGetAsync()
        {
            var p = new SoftwareoathauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationGetParameter, SoftwareoathauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationGetResponse> SoftwareoathauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new SoftwareoathauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationGetParameter, SoftwareoathauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationGetResponse> SoftwareoathauthenticationmethodConfigurationGetAsync(SoftwareoathauthenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationGetParameter, SoftwareoathauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationGetResponse> SoftwareoathauthenticationmethodConfigurationGetAsync(SoftwareoathauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationGetParameter, SoftwareoathauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
