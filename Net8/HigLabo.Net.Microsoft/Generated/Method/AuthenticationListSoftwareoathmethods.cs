using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationListSoftwareoathmethodsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_SoftwareOathMethods: return $"/me/authentication/softwareOathMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_SoftwareOathMethods: return $"/users/{IdOrUserPrincipalName}/authentication/softwareOathMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_SoftwareOathMethods,
            Users_IdOrUserPrincipalName_Authentication_SoftwareOathMethods,
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
    public partial class AuthenticationListSoftwareoathmethodsResponse : RestApiResponse<SoftwareOathAuthenticationMethod>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListSoftwareoathmethodsResponse> AuthenticationListSoftwareoathmethodsAsync()
        {
            var p = new AuthenticationListSoftwareoathmethodsParameter();
            return await this.SendAsync<AuthenticationListSoftwareoathmethodsParameter, AuthenticationListSoftwareoathmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListSoftwareoathmethodsResponse> AuthenticationListSoftwareoathmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationListSoftwareoathmethodsParameter();
            return await this.SendAsync<AuthenticationListSoftwareoathmethodsParameter, AuthenticationListSoftwareoathmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListSoftwareoathmethodsResponse> AuthenticationListSoftwareoathmethodsAsync(AuthenticationListSoftwareoathmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationListSoftwareoathmethodsParameter, AuthenticationListSoftwareoathmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListSoftwareoathmethodsResponse> AuthenticationListSoftwareoathmethodsAsync(AuthenticationListSoftwareoathmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationListSoftwareoathmethodsParameter, AuthenticationListSoftwareoathmethodsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-softwareoathmethods?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<SoftwareOathAuthenticationMethod> AuthenticationListSoftwareoathmethodsEnumerateAsync(AuthenticationListSoftwareoathmethodsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AuthenticationListSoftwareoathmethodsParameter, AuthenticationListSoftwareoathmethodsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<SoftwareOathAuthenticationMethod>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
