using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public partial class Oauth2permissiongrantListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Oauth2PermissionGrants: return $"/oauth2PermissionGrants";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClientId,
            ConsentType,
            Id,
            PrincipalId,
            ResourceId,
            Scope,
        }
        public enum ApiPath
        {
            Oauth2PermissionGrants,
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
    public partial class Oauth2permissiongrantListResponse : RestApiResponse
    {
        public OAuth2PermissionGrant[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync()
        {
            var p = new Oauth2permissiongrantListParameter();
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantListParameter();
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(Oauth2permissiongrantListParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantListResponse> Oauth2permissiongrantListAsync(Oauth2permissiongrantListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantListParameter, Oauth2permissiongrantListResponse>(parameter, cancellationToken);
        }
    }
}
