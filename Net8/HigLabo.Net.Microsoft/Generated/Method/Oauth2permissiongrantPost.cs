using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
    /// </summary>
    public partial class Oauth2PermissionGrantPostParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientId { get; set; }
        public string? ConsentType { get; set; }
        public string? Id { get; set; }
        public string? PrincipalId { get; set; }
        public string? ResourceId { get; set; }
        public string? Scope { get; set; }
    }
    public partial class Oauth2PermissionGrantPostResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ConsentType { get; set; }
        public string? Id { get; set; }
        public string? PrincipalId { get; set; }
        public string? ResourceId { get; set; }
        public string? Scope { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantPostResponse> Oauth2PermissionGrantPostAsync()
        {
            var p = new Oauth2PermissionGrantPostParameter();
            return await this.SendAsync<Oauth2PermissionGrantPostParameter, Oauth2PermissionGrantPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantPostResponse> Oauth2PermissionGrantPostAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2PermissionGrantPostParameter();
            return await this.SendAsync<Oauth2PermissionGrantPostParameter, Oauth2PermissionGrantPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantPostResponse> Oauth2PermissionGrantPostAsync(Oauth2PermissionGrantPostParameter parameter)
        {
            return await this.SendAsync<Oauth2PermissionGrantPostParameter, Oauth2PermissionGrantPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantPostResponse> Oauth2PermissionGrantPostAsync(Oauth2PermissionGrantPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2PermissionGrantPostParameter, Oauth2PermissionGrantPostResponse>(parameter, cancellationToken);
        }
    }
}
