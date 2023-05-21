using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessRootListAuthenticationcontextclassreferencesParameter : IRestApiParameter, IQueryParameterProperty
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
            Description,
            DisplayName,
            Id,
            IsAvailable,
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
    public partial class ConditionalAccessRootListAuthenticationcontextclassreferencesResponse : RestApiResponse
    {
        public AuthenticationContextClassReference[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListAuthenticationcontextclassreferencesResponse> ConditionalAccessRootListAuthenticationcontextclassreferencesAsync()
        {
            var p = new ConditionalAccessRootListAuthenticationcontextclassreferencesParameter();
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextclassreferencesParameter, ConditionalAccessRootListAuthenticationcontextclassreferencesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListAuthenticationcontextclassreferencesResponse> ConditionalAccessRootListAuthenticationcontextclassreferencesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootListAuthenticationcontextclassreferencesParameter();
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextclassreferencesParameter, ConditionalAccessRootListAuthenticationcontextclassreferencesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListAuthenticationcontextclassreferencesResponse> ConditionalAccessRootListAuthenticationcontextclassreferencesAsync(ConditionalAccessRootListAuthenticationcontextclassreferencesParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextclassreferencesParameter, ConditionalAccessRootListAuthenticationcontextclassreferencesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-authenticationcontextclassreferences?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListAuthenticationcontextclassreferencesResponse> ConditionalAccessRootListAuthenticationcontextclassreferencesAsync(ConditionalAccessRootListAuthenticationcontextclassreferencesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootListAuthenticationcontextclassreferencesParameter, ConditionalAccessRootListAuthenticationcontextclassreferencesResponse>(parameter, cancellationToken);
        }
    }
}
