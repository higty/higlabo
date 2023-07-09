using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class WindowshelloforbusinessauthenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_WindowsHelloForBusinessMethods: return $"/me/authentication/windowsHelloForBusinessMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods: return $"/users/{IdOrUserPrincipalName}/authentication/windowsHelloForBusinessMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            Id,
            KeyStrength,
            Device,
        }
        public enum ApiPath
        {
            Me_Authentication_WindowsHelloForBusinessMethods,
            Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods,
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
    public partial class WindowshelloforbusinessauthenticationmethodListResponse : RestApiResponse
    {
        public WindowsHelloForBusinessAuthenticationMethod[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync()
        {
            var p = new WindowshelloforbusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforbusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(WindowshelloforbusinessauthenticationmethodListParameter parameter)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(WindowshelloforbusinessauthenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(parameter, cancellationToken);
        }
    }
}
