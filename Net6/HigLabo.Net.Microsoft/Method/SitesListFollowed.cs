using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SitesListFollowedParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_FollowedSites,
            Users_UserId_FollowedSites,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_FollowedSites: return $"/me/followedSites";
                    case ApiPath.Users_UserId_FollowedSites: return $"/users/{UserId}/followedSites";
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
        public string UserId { get; set; }
    }
    public partial class SitesListFollowedResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/site?view=graph-rest-1.0
        /// </summary>
        public partial class Site
        {
            public string? Id { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? ETag { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Root? Root { get; set; }
            public SharePointIds? SharepointIds { get; set; }
            public SiteCollection? SiteCollection { get; set; }
            public string? WebUrl { get; set; }
        }

        public Site[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async Task<SitesListFollowedResponse> SitesListFollowedAsync()
        {
            var p = new SitesListFollowedParameter();
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async Task<SitesListFollowedResponse> SitesListFollowedAsync(CancellationToken cancellationToken)
        {
            var p = new SitesListFollowedParameter();
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async Task<SitesListFollowedResponse> SitesListFollowedAsync(SitesListFollowedParameter parameter)
        {
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async Task<SitesListFollowedResponse> SitesListFollowedAsync(SitesListFollowedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(parameter, cancellationToken);
        }
    }
}
