using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Oauth2PermissionGrants_Id: return $"/oauth2PermissionGrants/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Oauth2PermissionGrants_Id,
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
    public partial class Oauth2permissiongrantGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ClientId { get; set; }
        public string? ConsentType { get; set; }
        public string? PrincipalId { get; set; }
        public string? ResourceId { get; set; }
        public string? Scope { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantGetResponse> Oauth2permissiongrantGetAsync()
        {
            var p = new Oauth2permissiongrantGetParameter();
            return await this.SendAsync<Oauth2permissiongrantGetParameter, Oauth2permissiongrantGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantGetResponse> Oauth2permissiongrantGetAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantGetParameter();
            return await this.SendAsync<Oauth2permissiongrantGetParameter, Oauth2permissiongrantGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantGetResponse> Oauth2permissiongrantGetAsync(Oauth2permissiongrantGetParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantGetParameter, Oauth2permissiongrantGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantGetResponse> Oauth2permissiongrantGetAsync(Oauth2permissiongrantGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantGetParameter, Oauth2permissiongrantGetResponse>(parameter, cancellationToken);
        }
    }
}
