using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessRootListAuthenticationcontextClassreferencesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_AuthenticationContextClassReferences: return $"/identity/conditionalAccess/authenticationContextClassReferences";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_AuthenticationContextClassReferences,
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
    public partial class ConditionalAccessRootListAuthenticationcontextClassreferencesResponse : RestApiResponse<AuthenticationContextClassReference>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListAuthenticationcontextClassreferencesResponse> ConditionalAccessRootListAuthenticationcontextClassreferencesAsync()
        {
            var p = new ConditionalAccessRootListAuthenticationcontextClassreferencesParameter();
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextClassreferencesParameter, ConditionalAccessRootListAuthenticationcontextClassreferencesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListAuthenticationcontextClassreferencesResponse> ConditionalAccessRootListAuthenticationcontextClassreferencesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootListAuthenticationcontextClassreferencesParameter();
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextClassreferencesParameter, ConditionalAccessRootListAuthenticationcontextClassreferencesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListAuthenticationcontextClassreferencesResponse> ConditionalAccessRootListAuthenticationcontextClassreferencesAsync(ConditionalAccessRootListAuthenticationcontextClassreferencesParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextClassreferencesParameter, ConditionalAccessRootListAuthenticationcontextClassreferencesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListAuthenticationcontextClassreferencesResponse> ConditionalAccessRootListAuthenticationcontextClassreferencesAsync(ConditionalAccessRootListAuthenticationcontextClassreferencesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextClassreferencesParameter, ConditionalAccessRootListAuthenticationcontextClassreferencesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AuthenticationContextClassReference> ConditionalAccessRootListAuthenticationcontextClassreferencesEnumerateAsync(ConditionalAccessRootListAuthenticationcontextClassreferencesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ConditionalAccessRootListAuthenticationcontextClassreferencesParameter, ConditionalAccessRootListAuthenticationcontextClassreferencesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AuthenticationContextClassReference>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
