using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WindowshelloforbusinessauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string WindowsHelloForBusinessAuthenticationMethodId { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_WindowsHelloForBusinessMethods_WindowsHelloForBusinessAuthenticationMethodId: return $"/me/authentication/windowsHelloForBusinessMethods/{WindowsHelloForBusinessAuthenticationMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods_WindowsHelloForBusinessAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/windowsHelloForBusinessMethods/{WindowsHelloForBusinessAuthenticationMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_WindowsHelloForBusinessMethods_WindowsHelloForBusinessAuthenticationMethodId,
            Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods_WindowsHelloForBusinessAuthenticationMethodId,
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
    public partial class WindowshelloforbusinessauthenticationmethodGetResponse : RestApiResponse
    {
        public enum WindowsHelloForBusinessAuthenticationMethodAuthenticationMethodKeyStrength
        {
            Normal,
            Weak,
            Unknown,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public WindowsHelloForBusinessAuthenticationMethodAuthenticationMethodKeyStrength KeyStrength { get; set; }
        public Device? Device { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodGetResponse> WindowshelloforbusinessauthenticationmethodGetAsync()
        {
            var p = new WindowshelloforbusinessauthenticationmethodGetParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodGetParameter, WindowshelloforbusinessauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodGetResponse> WindowshelloforbusinessauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforbusinessauthenticationmethodGetParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodGetParameter, WindowshelloforbusinessauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodGetResponse> WindowshelloforbusinessauthenticationmethodGetAsync(WindowshelloforbusinessauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodGetParameter, WindowshelloforbusinessauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodGetResponse> WindowshelloforbusinessauthenticationmethodGetAsync(WindowshelloforbusinessauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodGetParameter, WindowshelloforbusinessauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
