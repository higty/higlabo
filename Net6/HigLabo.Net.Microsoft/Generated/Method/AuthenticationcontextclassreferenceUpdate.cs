using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationcontextclassreferenceUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsAvailable { get; set; }
    }
    public partial class AuthenticationcontextclassreferenceUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationcontextclassreferenceUpdateResponse> AuthenticationcontextclassreferenceUpdateAsync()
        {
            var p = new AuthenticationcontextclassreferenceUpdateParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceUpdateParameter, AuthenticationcontextclassreferenceUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationcontextclassreferenceUpdateResponse> AuthenticationcontextclassreferenceUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationcontextclassreferenceUpdateParameter();
            return await this.SendAsync<AuthenticationcontextclassreferenceUpdateParameter, AuthenticationcontextclassreferenceUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationcontextclassreferenceUpdateResponse> AuthenticationcontextclassreferenceUpdateAsync(AuthenticationcontextclassreferenceUpdateParameter parameter)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceUpdateParameter, AuthenticationcontextclassreferenceUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationcontextclassreferenceUpdateResponse> AuthenticationcontextclassreferenceUpdateAsync(AuthenticationcontextclassreferenceUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationcontextclassreferenceUpdateParameter, AuthenticationcontextclassreferenceUpdateResponse>(parameter, cancellationToken);
        }
    }
}
