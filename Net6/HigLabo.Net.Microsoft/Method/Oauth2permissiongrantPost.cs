using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantPostParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class Oauth2permissiongrantPostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantPostResponse> Oauth2permissiongrantPostAsync()
        {
            var p = new Oauth2permissiongrantPostParameter();
            return await this.SendAsync<Oauth2permissiongrantPostParameter, Oauth2permissiongrantPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantPostResponse> Oauth2permissiongrantPostAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantPostParameter();
            return await this.SendAsync<Oauth2permissiongrantPostParameter, Oauth2permissiongrantPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantPostResponse> Oauth2permissiongrantPostAsync(Oauth2permissiongrantPostParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantPostParameter, Oauth2permissiongrantPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantPostResponse> Oauth2permissiongrantPostAsync(Oauth2permissiongrantPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantPostParameter, Oauth2permissiongrantPostResponse>(parameter, cancellationToken);
        }
    }
}
