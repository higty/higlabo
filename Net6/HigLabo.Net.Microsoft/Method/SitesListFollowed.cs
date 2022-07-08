using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SitesListFollowedParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_FollowedSites: return $"/me/followedSites";
                    case ApiPath.Users_UserId_FollowedSites: return $"/users/{UserId}/followedSites";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
            Analytics,
            Columns,
            ContentTypes,
            Drive,
            Drives,
            Items,
            Lists,
            Onenote,
            Operations,
            Permissions,
            Sites,
            TermStore,
            TermStores,
        }
        public enum ApiPath
        {
            Me_FollowedSites,
            Users_UserId_FollowedSites,
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
    public partial class SitesListFollowedResponse : RestApiResponse
    {
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
