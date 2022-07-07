using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SitesId_Permissions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SitesId_Permissions: return $"/sites/{SitesId}/permissions";
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
    }
    public partial class SiteListPermissionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/permission?view=graph-rest-1.0
        /// </summary>
        public partial class Permission
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

        public Permission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync()
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListPermissionsParameter();
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListPermissionsResponse> SiteListPermissionsAsync(SiteListPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListPermissionsParameter, SiteListPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
