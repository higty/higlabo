using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WindowshelloforbusinessauthenticationmethodDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? WindowsHelloForBusinessAuthenticationMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class WindowshelloforbusinessauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodDeleteResponse> WindowshelloforbusinessauthenticationmethodDeleteAsync()
        {
            var p = new WindowshelloforbusinessauthenticationmethodDeleteParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodDeleteParameter, WindowshelloforbusinessauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodDeleteResponse> WindowshelloforbusinessauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforbusinessauthenticationmethodDeleteParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodDeleteParameter, WindowshelloforbusinessauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodDeleteResponse> WindowshelloforbusinessauthenticationmethodDeleteAsync(WindowshelloforbusinessauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodDeleteParameter, WindowshelloforbusinessauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodDeleteResponse> WindowshelloforbusinessauthenticationmethodDeleteAsync(WindowshelloforbusinessauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodDeleteParameter, WindowshelloforbusinessauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
