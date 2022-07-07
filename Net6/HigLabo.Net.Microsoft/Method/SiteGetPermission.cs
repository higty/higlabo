using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteGetPermissionParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            CreatedDateTime,
            Description,
            DisplayName,
            ETag,
            LastModifiedDateTime,
            Name,
            Root,
            SharepointIds,
            SiteCollection,
            WebUrl,
        }
        public enum ApiPath
        {
            Sites_SitesId_Permissions_PermissionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SitesId_Permissions_PermissionId: return $"/sites/{SitesId}/permissions/{PermissionId}";
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
        public string SitesId { get; set; }
        public string PermissionId { get; set; }
    }
    public partial class SiteGetPermissionResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/site-get-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetPermissionResponse> SiteGetPermissionAsync()
        {
            var p = new SiteGetPermissionParameter();
            return await this.SendAsync<SiteGetPermissionParameter, SiteGetPermissionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-get-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetPermissionResponse> SiteGetPermissionAsync(CancellationToken cancellationToken)
        {
            var p = new SiteGetPermissionParameter();
            return await this.SendAsync<SiteGetPermissionParameter, SiteGetPermissionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-get-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetPermissionResponse> SiteGetPermissionAsync(SiteGetPermissionParameter parameter)
        {
            return await this.SendAsync<SiteGetPermissionParameter, SiteGetPermissionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-get-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetPermissionResponse> SiteGetPermissionAsync(SiteGetPermissionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteGetPermissionParameter, SiteGetPermissionResponse>(parameter, cancellationToken);
        }
    }
}
