using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationcontextclassreferenceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_AuthenticationContextClassReferences_Id: return $"/identity/conditionalAccess/authenticationContextClassReferences/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_AuthenticationContextClassReferences_Id,
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
    public partial class AuthenticationcontextclassreferenceGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAvailable { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceGetResponse> AuthenticationcontextclassreferenceGetAsync()
        {
            var p = new AuthenticationcontextclassreferenceGetParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceGetParameter, AuthenticationcontextclassreferenceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceGetResponse> AuthenticationcontextclassreferenceGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationcontextclassreferenceGetParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceGetParameter, AuthenticationcontextclassreferenceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceGetResponse> AuthenticationcontextclassreferenceGetAsync(AuthenticationcontextclassreferenceGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceGetParameter, AuthenticationcontextclassreferenceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceGetResponse> AuthenticationcontextclassreferenceGetAsync(AuthenticationcontextclassreferenceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceGetParameter, AuthenticationcontextclassreferenceGetResponse>(parameter, cancellationToken);
        }
    }
}
