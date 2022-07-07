using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodconfigurationDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class Fido2authenticationmethodconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationDeleteResponse> Fido2authenticationmethodconfigurationDeleteAsync()
        {
            var p = new Fido2authenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodconfigurationDeleteParameter, Fido2authenticationmethodconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationDeleteResponse> Fido2authenticationmethodconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodconfigurationDeleteParameter, Fido2authenticationmethodconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationDeleteResponse> Fido2authenticationmethodconfigurationDeleteAsync(Fido2authenticationmethodconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodconfigurationDeleteParameter, Fido2authenticationmethodconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodconfigurationDeleteResponse> Fido2authenticationmethodconfigurationDeleteAsync(Fido2authenticationmethodconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodconfigurationDeleteParameter, Fido2authenticationmethodconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
