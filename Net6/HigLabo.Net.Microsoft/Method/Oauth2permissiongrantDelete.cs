using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            OAuth2PermissionGrants_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.OAuth2PermissionGrants_Id: return $"/oAuth2PermissionGrants/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class Oauth2permissiongrantDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync()
        {
            var p = new Oauth2permissiongrantDeleteParameter();
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantDeleteParameter();
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(Oauth2permissiongrantDeleteParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(Oauth2permissiongrantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
