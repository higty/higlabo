using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class WindowshelloforBusinessauthenticationmethodDeleteParameter : IRestApiParameter
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
    public partial class WindowshelloforBusinessauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodDeleteResponse> WindowshelloforBusinessauthenticationmethodDeleteAsync()
        {
            var p = new WindowshelloforBusinessauthenticationmethodDeleteParameter();
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodDeleteParameter, WindowshelloforBusinessauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodDeleteResponse> WindowshelloforBusinessauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforBusinessauthenticationmethodDeleteParameter();
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodDeleteParameter, WindowshelloforBusinessauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodDeleteResponse> WindowshelloforBusinessauthenticationmethodDeleteAsync(WindowshelloforBusinessauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodDeleteParameter, WindowshelloforBusinessauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodDeleteResponse> WindowshelloforBusinessauthenticationmethodDeleteAsync(WindowshelloforBusinessauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodDeleteParameter, WindowshelloforBusinessauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
