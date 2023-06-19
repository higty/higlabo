using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationcontextclassreferenceDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AuthenticationcontextclassreferenceDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceDeleteResponse> AuthenticationcontextclassreferenceDeleteAsync()
        {
            var p = new AuthenticationcontextclassreferenceDeleteParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceDeleteParameter, AuthenticationcontextclassreferenceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceDeleteResponse> AuthenticationcontextclassreferenceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationcontextclassreferenceDeleteParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceDeleteParameter, AuthenticationcontextclassreferenceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceDeleteResponse> AuthenticationcontextclassreferenceDeleteAsync(AuthenticationcontextclassreferenceDeleteParameter parameter)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceDeleteParameter, AuthenticationcontextclassreferenceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcontextclassreferenceDeleteResponse> AuthenticationcontextclassreferenceDeleteAsync(AuthenticationcontextclassreferenceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceDeleteParameter, AuthenticationcontextclassreferenceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
