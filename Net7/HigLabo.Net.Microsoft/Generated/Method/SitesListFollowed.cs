using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
    /// </summary>
    public partial class SitesListFollowedParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_FollowedSites: return $"/me/followedSites";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            ETag,
            Id,
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
        public Site[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitesListFollowedResponse> SitesListFollowedAsync()
        {
            var p = new SitesListFollowedParameter();
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitesListFollowedResponse> SitesListFollowedAsync(CancellationToken cancellationToken)
        {
            var p = new SitesListFollowedParameter();
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitesListFollowedResponse> SitesListFollowedAsync(SitesListFollowedParameter parameter)
        {
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitesListFollowedResponse> SitesListFollowedAsync(SitesListFollowedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(parameter, cancellationToken);
        }
    }
}
