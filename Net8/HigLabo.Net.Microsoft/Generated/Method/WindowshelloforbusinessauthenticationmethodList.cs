using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class WindowshelloforBusinessauthenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class WindowshelloforBusinessauthenticationmethodListResponse : RestApiResponse<WindowsHelloForBusinessAuthenticationMethod>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodListResponse> WindowshelloforBusinessauthenticationmethodListAsync()
        {
            var p = new WindowshelloforBusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodListParameter, WindowshelloforBusinessauthenticationmethodListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodListResponse> WindowshelloforBusinessauthenticationmethodListAsync(CancellationToken cancellationToken)
        {
            var p = new WindowshelloforBusinessauthenticationmethodListParameter();
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodListParameter, WindowshelloforBusinessauthenticationmethodListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodListResponse> WindowshelloforBusinessauthenticationmethodListAsync(WindowshelloforBusinessauthenticationmethodListParameter parameter)
        {
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodListParameter, WindowshelloforBusinessauthenticationmethodListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WindowshelloforBusinessauthenticationmethodListResponse> WindowshelloforBusinessauthenticationmethodListAsync(WindowshelloforBusinessauthenticationmethodListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WindowshelloforBusinessauthenticationmethodListParameter, WindowshelloforBusinessauthenticationmethodListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/windowshelloforbusinessauthenticationmethod-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<WindowsHelloForBusinessAuthenticationMethod> WindowshelloforBusinessauthenticationmethodListEnumerateAsync(WindowshelloforBusinessauthenticationmethodListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<WindowshelloforBusinessauthenticationmethodListParameter, WindowshelloforBusinessauthenticationmethodListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<WindowsHelloForBusinessAuthenticationMethod>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
