using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Oauth2PermissionGrants_Delta: return $"/oauth2PermissionGrants/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            ClientId,
            ConsentType,
            PrincipalId,
            ResourceId,
            Scope,
        }
        public enum ApiPath
        {
            Oauth2PermissionGrants_Delta,
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
    public partial class Oauth2permissiongrantDeltaResponse : RestApiResponse
    {
        public OAuth2PermissionGrant[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeltaResponse> Oauth2permissiongrantDeltaAsync()
        {
            var p = new Oauth2permissiongrantDeltaParameter();
            return await this.SendAsync<Oauth2permissiongrantDeltaParameter, Oauth2permissiongrantDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeltaResponse> Oauth2permissiongrantDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantDeltaParameter();
            return await this.SendAsync<Oauth2permissiongrantDeltaParameter, Oauth2permissiongrantDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeltaResponse> Oauth2permissiongrantDeltaAsync(Oauth2permissiongrantDeltaParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantDeltaParameter, Oauth2permissiongrantDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeltaResponse> Oauth2permissiongrantDeltaAsync(Oauth2permissiongrantDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantDeltaParameter, Oauth2permissiongrantDeltaResponse>(parameter, cancellationToken);
        }
    }
}
