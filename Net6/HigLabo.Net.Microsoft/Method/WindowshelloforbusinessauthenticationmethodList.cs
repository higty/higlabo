using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WindowshelloforbusinessauthenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_WindowsHelloForBusinessMethods,
            Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_WindowsHelloForBusinessMethods: return $"/me/authentication/windowsHelloForBusinessMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_WindowsHelloForBusinessMethods: return $"/users/{IdOrUserPrincipalName}/authentication/windowsHelloForBusinessMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class WindowshelloforbusinessauthenticationmethodListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/windowshelloforbusinessauthenticationmethod?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsHelloForBusinessAuthenticationMethod
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
        }

        public WindowsHelloForBusinessAuthenticationMethod[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync()
        {
            var p = new WindowshelloforbusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforbusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(WindowshelloforbusinessauthenticationmethodListParameter parameter)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WindowshelloforbusinessauthenticationmethodListResponse> WindowshelloforbusinessauthenticationmethodListAsync(WindowshelloforbusinessauthenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforbusinessauthenticationmethodListParameter, WindowshelloforbusinessauthenticationmethodListResponse>(parameter, cancellationToken);
        }
    }
}
