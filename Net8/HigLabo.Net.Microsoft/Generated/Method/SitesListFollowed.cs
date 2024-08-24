using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

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
    public partial class SitesListFollowedResponse : RestApiResponse<Site>
    {
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
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sites-list-followed?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Site> SitesListFollowedEnumerateAsync(SitesListFollowedParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SitesListFollowedParameter, SitesListFollowedResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Site>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
