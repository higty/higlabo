using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftauthenticatorauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MicrosoftAuthenticatorAuthenticationMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/me/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
            Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
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
    public partial class MicrosoftauthenticatorauthenticationmethodGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DeviceTag { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? PhoneAppVersion { get; set; }
        public Device? Device { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodGetResponse> MicrosoftauthenticatorauthenticationmethodGetAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodGetParameter, MicrosoftauthenticatorauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodGetResponse> MicrosoftauthenticatorauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodGetParameter, MicrosoftauthenticatorauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodGetResponse> MicrosoftauthenticatorauthenticationmethodGetAsync(MicrosoftauthenticatorauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodGetParameter, MicrosoftauthenticatorauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodGetResponse> MicrosoftauthenticatorauthenticationmethodGetAsync(MicrosoftauthenticatorauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodGetParameter, MicrosoftauthenticatorauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
