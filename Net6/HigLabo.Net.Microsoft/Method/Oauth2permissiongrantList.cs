using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Oauth2PermissionGrants,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Oauth2PermissionGrants: return $"/oauth2PermissionGrants";
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
    }
    public partial class Oauth2permissiongrantListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/oauth2permissiongrant?view=graph-rest-1.0
        /// </summary>
        public partial class OAuth2PermissionGrant
        {
            public string? Id { get; set; }
            public string? ClientId { get; set; }
            public string? ConsentType { get; set; }
            public string? PrincipalId { get; set; }
            public string? ResourceId { get; set; }
            public string? Scope { get; set; }
        }

        public OAuth2PermissionGrant[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync()
        {
            var p = new Oauth2permissiongrantListParameter();
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantListParameter();
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(Oauth2permissiongrantListParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(Oauth2permissiongrantListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(parameter, cancellationToken);
        }
    }
}
