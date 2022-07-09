using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SitePostPermissionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SitesId_Permissions: return $"/sites/{SitesId}/permissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SitesId_Permissions,
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
        public string? Id { get; set; }
        public SharePointIdentitySet? GrantedToV2 { get; set; }
        public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
        public SharingInvitation? Invitation { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public SharingLink? Link { get; set; }
        public string[]? Roles { get; set; }
        public string? ShareId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public bool? HasPassword { get; set; }
    }
    public partial class SitePostPermissionsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public SharePointIdentitySet? GrantedToV2 { get; set; }
        public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
        public SharingInvitation? Invitation { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public SharingLink? Link { get; set; }
        public string[]? Roles { get; set; }
        public string? ShareId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public bool? HasPassword { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostPermissionsResponse> SitePostPermissionsAsync()
        {
            var p = new SitePostPermissionsParameter();
            return await this.SendAsync<SitePostPermissionsParameter, SitePostPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostPermissionsResponse> SitePostPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new SitePostPermissionsParameter();
            return await this.SendAsync<SitePostPermissionsParameter, SitePostPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostPermissionsResponse> SitePostPermissionsAsync(SitePostPermissionsParameter parameter)
        {
            return await this.SendAsync<SitePostPermissionsParameter, SitePostPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostPermissionsResponse> SitePostPermissionsAsync(SitePostPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitePostPermissionsParameter, SitePostPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
