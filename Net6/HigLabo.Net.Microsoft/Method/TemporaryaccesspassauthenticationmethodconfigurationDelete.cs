using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse> TemporaryaccesspassauthenticationmethodconfigurationDeleteAsync()
        {
            var p = new TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter, TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse> TemporaryaccesspassauthenticationmethodconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter, TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse> TemporaryaccesspassauthenticationmethodconfigurationDeleteAsync(TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter, TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse> TemporaryaccesspassauthenticationmethodconfigurationDeleteAsync(TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodconfigurationDeleteParameter, TemporaryaccesspassauthenticationmethodconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
